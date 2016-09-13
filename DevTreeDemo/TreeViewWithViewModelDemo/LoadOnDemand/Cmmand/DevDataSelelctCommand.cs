using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    /// <summary>
    /// 在设备树上的设备节点被选中时触发的事件
    /// </summary>
    public class DevDataSelelctCommand:ICommand
    {
        DeviceItemViewModel _data;
        DataGridModelView _devGridItemdata;
        public DevDataSelelctCommand(DeviceItemViewModel sender,ref DataGridModelView targetModelView)
        {
            _data = sender;
            _devGridItemdata = targetModelView;
        }

       public  event EventHandler CanExecuteChanged;

        public  bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 在控件的右侧Grid中显示设备信息，如果当前的设备节点没有子对象类型，那么显示该对象本身
        /// 如果该设备对象具有子设备对象，那么在Grid中显示该设备对象的子设备对象信息
        /// 初始化DevGridModelView，并将它绑定到Grid上，完成显示过程
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            //有子对象，并且不是虚拟节点
            if (_data.Dev.Children.Count > 0 && _data.Dev.Children.Where(o=>o.DevClassID>0).Count()>0)
            {
                _devGridItemdata.Content = new DataGridModelView(_data.Dev.Children).Content;
                return;
            }

            if (_data.Dev.DevClassID > 0)
            {
                _devGridItemdata.Content = new DataGridModelView(new List<DeviceMode>() { _data.Dev }).Content;
            }
        }
    }
}
