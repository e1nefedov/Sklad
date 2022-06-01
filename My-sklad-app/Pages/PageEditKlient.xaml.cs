using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using My_sklad_app.AppDataFiles;


namespace My_sklad_app.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditKlient.xaml
    /// </summary>
    public partial class PageEditKlient : Page
    {
        public PageEditKlient(klients klients)
        {
            InitializeComponent();

            KlientObj.id_klient = klients.id_klient;

            TxtKlienName.Text = klients.name;
            TxtKlienAdres.Text = klients.addres;
            TxtKlienContact.Text = klients.contact;
            TxtKlienInn.Text = Convert.ToString(klients.INN);
            TxtKlienRS.Text = Convert.ToString(klients.Raschetniy_schet);
            
            

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<klients> klientses = skald_dbEntities.GetContext().klients.Where(x => x.id_klient == KlientObj.id_klient).AsEnumerable().Select(x => {
                   x.name = TxtKlienName.Text;
                    x.addres = TxtKlienAdres.Text;
                    x.contact = TxtKlienContact.Text;
                    x.Raschetniy_schet = Convert.ToInt32(TxtKlienRS.Text);
                    x.INN = Convert.ToInt32(TxtKlienInn.Text);

                    return x;
                });
                foreach (klients klnt in klientses)
                {
                    skald_dbEntities.GetContext().Entry(klnt).State = System.Data.Entity.EntityState.Modified;
                }
                skald_dbEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные упешно обновлены!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString(), "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
