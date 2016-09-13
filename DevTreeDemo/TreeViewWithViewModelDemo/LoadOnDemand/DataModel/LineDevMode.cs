using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    /// <summary>
    /// 线路数据模型，比普通的数据模型多了个2个属性
    /// </summary>
    public  class LineDevMode:DeviceMode
    {
        double lenght;
        /// <summary>
        /// 线路长度
        /// </summary>
        public double Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        string poleTowerMount;
        /// <summary>
        /// 线路上的杆塔号
        /// </summary>
        public string PoleTowerMount
        {
            get { return poleTowerMount; }
            set { poleTowerMount = value; }
        }
    }
}
