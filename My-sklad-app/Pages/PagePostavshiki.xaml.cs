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
using System.Windows.Threading;
using My_sklad_app.AppDataFiles;

namespace My_sklad_app.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePostavshiki.xaml
    /// </summary>
    public partial class PagePostavshiki : Page
    {
        public PagePostavshiki()
        {
            InitializeComponent();
            GrdPostavshiki.ItemsSource = skald_dbEntities.GetContext().postavshiki.ToList();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();


        }

        public void UpdateData(object sender,object e)
        {
            var searching = skald_dbEntities.GetContext().postavshiki.ToList();
            GrdPostavshiki.ItemsSource = searching;
            GrdPostavshiki.ItemsSource = skald_dbEntities.GetContext().postavshiki.Where(x => x.name.StartsWith(TxtSearch.Text) || x.addres.StartsWith(TxtSearch.Text)).ToList();
        }

        private void BtnDelKlient_Click(object sender, RoutedEventArgs e)
        {
            var remove = GrdPostavshiki.SelectedItems.Cast<postavshiki>().ToList();

            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение об удалении записи!", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                skald_dbEntities.GetContext().postavshiki.RemoveRange(remove);
                skald_dbEntities.GetContext().SaveChanges();

            }
            try
            {

            }
            catch (Exception er)
            {
                MessageBox.Show("При удалении записи возникла непредвиденная ошибка!", "Уведомление о непредвиденной ошибке!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSortKlient_Click(object sender, RoutedEventArgs e)
        {
            GrdPostavshiki.ItemsSource = skald_dbEntities.GetContext().postavshiki.OrderBy(x => x.name).ToList();
        }

        private void BtnAddKlient_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.MainFrame.Navigate(new PageAddPostavshik());
        }
    }
}
