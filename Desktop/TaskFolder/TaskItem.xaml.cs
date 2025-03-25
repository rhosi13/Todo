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
    /// Логика взаимодействия для TaskItem.xaml
    /// </summary>
    public partial class TaskItem : UserControl
    {
        public TaskDictionary? Task;
        public TaskItem()
        {
            InitializeComponent();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            ItemTaskBorder.Background = new BrushConverter().ConvertFromString("#eeedfe") as SolidColorBrush;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            ItemTaskBorder.Background = Brushes.White;
        }

        public void InfoLoad(TaskDictionary taskItem)
        {
            this.Task = taskItem;
            InitializeTaskInfo();
        }

        public void InitializeTaskInfo()
        {
            if (this.Task == null)
                return;

            finishedEllipseCanvas.Visibility = Visibility.Collapsed;
            unfinishedEllipse.Visibility = Visibility.Collapsed;
            TitleTask.Text = this.Task.Name;
            TimeTask.Text = this.Task.Time;

            if (this.Task.IsCompleted)
            {
                TitleTask.TextDecorations = TextDecorations.Strikethrough;
                TimeTask.TextDecorations = TextDecorations.Strikethrough;
                finishedEllipseCanvas.Visibility = Visibility.Visible;
            }
            else
                unfinishedEllipse.Visibility = Visibility.Visible;
        }
    }
}
