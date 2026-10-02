using System.Collections.ObjectModel;
using System.Windows;

namespace Todolistapp
{
    public partial class MainWindow : Window
    {
        ObservableCollection<string> tasks = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            TaskListBox.ItemsSource = tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;

            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);

                TaskTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a task.");
            }
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                string task = TaskListBox.SelectedItem.ToString();

                int index = TaskListBox.SelectedIndex;

                tasks[index] = "Completed - " + task;
            }
            else
            {
                MessageBox.Show("Please select a task.");
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                int index = TaskListBox.SelectedIndex;

                tasks.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Please select a task.");
            }
        }
    }
}