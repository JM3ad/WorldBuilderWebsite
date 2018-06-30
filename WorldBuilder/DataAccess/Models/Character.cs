using DataAccess.Models.Characteristics;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Race Race { get; set; }
    }
}
