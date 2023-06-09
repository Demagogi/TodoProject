using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TodoProject.DataAccess.Data;
using TodoProject.Hubs;
using ToDoProject.Application.Services;
using ToDoProject.DataAccess.Repository;
using ToDoProject.Domain.Interfaces;
using ToDoProject.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSignalR();

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoListItemsRepository, ToDoListItemsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IToDoListItemService, ToDoListItemService>();
builder.Services.AddScoped<IToDoListService, ToDoListService>();

builder.Services.AddScoped<IToDoListApplicationService, ToDoListApplicationService>();
builder.Services.AddScoped<IToDoListItemApplicationService, ToDoListItemApplicationService>();
builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<UserHub>("/hubs/user");

app.Run();
