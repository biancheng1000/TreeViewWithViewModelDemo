using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    public partial class LoadOnDemandDemoControl : UserControl
    {
        public LoadOnDemandDemoControl()
        {
            InitializeComponent();

            DeviceMode[] devices = DataAccess.DataAccess.GetTopLevelDev();
            TopLevelDeviceViewModel viewModel = new TopLevelDeviceViewModel(devices);
            base.DataContext = viewModel;
            this.tree.SelectedItemChanged += tree_SelectedItemChanged;
        }

        void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Grid.DataContext = e.NewValue;
            //根据当前的设备类型判断是否是线路的类型，显示隐藏的2列
            DeviceItemViewModel selectData = e.NewValue as DeviceItemViewModel;
            if ((selectData.Dev.DevClassID.Equals(156) && selectData.Children.Count==0) || CheckContent(selectData.Content))
            {
                Grid.Columns[Grid.Columns.Count - 4].Visibility = Visibility.Visible;
                Grid.Columns[Grid.Columns.Count - 5].Visibility = Visibility.Visible;
            }
            else
            {
                Grid.Columns[Grid.Columns.Count - 4].Visibility = Visibility.Collapsed;
                Grid.Columns[Grid.Columns.Count - 5].Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 检查如果存在子对象，下属的设备对象是否全是线路
        /// </summary>
        /// <param name="observableCollection"></param>
        /// <returns></returns>
        private bool CheckContent(System.Collections.ObjectModel.ObservableCollection<DeviceMode> observableCollection)
        {
            if (observableCollection == null || observableCollection.Count==0)
            {
                return false;
            }
            foreach (DeviceMode eDevMode in observableCollection)
            {
                if (!eDevMode.DevClassID.Equals(156))
                {
                    return false;
                }
            }
            return true;
        }
       
    }
}