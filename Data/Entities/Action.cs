using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Action
    {
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
