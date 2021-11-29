using System.Windows;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System;
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
        int i,j,p,pmin,pmax = 0;//dane potrzebne przy sortowanie tzw zmienne pomocnicze
        

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


            for (j = 0; j < intList.Count - 1; j++)
                for (i = 0; i < intList.Count - 1; i++)
                    if (intList[i] > intList[i + 1])
                    {
                       //w c++ jest funkcja swap, ktora zamienia wartosci, jednakze tutaj uzyjemy tradycyjnej metody z a i b 
                        intList[i] = intList[i] + intList[i + 1];  
                        intList[i + 1]= intList[i] - intList[i + 1];
                        intList[i] = intList[i] - intList[i + 1];

                    }

                        

            myListBox_Sort_bomb_1.ItemsSource = intList;
            stopwatch.Stop();

            
            TextBoxTime_Bomb_1.Text = "" + stopwatch.ElapsedMilliseconds;

        }

        private void btn_bomb_2_Click(object sender, RoutedEventArgs e)
        {
            {
                
                List<int> intList = new List<int>();
                for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
                {
                    intList.Add(int.Parse(Lista[o]));

                }
                Stopwatch stopwatch = new Stopwatch();//zegar

                stopwatch.Start();
                //sortowanie


                for (j = intList.Count - 1; j > 0; j--)
                    for (i = 0; i < j; i++)
                        if (intList[i] > intList[i + 1]) 
                        {
                            //w c++ jest funkcja swap, ktora zamienia wartosci, jednakze tutaj uzyjemy tradycyjnej metody z a i b 
                            intList[i] = intList[i] + intList[i + 1];
                            intList[i + 1] = intList[i] - intList[i + 1];
                            intList[i] = intList[i] - intList[i + 1];

                        }



                myListBox_Sort_bomb_2.ItemsSource = intList;
                stopwatch.Stop();

                
                TextBoxTime_Bomb_2.Text = "" + stopwatch.ElapsedMilliseconds;

            }
        }

        private void btn_bomb_3_Click(object sender, RoutedEventArgs e)
        {
            {
                {

                    List<int> intList = new List<int>();
                    for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
                    {
                        intList.Add(int.Parse(Lista[o]));

                    }
                    Stopwatch stopwatch = new Stopwatch();//zegar

                    stopwatch.Start();
                    //sortowanie


                    for (j = intList.Count - 1; j > 0; j--)
                    {
                        p = 1;
                        for (i = 0; i < j; i++)
                            if (intList[i] > intList[i + 1])
                            {
                                intList[i] = intList[i] + intList[i + 1];
                                intList[i + 1] = intList[i] - intList[i + 1];
                                intList[i] = intList[i] - intList[i + 1];
                                p = 0;
                            }
                        if (p==1) break;
                    }




                    myListBox_Sort_bomb_3.ItemsSource = intList;
                    stopwatch.Stop();

                   
                    TextBoxTime_Bomb_3.Text = "" + stopwatch.ElapsedMilliseconds;

                }
            }
        }

        private void btn_bomb_4_Click(object sender, RoutedEventArgs e)
        {
            {
                {

                    List<int> intList = new List<int>();
                    for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
                    {
                        intList.Add(int.Parse(Lista[o]));

                    }
                    Stopwatch stopwatch = new Stopwatch();//zegar

                    stopwatch.Start();
                    //sortowanie


                    pmin = 0; pmax = intList.Count - 1;
                    do
                    {
                        p = -1;
                        for (i = pmin; i < pmax; i++)
                            if (intList[i] > intList[i + 1])
                            {
                                intList[i] = intList[i] + intList[i + 1];
                                intList[i + 1] = intList[i] - intList[i + 1];
                                intList[i] = intList[i] - intList[i + 1];
                                if (p < 0) pmin = i;
                                p = i;
                            }
                        if (pmin>1) pmin--;
                        pmax = p;
                    } while (p >= 0);




                    myListBox_Sort_bomb_4.ItemsSource = intList;
                    stopwatch.Stop();


                    TextBoxTime_Bomb_4.Text = "" + stopwatch.ElapsedMilliseconds;

                }

            }
        }
        private void btn_bomb_5_Click(object sender, RoutedEventArgs e)
        {
            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie


            pmin = 0; pmax = intList.Count - 2;
            do
            {
                p = -1;
                for (i = pmin; i <= pmax; i++)
                    if (intList[i] > intList[i + 1])
                    {
                        intList[i] = intList[i] + intList[i + 1];
                        intList[i + 1] = intList[i] - intList[i + 1];
                        intList[i] = intList[i] - intList[i + 1];
                        p = i;
                    }
                if (p < 0) break;
                pmax = p - 1;
                p = -1;
                for (i = pmax; i >= pmin; i--)
                    if (intList[i] > intList[i + 1])
                    {
                        intList[i] = intList[i] + intList[i + 1];
                        intList[i + 1] = intList[i] - intList[i + 1];
                        intList[i] = intList[i] - intList[i + 1];
                        p = i;
                    }
                pmin = p + 1;
            } while (p >= 0);




            myListBox_Sort_bomb_5.ItemsSource = intList;
            stopwatch.Stop();


            TextBoxTime_Bomb_5.Text = "" + stopwatch.ElapsedMilliseconds;
        }
    }
 }

