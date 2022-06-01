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
    /// Логика взаимодействия для AddKlient.xaml
    /// </summary>
    public partial class AddKlient : Page
    {
        public AddKlient()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                klients klients = new klients()
                {
                    name = TxtKlienName.Text,
                    contact = TxtKlienContact.Text,
                    addres = TxtKlienAdres.Text,
                    INN = Convert.ToInt32(TxtKlienInn.Text),
                    Raschetniy_schet = Convert.ToInt32(TxtKlienRS.Text),


                };

                skald_dbEntities.GetContext().klients.Add(klients);
                skald_dbEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно добавлены!","Уведомление об успешном добавлении данных!",MessageBoxButton.OK, MessageBoxImage.Information);


            } catch (Exception ex) {
                MessageBox.Show("Ошибка!", "Уведомление об ошибке!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
