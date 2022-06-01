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
using My_sklad_app.Pages;

namespace My_sklad_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameObj.MainFrame = mainFrame;
        }

        private void BtnKlients_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.MainFrame.Navigate(new PageKlient());
        }

        private void BtnPostavshiki_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.MainFrame.Navigate(new PagePostavshiki());
        }

        private void BtnProdanniyTovar_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.MainFrame.Navigate(new PageProdanniyTovar());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameObj.MainFrame.GoBack();
            } catch (Exception ex)
            {
                if(MessageBox.Show("Вы уверены что хотите закрыть приложение?","Закрыть приложение?",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
