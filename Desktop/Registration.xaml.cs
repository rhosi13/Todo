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
    }
}
