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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "INoteServiceWCF" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface INoteServiceWCF
    {
        [OperationContract]
        IReadOnlyCollection<Note>GetAllNote();

        [OperationContract]
        IReadOnlyCollection<Note>GetNote(int id);

        [OperationContract]
        bool CreateNote(int _note, string _comment, int _idUser, int _idMovie);

        [OperationContract]
        bool UpdateNote(Note note);

        [OperationContract]
        bool DeleteNote(Note note);

        [OperationContract]
        ObservableCollection<Note> FindNotesOfMovie(int idMovie);

        [OperationContract]
        IReadOnlyCollection<Note>FindNotesOfUser(int idUser);
    }

    public class Note : INotifyPropertyChanged
    {
        private int id;
        private int score;
        private string comment;
        private int User_id;
        private int Movie_id;

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

        #region ScoreGetSet

        [DataMember]
        public int ScoreGetSet
        {
            get
            {
                return score;
            }
            set
            {
                if (score != value)
                {
                    score = value;
                }
            }
        }
        #endregion

        #region CommentGetSet

        [DataMember]
        public string CommentGetSet
        {
            get
            {
                return comment;
            }
            set
            {
                if (comment != value)
                {
                    comment = value;
                }
            }
        }
        #endregion

        #region User_idGetSet

        [DataMember]
        public int User_idGetSet
        {
            get
            {
                return User_id;
            }
            set
            {
                if (User_id != value)
                {
                    User_id = value;
                }
            }
        }
        #endregion

        #region IdGetSet

        [DataMember]
        public int Movie_idGetSet
        {
            get
            {
                return Movie_id;
            }
            set
            {
                if (Movie_id != value)
                {
                    Movie_id = value;
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
