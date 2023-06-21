using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoProject.Domain.Models;
using ToDoProject.Domain.Interfaces;

namespace ToDoProject.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserModel user)
        {
            _userRepository.Add(user);
            _userRepository.Save();
        }

        public List<UserModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.ToList();
        }

        public UserModel GetUser()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(UserModel user)
        {
            _userRepository.Delete(user); 
            _userRepository.Save();
        }

        public void UpdateUser(UserModel user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }
    }
}
