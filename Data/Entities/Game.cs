using Data.Enums;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public GameStatus GameStatus { get; set; }

        public virtual List<Player> Players { get; set; }
        public virtual List<Action> Actions { get; set; }
    }
}
