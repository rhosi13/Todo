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

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

            usernameBox.Foreground = Brushes.Gray;
            mailBox.Foreground = Brushes.Gray;
            passBlock.Foreground = Brushes.Gray;
            pass2Block.Foreground = Brushes.Gray;
        }

        private void usernameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (usernameBox.Text == "Введите имя пользователя" && usernameBox.Foreground == Brushes.Gray)
            {
                usernameBox.Text = "";
                usernameBox.Foreground = Brushes.Black;
            }
        }

        private void usernameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (usernameBox.Text == "")
            {
                usernameBox.Foreground = Brushes.Gray;
                usernameBox.Text = "Введите имя пользователя";
            }
        }

        private void mailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (mailBox.Text == "exam@yandex.ru" && mailBox.Foreground == Brushes.Gray)
            {
                mailBox.Text = "";
                mailBox.Foreground = Brushes.Black;
            }
        }

        private void mailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (mailBox.Text == "")
            {
                mailBox.Foreground = Brushes.Gray;
                mailBox.Text = "exam@yandex.ru";
            }
        }

        private void passPASSwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passPASSwordBox.Password == "")
                passBlock.Visibility = Visibility.Hidden;
        }

        private void passPASSwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passPASSwordBox.Password == "")
                passBlock.Visibility = Visibility.Visible;
        }

        private void passPASSwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passPASSwordBox.Password != "")
                passBlock.Visibility = Visibility.Hidden;
            else
                passBlock.Visibility = Visibility.Visible;
        }

        private void pass2PASSwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pass2PASSwordBox.Password == "")
                pass2Block.Visibility = Visibility.Hidden;
        }

        private void pass2PASSwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pass2PASSwordBox.Password == "")
                pass2Block.Visibility = Visibility.Visible;
        }

        private void pass2PASSwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pass2PASSwordBox.Password != "")
                pass2Block.Visibility = Visibility.Hidden;
            else
                pass2Block.Visibility = Visibility.Visible;
        }

        private void nazadB_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void registrationB_Click(object sender, RoutedEventArgs e)
        {
            InputValidator inputValidator = new InputValidator();
            string mail = mailBox.Text;
            string name = usernameBox.Text;
            string password = passPASSwordBox.Password;

            inputValidator.IsValidEmail(mail);
            inputValidator.IsValidName(name);
            inputValidator.IsValidPassword(password);

            if (!inputValidator.IsValidName(name) || name == "Введите имя пользователя")
            {
                MessageBox.Show("Имя пользователя слишком короткое!\nИмя пользователя обязательно должно содержать не менее трех символов.", "Ошибка регистрации [Имя пользователя]");
            }
            else if (!inputValidator.IsValidEmail(mail) || mailBox.Foreground == Brushes.Gray && mailBox.Text == "exam@yandex.ru")
                MessageBox.Show("Указан неверный формат Почты!\nПример правильной Почты: example@mail.ru", "Ошибка регистрации [Почта]");
            else if (!inputValidator.IsValidPassword(password))
                MessageBox.Show("Слишком короткий Пароль!\nПароль обязательно должен содержать не менее шести символов.", "Ошибка регистрации [Пароль]");
            else if (password != pass2PASSwordBox.Password)
                MessageBox.Show("Пароли должны совпадать!", "Ошибка регистрации [Пароль]");
            else
            {
                MainEmpty mainempty = new MainEmpty();
                mainempty.Show();
                this.Close();
            }
        }
    }
}
