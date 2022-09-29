using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreDbFirst.Model
{
    public partial class Customer
    {
        [NotMapped]
        public int MyProperty { get; set; }
    }
}
