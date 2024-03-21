﻿using Client.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.BLL.Interfaces
{
    internal interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department Get(int id);
        int Add(Department enity);
        int Update(Department enity);
        int Delete(Department enity); 

    }
}