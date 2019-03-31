namespace FactOff.Models.DB
{
    public class Fact
    {
        public int ID { get; set; }
        public string Context { get; set; }
        public float Rating { get; set; }
        public int CreatorID { get; set; }
    }
}
