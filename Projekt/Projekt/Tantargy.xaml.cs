﻿using Microsoft.Win32;
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
using static System.Net.Mime.MediaTypeNames;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for Tantargy.xaml
    /// </summary>
    public partial class Tantargy : Window
    {
        public Tantargy()
        {
            InitializeComponent();
            FelvetelGombLetiltasa();
        }

        private void HetiOraszamBeallitasa()
        {
            if (EvfolyamCB.SelectedIndex != -1 && HetiOraszamTB.Text != "")
            {
                switch (EvfolyamCB.SelectedIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                        EvesOraszam.Content = Convert.ToInt32(HetiOraszamTB.Text) * 36;
                        break;
                    case 3:
                        if (KozismeretiRB.IsChecked == true)
                            EvesOraszam.Content = Convert.ToInt32(HetiOraszamTB.Text) * 31;
                        else if (SzakmaiRB.IsChecked == true)
                            EvesOraszam.Content = Convert.ToInt32(HetiOraszamTB.Text) * 36;
                        break;
                    case 4:
                        EvesOraszam.Content = Convert.ToInt32(HetiOraszamTB.Text) * 31;
                        break;
                }
            }
            FelvetelGombLetiltasa();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HetiOraszamBeallitasa();
        }

        private void EvfolyamCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HetiOraszamBeallitasa();
        }

        private void KozismeretiRB_Checked(object sender, RoutedEventArgs e)
        {
            HetiOraszamBeallitasa();
        }

        private void SzakmaiRB_Checked(object sender, RoutedEventArgs e)
        {
            HetiOraszamBeallitasa();
        }

        private void Felvetel(object sender, RoutedEventArgs e)
        {
            string tipus;
            if (KozismeretiRB.IsChecked == true)
                tipus = "közismereti";
            else
                tipus = "szakmai";
            using (StreamWriter sw = new("tantargyak.csv", true, Encoding.UTF8))
            {
                sw.WriteLine($"{TantargyNeve.Text};{EvfolyamCB.Text};{tipus};{HetiOraszamTB.Text}");
            }            
        }

        private void FelvetelGombLetiltasa()
        {
            FelvetelGomb.IsEnabled = false;
            if (TantargyNeve.Text != "" && EvfolyamCB.SelectedIndex > -1 && (KozismeretiRB.IsChecked == true || SzakmaiRB.IsChecked == true) && HetiOraszamTB.Text != "")
            {
                FelvetelGomb.IsEnabled = true;
            }
        }

        private void TorlesGomb(object sender, RoutedEventArgs e)
        {
            new Torles().ShowDialog();
        }

        private void AdminGomb(object sender, RoutedEventArgs e)
        {
            new TantargyAdminisztracio().ShowDialog();
        }

        private void DiakhozRendeles(object sender, RoutedEventArgs e)
        {
            new DiakhozRendelesAblak().ShowDialog();
        }

        private void Vissza(object sender, RoutedEventArgs e)
        {
            new Admin().Show();
            this.Close();
        }
    }
}
