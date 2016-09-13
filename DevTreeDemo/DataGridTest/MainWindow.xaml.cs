using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
             initData();
        }
        void initData()
        {

            DevDataMode DevDateItem = new DevDataMode() {DevName="张北线",PowerLevel=500,DevClassID=156,RunDepartment="运检三班",LocalDepart="张北县供电局",LineWorkDepart="张北线管理单位" };
            DevDataViewModel viewMode = new DevDataViewModel(new List<DevDataMode>() { DevDateItem });
            mainGrid.DataContext = viewMode;
        }
    }
}
