using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Desktop.Repository;
using Desktop.TaskFolder;
using Entities;
using System.ComponentModel;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Main(string name)
        {
            
            var taskRepos = TaskRepository.GetTaskRepository();

            InitializeComponent();

            UserNameBlock.Text = name;

            var taskItem1 = new TaskDictionary()
            {
                Id = 1,
                Name = "Пойти на рыбалку со Стефаном",
                Description = "Стефан обещал поделиться своими советами по ловле, и я с нетерпением жду, чтобы применить их на практике.",
                Date = "01 Ноября 2024",
                Time = "9:00",
                IsCompleted = true
            };

            var taskItem2 = new TaskDictionary()
            {
                Id = 2,
                Name = "Прочитать книгу Златана",
                Description = "Интересная книга, которая не уходит из моей памяти уже как пару месяцев, стоит прочитать.",
                Date = "31 Декабря 2024",
                Time = "6:00",
                IsCompleted = false
            };

            var taskItem3 = new TaskDictionary()
            {
                Id = 3,
                Name = "Встретиться с командой дизайнеров",
                Description = "Назначена встреча, обязательная задача.",
                Date = "22 Ноября 2024",
                Time = "3:00",
                IsCompleted = false
            };


            taskRepos.AddTaskDictionary(taskItem1);
            taskRepos.AddTaskDictionary(taskItem2);
            taskRepos.AddTaskDictionary(taskItem3);

            InitializeTasks(taskRepos.GetTaskReposes());

            taskRepos.TaskItemsChanged += TaskReposChanged;
        }

        private void TaskReposChanged()
        {
            InitializeTasks(TaskRepository.GetTaskRepository().GetTaskReposes());
        }

        private void InitializeTasks(List<TaskDictionary> taskItems)
        {
            ItemsTasksSPanel.Children.Clear();

            foreach (TaskDictionary task in taskItems)
            {
                var item = new TaskItem();
                item.InfoLoad(task);
                item.Margin = new Thickness(10);
                item.Effect = new DropShadowEffect()
                {
                    ShadowDepth = 5,
                    Direction = -90,
                    BlurRadius = 20,
                    Color = System.Windows.Media.Color.FromArgb(0xF2, 0xF2, 0xF2, 0xF2),
                };

                item.MouseDown += TaskItem_MouseDown;
                ItemsTasksSPanel.Children.Add(item);

            }
        }

        private void TaskItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var taskItem = (TaskItem)sender;
            if (taskItem == null || taskItem.Task == null)
                return;

            var item = taskItem.Task;

            var itemInfo = new TaskInfo();
            itemInfo.InfoLoad(item);

            TaskInfoBlock.Children.Clear();
            TaskInfoBlock.Children.Add(itemInfo);
            itemInfo.DeleteTaskItem += () => { TaskInfoBlock.Children.Clear(); };
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

        
    }
}
