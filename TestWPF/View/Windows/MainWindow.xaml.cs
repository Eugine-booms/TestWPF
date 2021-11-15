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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestWPFApp.Model.Decant;

namespace TestWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupCollectionFilter(object sender, FilterEventArgs e)
        {
            //Если e.Item не группа - ничего не делаем
            if (!(e.Item is Group group )) return;
            if (group.Name is null) return;
            //получаем строку из TextBox 
            
            var filterText = GroupNameFilterText.Text;
            if (filterText.Length == 0) return;
            if (group.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            //if (group.De)
            e.Accepted = false;
        }

        private void GroupNameFilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var collection = textBox.FindResource("GroupsCollection") as CollectionViewSource;
            collection.View.Refresh();
        }
    }
}
