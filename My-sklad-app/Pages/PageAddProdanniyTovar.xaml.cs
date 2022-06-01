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
    /// Логика взаимодействия для PageAddProdanniyTovar.xaml
    /// </summary>
    public partial class PageAddProdanniyTovar : Page
    {
        public PageAddProdanniyTovar()
        {
            InitializeComponent();
            TxtKlient.SelectedValuePath = "id_klient";
            TxtKlient.DisplayMemberPath = "name";
            TxtKlient.ItemsSource = skald_dbEntities.GetContext().klients.ToList();


        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
               
                

                prodanniy_tovar prodanniy_tovar = new prodanniy_tovar()
                {
                    name = TxtTovarName.Text,
                    count = Convert.ToInt32(TxtCountTovar.Text),
                    id_klient = (int)TxtKlient.SelectedValue,
                    date_prodazhi = Convert.ToDateTime(DpDateProdazh.Text),
                    perevozchik = TxtPerevozchik.Text,
                    sum = Convert.ToInt32(TxtSumma.Text),
                    // fdgdfgg
              

                };

                skald_dbEntities.GetContext().prodanniy_tovar.Add(prodanniy_tovar);
                skald_dbEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление об успешном добавлении данных!", MessageBoxButton.OK, MessageBoxImage.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Уведомление об ошибке!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
