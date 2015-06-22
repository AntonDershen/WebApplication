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
    public class AuthorizationServices:IAuthorizationService
    {
        private readonly IUnitOfWork uow;
        private readonly IRepository<DalAuthorization> authRepository;
        public AuthorizationServices(IUnitOfWork uow, IRepository<DalAuthorization> repository)
        {
            this.uow = uow;
            this.authRepository = repository;
        }
        public IEnumerable<AuthorizationEntity> GetAllUserEntities()
        {
            return authRepository.GetAll().Select(auth => auth.ToBllAuthorization());
        }
        public AuthorizationEntity GetAuthorizationById(int Id)
        {
            return authRepository.GetById(Id).ToBllAuthorization();

        }
        public AuthorizationEntity GetAuthorizationByEmail(string Email)
        {
            return authRepository.GetByName(Email).ToBllAuthorization();

        }
        public void CreateAuthorization(AuthorizationEntity user)
        {
             authRepository.Create(user.ToDalAuthorization());
             uow.Commit();

        }
        public void DeleteAuthorization(AuthorizationEntity auth)
        {
            authRepository.Delete(auth.ToDalAuthorization());
            uow.Commit();
        }
        public bool CheckForm(AuthorizationEntity authorization)
        {
            DalAuthorization auth =  authRepository.GetByName(authorization.Email);
            if (auth != null && auth.Password == authorization.Password)
                return true;
            return false;
        }
    }
}
