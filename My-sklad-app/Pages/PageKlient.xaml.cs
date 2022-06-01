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
using System.Windows.Threading;

namespace My_sklad_app.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageKlient.xaml
    /// </summary>
    public partial class PageKlient : Page
    {
        public PageKlient()
        {
            InitializeComponent();
            GrdKlient.ItemsSource = skald_dbEntities.GetContext().klients.ToList(); 
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();



        }
        public void UpdateData(object sender,object e)
        {
            var searching = skald_dbEntities.GetContext().klients.ToList();
            GrdKlient.ItemsSource = searching;
            GrdKlient.ItemsSource = skald_dbEntities.GetContext().klients.Where(x => x.name.StartsWith(TxtSearch.Text) || x.addres.StartsWith(TxtSearch.Text)).ToList();
        }

        private void BtnDelKlient_Click(object sender, RoutedEventArgs e)
        {
            var remove = GrdKlient.SelectedItems.Cast<klients>().ToList();
            
            if(MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение об удалении записи!",MessageBoxButton.OKCancel,MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                skald_dbEntities.GetContext().klients.RemoveRange(remove);
                skald_dbEntities.GetContext().SaveChanges();

            }
            try
            {

            } catch (Exception er) {
                MessageBox.Show("При удалении записи возникла непредвиденная ошибка!", "Уведомление о непредвиденной ошибке!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            
        }

        private void BtnSortKlient_Click(object sender, RoutedEventArgs e)
        {
            GrdKlient.ItemsSource = skald_dbEntities.GetContext().klients.OrderBy(x => x.name).ToList();
        }

        private void BtnAddKlient_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.MainFrame.Navigate(new AddKlient());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.MainFrame.Navigate(new PageEditKlient((sender as Button).DataContext as klients));
        }
    }
}
