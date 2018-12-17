using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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

namespace MusicScalesPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Scale currScl;
        private ScalesUtil util;
        public MainWindow()
        {
            InitializeComponent();
            util = new ScalesUtil();
            currScl = util.GetRandomScale();
            handleChangeScale();
            TxtBx1.TextWrapping = TextWrapping.NoWrap;
            TxtBx2.TextWrapping = TextWrapping.NoWrap;
            TxtBx3.TextWrapping = TextWrapping.NoWrap;
            TxtBx4.TextWrapping = TextWrapping.NoWrap;
            TxtBx5.TextWrapping = TextWrapping.NoWrap;
            TxtBx6.TextWrapping = TextWrapping.NoWrap;
            TxtBx7.TextWrapping = TextWrapping.NoWrap;
            TxtBxSclNm.TextWrapping = TextWrapping.NoWrap;
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            currScl = util.GetRandomScale();
            handleChangeScale();
        }

        //Changes the musical scale of the programm
        public void handleChangeScale()
        {
            InitTextBoxesEnabled();
            int[] twoDegs = chooseTwoInts();
            LocateDegreesInTxtBx(twoDegs);
        }

        //Inits all the text boxes to enables=true
        private void InitTextBoxesEnabled()
        {
            TxtBx1.IsEnabled = true;
            TxtBx1.Text = "";
            TxtBx1.Background = Brushes.White;
            TxtBx2.IsEnabled = true;
            TxtBx2.Text = "";
            TxtBx2.Background = Brushes.White;
            TxtBx3.IsEnabled = true;
            TxtBx3.Text = "";
            TxtBx3.Background = Brushes.White;
            TxtBx4.IsEnabled = true;
            TxtBx4.Text = "";
            TxtBx4.Background = Brushes.White;
            TxtBx5.IsEnabled = true;
            TxtBx5.Text = "";
            TxtBx5.Background = Brushes.White;
            TxtBx6.IsEnabled = true;
            TxtBx6.Text = "";
            TxtBx6.Background = Brushes.White;
            TxtBx7.IsEnabled = true;
            TxtBx7.Text = "";
            TxtBx7.Background = Brushes.White;
            TxtBxSclNm.Text = "";
            TxtBxSclNm.Background = Brushes.White;
            ComboBxScales.Foreground = Brushes.Black;
        }
        //Locate the given degrees in text boxes
        private void LocateDegreesInTxtBx(int[] degrees)
        {
            foreach (int deg in degrees)
            {
                string txt = currScl.GetNoteInDeg(deg);
                if (deg == 1)
                {
                    TxtBx1.Text = txt;
                    TxtBx1.IsEnabled = false;
                }
                if (deg == 2)
                {
                    TxtBx2.Text = txt;
                    TxtBx2.IsEnabled = false;
                }
                if (deg == 3)
                {
                    TxtBx3.Text = txt;
                    TxtBx3.IsEnabled = false;
                }
                if (deg == 4)
                {
                    TxtBx4.Text = txt;
                    TxtBx4.IsEnabled = false;
                }
                if (deg == 5)
                {
                    TxtBx5.Text = txt;
                    TxtBx5.IsEnabled = false;
                }
                if (deg == 6)
                {
                    TxtBx6.Text = txt;
                    TxtBx6.IsEnabled = false;
                }
                if (deg == 7)
                {
                    TxtBx7.Text = txt;
                    TxtBx7.IsEnabled = false;
                }
            }
        }
        //Generate 2 random ints between 1 and 8 (not including 8)
        private int[] chooseTwoInts()
        {
            Random rnd = new Random();
            int num1 = rnd.Next(1, 8);
            int num2 = rnd.Next(1, 8);
            while (num1 == num2)
            {
                num2 = rnd.Next(1, 8);
            }
            int[] toReturn = { num1, num2 };
            return toReturn;
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            HandleCorrectPerTxtBx(TxtBx1, 1);
            HandleCorrectPerTxtBx(TxtBx2, 2);
            HandleCorrectPerTxtBx(TxtBx3, 3);
            HandleCorrectPerTxtBx(TxtBx4, 4);
            HandleCorrectPerTxtBx(TxtBx5, 5);
            HandleCorrectPerTxtBx(TxtBx6, 6);
            HandleCorrectPerTxtBx(TxtBx7, 7);
            HandleCorrectScaleName();
        }

        private void HandleCorrectPerTxtBx(TextBox txtBx, int deg)
        {
            if (txtBx.IsEnabled)   //if a user can insert to it
            {
                string toCheckOn = txtBx.Text.Trim();
                //check correctness
                if (txtBx.Text.Equals(currScl.GetNoteInDeg(deg)))
                {
                    txtBx.Background = Brushes.Green;
                }
                else
                {
                    txtBx.Background = Brushes.Red;
                }
            }
        }

        private void HandleCorrectScaleName()
        {
            String scaleNm = TxtBxSclNm.Text.Trim() + " " + ComboBxScales.Text;
            //check for correctness
            if (scaleNm.Equals(currScl.GetScaleName()))
            {
                TxtBxSclNm.Background = Brushes.Green;
                ComboBxScales.Foreground = Brushes.Green;
            }
            else
            {
                TxtBxSclNm.Background = Brushes.Red;
                ComboBxScales.Foreground = Brushes.Red;
            }
        }
    }
}
