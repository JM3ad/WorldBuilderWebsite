using DataAccess.Models.Characteristics;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Race Race { get; set; }
    }
}
