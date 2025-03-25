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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private string name;

        public LogIn()
        {
            InitializeComponent();

            mailBox.Foreground = Brushes.Gray;
            passBlock.Foreground = Brushes.Gray;
        }

        private void MailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (mailBox.Text == "Введите почту" && mailBox.Foreground == Brushes.Gray)
            {
                mailBox.Text = "";
                mailBox.Foreground = Brushes.Black;
            }
        }

        private void MailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (mailBox.Text == "")
            {
                mailBox.Foreground = Brushes.Gray;
                mailBox.Text = "Введите почту";
            }
        }

        private void PassPASSwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passPASSwordBox.Password == "")
                passBlock.Visibility = Visibility.Hidden;
        }

        private void PassPASSwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passPASSwordBox.Password == "")
                passBlock.Visibility = Visibility.Visible;
        }

        private void PassPASSwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passPASSwordBox.Password != "")
                passBlock.Visibility = Visibility.Hidden;
            else
                passBlock.Visibility = Visibility.Visible;
        }

        private void RegistrationB_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new();
            reg.Show();
            this.Close();
        }

        private void LoginB_Click(object sender, RoutedEventArgs e)
        {
            InputValidator inputValidator = new();
            string mail = mailBox.Text;
            string password = passPASSwordBox.Password;

            inputValidator.IsValidEmail(mail);
            inputValidator.IsValidPassword(password);

            if (!inputValidator.IsValidEmail(mail) || mailBox.Foreground == Brushes.Gray && mailBox.Text == "exam@yandex.ru")
                MessageBox.Show("Указан неверный формат Почты!\nПример правильной Почты: example@mail.ru", "Ошибка авторизации [Почта]", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (!inputValidator.IsValidPassword(password))
                MessageBox.Show("Слишком короткий Пароль!\nПароль обязательно должен содержать не менее шести символов.", "Ошибка авторизации [Пароль]", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                //MainEmpty mainempty = new MainEmpty();
                //mainempty.Show();
                //this.Close();

                Main main = new(name);
                main.Show();
                this.Close();
            }
        }
    }
}
