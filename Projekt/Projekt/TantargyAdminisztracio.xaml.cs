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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for TantargyAdminisztracio.xaml
    /// </summary>
    public partial class TantargyAdminisztracio : Window
    {
        List<TTargy> Tantargyak = new();
        public TantargyAdminisztracio()
        {
            InitializeComponent();
            ListaFeltoltese();
            Statisztika1();
        }

        public void ListaFeltoltese()
        {
            foreach (var sor in File.ReadAllLines("tantargyak.csv"))
            {
                if (sor != "")
                {
                    string[] resz = sor.Split(";");
                    string nev = resz[0];
                    string[] evfolyamReszei = resz[1].Split(".");
                    int evfolyam = int.Parse(evfolyamReszei[0]);
                    string tipus = resz[2];
                    int HetiOraszam = int.Parse(resz[3]);
                    TTargy uj = new TTargy(nev, evfolyam, tipus, HetiOraszam);
                    Tantargyak.Add(uj);
                }
            }
        }

        public void Statisztika1()
        {
            var evfolyam9 = Tantargyak.Where(x => x.Evfolyam == 9).ToList();
            var kozism9 = evfolyam9.Where(x => x.Tipus == "közismereti").ToList();
            var szakmai9 = evfolyam9.Where(x => x.Tipus == "szakmai").ToList();

            var evfolyam10 = Tantargyak.Where(x => x.Evfolyam == 10).ToList();
            var kozism10 = evfolyam10.Where(x => x.Tipus == "közismereti").ToList();
            var szakmai10 = evfolyam10.Where(x => x.Tipus == "szakmai").ToList();

            var evfolyam11 = Tantargyak.Where(x => x.Evfolyam == 11).ToList();
            var kozism11 = evfolyam11.Where(x => x.Tipus == "közismereti").ToList();
            var szakmai11 = evfolyam11.Where(x => x.Tipus == "szakmai").ToList();

            var evfolyam12 = Tantargyak.Where(x => x.Evfolyam == 12).ToList();
            var kozism12 = evfolyam12.Where(x => x.Tipus == "közismereti").ToList();
            var szakmai12 = evfolyam12.Where(x => x.Tipus == "szakmai").ToList();

            var evfolyam13 = Tantargyak.Where(x => x.Evfolyam == 13).ToList();
            var kozism13 = evfolyam13.Where(x => x.Tipus == "közismereti").ToList();
            var szakmai13 = evfolyam13.Where(x => x.Tipus == "szakmai").ToList();

            evfolyam9Label.Content = $"9. évfolyam:\tközismereti: {kozism9.Count()}db tárgy van\n\t\tszakmai: {szakmai9.Count()}db tárgy van";
            evfolyam10Label.Content = $"10. évfolyam:\tközismereti: {kozism10.Count()}db tárgy van\n\t\tszakmai: {szakmai10.Count()}db tárgy van";
            evfolyam11Label.Content = $"11. évfolyam:\tközismereti: {kozism11.Count()}db tárgy van\n\t\tszakmai: {szakmai11.Count()}db tárgy van";
            evfolyam12Label.Content = $"12. évfolyam:\tközismereti: {kozism12.Count()}db tárgy van\n\t\tszakmai: {szakmai12.Count()}db tárgy van";
            evfolyam13Label.Content = $"13. évfolyam:\tközismereti: {kozism13.Count()}db tárgy van\n\t\tszakmai: {szakmai13.Count()}db tárgy van";
        }

        public void Statisztika2()
        {

        }

    }
}
