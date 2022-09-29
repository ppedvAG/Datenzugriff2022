using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDbFirst.Model
{
    public partial class Customer
    {
        [NotMapped]
        public int MyProperty { get; set; }
    }
}
