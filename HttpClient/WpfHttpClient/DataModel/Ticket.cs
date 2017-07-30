using WpfHttpClient.DataModel;

namespace WpfHttpClient
{
    public class Ticket
    {
        public Ticket(Movie movie, int count =1)
        {
            Movie = movie;
            Count = count;
        }
        public Movie Movie { get; set; }
        public int Count { get; set; }
    }
}