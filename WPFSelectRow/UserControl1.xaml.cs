using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFSelectRow
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel vm = new ViewModel();
            dataGrid1.DataContext = vm;
        }

        public void SetRow(int index)
        {
            dataGrid1.Focus();
            SelectRowByIndex(dataGrid1, index);
            return;
        }

        public static void SelectRowByIndex(DataGrid dataGrid, int rowIndex)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

            if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

            dataGrid.SelectedItems.Clear();
            /* set the SelectedItem property */
            object item = dataGrid.Items[rowIndex]; // = Product X
            dataGrid.SelectedItem = item;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex);
            row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

        }


    }


    /// <summary>
    /// The test class for our example.
    /// </summary>
    public class TestObject
    {
        public int OneValue { get; set; }
        public int TwoValue { get; set; }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IList<TestObject> TestList
        {
            get
            {
                List<TestObject> list = new List<TestObject>()
                    {
                        new TestObject(){OneValue = 1, TwoValue = 3},
                        new TestObject(){OneValue = 12, TwoValue = 23},
                        new TestObject(){OneValue = 31, TwoValue = 73},
                   };

                return list;

            }
        }
    }

}
