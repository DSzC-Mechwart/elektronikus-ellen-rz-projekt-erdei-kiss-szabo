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
            Statisztika2();
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

            evfolyam9Label.Content = $"9. évfolyam:\tközismereti: {kozism9.Count()}db tárgy van\n\t\tszakmai: {szakmai9.Count()}db tárgy van\n\t\tösszesen: {kozism9.Count() + szakmai9.Count()}db tárgy van";
            evfolyam10Label.Content = $"10. évfolyam:\tközismereti: {kozism10.Count()}db tárgy van\n\t\tszakmai: {szakmai10.Count()}db tárgy van\n\t\tösszesen: {kozism10.Count() + szakmai10.Count()}db tárgy van";
            evfolyam11Label.Content = $"11. évfolyam:\tközismereti: {kozism11.Count()}db tárgy van\n\t\tszakmai: {szakmai11.Count()}db tárgy van\n\t\tösszesen: {kozism11.Count() + szakmai11.Count()}db tárgy van";
            evfolyam12Label.Content = $"12. évfolyam:\tközismereti: {kozism12.Count()}db tárgy van\n\t\tszakmai: {szakmai12.Count()}db tárgy van\n\t\tösszesen: {kozism12.Count() + szakmai12.Count()}db tárgy van";
            evfolyam13Label.Content = $"13. évfolyam:\tközismereti: {kozism13.Count()}db tárgy van\n\t\tszakmai: {szakmai13.Count()}db tárgy van\n\t\tösszesen: {kozism13.Count() + szakmai13.Count()}db tárgy van";
        }

        public void Statisztika2()
        {
            int kozism9HetiOraszamOsszeg = 0;
            int szakmai9HetiOraszamOsszeg = 0;

            var evfolyam9 = Tantargyak.Where(x => x.Evfolyam == 9).ToList();
            var kozism9 = evfolyam9.Where(x => x.Tipus == "közismereti").ToList();
            var kozism9HetiOraszam = kozism9.Select(x => x.HetiOraszam).ToList();
            foreach (var item in kozism9HetiOraszam)
            {
                kozism9HetiOraszamOsszeg += item;
            }

            var szakmai9 = evfolyam9.Where(x => x.Tipus == "szakmai").ToList();
            var szakmai9HetiOraszam = szakmai9.Select(x => x.HetiOraszam).ToList();
            foreach (var item in szakmai9HetiOraszam)
            {
                szakmai9HetiOraszamOsszeg += item;
            }
            evfolyam9Label2.Content = $"9. évfolyam:\t{kozism9HetiOraszamOsszeg}db közismereti óra van egy héten\n\t\t{szakmai9HetiOraszamOsszeg}db szakmai óra van egy héten\n\t\tösszesen: {kozism9HetiOraszamOsszeg + kozism9HetiOraszamOsszeg}db óra van egy héten";



            int kozism10HetiOraszamOsszeg = 0;
            int szakmai10HetiOraszamOsszeg = 0;

            var evfolyam10 = Tantargyak.Where(x => x.Evfolyam == 10).ToList();
            var kozism10 = evfolyam10.Where(x => x.Tipus == "közismereti").ToList();
            var kozism10HetiOraszam = kozism10.Select(x => x.HetiOraszam).ToList();
            foreach (var item in kozism10HetiOraszam)
            {
                kozism10HetiOraszamOsszeg += item;
            }

            var szakmai10 = evfolyam10.Where(x => x.Tipus == "szakmai").ToList();
            var szakmai10HetiOraszam = szakmai10.Select(x => x.HetiOraszam).ToList();
            foreach (var item in szakmai10HetiOraszam)
            {
                szakmai10HetiOraszamOsszeg += item;
            }
            evfolyam10Label2.Content = $"10. évfolyam:\t{kozism10HetiOraszamOsszeg}db közismereti óra van egy héten\n\t\t{szakmai10HetiOraszamOsszeg}db szakmai óra van egy héten\n\t\tösszesen: {kozism10HetiOraszamOsszeg + kozism10HetiOraszamOsszeg}db óra van egy héten";



            int kozism11HetiOraszamOsszeg = 0;
            int szakmai11HetiOraszamOsszeg = 0;

            var evfolyam11 = Tantargyak.Where(x => x.Evfolyam == 11).ToList();
            var kozism11 = evfolyam11.Where(x => x.Tipus == "közismereti").ToList();
            var kozism11HetiOraszam = kozism11.Select(x => x.HetiOraszam).ToList();
            foreach (var item in kozism11HetiOraszam)
            {
                kozism11HetiOraszamOsszeg += item;
            }

            var szakmai11 = evfolyam11.Where(x => x.Tipus == "szakmai").ToList();
            var szakmai11HetiOraszam = szakmai11.Select(x => x.HetiOraszam).ToList();
            foreach (var item in szakmai11HetiOraszam)
            {
                szakmai11HetiOraszamOsszeg += item;
            }
            evfolyam11Label2.Content = $"11. évfolyam:\t{kozism11HetiOraszamOsszeg}db közismereti óra van egy héten\n\t\t{szakmai11HetiOraszamOsszeg}db szakmai óra van egy héten\n\t\tösszesen: {kozism11HetiOraszamOsszeg + kozism11HetiOraszamOsszeg}db óra van egy héten";



            int kozism12HetiOraszamOsszeg = 0;
            int szakmai12HetiOraszamOsszeg = 0;

            var evfolyam12 = Tantargyak.Where(x => x.Evfolyam == 12).ToList();
            var kozism12 = evfolyam12.Where(x => x.Tipus == "közismereti").ToList();
            var kozism12HetiOraszam = kozism12.Select(x => x.HetiOraszam).ToList();
            foreach (var item in kozism12HetiOraszam)
            {
                kozism12HetiOraszamOsszeg += item;
            }

            var szakmai12 = evfolyam12.Where(x => x.Tipus == "szakmai").ToList();
            var szakmai12HetiOraszam = szakmai12.Select(x => x.HetiOraszam).ToList();
            foreach (var item in szakmai12HetiOraszam)
            {
                szakmai12HetiOraszamOsszeg += item;
            }
            evfolyam12Label2.Content = $"12. évfolyam:\t{kozism12HetiOraszamOsszeg}db közismereti óra van egy héten\n\t\t{szakmai12HetiOraszamOsszeg}db szakmai óra van egy héten\n\t\tösszesen: {kozism12HetiOraszamOsszeg + kozism12HetiOraszamOsszeg}db óra van egy héten";



            int kozism13HetiOraszamOsszeg = 0;
            int szakmai13HetiOraszamOsszeg = 0;

            var evfolyam13 = Tantargyak.Where(x => x.Evfolyam == 13).ToList();
            var kozism13 = evfolyam13.Where(x => x.Tipus == "közismereti").ToList();
            var kozism13HetiOraszam = kozism13.Select(x => x.HetiOraszam).ToList();
            foreach (var item in kozism13HetiOraszam)
            {
                kozism13HetiOraszamOsszeg += item;
            }

            var szakmai13 = evfolyam13.Where(x => x.Tipus == "szakmai").ToList();
            var szakmai13HetiOraszam = szakmai13.Select(x => x.HetiOraszam).ToList();
            foreach (var item in szakmai13HetiOraszam)
            {
                szakmai13HetiOraszamOsszeg += item;
            }
            evfolyam13Label2.Content = $"13. évfolyam:\t{kozism13HetiOraszamOsszeg}db közismereti óra van egy héten\n\t\t{szakmai13HetiOraszamOsszeg}db szakmai óra van egy héten\n\t\tösszesen: {kozism13HetiOraszamOsszeg + kozism13HetiOraszamOsszeg}db óra van egy héten";
        }

    }
}
