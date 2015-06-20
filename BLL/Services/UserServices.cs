using System;
using System.Collections.Generic;
using System.Linq;
using Dal.Interface.Repository;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using Dal.Interface.DTO;
using BLL.Mapper;
namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalUser> userRepository;
        public UserService(IUnitOfWork uow, IRepository<DalUser> repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }
        public UserEntity GetUserById(int Id)
        {
            return userRepository.GetById(Id).ToBllUser();

        }
        public bool CreateUser(UserEntity user)
        {
            if (userRepository.GetByUserName(user.UserName) == null)
            {
                userRepository.Create(user.ToDalUser());
                uow.Commit();
                return true;
            }
            return false;
        }
        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }
    }
}
