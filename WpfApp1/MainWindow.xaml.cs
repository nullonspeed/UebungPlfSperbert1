using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       List<Patient> patients { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            patients = new List<Patient>();
        }
       
        private void OpenFileEvent(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
               string filename= openFileDialog.FileName;
               
               string [] file = File.ReadAllLines(openFileDialog.FileName);
                for (int fileReading = 0; fileReading < file.Length; fileReading++)
                {
                    if (Patient.TryParse(file[fileReading],out Patient patient))
                    {
                        patients.Add(patient);
                    }
                    else
                    {

                    }

                }
            }
        }

        private void SaveFileEvent(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.Filter = "CSV-Datei (*.csv)|*.csv";
            saveFileDialog.CheckFileExists = false;

            if (saveFileDialog.ShowDialog() == true)
            {
               
                string TextForFile = "";
                for (int patientNum = 0; patientNum < patients.Count; patientNum++)
                {
                    TextForFile += patients[patientNum].ToCSVString()+"\n";
                } 
                if(TextForFile!="" && saveFileDialog.CheckPathExists)
                {
                    File.WriteAllText(saveFileDialog.FileName+".csv", TextForFile);
                }
               
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("Wollen sie wirklich schließen?", "Closing", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

            }
            else
            {
               e.Cancel = true;
            }


        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
