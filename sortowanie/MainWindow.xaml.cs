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
        //zmienne
        List<String> Lista = new List<String>(); // nasza lista

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
            {
                using (var streamReader = File.OpenText(openFileDialog.FileName))// czytanie z pliku
                {
                    var s = string.Empty;
                    while ((s = streamReader.ReadLine()) != null)
                        Lista.Add(s);  //sam nwm
                }
                myListbox.ItemsSource = Lista;
                
            }
            






            //Lista.ForEach(item => Debug.WriteLine(item)); //wypisane kazdego indexu listy
            /* Debug.WriteLine("===");
             Debug.WriteLine(Lista[1]); */ //sprawdzenie czy lista dobrze funkcjonuje


        }


        private void btn_start_Click(object sender, RoutedEventArgs e) //button insert
        {

            int i=0;
            int j=0;
          


            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
           // intList.ForEach(item => Debug.WriteLine(item));//wypisanie listy zmienionej e string na int w konsoli

            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie

            for (j = intList.Count - 2; j >= 0; j--)
            {
                
                int x = intList[j];
                i = j + 1;
                
                while ((i < intList.Count) && (x > intList[i]))
                {
                    intList[i - 1] = intList[i];
                    i++;
                }
                intList[i - 1] = x;

            }
            myListbox_Sort.ItemsSource = intList;

            stopwatch.Stop();

            //System.Diagnostics.Debug.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds); - wypisanie czasu w konsoli
            TextBoxTime.Text = "" + stopwatch.ElapsedMilliseconds;


        }

       

        private void lbFiles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void btn_bomb_1_Click(object sender, RoutedEventArgs e)
        {
            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie


             myListBox_Sort_bomb_1.ItemsSource = intList;
            stopwatch.Stop();

            //System.Diagnostics.Debug.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds); - wypisanie czasu w konsoli
            TextBoxTime_Bomb_1.Text = "" + stopwatch.ElapsedMilliseconds;

        }

    }
}
