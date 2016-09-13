using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeViewWithViewModelDemo
{
    public class DeviceMode
    {
        /// <summary>
        /// 设备ID
        /// </summary>
        public int DevID
        {
            set;
            get;
        }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DevName
        {
            set;
            get;
        }

        /// <summary>
        /// 设备类型
        /// </summary>
        public int DevClassID
        {
            set;
            get;
        }

        /// <summary>
        /// 电压等级
        /// </summary>
        int powerLevel;

        public int PowerLevel
        {
            get { return powerLevel; }
            set { powerLevel = value; }
        }

        string runDepartment;
        /// <summary>
        /// 运行单位
        /// </summary>
        public string RunDepartment
        {
            get { return runDepartment; }
            set { runDepartment = value; }
        }

        string localDepart;
        /// <summary>
        /// 地区局
        /// </summary>
        public string LocalDepart
        {
            get { return localDepart; }
            set { localDepart = value; }
        }

        string lineWorkDepart;
        /// <summary>
        /// 线路工区或县局
        /// </summary>
        public string LineWorkDepart
        {
            get { return lineWorkDepart; }
            set { lineWorkDepart = value; }
        }


        List<DeviceMode> _children = new List<DeviceMode>();
        /// <summary>
        /// 子设备对象
        /// </summary>
        public List<DeviceMode> Children
        {
            set
            {
                _children = value;
            }
            get
            {
                return _children;
            }
        }
        DeviceMode _prentDev = null;
        /// <summary>
        /// 父设备对象
        /// </summary>
        public DeviceMode PrarentDev
        {
            set
            {
                _prentDev = value;
            }
            get
            {
                return _prentDev;
            }
        }
    }
}
