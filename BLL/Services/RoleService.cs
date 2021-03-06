﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using Dal.Interface.Repository;
using Dal.Interface.DTO;
using BLL.Interface.Services;
using BLL.Mapper;
namespace BLL.Services
{
    public class RoleService : IRoleService 
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository<DalRole> roleRepository;
        public RoleService(IUnitOfWork uow, IRoleRepository<DalRole> repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }
        public int GetIdByDescriptor(string descriptor)
        {
            return roleRepository.GetIdByDescriptor(descriptor);
        }
    }
}
