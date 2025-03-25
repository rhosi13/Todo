using Entities;
using Microsoft.Win32;
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
    public partial class MainEmpty : Window
    {
        private string userName;
        private List<TaskDictionary> userTasks;

        public MainEmpty(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            UserNameBlock.Text = userName;
            userTasks = new List<TaskDictionary>();
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
            LogIn logIn = new();
            logIn.Show();
            this.Close();
        }

        private void zada4aB_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTask createNewTask = new CreateNewTask(userName, userTasks);
            createNewTask.ShowDialog();

            if (createNewTask.DialogResult == true)
            {
                Main main = new Main(userName, userTasks);
                main.Show();
                this.Close();
            }
        }

        private void CreateNewCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName) || categoryName.Contains(" "))
            {
                MessageBox.Show("Название категории не может содержать пробелы и быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создаем новую категорию
            userTasks.Add(new TaskDictionary { Category = categoryName });
            MessageBox.Show("Новая категория создана успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
