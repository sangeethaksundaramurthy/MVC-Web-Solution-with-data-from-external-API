using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TMDB.Models;

namespace TMDB.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        private readonly HttpClient HttpClient;
        private readonly string apikey = "";
        private readonly string apiurl = "";
        private MovieTVShowResults? MovieTVShowResultsObj;
        private List<MovieTVShowDetails> MovieTVShowObj;  
        public HomeController(IConfiguration configuration, List<MovieTVShowDetails> movies)
        {
            this.apikey = configuration["api:apikey"];
            this.apiurl = configuration["api:apiurl"];            
            HttpClient = new HttpClient();
            this.MovieTVShowObj = movies;
        }
        private async Task<MovieTVShowResults> LoadBestRatedMovies()
        {
            var url = this.apiurl + "/movie?certification_country=US&certification=R&sort_by=vote_average.desc&api_key=" + this.apikey;
            return await HttpClient.GetFromJsonAsync<MovieTVShowResults>(url);
        }
        private async Task<MovieTVShowResults> LoadBestRatedTVShows()
        {
            var url = this.apiurl + "/tv?certification_country=US&certification=R&sort_by=vote_average.desc&api_key=" + this.apikey;
            return await HttpClient.GetFromJsonAsync<MovieTVShowResults>(url);
        }
        public async Task<ActionResult> OnLoad()
        {  
            MovieTVShowResultsObj = await LoadBestRatedMovies();
            int load = 1;
            foreach (var item in MovieTVShowResultsObj.Results)
            {
                
                if (load <=10)
                {
                    MovieTVShowObj.Add(item);
                    load++;
                }
                
            }
            MovieTVShowResultsObj = await LoadBestRatedTVShows();
            load = 1;
            foreach (var item in MovieTVShowResultsObj.Results)
            {                
                if (load <= 10)
                {
                    MovieTVShowObj.Add(item);
                    load++;
                }
            }
            return View("DisplayMovie", MovieTVShowObj);
        }

       
        public ActionResult DisplayMovieAction(int id)
        {   
            var movie = ((List<MovieTVShowDetails>)MovieTVShowObj)[id];
            return View("DisplayMovieDetails", movie);
        }

        public ActionResult SearchButtonOnClick(string MovieName)
        {
            var movies =   (from temp in MovieTVShowObj
                            where temp.Original_title.IndexOf(MovieName, StringComparison.CurrentCultureIgnoreCase)!= -1
                            || temp.Original_name.IndexOf(MovieName, StringComparison.CurrentCultureIgnoreCase) != -1
                            select temp).ToList<MovieTVShowDetails>(); 
            return View("DisplayMovie", movies);
        }
    }
}
