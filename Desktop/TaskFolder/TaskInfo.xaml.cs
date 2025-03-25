using Desktop.Repository;
using Entities;
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

namespace Desktop.TaskFolder
{
    /// <summary>
    /// Логика взаимодействия для TaskInfo.xaml
    /// </summary>
    public partial class TaskInfo : UserControl
    {
        public delegate void DeleteTaskItemDel();
        public event DeleteTaskItemDel? DeleteTaskItem;

        private TaskDictionary? Task;

        public TaskInfo()
        {
            InitializeComponent();
        }

        public void InfoLoad(TaskDictionary? Task)
        {
            this.Task = Task;
            InitializeTaskInfo();
        }

        private void InitializeTaskInfo()
        {
            if (Task == null)
                return;

            TitleItem.Text = Task.Name;
            TimeItem.Text = Task.Time;
            DateItem.Text = Task.Date;
            SubtitleItem.Text = Task.Description;
        }

        private void DoneB_Click(object sender, RoutedEventArgs e)
        {
            var itemRepos = TaskRepository.GetTaskRepository();
            var tasksRepos = itemRepos.GetTaskRepos((int)Task.Id);
            tasksRepos.IsCompleted = !Task.IsCompleted;
            itemRepos.RefreshTaskItems();

        }

        private void DeleteB_Click(object sender, RoutedEventArgs e)
        {
            var itemRepos = TaskRepository.GetTaskRepository();
            itemRepos.RemoveTaskDictionary(Task);
            DeleteTaskItem?.Invoke();
        }
    }
}
