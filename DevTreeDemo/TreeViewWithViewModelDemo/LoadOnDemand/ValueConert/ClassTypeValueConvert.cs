using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    /// <summary>
    /// 将数值型对象转换为值对象
    /// </summary>
   public abstract  class BaseValueConvert : IValueConverter
    {
        protected  Dictionary<int, string> DevDictionary = null;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType().Equals(typeof(int)) && targetType.Equals(typeof(string)))
            {
                if (DevDictionary.Keys.Contains((int)value))
                {
                    return DevDictionary[(int)value];
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType().Equals(typeof(string)) && targetType.Equals(typeof(int)))
            {
                if (DevDictionary.Values.Contains((string)value))
                {
                    foreach (int key in DevDictionary.Keys)
                    {
                        if (DevDictionary[key].Equals((string)value))
                        {
                            return key;
                        }
                    }
                }
            }
            return null;
        }

    }

    /// <summary>
    /// 将设备的ClassID转换为类型名称，目前只支持四种设备类的转换，以后再扩展
    /// </summary>
   public class ClassTypeValueConvert : BaseValueConvert
   {
       public ClassTypeValueConvert()
       {
           if (DevDictionary == null)
           {
               DevDictionary = new Dictionary<int, string>();
               DevDictionary.Add(156, "线路");
               DevDictionary.Add(200, "变电站");
               DevDictionary.Add(158, "杆塔");
               DevDictionary.Add(210, "电缆井");
           } 
       }
   }
    /// <summary>
    /// 电压等级转换
    /// </summary>
   public class PowerLeverValueConvert : BaseValueConvert
   {
       public PowerLeverValueConvert()
       {
           if (DevDictionary == null)
           {
               DevDictionary = new Dictionary<int, string>();
               DevDictionary.Add(220, "200kV");
               DevDictionary.Add(500, "500kV");
               DevDictionary.Add(110, "100kV");
           } 
       }
   }
}
