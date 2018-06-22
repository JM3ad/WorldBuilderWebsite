using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Associations
{
    public class CharacterLocationAssociation
    {
        [Key]
        public int Id { get; set; }
        public virtual Location Location { get; set; }
        public virtual Character Character { get; set; }
    }
}
