﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public interface IDelete
    {
        public bool IsDeleted { get; set; }
    }
}
