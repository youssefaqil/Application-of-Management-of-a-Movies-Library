using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieNetWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "NoteServiceWCF" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez NoteServiceWCF.svc ou NoteServiceWCF.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class NoteServiceWCF : INoteServiceWCF
    {
        #region GetAllNote
        public IReadOnlyCollection<Note> GetAllNote()
        {
            IReadOnlyCollection<Note> movieCollection = default(IReadOnlyCollection<Note>);
            IList<Note> NoteList = new List<Note>();
            var resultNoteSet = (dynamic)null;

            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    resultNoteSet = (from nt in entities.NoteSets select nt).ToList();
                }


                foreach (NoteSet mv in resultNoteSet)
                {
                    NoteList.Add(new Note
                    {
                        ScoreGetSet = mv.Score,
                        CommentGetSet = mv.Comment,
                        Movie_idGetSet = mv.Movie_Id
                    });
                }

                movieCollection = new ReadOnlyCollection<Note>(NoteList);

            }
            catch (SqlException ex)
            {
                NewMethodException(ex);
            }

            return movieCollection;
        }

        #endregion

        #region GetNoteID

        public IReadOnlyCollection<Note> GetNote(int id)
        {
            IReadOnlyCollection<Note> NoteCollection = default(IReadOnlyCollection<Note>);
            IList<Note> NoteList = new List<Note>();
            NoteSet resultNoteSet = null;

            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    resultNoteSet = entities.NoteSets.Where(note => note.Id == id).FirstOrDefault();
                }


                NoteList.Add(new Note
                {
                    ScoreGetSet = resultNoteSet.Score,
                    CommentGetSet = resultNoteSet.Comment,
                    Movie_idGetSet = resultNoteSet.Movie_Id

                });

              

            }
            catch (SqlException ex)
            {
                NewMethodException(ex);
            }

            return NoteCollection = new ReadOnlyCollection<Note>(NoteList);
        }

        #endregion

        #region CreateNote
        public bool CreateNote(int _note, string _comment, int _idUser, int _idMovie)
        {

            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    entities.NoteSets.Add(new NoteSet()
                    {
                        Score = _note,
                        Comment = _comment,
                        Movie_Id = _idMovie,
                        User_Id = _idUser
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

        #region DeleteNote

        public bool DeleteNote(Note note)
        {
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    var Notedelete = entities.NoteSets.Where(nt => nt.Id == note.IdGetSet).ToArray();

                    entities.NoteSets.RemoveRange(Notedelete);
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

        #region FindNotesOfMovie

        public ObservableCollection<Note> FindNotesOfMovie(int idMovie)
        {

            ObservableCollection<Note> FindNoteList = null;

            try
            {
                 using (var entities = new DbMovieNetEntities())
                 {
                FindNoteList = new ObservableCollection<Note>(entities.NoteSets.Where(note => note.Movie_Id == idMovie).Select(
                    note => new Note()
                    {
                        ScoreGetSet = note.Score,
                        CommentGetSet = note.Comment,
                        Movie_idGetSet = note.Movie_Id

                    }).ToList());
                     }
                
            }
            catch (SqlException ex)
            {
                NewMethodException(ex);
            }

            return FindNoteList;
        }
        #endregion

        #region FindNotesOfUser

        public IReadOnlyCollection<Note> FindNotesOfUser(int idUser)
        {
            IReadOnlyCollection<Note> FindNoteUserCollection = default(IReadOnlyCollection<Note>);
            IList<Note> FindNoteUserList = new List<Note>();
            NoteSet resultFindUserNoteSet = null;

            try
            {
                using (DbMovieNetEntities entities = new DbMovieNetEntities())
                {
                    resultFindUserNoteSet = (from nt in entities.NoteSets where nt.UserSet.Id == idUser select nt).FirstOrDefault();
                }

                FindNoteUserList.Add(new Note
                {
                    ScoreGetSet =  resultFindUserNoteSet.Score,
                    CommentGetSet = resultFindUserNoteSet.Comment,
                    Movie_idGetSet = resultFindUserNoteSet.Movie_Id,
                    User_idGetSet = resultFindUserNoteSet.User_Id

                });

            }
            catch (SqlException ex)
            {
                NewMethodException(ex);
            }

            return FindNoteUserCollection = new ReadOnlyCollection<Note>(FindNoteUserList);
        }
        #endregion


        #region UpdateNote
        public bool UpdateNote(Note noteSet)
        {
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    var NoteUpdate = entities.NoteSets.FirstOrDefault(movie =>
                                                                              movie.Score == noteSet.ScoreGetSet 
                                                                              && movie.Comment == noteSet.CommentGetSet);

                    if (NoteUpdate != null)
                    {
                        NoteUpdate.Score = noteSet.ScoreGetSet;
                        NoteUpdate.Comment = noteSet.CommentGetSet;

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
        #endregion
    }
}
