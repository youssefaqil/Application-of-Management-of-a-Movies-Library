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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "UserServiceWCF" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez UserServiceWCF.svc ou UserServiceWCF.svc.cs dans l'Explorateur de solutions et démarrez le débogage.

    /// <summary>
    /// [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] : aune instance unique sera créée pour l'objet de service, qui traitera toutes les requêtes provenant du même client ou de différentes clientes, ce qui signifie qu'une instance globale est nécessaire pour tous les clients WCF. Dans ce mode, l'état est maintenu entre les différentes requêtes du même client ou de différents clients.
    /// [ServiceBehavior (InstanceContextMode = InstanceContextMode.PerCall)] :une nouvelle instance du service sera créée pour la demande émanant du même client ou d'un client différent, ce qui signifie que chaque demande est une nouvelle demande. Dans ce mode, aucun état n'est maintenu. 
    /// [ServiceBehavior (InstanceContextMode = InstanceContextMode.PerSession)]  :un nouveau contexte d'instance, c'est-à-dire un objet de service, est créé pour chaque nouvelle session client et maintenu pendant la durée de vie de cette session.
    /// </summary>
    /// 
    //// singleton
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class UserServiceWCF : IUserServiceWCF
    {
        #region GetUsers
      
        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> UserCollec = null;

            using (var entities = new DbMovieNetEntities())
            {
                UserCollec = new ObservableCollection<User>(entities.UserSets.Select(
                    user => new User()
                    {
                        FirstnameGetSet = user.Firstname,
                        LastnameGetSet = user.Lastname,
                        LoginGetSet = user.Login,
                        PasswordGetSet = user.Password
                    }));
            }
            return UserCollec;
        }

        #endregion

        #region GetUsersID

        public ObservableCollection<User> GetUsersFind(int id)
        {
            ObservableCollection<User> searchUser = null;
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    searchUser = new ObservableCollection<User>(entities.UserSets.Where(u => u.Id == id).Select(

                        user => new User()
                        {
                            IdGetSet = user.Id,
                            FirstnameGetSet = user.Firstname,
                            LastnameGetSet = user.Lastname,
                            LoginGetSet = user.Login,
                            PasswordGetSet = user.Password

                        })); ;
                }

                return searchUser;
            }
            catch (SqlException ex)
            {
                throw new FaultException("Erreur GetUsers: " + ex.Errors);
            }

        }
        #endregion

        #region CreateUser
        public bool CreateUser(string _Firstname, string _Lastname, string _Login, string _Password)
        {


            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    entities.UserSets.Add(new UserSet()
                    {
                        Firstname = _Firstname,
                        Lastname = _Lastname,
                        Login = _Login,
                        Password = _Password
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

        #region DeleteUser

        public bool DeleteUser(User user)
        {
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    var Userdelete = entities.UserSets.Where(userSet => userSet.Login == user.LoginGetSet).ToArray();

                    entities.UserSets.RemoveRange(entities: Userdelete);
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

        #region UpdateUser

        public bool UpdateUser(string _nom, string _prenom,string _login, string _password)
        {
            try
            {
                using (DbMovieNetEntities entities = new DbMovieNetEntities())
                {

                    UserSet UserUpdate = null;
                      UserUpdate = (from u in entities.UserSets where u.Login == _login select u).FirstOrDefault();


                

                    if (UserUpdate == null)
                    {
                        return false;
                    }
                    else
                    {
                        UserUpdate.Firstname = _nom;
                        UserUpdate.Lastname = _prenom;
                        UserUpdate.Login = _login;
                        UserUpdate.Password = _password;

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

        #region LoginUser
        public User LoginUser(string _Login, string _Password)
        {
            UserSet userset = null;
            User user = null;
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    userset = (from u in entities.UserSets where u.Login == _Login && u.Password == _Password select u).FirstOrDefault();

                    if (userset == null)
                        return null;
                }
                user = new User
                {
                    LoginGetSet = userset.Login,
                    PasswordGetSet = userset.Password
                };
            }

            catch (SqlException ex)
            {
                NewMethodException(ex);

            }
            return user;
        }

        #endregion

        #region NewMethodException
        private static void NewMethodException(SqlException ex)
        {
            throw new FaultException("Erreur GetUsers: " + ex.Errors);
        }

        public ObservableCollection<User> GetUsersFindByLogin(string login)
        {

            ObservableCollection<User> searchUser = null;
            try
            {
                using (var entities = new DbMovieNetEntities())
                {
                    searchUser = new ObservableCollection<User>(entities.UserSets.Where(u => u.Login == login).Select(

                        user => new User()
                        {
                            IdGetSet = user.Id,
                            FirstnameGetSet = user.Firstname,
                            LastnameGetSet = user.Lastname,
                            LoginGetSet = user.Login,
                            PasswordGetSet = user.Password

                        })) ;
                }
                

            }
            catch (SqlException ex)
            {
                NewMethodException(ex);

            }
            return searchUser;
            #endregion



        }
    }
}
