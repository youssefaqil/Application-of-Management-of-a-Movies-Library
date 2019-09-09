using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieNetWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "MovieServiceWCF" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez MovieServiceWCF.svc ou MovieServiceWCF.svc.cs dans l'Explorateur de solutions et démarrez le débogage.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MovieServiceWCF : IMovieServiceWCF
    {
        #region GetAllMovies
        public ObservableCollection<Movie> GetAllMovies()
        {

            ObservableCollection<Movie> MovieCollec = null;

            using (var entities = new DbMovieNetEntities())
            {
                MovieCollec = new ObservableCollection<Movie>(entities.MovieSets.Select(
                    movie => new Movie()
                    {
                        IdGetSet =  movie.Id,
                        TitleGetSet = movie.Title,
                        DurationGetSet = movie.Duration,
                        GenreGetSet = movie.Genre,
                        SummaryGetSet = movie.Summary,
                        ImageGetSet =  movie.Image,
                        UserSet_idGetSet = movie.UserSet.Id
                    }));
            }
            return MovieCollec;
        }
        #endregion

        #region CreateMovie

        public bool CreateMovie(string _title, string _duration, string _genre, string _summary,string _image, int _UserSet_id)
        {
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    entities.MovieSets.Add(new MovieSet()
                    {
                        Title = _title,
                        Duration = _duration,
                        Genre = _genre,
                        Summary = _summary,
                        Image = _image,
                        User_Id = _UserSet_id
                    });

                    entities.SaveChanges();
                }


            }
            catch (SqlException ex)
            {
                NewMethodException(ex);

            }
            return true;
        }

        #endregion

        #region DeleteMovie

        public bool DeleteMovie(int idSet)
        {
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    var Moviedelete = entities.MovieSets.Where(movie => movie.Id == idSet).ToArray();

                    entities.MovieSets.RemoveRange(Moviedelete);
                    entities.SaveChanges();
                }
            }

            catch (SqlException ex)
            {
                NewMethodException(ex);
            }
            return true;
        }

        #endregion

        #region FindMovieByGenre

        public IReadOnlyCollection<Movie> FindMovieByGenre(string genreSet)
        {
            IReadOnlyCollection<Movie> movieCollectGenre = default(IReadOnlyCollection<Movie>);
            IList<Movie> movieList = new List<Movie>();
            IList<MovieSet> resultMovieSet = default(IList<MovieSet>);

            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    resultMovieSet = entities.MovieSets.Where(movie => movie.Genre.Contains(genreSet)).ToList();
                }

                foreach (MovieSet mv in resultMovieSet)
                {
                    movieList.Add(new Movie
                    {
                        TitleGetSet = mv.Title,
                        DurationGetSet = mv.Duration,
                        GenreGetSet = mv.Genre,
                        SummaryGetSet = mv.Summary,
                        ImageGetSet =  mv.Image
                    });
                }

                movieCollectGenre = new ReadOnlyCollection<Movie>(movieList);

            }
            catch (SqlException ex)
            {
                NewMethodException(ex);
            }

            return (movieCollectGenre);
        }

        #endregion

        #region FindMovieByTitle

        public ObservableCollection<Movie> FindMovieByTitle(string titleSet)
        {
            ObservableCollection<Movie> MovieCollec = null;
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    MovieCollec = new ObservableCollection<Movie>(entities.MovieSets.Where(movie => movie.Title.Contains(titleSet)).Select(
                        movie => new Movie()
                        {
                            IdGetSet = movie.Id,
                            TitleGetSet = movie.Title,
                            DurationGetSet = movie.Duration,
                            GenreGetSet = movie.Genre,
                            SummaryGetSet = movie.Summary,
                            ImageGetSet = movie.Image,

                        })) ;
                }
               
            }
            catch (SqlException ex)
            {
                NewMethodException(ex);
            }

            return  MovieCollec; 

        }
        #endregion
        /*
        #region GetMovieID

        public IReadOnlyCollection<Movie> GetMovie(int idSet)
        {
            IReadOnlyCollection<Movie> movieCollection = default(IReadOnlyCollection<Movie>);
            IList<Movie> movieList = new List<Movie>();
            MovieSet resultMovieSet = null;

            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    resultMovieSet = entities.MovieSets.Where(movie => movie.Id == idSet).FirstOrDefault();
                }

               
                    movieList.Add(new Movie
                    {
                        TitleGetSet = resultMovieSet.Title,
                        DurationGetSet = resultMovieSet.Duration,
                        GenreGetSet = resultMovieSet.Genre,
                        SummaryGetSet = resultMovieSet.Summary
                        
                    });


                movieCollection = new ReadOnlyCollection<Movie>(movieList);

            }
            catch (SqlException ex)
            {
                NewMethodException(ex);
            }

            return movieCollection;
        }
        #endregion
    */
        #region Movie by Id
        public ObservableCollection<Movie> GetAllMoviesById(int idSet)
        {

            ObservableCollection<Movie> MovieCollec = null;

            using (var entities = new DbMovieNetEntities())
            {
                MovieCollec = new ObservableCollection<Movie>(entities.MovieSets.Where(movie => movie.Id == idSet).Select(
                    movie => new Movie()
                    {
                        TitleGetSet = movie.Title,
                        DurationGetSet = movie.Duration,
                        GenreGetSet = movie.Genre,
                        SummaryGetSet = movie.Summary,
                        ImageGetSet = movie.Image,
                        UserSet_idGetSet = movie.UserSet.Id
                    }));
            }
            return MovieCollec;
        }

        #endregion

        #region UpdateMovies

        public bool UpdateUser(int _Id,string _title, string _duration, string _genre, string _summary, string _image)
        {
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                      MovieSet MovieUpdate = null;
                     MovieUpdate = (from mv in entities.MovieSets where mv.Id == _Id select mv).FirstOrDefault();

                    if (MovieUpdate == null)
                    {
                        return false;
                    }
                    else
                    {
                        MovieUpdate.Title = _title;
                        MovieUpdate.Duration = _duration;
                        MovieUpdate.Genre = _genre;
                        MovieUpdate.Summary = _summary;
                        MovieUpdate.Image = _image;
               
                        entities.SaveChanges();
                    }


                }
            }

            catch (SqlException ex)
            {
                NewMethodException(ex);

            }
            return true;
        }

        #endregion



        #region NewMethodException
        private static void NewMethodException(SqlException ex)
        {
            throw new FaultException("Erreur GetUsers: " + ex.Errors);
        }

        public List<Movie> FindMoviesOfUser(int idUser)
        {
            List<Movie> movies = new List<Movie>();

            try
            {
                DbMovieNetEntities entities = new DbMovieNetEntities();

                var query = (from n in entities.MovieSets where n.UserSet.Id == idUser select n).ToList();
                List<MovieSet> list = query.ToList();

                foreach (MovieSet mv in list)
                {
                    movies.Add(new Movie
                    {
                        IdGetSet = mv.Id,
                        TitleGetSet = mv.Title,
                        DurationGetSet = mv.Duration,
                        GenreGetSet = mv.Genre,
                        SummaryGetSet = mv.Summary,
                        ImageGetSet = mv.Image
                    }); ;
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException("Erreur Finding note of user " + ex.Errors);
            }

            return movies;
        }

        public IReadOnlyCollection<Movie> GetMovie(int idSet)
        {
            throw new NotImplementedException();
        }

  

        #endregion
    }
}
