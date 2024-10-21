using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sport.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if(string.IsNullOrEmpty(LoginTextBox.Text))
                {
                    error.AppendLine("Введите логин");
                }
                if(string.IsNullOrEmpty(LoginPasswordBox.Password))
                {
                    error.AppendLine("Введите пароль");
                }
                if(error.Length >0)
                {
                    MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if(Data.SportEntities.GetContext().User.Any(d =>d.Login == LoginTextBox.Text && d.Password == LoginPasswordBox.Password))
                {
                    var user = Data.SportEntities.GetContext().User.Where(d => d.Login == LoginTextBox.Text && d.Password == LoginPasswordBox.Password).FirstOrDefault();
                    switch(user.Role.RoleName)
                    {
                        case "Администратор":
                            Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
                            break;
                        case "Исполнитель":
                            Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
                            break;
                        case "Менеджер":
                            Classes.Manager.MainFrame.Navigate(new Pages.AdminPage());
                            break;
                    }
                    MessageBox.Show("Успех", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
