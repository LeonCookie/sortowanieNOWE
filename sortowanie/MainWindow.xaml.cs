using System.Windows;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
namespace sortowanie
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

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                //txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }
}
