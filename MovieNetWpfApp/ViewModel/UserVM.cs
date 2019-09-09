using Microsoft.Win32;
using MovieNetWpfApp.MovieServiceRef;
using MovieNetWpfApp.UserServiceRef;
using MovieNetWpfApp.NoteServiceRef;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MovieNetWpfApp.ViewModel
{
    class UserVM : INotifyPropertyChanged
    {

        // Déclaration des Windows
        private WindowUser windowUser;
        private WindowGestionProfile windowGestionProfile;
        private WindowAfficheModiferProfiel windowAfficheModiferProfiel;
        private WindowGestionMovies windowGestionMovies;
        private WindowAjoutFilme windowAjoutFilme;
        private WinModifierMovie winModifierMovie;
        private WindowChercherFilm wndowChercherFilm;
        private WindowNote windowNote;
      //NoteServiceWCFClient noteServiceWCFClient = new NoteServiceWCFClient();

        #region UserEntitie
        private UserServiceRef.User userSelectionne ;

        private ObservableCollection<UserServiceRef.User> listeDeUsers;

        public ObservableCollection<User> ListeDeUsers
        {
            get
            {
                return listeDeUsers;
            }
            private set
            {
                if (listeDeUsers != value)
                {
                    listeDeUsers = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public User UserSelectionne
        {
            get
            {
                return userSelectionne;
            }
            private set
            {
                if (userSelectionne != value)
                {
                    userSelectionne = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region La_partie_MainWindow

        #region AjouterUser


        private string nomVM;
        public string NomVM
        {
            get { return nomVM; }
            set
            {
                nomVM = value;
                NotifyPropertyChanged();


            }
        }
        private string prenomVM;
        public string PrenomVM
        {
            get { return prenomVM; }
            set
            {
                prenomVM = value;
                NotifyPropertyChanged();

            }
        }
        private string loginVM;
        public string LoginVM
        {
            get { return loginVM; }
            set
            {
                loginVM = value;
                NotifyPropertyChanged();

            }
        }

        

       public ICommand ajouterUser;
        public ICommand AjouterUser
        {
            
            get
            {
                if (ajouterUser == null)
                {
                    ajouterUser = new RelayCommand<object>((obj) => 
                    {
                        var passwordBox = obj as PasswordBox;
                        var LogPassword = passwordBox.Password;
                        var user = new UserServiceRef.UserServiceWCFClient();
                        user.CreateUserAsync(NomVM, PrenomVM, LoginVM, LogPassword);
                       
                        if (user != null)
                        {
                            NomVM = string.Empty;
                            PrenomVM = string.Empty;
                            LoginVM = string.Empty;
                            passwordBox.Password = string.Empty;
                            user.Close();
                            MessageBox.Show("Félicitations! Votre inscription a été passé avec succès!");
                        }
                        else
                        {
                            MessageBox.Show("Ce compte existe déjà, veuillez choisir un autre!");
                        }
                       
                    });

                }
                return ajouterUser;
            }
        }

        #endregion


        #region LoginUser
        ICommand logOnUser;
        private string loginBoxValue;
        public string LoginBoxValue
        {
            get { return loginBoxValue; }
            set
            {
                if (value != loginBoxValue)
                {
                    loginBoxValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public ICommand LogOnUser
        {

            get
            {
                if (logOnUser == null)
                {
                    logOnUser = new RelayCommand<object>((obj) =>
                    {

                        var pwdBox = obj as PasswordBox;
                        var password = pwdBox.Password;
                        
                        var user = new UserServiceRef.UserServiceWCFClient();
                       
                        if ( (UserSelectionne = user.LoginUser(LoginBoxValue,password)) == null)
                        {

                            MessageBox.Show("Login ou le mot de passe est incorrect !");
                        }
                        else
                        {
                            
                            
                            windowUser = new WindowUser
                            {
                                DataContext = this,
                            };
                           
                            windowUser.Show();
                            App.Current.MainWindow.Close();
                        }

                    });

                }
                return logOnUser;

            }
        }
        #endregion

        #endregion




         public void AffPorfil()
         {
             var user = new UserServiceRef.UserServiceWCFClient();

             List<User> Listprofil = user.GetUsersFindByLoginAsync(LoginBoxValue).Result.ToList();

             foreach (var profil in Listprofil)
             {
                 NomProfil = profil.FirstnameGetSet;
                 PrenomProfil = profil.LastnameGetSet;
                 LoginProfil = profil.LoginGetSet;

            }
         }

        #region ModifierDirection
        ICommand modifierDirectio;
         public ICommand ModifierDirection
         {
             get
             {
                modifierDirectio = new RelayCommand<object>((obj) => {

                var user = new UserServiceRef.UserServiceWCFClient();
                List<User> Listprofil = user.GetUsersFindByLoginAsync(LoginBoxValue).Result.ToList();

                foreach (var profil in Listprofil)
                {
                    NomProfil = profil.FirstnameGetSet;
                    PrenomProfil = profil.LastnameGetSet;
                    LoginProfil = profil.LoginGetSet;
                }

                    windowAfficheModiferProfiel = new WindowAfficheModiferProfiel
                    {
                        DataContext = this,
                    };
                    windowAfficheModiferProfiel.Show();
                    windowGestionProfile = new WindowGestionProfile();
                    windowGestionProfile.Close();
                 });

                 return modifierDirectio;
             }

         }
        #endregion
        #region EditerProfile
        ICommand editerProfile;
        public ICommand EditerProfile
        {
            get
            {
                if (editerProfile == null)
                {
                    editerProfile = new RelayCommand<object>((obj) =>
                    {
                        var pwdBox = obj as PasswordBox;
                        var password = pwdBox.Password;
                        var user = new UserServiceRef.UserServiceWCFClient();
                        if(user.UpdateUserAsync(PrenomProfil,NomProfil,LoginProfil, password) != null)
                        {
                            
                            MessageBox.Show("Vous avez modifié votre profile!");
                            PrenomProfil = string.Empty;
                            NomProfil = string.Empty;
                            LoginProfil = string.Empty;
                            password = string.Empty;
                            windowAfficheModiferProfiel = new WindowAfficheModiferProfiel();
                            windowAfficheModiferProfiel.Close();
                        }
                        else
                        {
                            MessageBox.Show("error");
                        }


                    });
                }
                return editerProfile;
            }
        }

        #region La partie WindowUser


        //Methode sert à afficher un porfile d'un utilisateur

        private string nomProfil;
        public string NomProfil
        {
            get { return nomProfil; }
            set
            {
                nomProfil = value;
                NotifyPropertyChanged();


            }
        }
        private string prenomProfil;
        public string PrenomProfil
        {
            get { return prenomProfil; }
            set
            {
                prenomProfil = value;
                NotifyPropertyChanged();

            }
        }
        private string loginProfil;
        public string LoginProfil
        {
            get { return loginProfil; }
            set
            {
                loginProfil = value;
                NotifyPropertyChanged();

            }
        }
        ICommand gestionDesProfiles;
        public ICommand GestionDesProfiles
        {
            get
            {
                gestionDesProfiles = new RelayCommand<User>((obj) => {

                var user = new UserServiceRef.UserServiceWCFClient();

                 List<User> Listprofil = user.GetUsersFindByLoginAsync(LoginBoxValue).Result.ToList();


                  
                    foreach (var profil in Listprofil)
                    {
                        NomProfil = profil.FirstnameGetSet;
                        PrenomProfil = profil.LastnameGetSet;
                        LoginProfil = profil.LoginGetSet;

                    }

                    windowGestionProfile = new WindowGestionProfile
                    {
                        DataContext = this,
                    };
                    windowGestionProfile.Show();
                    windowUser = new WindowUser();
                    windowUser.Close();
                });


                return gestionDesProfiles;
            }

        }


        #endregion

        #endregion

        #region La partie des filmes 

        private MovieServiceRef.Movie movieSelectionne;

        private ObservableCollection<MovieServiceRef.Movie> listeDeMovies;

        public ObservableCollection<Movie> ListeDeMovie
        {
            get
            {
                return listeDeMovies;
            }
            private set
            {
                if (listeDeMovies != value)
                {
                    listeDeMovies = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Movie MovieSelectionne
        {
            get
            {
                return movieSelectionne;
            }
            private set
            {
                if (movieSelectionne != value)
                {
                    movieSelectionne = value;
                    NotifyPropertyChanged();
                }
            }
        }

        ICommand gestionDesMovies;
        public ICommand GestionDesMovies
        {
            get
            {
                gestionDesMovies = new RelayCommand<Movie>((obj) => {

                     windowGestionMovies = new WindowGestionMovies
                     {
                         DataContext = this,
                     };
                     windowGestionMovies.Show();
                   


                });


                return gestionDesMovies;
            }

        }
     

        private int id_UserMovie;
        public int Id_UserMovie
        {
            get { return id_UserMovie; }
            set
            {
                id_UserMovie = value;
                NotifyPropertyChanged();

            }
        }
        private string title_UserMovie;
        public string Title_UserMovie
        {
            get { return title_UserMovie; }
            set
            {
                title_UserMovie = value;
                NotifyPropertyChanged();

            }
        }
        private string duration_UserMovie;
        public string Duration_UserMovie
        {
            get { return duration_UserMovie; }
            set
            {
                duration_UserMovie = value;
                NotifyPropertyChanged();
            }
        }
        private string genre_UserMovie;
        public string Genre_UserMovie
        {
            get { return genre_UserMovie; }
            set
            {
                genre_UserMovie = value;
                NotifyPropertyChanged();
            }
        }

        private string summary_UserMovie;
        public string Summary_UserMovie
        {
            get { return summary_UserMovie; }
            set
            {
                summary_UserMovie = value;
                NotifyPropertyChanged();
            }
        }
        private List<Movie> userMovieclass;
        public List<Movie> UserMovieclass
        {
            get { return userMovieclass; }
            set
            {
                userMovieclass = value;
                NotifyPropertyChanged();
            }
        }



        #region file importer

        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; NotifyPropertyChanged(); }
        }

        ICommand pathfile;
        public ICommand Pathfile
        {
            get
            {
                pathfile = new RelayCommand<object>((obj) => {

                    OpenFileDialog open = new OpenFileDialog();
                    string filepath;
                    open.Multiselect = false;
                    open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                    bool? result = open.ShowDialog();

                    if (result == true)
                    {
                        filepath = open.FileName; // Stores Original Path in Textbox    
                        ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                        

                        string name = System.IO.Path.GetFileName(filepath);
                        string destinationPath = GetDestinationPath(name, "Resources");
                        //C:\Users\yaqil\source\repos\MovieNetLibSolution\MovieNetWpfApp\bin\Debug\Resources\
                        File.Copy(filepath, destinationPath, true);
                        SelectedPath = destinationPath;
                    }
                });
                return pathfile;
            }
        }
        // save le chemin de l'image d'un filme dans le répertoire Resources
        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }
        #endregion
        #region Liste de Genre des filmes
        //Liste de genre d'un filme sélectionner 
        /*static UserVM()
        {
          



        }*/
        //GenreItem
        private static string _selectedItem;
        public static string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                //MessageBox.Show("Filme " + value + " a été sélectionné");
            }
        }

        private static ObservableCollection<string> _items;
        public static ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        #endregion


        #region Afficher Window AjoutFilme
        ICommand affAjoutWindow;
        public ICommand AffAjoutWindow
        {
            get
            {
                affAjoutWindow = new RelayCommand<object>((obj) =>
                {
                    Title_UserMovie = string.Empty;
                    Duration_UserMovie = string.Empty;
                    SelectedItem = string.Empty;
                    Summary_UserMovie = string.Empty;
                    SelectedPath = string.Empty;
                    windowAjoutFilme = new WindowAjoutFilme
                    {
                        DataContext = this,
                    };
                    windowGestionMovies = new WindowGestionMovies
                    {
                        DataContext = this,
                    };
                    windowAjoutFilme.Show();
                    windowGestionMovies.Close();
                });

                return affAjoutWindow;
            }
        }
        #endregion

        #region Ajouter un Filmes
        ICommand ajouterFilme;
        public ICommand AjouterFilme
        {
            get
            {
                ajouterFilme = new RelayCommand<Movie>((obj) =>
                {
                    var user = new UserServiceRef.UserServiceWCFClient();
                    var filme = new MovieServiceRef.MovieServiceWCFClient();
                    //public bool CreateMovie(string _title, string _duration, string _genre, string _summary, string _image, int _UserSet_id
                    filme.CreateMovieAsync(Title_UserMovie, Duration_UserMovie, SelectedItem, Summary_UserMovie, SelectedPath, MovieSelectionne.UserSet_idGetSet);
                    if (user != null)
                    {
                        Title_UserMovie = string.Empty;
                        Duration_UserMovie = string.Empty;
                        SelectedItem = string.Empty;
                        Summary_UserMovie = string.Empty;
                        SelectedPath = string.Empty;
                        MessageBox.Show("Félicitations! Votre Filme a été enregistré avec succès!");
                        UserMovieclass = new List<Movie>(filme.GetAllMoviesAsync().Result.ToList());
                    }
                    else
                    {
                        MessageBox.Show("Une erreur enregistrement! veuillez choisir un autre!");
                    }
                });

                return ajouterFilme;
            }
        }
        #endregion

        #region Afficher Window Modifier Filme
        ICommand affModifierFilmWindow;
        public ICommand AffModifierFilmeWindow
        {
            get
            {
               
                affModifierFilmWindow = new RelayCommand<Movie>((obj) => {

                    
                    var movie = new MovieServiceRef.MovieServiceWCFClient();
                    //Id_UserMovie = Use;
                    List<Movie> ListMovies = movie.GetAllMoviesByIdAsync(id_UserMovie).Result.ToList();
                    foreach (var listMV in ListMovies)
                    {
                        Title_UserMovie = listMV.TitleGetSet;
                        
                        Duration_UserMovie = listMV.DurationGetSet;
                        SelectedItem = listMV.GenreGetSet;
                        Summary_UserMovie = listMV.SummaryGetSet;
                        SelectedPath = listMV.ImageGetSet;
                    }
                    winModifierMovie = new WinModifierMovie
                    {
                        DataContext = this,
                    };
                    winModifierMovie.Show();
                });



                return affModifierFilmWindow;
            }
        }
        #endregion
        #region Modifier Un Filme

        ICommand modifierFilme;
        public ICommand ModifierFilme
        {
            get
            {
                modifierFilme = new RelayCommand<Movie>((obj) => {

                    var movie = new MovieServiceRef.MovieServiceWCFClient();

                    movie.UpdateUserAsync(Id_UserMovie,Title_UserMovie, Duration_UserMovie, SelectedItem, Summary_UserMovie, SelectedPath);
                    UserMovieclass = new List<Movie>(movie.GetAllMoviesAsync().Result.ToList());

                    MessageBox.Show("Le Film a été bien modifié avec succès.");
                    Title_UserMovie = string.Empty;
                    Duration_UserMovie = string.Empty;
                    SelectedItem = string.Empty;
                    Summary_UserMovie = string.Empty;
                    SelectedPath = string.Empty;

                    /*if (movie. != null)
                    {
                        MessageBox.Show("Le Film a été bien modifié avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("Erreur de modification !");
                    }*/

                });
                return modifierFilme;
            }
        }
        #endregion

        #region Supprimer Un Filme


        ICommand supprimerFilme;
        public ICommand SupprimerFilme
        {
            get
            {
                supprimerFilme = new RelayCommand<Movie>((obj) => {

                    var movie = new MovieServiceRef.MovieServiceWCFClient();
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Vous êtes sur?", "Confirmation de supprition", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                            movie.DeleteMovieAsync(Id_UserMovie);
                            UserMovieclass = new List<Movie>(movie.GetAllMoviesAsync().Result.ToList());
                    }
 
                   

                });
                return supprimerFilme;
            }
        }

        ICommand rechercherFilm;

        public ICommand RechercherFilm
        {
            get
            {
                rechercherFilm = new RelayCommand<Movie>((obj) => {

                    var movie = new MovieServiceRef.MovieServiceWCFClient();
                    var note = new NoteServiceRef.NoteServiceWCFClient();
                    int count = 0;
                    int Somme_Score = 0;

                    List<Movie> ListMoviesRechercher = movie.FindMovieByTitleAsync(Title_UserMovie).Result.ToList();
                    foreach (var listMV in ListMoviesRechercher)
                    {
                        NoteMovie_IdGetSet = listMV.IdGetSet;
                        Title_UserMovie = listMV.TitleGetSet;
                        Duration_UserMovie = listMV.DurationGetSet;
                        SelectedItem = listMV.GenreGetSet;
                        Summary_UserMovie = listMV.SummaryGetSet;
                        SelectedPath = listMV.ImageGetSet;
                    }
                    List<Note> ListScore = note.FindNotesOfMovieAsync(NoteMovie_IdGetSet).Result.ToList();
                    count = ListScore.Count();
                    
                    foreach (var listScore in ListScore)
                    {
                        Somme_Score += listScore.ScoreGetSet;
                    }
                    Moyenne_Score = Somme_Score / count; 
                    wndowChercherFilm = new WindowChercherFilm
                    {
                       DataContext = this,
                    };

                    wndowChercherFilm.Show();




                });
                return rechercherFilm;
            }
        }

        #endregion

        #endregion

        #region Gestion des Notes
        private NoteServiceRef.Note  noteSelectionne;
        private ObservableCollection<NoteServiceRef.Note> listeDesNotes;

        public ObservableCollection<Note> ListeDesNotes
        {
            get
            {
                return listeDesNotes;
            }
            private set
            {
                if (listeDesNotes != value)
                {
                    listeDesNotes = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Note NoteSelectionne
        {
            get
            {
                return noteSelectionne;
            }
            private set
            {
                if (noteSelectionne != value)
                {
                    noteSelectionne = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int Note_id;
        private static int Note_score;
        private string Note_comment;
        private int NoteUser_id;
        private int NoteMovie_id;

        #region Note_IdGetSet
       
        public int Note_IdGetSet
        {
            get
            {
                return Note_id;
            }
            set
            {
                if (Note_id != value)
                {
                    Note_id = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Note_ScoreGetSet


        public static int Note_ScoreGetSet
        {
            get
            {
                return Note_score;
            }
            set
            {
                if (Note_score != value)
                {
                    Note_score = value;
                   
                }
            }
        }
        #endregion

        #region Note_CommentGetSet
        public string Note_CommentGetSet
        {
            get
            {
                return Note_comment;
                
            }
            set
            {
                if (Note_comment != value)
                {
                    Note_comment = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Note_UseridGetSet

      
        public int NoteUser_IdGetSet
        {
            get
            {
                return NoteUser_id;
            }
            set
            {
                if (NoteUser_id != value)
                {
                    NoteUser_id = value;
                }
            }
        }
        #endregion

        #region Note_MovieIdGetSet

        public int NoteMovie_IdGetSet
        {
            get
            {
                return NoteMovie_id;
            }
            set
            {
                if (NoteMovie_id != value)
                {
                    NoteMovie_id = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Moyenne_Score
        private double moyenne_Score;
        public double Moyenne_Score
        {
            get
            {
                return moyenne_Score;
            }
            set
            {
                if (moyenne_Score != value)
                {
                    moyenne_Score = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion


        #region Afficher Window Ajouter Commentaire

        ICommand affAjouterCommentaire;
        public ICommand AffAjouterCommentaire
        {
            get
            {
                affAjouterCommentaire = new RelayCommand<Note>((obj) => {

                    windowNote = new WindowNote
                    {
                        DataContext = this,
                    };
                    windowNote.Show();

                });
                return affAjouterCommentaire;
            }
        }

        #endregion

        #region Ajouter Commentaire

        ICommand ajouterCommentaire;
        private static ObservableCollection<int> itemNoteScore;
        public static ObservableCollection<int> ItemNoteScore
        {
            get
            {
                return itemNoteScore;
            }
            set
            {
                if (itemNoteScore != value)
                {
                    itemNoteScore = value;

                }
            }
        }
        public ICommand AjouterCommentaire
        {
            get
            {
                ajouterCommentaire = new RelayCommand<Note>((obj) => {


                    var note = new NoteServiceRef.NoteServiceWCFClient() ;

                    var user = new UserServiceRef.UserServiceWCFClient();

                    //Récupérer ID de User
                    List<User> ListIdUser = user.GetUsersFindByLoginAsync(LoginBoxValue).Result.ToList();
                    foreach (var profil in ListIdUser)
                    {
                        NoteUser_IdGetSet = profil.IdGetSet;
                    }

                    //Récupérer Id du Film
                    var movie = new MovieServiceRef.MovieServiceWCFClient();
                    List<Movie> ListIdMovie = movie.FindMovieByTitleAsync(Title_UserMovie).Result.ToList();
                    foreach (var listMV in ListIdMovie)
                    {
                        NoteMovie_IdGetSet = listMV.IdGetSet;

                    }
                    note.CreateNoteAsync(Note_ScoreGetSet, Note_CommentGetSet, NoteUser_IdGetSet, NoteMovie_IdGetSet);

                    if (note != null)
                    {
                        //Note_ScoreGetSet = ;
                        Note_CommentGetSet = string.Empty;
                        Note_CommentGetSet = string.Empty;
    
                        note.Close();
                        MessageBox.Show("Félicitations! Votre Commentaire a été ajouté avec succès!");
                    }
                    else
                    {
                        MessageBox.Show("Erreur du Commentaire!");
                    }

                });
                return ajouterCommentaire;
            }
        }
        #endregion

        #endregion


        public UserVM()
        {
            var movie = new MovieServiceRef.MovieServiceWCFClient();

            ListeDeMovie = new ObservableCollection<Movie>(movie.GetAllMovies());
            movieSelectionne = new Movie();
            foreach (var mvs in ListeDeMovie)
            {
                Title_UserMovie = mvs.TitleGetSet;
                Duration_UserMovie = mvs.DurationGetSet;
                Genre_UserMovie = mvs.GenreGetSet;
                MovieSelectionne.UserSet_idGetSet = mvs.UserSet_idGetSet;
                Id_UserMovie = mvs.IdGetSet;
            }
            UserMovieclass = movie.FindMoviesOfUserAsync(MovieSelectionne.UserSet_idGetSet).Result.ToList();
            movie.Close();

            Items = new ObservableCollection<string>();
            SelectedItem = "Film d'amour";
            Items.Add("Drame");
            Items.Add("Comédie");
            Items.Add("Thriller");
            Items.Add("Film d'action");
            Items.Add("Film fantastique");
            Items.Add("Film d'horreur");
            Items.Add("Film autobiographique");
            Items.Add("Comédie romantique");
            Items.Add("Film d'amour");

            ItemNoteScore = new ObservableCollection<int>();
            Note_ScoreGetSet = 1;
            ItemNoteScore.Add(1);
            ItemNoteScore.Add(2);
            ItemNoteScore.Add(3);
            ItemNoteScore.Add(4);
            ItemNoteScore.Add(5);
            ItemNoteScore.Add(6);
            ItemNoteScore.Add(7);
            ItemNoteScore.Add(8);
            ItemNoteScore.Add(9);
            ItemNoteScore.Add(10);


        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }

       


    }
}
