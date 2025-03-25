﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Desktop.Repository;
using Entities;

namespace Desktop.View
{
    public partial class LogIn : Page
    {
        private string name;

        public LogIn()
        {
            InitializeComponent();

            mailBox.Foreground = Brushes.Gray;
            passBlock.Foreground = Brushes.Gray;

            mailBox.TabIndex = 0;
            passPASSwordBox.TabIndex = 1;
            loginB.TabIndex = 2;
            registrationB.TabIndex = 3;
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
            this.NavigationService.Navigate(new Registration());
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
                var user = UserRepository.AuthorizeUser(mail, password);
                if (user != null)
                {
                    name = user.Name;
                    var tasks = TaskRepository.GetTaskRepository().GetTaskReposes();
                    if (tasks.Count == 0)
                    {
                        this.NavigationService.Navigate(new MainEmpty(name));
                    }
                    else
                    {
                        this.NavigationService.Navigate(new Main(name, tasks));
                    }
                }
                else
                {
                    MessageBox.Show("Неверная почта или пароль.", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
