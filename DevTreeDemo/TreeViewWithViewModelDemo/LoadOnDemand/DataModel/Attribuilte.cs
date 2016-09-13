using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeViewWithViewModelDemo
{
   /// <summary>
   /// 属性类，支持动态的把设备的属性信息绑定到Grid上
   /// </summary>
   public class Attribuilte
    {
        string attribuilteName;
       /// <summary>
       /// 属性名称
       /// </summary>
        public string AttribuilteName
        {
            get { return attribuilteName; }
            set { attribuilteName = value; }
        }
        Type atrribuilteType;
       /// <summary>
       /// 属性的类型
       /// </summary>
        public Type AtrribuilteType
        {
            get { return atrribuilteType; }
            set { atrribuilteType = value; }
        }
        object attribuilteValue;
       /// <summary>
       /// 属性的值
       /// </summary>
        public object AttribuilteValue
        {
            get { return attribuilteValue; }
            set { attribuilteValue = value; }
        }
    }
}
