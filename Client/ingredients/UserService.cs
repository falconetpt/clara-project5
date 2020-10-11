using System;
using System.Collections.Generic;
using DAL.ingredients;
using Domain;
using Domain.ingredients;

namespace Client.ingredients
{
    public class UserService
    {
        private UserRespository _repository = new UserRespository();
        
        public User GetByUserName(String username)
        {
            return _repository.GetById(username);
        }
        
        public void Create(User user) {
            _repository.Create(user);
        }
        
        public void ChangeStatus(User user, UserStatus userStatus)
        {
            user.UserStatus = userStatus;
            _repository.Create(user);
        }
    }
}