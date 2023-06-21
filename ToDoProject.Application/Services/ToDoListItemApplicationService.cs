using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Application.ViewModels;
using ToDoProject.Application.Mappers;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.Application.Services
{
    public class ToDoListItemApplicationService : IToDoListItemApplicationService
    {
        private readonly IToDoListItemService _service;

        public ToDoListItemApplicationService(IToDoListItemService service)
        {
            _service = service;
        }

        public void AddItemView(ToDoListItemViewModel item)
        {
            var itemModel = ToDoListItemMapper.MapItemsViewModelToItemsModel(item);
            _service.AddItem(itemModel);
        }

        public List<ToDoListItemViewModel> GetItemsToView()
        {
            var items = _service.GetAllItems();
            var itemsViewModel = items.Select(item => ToDoListItemMapper.MapItemsModelToItemsViewModel(item)).ToList();

            return itemsViewModel;
        }

        public ToDoListItemViewModel GetItemToView()
        {
            throw new NotImplementedException();
        }

        public void RemoveItemView(ToDoListItemViewModel item)
        {
            var itemModel = ToDoListItemMapper.MapItemsViewModelToItemsModel(item);
            _service.RemoveItem(itemModel);
        }

        public void UpdateItemView(ToDoListItemViewModel item)
        {
            var itemModel = ToDoListItemMapper.MapItemsViewModelToItemsModel(item);
            _service.UpdateItem(itemModel);
        }
    }
}
