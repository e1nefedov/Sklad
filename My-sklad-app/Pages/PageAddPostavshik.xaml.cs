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
    /// Логика взаимодействия для PageAddPostavshik.xaml
    /// </summary>
    public partial class PageAddPostavshik : Page
    {
        public PageAddPostavshik()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                postavshiki postavshiki = new postavshiki()
                {
                    name = TxtKlienName.Text,
                    contact = TxtKlienContact.Text,
                    addres = TxtKlienAdres.Text,

                };

                skald_dbEntities.GetContext().postavshiki.Add(postavshiki);
                skald_dbEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление об успешном добавлении данных!", MessageBoxButton.OK, MessageBoxImage.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!", "Уведомление об ошибке!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
