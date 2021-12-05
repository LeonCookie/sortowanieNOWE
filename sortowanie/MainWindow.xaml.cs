using System.Windows;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Linq;

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
        int Irepeat;//ilosc powtorzen



        private void NumberInput_previewtextinput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            string text = NumberInput.Text;
            
            Debug.WriteLine(text);




        }
        private void btn_repeat_Click(object sender, RoutedEventArgs e)
        {
            string text = NumberInput.Text;
            void NumberInput_previewtextinput(object sender, TextCompositionEventArgs e)
            {
                e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);// tylko liczby w NumberInput-  ilosc powtorzen
            }
            Irepeat = int.Parse(NumberInput.Text);
            Debug.WriteLine(Irepeat);
        }

        private void btn_load_Click(object sender, RoutedEventArgs e) // wybor liczb
        {
            Lista.Clear();
            myListbox.ItemsSource = "";
            TabControl_Main.IsEnabled = true;

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


        private void btn_start_Click(object sender, RoutedEventArgs e) //Sortowanie przez wstawianie
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

       

        

       

        private void btn_bomb_1_Click(object sender, RoutedEventArgs e)  //Sortowanie bąbelkowe - wersja 1
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

        

        private void btn_bomb_2_Click(object sender, RoutedEventArgs e) //Sortowanie bąbelkowe - wersja 2
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

        

        private void btn_bomb_3_Click(object sender, RoutedEventArgs e) //Sortowanie bąbelkowe - wersja 3
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
                                int t = intList [i];
                                intList[i] =  intList[i + 1];
                                intList[i + 1] = t;
                               
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

        

        private void btn_bomb_4_Click(object sender, RoutedEventArgs e)//Sortowanie bąbelkowe - wersja 4- z błędem w postaci 1 pozycji(to co z Panem próbowałem rozwiązać na lekcji)
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


                    pmin = 0; pmax = intList.Count-1 ;
                    do
                    {
                        p = -1;
                        for (i = pmin; i < pmax; i++)
                            if (intList[i] > intList[i + 1])
                            {
                                int t = intList[i];
                                intList[i] =  intList[i + 1];
                                intList[i + 1] = t;
                                if (p < 0) pmin = i;
                                p = i;
                            }
                        if (pmin>1) pmin--;
                        pmax = p--;
                    } while (p >= 0);




                    myListBox_Sort_bomb_4.ItemsSource = intList;
                    stopwatch.Stop();


                    TextBoxTime_Bomb_4.Text = "" + stopwatch.ElapsedMilliseconds;

                }

            }
        }

       

        private void btn_bomb_5_Click(object sender, RoutedEventArgs e)//Sortowanie bąbelkowe - wersja 5
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

        private void btn_headsort_Click(object sender, RoutedEventArgs e) //Sortowanie przez kopcowanie
        {
             List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            int N = intList.Count;
            int i, j, k, m, x;

            Stopwatch stopwatch = new Stopwatch();//zegar
            stopwatch.Start();
            //sortowanie

            // Budujemy kopiec

            for (i = 2; i <= N; i++)
            {
                j = i; k = j / 2;
                x = intList[i];
                while ((k > 0) && (intList[k] < x))
                {
                    intList[j] = intList[k];
                    j = k; k = j / 2;
                }
                intList[j] = x;
            }

            // Rozbieramy kopiec

            for (i = N; i > 1; i--)
            {
                intList[1] = intList[1] + intList[i];
                intList[i] = intList[1] - intList[i];
                intList[1] = intList[1] - intList[i];
                j = 1; k = 2;
                while (k < i)
                {
                    if ((k + 1 < i) && (intList[k + 1] > intList[k]))
                        m = k + 1;
                    else
                        m = k;
                    if (intList[m] <= intList[j]) break;
                    intList[j] = intList[j] + intList[m];
                    intList[m] = intList[j] - intList[m];
                    intList[j] = intList[j] - intList[m];
                    j = m; k = j + j;
                }
            }




            myListBox_headsort.ItemsSource = intList;
            stopwatch.Stop();


            TextBoxTimeHeadsort.Text = "" + stopwatch.ElapsedMilliseconds;

        }

        private void btn_select_Click(object sender, RoutedEventArgs e)// sortowanie szybkie
        {
            List<int> intList = new List<int>();
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie

            void Sortuj_szybko(int lewy, int prawy)
            {
                int i;
                int j;
                int piwot;

                i = (lewy + prawy) / 2;
                piwot = intList[i];
                intList[i] = intList[prawy];
                for (j = i = lewy; i < prawy; i++)
                {
                    if (intList[i] < piwot)
                    {
                        //Swap (intList[i], intList[j]);
                        (intList[i], intList[j]) = (intList[j],intList[j]);

                        j++;
                    }
                }
                intList[prawy] = intList[j];
                intList[j] = piwot;
                if (lewy < j - 1)
                {
                    Sortuj_szybko(lewy, j - 1);
                }
                if (j + 1 < prawy)
                {
                    Sortuj_szybko(j + 1, prawy);
                }

            }

            Sortuj_szybko(0, intList.Count - 1);
            myListBox_Fast.ItemsSource = intList;
            stopwatch.Stop();


            TextTimeBoxFast.Text = "" + stopwatch.ElapsedMilliseconds;
        }
        
        private void btn_scalenie_Click(object sender, RoutedEventArgs e) //sortowanie scalenie
        {
            
            List<int> intList = new List<int>();
            
            for (int o = 0; o < Lista.Count; o++)     //zamiany list string na list int
            {
                intList.Add(int.Parse(Lista[o]));

            }
            
            Stopwatch stopwatch = new Stopwatch();//zegar

            stopwatch.Start();
            //sortowanie
            void MergeSort(int i_p, int i_k)
            {
                int i_s, i1, i2, i;
                int N = intList.Count;
                int[] p = new int [N];
                i_s = (i_p + i_k + 1) / 2;
                if (i_s - i_p > 1) MergeSort(i_p, i_s - 1);
                if (i_k - i_s > 0) MergeSort(i_s, i_k);
                i1 = i_p; i2 = i_s;
                for (i = i_p; i <= i_k; i++)
                    p[i] = ((i1 == i_s) || ((i2 <= i_k) && (intList[i1] > intList[i2]))) ? intList[i2++] : intList[i1++];
                for (i = i_p; i <= i_k; i++) intList[i] = p[i];
            }
            
            MergeSort(0, Lista.Count - 1);





            myListBox_scalenie.ItemsSource = intList;
            stopwatch.Stop();



            TextBoxTimeScalenie.Text = "" + stopwatch.ElapsedMilliseconds;
        }
        
    }
 }

