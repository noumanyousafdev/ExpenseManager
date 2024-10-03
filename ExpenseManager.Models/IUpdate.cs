using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public interface IUpdate
    {
        public DateTime? UpdatedDate { get; set; }
    }
}
