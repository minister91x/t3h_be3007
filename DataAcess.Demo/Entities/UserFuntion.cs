using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Entities
{
    public class UserFuntion
    {
        [Key]
        public int UserFunctionID { get; set; }
        public int FunctionID { get; set; }
        public int UserID { get; set; }
        public int IsView { get; set; }
        public int IsUpdate { get; set; }
        public int IsDelete { get; set; }
    }
}
