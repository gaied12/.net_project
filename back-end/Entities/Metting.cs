namespace API.Entities
{
    public class Metting
    {
        public int Id { get; set; }
        public string date { get; set; }
        public string start { get; set; }
         public Doctor doctor { get; set; }
         public Patient patient { get; set; }

        public State state { get; set; }






        
    }
}