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
        private readonly IUserRepository userRepository;
        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }
        public UserEntity GetUserById(int id)
        {
            return userRepository.GetById(id).ToBllUser();

        }
        public int CreateUser(UserEntity user)
        {
            if (userRepository.GetByName(user.UserName) == null)
            {
                userRepository.Create(user.ToDalUser());
                uow.Commit();
                return userRepository.GetId(user.ToDalUser());
            }
            return 0;
        }
        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }
        public UserEntity GetUserByName(string name) {
            return userRepository.GetByName(name).ToBllUser();
        }
        public IEnumerable<DocumentEntity> GetUserDocument(string userName) {
            IEnumerable<DalDocument> dalDocument= userRepository.GetAllDocument(userName);
            if(dalDocument!=null)
                return dalDocument.Select(x => x.ToBllAuthorization());
            return null;
        
        }
    }
}
