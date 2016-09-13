using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    public class DataGridModelView : INotifyPropertyChanged
    {
        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <param name="_data"></param>
        public DataGridModelView(List<DeviceMode> _data)
        {
            Array.ForEach(_data.ToArray(), (o) => { _content.Add(o); });
        }

        ObservableCollection<DeviceMode> _content = new ObservableCollection<DeviceMode>();
        /// <summary>
        /// 所有的数据内容
        /// </summary>
        public ObservableCollection<DeviceMode> Content
        {
            get { return _content; }
            set { _content = value; }
        }
        #region IsSelected

        bool _isSelected = false;
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
            }
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
