


using DevNameSpace;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
//using System.Windows.Media.Imaging;
using System.Windows.Media.Imaging;
namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    public class DeviceItemViewModel:TreeViewItemViewModel
    {
        DeviceMode _dev;
        /// <summary>
        /// 保留此数据模型以便在GridItemViewModel中共用
        /// </summary>
        public DeviceMode Dev
        {
            get { return _dev; }
            set { _dev = value; }
        }
        public DeviceItemViewModel(DeviceMode dev, DeviceItemViewModel parentDev)
            : base(parentDev, false)
        {
            _dev = dev;
            if (_dev.Children.Count > 0)
            {
                initChile(_dev, Children,this);
            }
        }
        public DeviceItemViewModel(DeviceMode dev, DeviceItemViewModel parentDev,bool isTrans)
            : base(parentDev, false)
        {
            _dev = dev;
            if (_dev.Children.Count > 0 && isTrans)
            {
                initChile(_dev, Children, this);
            }
        }

        #region IsSelected

        bool _isSelected;

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
                if (_isSelected)
                {
                    SelectCmd.Execute(this);
                }
            }
        }

        #endregion // IsSelected

        /// <summary>
        ///在Grid中显示选中的设备，在DevDataSelectCommand中构建该对象
        /// </summary>
        DataGridModelView _showDevDataInGrid = new DataGridModelView(new List<DeviceMode>());
        DevDataSelelctCommand selectCmd = null;

        public DevDataSelelctCommand SelectCmd
        {
            get 
            {
                if (selectCmd == null)
                { 
                    selectCmd=new DevDataSelelctCommand (this,ref _showDevDataInGrid);
                }
                return selectCmd;
            }
        }

        /// <summary>
        /// 为实现数据绑定而建立
        /// </summary>
        public ObservableCollection<DeviceMode> Content
        {
            get { return _showDevDataInGrid==null?null: _showDevDataInGrid.Content; }
        }


        /// <summary>
        /// 向下递归初始化所有的子节点viewModel
        /// </summary>
        /// <param name="_dev"></param>
        /// <param name="Children"></param>
        /// <param name="parent"></param>
        private void initChile(DeviceMode _dev, System.Collections.ObjectModel.ObservableCollection<TreeViewItemViewModel> Children,DeviceItemViewModel parent)
        {
            if (_dev.Children.Count > 0)
            {
                foreach (DeviceMode eDataMode in _dev.Children)
                {
                    DeviceItemViewModel modeview = new DeviceItemViewModel(eDataMode, parent,false);
                    parent.Children.Add(modeview);
                    if (eDataMode.Children.Count > 0)
                    {
                        initChile(eDataMode, modeview.Children, modeview);
                    }
                }
            }
        }
       
        ///// <summary>
        ///// 设备名称
        ///// </summary>
        public string DevName
        {
            get { return _dev.DevName; }
        }

        ///// <summary>
        ///// 设备的psrid
        ///// </summary>
        //public int DevID
        //{
        //    get { return _dev.DevID; }
        //}
        ///// <summary>
        ///// 设备类型
        ///// </summary>
        //public int DevClassID
        //{
        //    get { return  _dev.DevClassID; }
        //}

        /// <summary>
        /// 节点显示的图标
        /// </summary>
        public override BitmapImage ImageSource
        {
            get
            {
               // return new BitmapImage(new Uri("pack://application:,,,/LoadOnDemand/Images/City.png"));
               // return new BitmapImage(new Uri("pack://application:,,,/DevTreeNodeIcon;Component/Images/State.png"));
                string imageUri = DevTreeNodeIconClass.GetClassSymbol(_dev.DevClassID);
                if (!string.IsNullOrEmpty(imageUri))
                {
                    return new BitmapImage(new Uri(imageUri));
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 设备树上右键弹出菜单
        /// </summary>
        public ContextMenu PopupMenu
        {
            get
            {
                return GetCurrentDevMenu();
            }
        }

        /// <summary>
        /// 清空右键菜单
        /// </summary>
        public ContextMenu NullMenu
        {
            get
            {
                return null;
            }
        }
        /// <summary>
        /// 根据设备的类型，动态初始化菜单
        /// </summary>
        /// <returns></returns>
        private ContextMenu GetCurrentDevMenu()
        {
            List<IMenuItemCommand> allCommand = MenuDictionary.GetMenuItems(_dev.DevClassID);
            if (allCommand != null && allCommand.Count > 0)
            {
                ContextMenu menu = new ContextMenu();
                DevItemData data = new DevItemData(_dev.DevClassID, 0, _dev.DevID.ToString(), "");
                foreach (IMenuItemCommand cmd in allCommand)
                {
                    cmd.Data = data;
                    MenuItem item = new MenuItem();
                    item.Header = cmd.ItemName;
                    item.Click += cmd.OnClick;
                    menu.Items.Add(item);
                }
                return menu;
            }
            return null;
        }
        /// <summary>
        /// 设备树展开时，获得下级数据
        /// </summary>
        protected override void LoadChildren()
        {
            DataAccess.DataAccess.LoadSubDev(_dev);
        }
    }
}
