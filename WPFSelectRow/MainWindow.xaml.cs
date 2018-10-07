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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGridUC.dataGrid1.Focus();
            SelectRowByIndex(dataGridUC.dataGrid1, 0);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGridUC.dataGrid1.Focus();
            SelectRowByIndex(dataGridUC.dataGrid1, 1);
        }

        public void SetRow(int index)
        {
            dataGridUC.dataGrid1.Focus();
            SelectRowByIndex(dataGridUC.dataGrid1, index);
            return;
        }
    }
}
