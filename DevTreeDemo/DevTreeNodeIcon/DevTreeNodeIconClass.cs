using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
namespace DevNameSpace
{
         /// <summary>
        /// 所有图标的资源字典
        /// </summary>
    public class DevTreeNodeIconClass
    {
        private static Dictionary<int, String> allSymbol = null;
        static DevTreeNodeIconClass()
            {
                if (allSymbol == null)
                {
                    allSymbol = new Dictionary<int, string>();
                    allSymbol.Add(150, "pack://application:,,,/DevTreeNodeIcon;component/Images/03_pole.png");
                    allSymbol.Add(158, "pack://application:,,,/DevTreeNodeIcon;component/Images/02_branch.png");
                    allSymbol.Add(0, "pack://application:,,,/DevTreeNodeIcon;component/Images/Region.png");
                    allSymbol.Add(200, "pack://application:,,,/DevTreeNodeIcon;component/Images/01_subst.png");
                }
            }
        /// <summary>
        /// 根据ThpClassID返回指定的图标
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
            public static string GetClassSymbol(int classID)
            {
                if (allSymbol.ContainsKey(classID))
                {
                    return allSymbol[classID];
                }
                else
                {
                    return "";
                }
            }
        }
}
