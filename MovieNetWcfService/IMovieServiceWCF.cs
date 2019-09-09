using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieNetWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IMovieServiceWCF" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IMovieServiceWCF
    {
        [OperationContract]
        ObservableCollection<Movie> GetAllMovies();

        [OperationContract]
        IReadOnlyCollection<Movie> GetMovie(int idSet);

        [OperationContract]
        bool CreateMovie(string _title, string _duration, string _genre, string _summary,string image, int _UserSet_id);

        [OperationContract]
        bool DeleteMovie(int idSet);

        [OperationContract]
        bool UpdateUser(int _Id,string _title, string _duration, string _genre, string _summary, string _image);

        [OperationContract]
        ObservableCollection<Movie> FindMovieByTitle(string titleSet);

        [OperationContract]
        IReadOnlyCollection<Movie> FindMovieByGenre(string genreSet);

        [OperationContract]
        List<Movie> FindMoviesOfUser(int idUser);

        [OperationContract]
        ObservableCollection<Movie> GetAllMoviesById(int idSet);
        
    }

    [DataContract]
    public class Movie : INotifyPropertyChanged
    {
        //internal UserSet user;
        private int id;
        private string title;
        private string duration;
        private string genre;
        private string summary;
        private string image;
        private int UserSet_id;
        private int NoteSet_id;

        #region IdGetSet
        [DataMember]
        public int IdGetSet
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                }
            }
        }
        #endregion

        #region TitleGetSet
        [DataMember]
        public string TitleGetSet
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                }
            }
        }
        #endregion

        #region DurationGetSet
        [DataMember]
        public string DurationGetSet
        {
            get
            {
                return duration;
            }
            set
            {
                if (duration != value)
                {
                    duration = value;
                }
            }
        }
        #endregion

        #region GenreGetSet
        [DataMember]
        public string GenreGetSet
        {
            get
            {
                return genre;
            }
            set
            {
                if (genre != value)
                {
                    genre = value;
                }
            }
        }
        #endregion

        #region SummaryGetSet
        [DataMember]
        public string SummaryGetSet
        {
            get
            {
                return summary;
            }
            set
            {
                if (summary != value)
                {
                    summary = value;
                }
            }
        }

        [DataMember]
        public string ImageGetSet
        {
            get
            {
                return image;
            }
            set
            {
                if (image != value)
                {
                    image = value;
                }
            }
        }
        #endregion

        #region UserSet_idGetSet
        [DataMember]
        public int UserSet_idGetSet
        {
            get
            {
                return UserSet_id;
            }
            set
            {
                if (UserSet_id != value)
                {
                    UserSet_id = value;
                }
            }
        }
        #endregion

        #region NoteSet_idGetSet
        [DataMember]
        public int NoteSet_idGetSet
        {
            get
            {
                return NoteSet_id;
            }
            set
            {
                if (NoteSet_id != value)
                {
                    NoteSet_id = value;
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string str = "") =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));

        #endregion


    }


}
