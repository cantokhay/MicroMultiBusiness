namespace MicroMultiBusiness.RapidAPIWebUI.Models
{
    public class ScoreboardViewModel
    {
        public Venue Venue { get; set; }
        public List<Team> T1 { get; set; }
        public List<Team> T2 { get; set; }
    }

    public class Venue
    {
        public string Vnm { get; set; }
    }

    public class Team
    {
        public string Nm { get; set; }
        public int tbd { get; set; }
    }
}
