﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface.DTO
{
    public class DalUser:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
    }
}
