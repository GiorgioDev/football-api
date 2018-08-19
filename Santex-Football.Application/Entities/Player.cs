namespace Santex_Football.Application.Entities
{
    public class Player
    {
        public string name { get; set; }
        public string position { get; set; }
        public int? jerseyNumber { get; set; }
        public string dateOfBirth { get; set; }
        public string nationality { get; set; }
        public string contractUntil { get; set; }
        public object marketValue { get; set; }

        public int teamId { get; set; }
    }
}