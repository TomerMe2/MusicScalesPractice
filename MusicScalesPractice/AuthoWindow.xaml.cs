using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace MusicScalesPractice
{
    /// <summary>
    /// Interaction logic for AuthoWindow.xaml
    /// </summary>
    public partial class AuthoWindow : Window
    {
        private static string TXT_PATH = Environment.CurrentDirectory + @"Code.txt";
        private string code;

        public AuthoWindow()
        {
            InitializeComponent();
            TxtBxChallenge.Text = FingerPrint.Value();
            code = "";
            TxtBxAnswer.TextWrapping = TextWrapping.NoWrap;
            ReadCodeFromFileAndOpenTheMain();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FingerPrint.Decrypt(TxtBxAnswer.Text))
            {
                //The code was correct!
                MessageBox.Show("Great! Enjoy!");
                code = TxtBxAnswer.Text;
                WriteCodeToFile();
                MainWindow main = new MainWindow();
                main.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }

        /// <summary>
        /// Writes the key to a txt file so the user won't need to insert it all the time
        /// </summary>
        private void WriteCodeToFile()
        {
            bool needToExist = false;
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(TXT_PATH);
                sw.WriteLine(code);
            }
            catch
            {
                MessageBox.Show("Fatal Error occured. Please try again.");
                needToExist = true;
            }
            finally
            {
                sw.Close();
            }
            if (needToExist)
            {
                Environment.Exit(2);
            }
        }

        /// <summary>
        /// If the file that contains the key holds the correct key, it will open the main window
        /// </summary>
        private void ReadCodeFromFileAndOpenTheMain()
        {
            StreamReader sr = null;
            bool needToExist = false;
            bool isCorrect = false;
            if (File.Exists(TXT_PATH))
            {
                try
                {
                    sr = new StreamReader(TXT_PATH);
                    isCorrect = FingerPrint.Decrypt(sr.ReadLine());
                }
                catch
                {
                    MessageBox.Show("Fatal Error occured with the read of the code file. Please try again.");
                    needToExist = true;
                }
                finally
                {
                    sr.Close();
                }
                if (needToExist)
                {
                    Environment.Exit(2);
                }
                if (isCorrect)
                {
                    MainWindow main = new MainWindow();
                    main.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
