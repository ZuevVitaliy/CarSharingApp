using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarSharingApp.Helpers;
using CarSharingApp.Views;

namespace CarSharingApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly LoginWindow _loginWindow;

        public LoginViewModel(LoginWindow loginWindow)
        {
            _loginWindow = loginWindow;
        }

        private string _login;
        public string Login 
        { 
            get => _login; 
            set
            {
                _login = value;
                LoginCommand.RaiseCanExecuteChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }

        private string _password;
        public string Password
        { 
            get => _password;
            set
            {
                _password = value;
                LoginCommand.RaiseCanExecuteChanged();
                RegisterCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanLoginOrRegister =>
            !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ??= new DelegateCommand(LoginCommand_Execute, LoginCommand_CanExecute);

        private void LoginCommand_Execute()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                User? user = null;
                try
                {
                    user = dbContext.Users.FirstOrDefault(u => u.Login == Login);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                var encryptor = new Encryptor();
                if (user == null || user.Password != encryptor.GenerateHash(Password))
                {
                    MessageBox.Show("Неверно введён логин или пароль.");
                    return;
                }

                EnterToSystem(user.Login, user.Role);
            }
        }

        private bool LoginCommand_CanExecute()
        {
            return CanLoginOrRegister;
        }

        private DelegateCommand _registerCommand;
        

        public DelegateCommand RegisterCommand =>
                    _registerCommand ??= new DelegateCommand(RegisterCommand_Execute, RegisterCommand_CanExecute);

        private void RegisterCommand_Execute()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                User? user = null;
                try
                {
                    user = dbContext.Users.FirstOrDefault(u => u.Login == Login);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                var encryptor = new Encryptor();
                if (user != null)
                {
                    MessageBox.Show("Такой пользователь существует.");
                    return;
                }

                user = new User
                {
                    Id = Guid.NewGuid(),
                    Login = Login,
                    Password = encryptor.GenerateHash(Password),
                    Role = Role.Operator
                };
                try
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                EnterToSystem(user.Login, user.Role);
            }
        }

        private bool RegisterCommand_CanExecute()
        {
            return CanLoginOrRegister;
        }

        private void EnterToSystem(string login, Role role)
        {
            var carsWindow = new CarsWindow(login, role);
            carsWindow.Show();
            _loginWindow.Close();
        }
    }
}
