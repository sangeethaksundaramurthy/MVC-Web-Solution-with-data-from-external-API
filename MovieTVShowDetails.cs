
namespace TMDB.Models
{
    public class MovieTVShowResults
    {
        private List<MovieTVShowDetails>? results;
        
        public List<MovieTVShowDetails>? Results { get => results; set => results = value; }
        
    }
    public class MovieTVShowDetails
    {
        private bool adult;
        private string backdrop_path = "";
        private int[]? genre_ids;
        private int id;
        private string original_language = "";
        private string original_name = "";
        private string original_title = "";
        private string name = "";
        private string overview = "";
        private float popularity;
        private string poster_path = "";
        private DateTime release_date;
        private String first_air_date = "";
        private string title = "";
        private bool video;
        private float vote_average;
        private int vote_count;

        public bool Adult { get => adult; set => adult = value; }
        public string Backdrop_path { get => backdrop_path; set => backdrop_path = value; }
        public int[]? Genre_ids { get => genre_ids; set => genre_ids = value; }
        public int Id { get => id; set => id = value; }
        public string Original_language { get => original_language; set => original_language = value; }
        public string Original_title { get => original_title; set => original_title = value; }
        public string Overview { get => overview; set => overview = value; }
        public float Popularity { get => popularity; set => popularity = value; }
        public string Poster_path { get => poster_path; set => poster_path = value; }
       
        public string Title { get => title; set => title = value; }
        public bool Video { get => video; set => video = value; }
        public float Vote_average { get => vote_average; set => vote_average = value; }
        public int Vote_count { get => vote_count; set => vote_count = value; }
        public DateTime Release_date { get => release_date; set => release_date = value; }
        public string Original_name { get => original_name; set => original_name = value; }
        public String First_air_date { get => first_air_date; set => first_air_date = value; }
        public string Name { get => name; set => name = value; }
    }
}
 