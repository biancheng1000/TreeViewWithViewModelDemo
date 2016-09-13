using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
namespace DataGridTest
{
    public class DevDataViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <param name="_data"></param>
        public  DevDataViewModel(List<DevDataMode> _data)
        {
            Array.ForEach(_data.ToArray(), (o) => { _content.Add(o); });
        }

        ObservableCollection<DevDataMode> _content = new ObservableCollection<DevDataMode>();
        /// <summary>
        /// 所有的数据内容
        /// </summary>
        public ObservableCollection<DevDataMode> Content
        {
            get { return _content; }
            set { _content = value; }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void onPropertyChange(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
