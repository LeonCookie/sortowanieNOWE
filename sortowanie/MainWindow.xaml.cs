using System.Windows;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace sortowanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string strPath;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
        /*OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
            txtEditor.Text = File.ReadAllText(openFileDialog.FileName); */
        

         var MyList = new List<string>();
            using (var streamReader = File.OpenText("C:\\Users\\student\\Desktop\\liczby.txt"))
            {
                var s = string.Empty;
                while ((s = streamReader.ReadLine()) != null)
                    MyList.Add(s);
            }
            myListbox.ItemsSource = MyList;
            MyList.ForEach(item => Debug.WriteLine(item));
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {

            
             
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            //sortowani

            for(int i=1; i < 1000; i++)
            {
                Debug.WriteLine("heheh");
            }

            stopwatch.Stop();

            System.Diagnostics.Debug.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
           
        }

       

        private void lbFiles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
