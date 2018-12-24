using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string AuthorizationCode { get; set; }
    }
}
