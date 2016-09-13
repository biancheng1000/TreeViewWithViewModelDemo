using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    /// <summary>
    /// 设备树右键菜单控制
    /// </summary>
    public class MenuDictionary
    {

        /// <summary>
        /// 按照设备类型（classID)对所有的右键菜单进行分组
        /// </summary>
        private static Dictionary<int, List<IMenuItemCommand>> allMenuItem = null;

        /// <summary>
        /// 初始化所有可能用到的设备树上的右键菜单
        /// </summary>
        static MenuDictionary()
        {
            if (allMenuItem == null)
            {
                allMenuItem = new Dictionary<int, List<IMenuItemCommand>>();

                LineLocateMitem locationCmd = new LineLocateMitem();
                PowerOffSectionAnaliy poweroffAnaliyCmd = new PowerOffSectionAnaliy();
                SupplaySecitonAnaliy supplayAnaliy = new SupplaySecitonAnaliy();
                ShowPoleTowerAccountMitem showPoleTowerAccount = new ShowPoleTowerAccountMitem();

                AddMenuCmdToDiction(locationCmd);
                AddMenuCmdToDiction(poweroffAnaliyCmd);
                AddMenuCmdToDiction(supplayAnaliy);
                AddMenuCmdToDiction(showPoleTowerAccount);
            }
        }

        private static void AddMenuCmdToDiction(IMenuItemCommand locationCmd)
        {

            Array.ForEach(locationCmd.DevClassIds, (o) =>
            {
                if (allMenuItem.ContainsKey(o))
                {
                    if (!allMenuItem[o].Contains(locationCmd))
                    {
                        allMenuItem[o].Add(locationCmd);
                    }
                }
                else
                {
                    allMenuItem.Add(o, new List<IMenuItemCommand>() { locationCmd });
                }

            });
        }
        /// <summary>
        /// 根据ClassID返回所有应用到该设备上的所有右键菜单
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static List<IMenuItemCommand> GetMenuItems(int classID)
        {
            if (allMenuItem.ContainsKey(classID))
            {
                return allMenuItem[classID];
            }
            return null;
        }
    }

    /// <summary>
    /// 通用菜单接口
    /// </summary>
    abstract public class WpfCommand : ICommand
    {
        virtual public bool CanExecute(object parameter)
        {
            return true;
        }

        virtual public event EventHandler CanExecuteChanged;

        virtual public void Execute(object parameter)
        {

        }
    }

    /// <summary>
    /// 通用菜单
    /// </summary>
    public class CommonMenuCommand : WpfCommand
    {
        private Action _action;
        public CommonMenuCommand(Action action)
        {
            _action = action;
        }

        override public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action();
            }
        }
    }

    /// <summary>
    /// 右键菜单执行时需要的数据
    /// </summary>
    public class DevItemData
    {
        public string Name;  // 设备名称     
        public int ClassId; // 设备类别
        public int FeatureID;   // 对象的图形ID
        public string EntityID;   // 设备ID

        public string UserData;
        public string StringUserData;  // 用户扩展数据

        public DevItemData(int nClassID, int nFeatureID, string nDevID, string strName)
        {
            Name = strName;
            ClassId = nClassID;
            FeatureID = nFeatureID;
            EntityID = nDevID;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// 右键菜单接口
    /// </summary>
    public interface IMenuItemCommand
    {
        /// <summary>
        /// 菜单显示的名称
        /// </summary>
        string ItemName { get; }
        /// <summary>
        /// 对应的设备classid,用来匹配菜单显示在那个设备下
        /// </summary>
        int[] DevClassIds { get; }
        /// <summary>
        /// 封装菜单执行需要的信息
        /// </summary>
        DevItemData Data { get; set; }
        /// <summary>
        /// 事件响应方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnClick(object sender, EventArgs e);
    }


    #region 所有可以应用到设备树上菜单命令的定义

    public class LineLocateMitem : WpfCommand, IMenuItemCommand
    {
        public string ItemName
        {
            get { return "定位到GIS图"; }
        }
        /// <summary>
        /// 设备信息数据
        /// </summary>
        public DevItemData Data { get; set; }
        int[] devclassids = new int[] { 156,158,211 };
        public int[] DevClassIds
        {
            get { return devclassids; }
        }

        public void OnClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("定位到GIS图上！");
        }
    }

    /// <summary>
    /// 供电范围分析
    /// </summary>
    public class SupplaySecitonAnaliy : WpfCommand, IMenuItemCommand
    {
        public string ItemName
        {
            get { return "供电范围分析"; }
        }
        /// <summary>
        /// 设备信息数据
        /// </summary>
        public DevItemData Data { get; set; }
        int[] devclassids = new int[] { 156 };
        public int[] DevClassIds
        {
            get { return devclassids; }
        }

        public void OnClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("供电范围分析！");
        }
    }


    /// <summary>
    /// 供电范围分析
    /// </summary>
    public class PowerOffSectionAnaliy : WpfCommand, IMenuItemCommand
    {
        public string ItemName
        {
            get { return "停电范围分析"; }
        }
        /// <summary>
        /// 设备信息数据
        /// </summary>
        public DevItemData Data { get; set; }
        int[] devclassids = new int[] { 211 };
        public int[] DevClassIds
        {
            get { return devclassids; }
        }

        public void OnClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("停电范围分析！");
        }
    }

    /// <summary>
    /// 杆塔台账菜单
    /// </summary>
    public class ShowPoleTowerAccountMitem : WpfCommand, IMenuItemCommand
    {

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string ItemName
        {
            get { return "查看杆塔台账"; }
        }
        /// <summary>
        /// 封装该菜单执行需要的所有谁
        /// </summary>
        public DevItemData Data { get; set; }

 
        int[] devclassids = new int[] { 158 };

        /// <summary>
        /// 所有可以使用该菜单的设备类型集合
        /// </summary>
        public int[] DevClassIds
        {
            get { return devclassids; }
        }

        /// <summary>
        /// 菜单执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnClick(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("当前的杆塔PSRID:"+Data.EntityID);
        }
    }



    #endregion
}
