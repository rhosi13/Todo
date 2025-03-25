using Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

namespace Desktop.View
{
    public partial class MainEmpty : Page
    {
        private string userName;
        private List<TaskDictionary> userTasks;

        public MainEmpty(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            UserNameBlock.Text = userName;
            userTasks = new List<TaskDictionary>();

            // Animation for UserNameBlock
            var animation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };
            UserNameBlock.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void ProfileImageSwitch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Image Files (*.png;*.jpg)| *.png;*.jpg",
                Title = "Выберите изображение профиля"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                profileImageButton.Source = bitmap;
            }
        }

        private void ProfileImageButton_MouseEnter(object sender, MouseEventArgs e)
        {
            menuGrid.Visibility = Visibility.Visible;
        }

        private void MenuGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            menuGrid.Visibility = Visibility.Hidden;
        }

        private void ExitB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LogIn());
        }

        private void zada4aB_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateNewTask(userName, userTasks));
        }
    }
}
