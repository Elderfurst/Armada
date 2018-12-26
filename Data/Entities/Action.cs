namespace Data.Entities
{
    public class Action
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
