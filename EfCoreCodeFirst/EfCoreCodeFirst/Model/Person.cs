using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreCodeFirst.Model
{
    [Table("Leute")]
    public abstract class Person
    {
        [Key]
        public int EiDii { get; set; }
        [Required]
        [Column("VorUndNachname")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public DateTime GebDatum { get; set; }
    }
}
