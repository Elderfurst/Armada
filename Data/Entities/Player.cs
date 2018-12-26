using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string AuthorizationCode { get; set; }
    }
}
