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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IUserServiceWCF" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IUserServiceWCF
    {
        [OperationContract]
        ObservableCollection<User> GetUsers();

        [OperationContract]
        ObservableCollection<User> GetUsersFind(int id);

        [OperationContract]
        bool CreateUser(string _Firstname, string _Lastname, string _Login, string _Password);

        [OperationContract]
        bool DeleteUser(User user);

        [OperationContract]
        bool UpdateUser(string _nom, string _prenom, string _login, string _password);

        [OperationContract]
        User LoginUser(string _Login, string _Password);

        [OperationContract]
        ObservableCollection<User> GetUsersFindByLogin(string login);
    }

    [DataContract]
    public class User : INotifyPropertyChanged
    {
        private int id;
        string firstname;
         string lastname;
         string login;
         string password;

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
        [DataMember]
        public string FirstnameGetSet
        {
            get
            {
                return firstname;
            }
            set
            {
                if(firstname != value)
                {
                    firstname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DataMember]
        public string LastnameGetSet
        {
            get
            {
                return lastname;
            }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DataMember]
        public string LoginGetSet
        {
            get
            {
                return login;
            }
            set
            {
                if (login != value)
                {
                    login = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [DataMember]
        public string PasswordGetSet
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;



        public void NotifyPropertyChanged([CallerMemberName] string str = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
    }
}
