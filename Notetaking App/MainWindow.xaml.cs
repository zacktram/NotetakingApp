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
using System.Data;

namespace Notetaking_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {

        DataTable table = new DataTable();

        public MainWindow()
        {
            InitializeComponent();          
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {                       
            table.Columns.Add("Title");
            table.Columns.Add("Context");
            noteList.ItemsSource = table.DefaultView;

            noteList.Columns.ElementAt(1).Visibility = Visibility.Hidden;
            noteList.Columns.ElementAt(0).Width = 175;
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            titleTxtBox.Clear();
            contentTxtBox.Clear();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(titleTxtBox.Text) || String.IsNullOrEmpty(contentTxtBox.Text))
            {
                MessageBox.Show("One or more fields missing");                
            }
            else
            {
                DataView view = noteList.ItemsSource as DataView;
                DataTable table = view.Table;
                DataRow row = table.NewRow();
                row["Title"] = titleTxtBox.Text;
                row["Context"] = contentTxtBox.Text;
                table.Rows.Add(row);

                titleTxtBox.Clear();
                contentTxtBox.Clear();
            }

         
        }

        private void readBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = noteList.SelectedIndex;

            if(index >= -1)
            {
                titleTxtBox.Text = table.Rows[index].ItemArray[0].ToString();
                contentTxtBox.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = noteList.SelectedIndex;

            table.Rows[index].Delete();
        }
    }
}
