using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using SQLite.Entity;

namespace SQLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TodoItem> itemsFromDb;
        public MainWindow()
        {
            InitializeComponent();

            TodoItem item = new TodoItem();
            item.Name = "item";
            item.Text = "item text";
            item.Done = 0;

            App.Database.SaveItemAsync(item);

            itemsFromDb =new  ObservableCollection<TodoItem>(App.Database.GetItemsNotDoneAsync().Result );

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDb.Count);
            foreach (TodoItem todoItem in itemsFromDb)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");


            ItemsCount.Content = "Items in Database " + itemsFromDb.Count;
            ToDoItemsListView.ItemsSource = itemsFromDb;
        }

        /// <summary>
        /// Show selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToDoItemsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TodoItem todoItem = (TodoItem) ToDoItemsListView.SelectedItems[0];
            ItemsCount.Content = itemsFromDb.IndexOf(todoItem);
        }


        /// <summary>
        /// Delete item from Observable collection 
        /// When item is deleted ListView automatically refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(itemsFromDb.Count > 0) itemsFromDb.RemoveAt(0);
        }
    }
}
