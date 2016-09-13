using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TreeViewWithViewModelDemo.LoadOnDemand.DataAccess
{
   public class DataAccess
    {

        public static List<DeviceMode> allDev = null;
        static DataAccess()
        {
            if (allDev == null)
            {
                allDev = new List<DeviceMode>();
            }
        }

        /// <summary>
        /// 产生模拟顶层数据
        /// </summary>
        /// <returns></returns>
        public static DeviceMode[] GetTopLevelDev()
        {
            List<DeviceMode> result = new List<DeviceMode>();
            DeviceMode tmssDev = new DeviceMode() { DevName = "输电", DevClassID = 0, DevID = 0, PrarentDev = null };
            DeviceMode disDev = new DeviceMode() { DevName = "配电", DevClassID = 0, DevID = 0, PrarentDev = null };
            DeviceMode transDev = new DeviceMode() { DevName = "变电", DevClassID = 0, DevID = 0, PrarentDev = null };
            DeviceMode lowDev = new DeviceMode() { DevName = "低压", DevClassID = 0, DevID = 0, PrarentDev = null };

            DeviceMode level500 = new DeviceMode() { DevName = "500kV线路(2)", DevClassID = 0, DevID = 0, PrarentDev = tmssDev };
            DeviceMode level220 = new DeviceMode() { DevName = "220kV线路(2)", DevClassID = 0, DevID = 0, PrarentDev = tmssDev };
            DeviceMode level110 = new DeviceMode() { DevName = "110kV线路(1)", DevClassID = 0, DevID = 0, PrarentDev = tmssDev };

            tmssDev.Children.Add(level500);
            tmssDev.Children.Add(level220);
            tmssDev.Children.Add(level110);

            DeviceMode line1 = new DeviceMode() { DevName = "500kV线路1线", DevClassID = 156, DevID = 1, PrarentDev = level500, PowerLevel = 500, LineWorkDepart = "黑河市", RunDepartment = "运检三班", LocalDepart = "黑河县" };
            DeviceMode line2 = new DeviceMode() { DevName = "500kV线路2线", DevClassID = 156, DevID = 2, PrarentDev = level500, PowerLevel = 500, LineWorkDepart = "黑河市", RunDepartment = "运检三班", LocalDepart = "黑河县" };

            level500.Children.Add(line1);
            level500.Children.Add(line2);

            DeviceMode line3 = new DeviceMode() { DevName = "220kV线路1线", DevClassID = 156, DevID = 3, PrarentDev = level220, PowerLevel = 220, LineWorkDepart = "黑河市", RunDepartment = "运检三班", LocalDepart = "黑河县" };
            DeviceMode line4 = new DeviceMode() { DevName = "220kV线路2线", DevClassID = 156, DevID = 4, PrarentDev = level220, PowerLevel = 220, LineWorkDepart = "黑河市", RunDepartment = "运检三班", LocalDepart = "黑河县" };

            level220.Children.Add(line3);
            level220.Children.Add(line4);

            DeviceMode line5 = new DeviceMode() { DevName = "110kV线路1线", DevClassID = 156, DevID = 5, PrarentDev = level110, PowerLevel = 110, LineWorkDepart = "黑河市", RunDepartment = "运检三班", LocalDepart = "黑河县" };

            DeviceMode poleTower1 = new DeviceMode() { DevName = "1#", DevClassID = 158, DevID = 1, PrarentDev = line5 };
            line5.Children.Add(poleTower1);

            DeviceMode poleTower2 = new DeviceMode() { DevName = "2#", DevClassID = 158, DevID = 2, PrarentDev = line5 };
            line5.Children.Add(poleTower2);

            DeviceMode breaker = new DeviceMode() { DevName = "1刀闸", DevClassID = 211, PrarentDev = line5 };
            line5.Children.Add(breaker);

            DeviceMode poleTower3 = new DeviceMode() { DevName = "3#", DevClassID = 158, DevID = 3, PrarentDev = line5 };
            line5.Children.Add(poleTower3);

            DeviceMode poleTower4 = new DeviceMode() { DevName = "4#", DevClassID = 158, DevID = 4, PrarentDev = line5 };
            line5.Children.Add(poleTower4);


            level110.Children.Add(line5);

            result.Add(tmssDev);
            result.Add(disDev);
            result.Add(transDev);
            result.Add(lowDev);

            return result.ToArray();
        }

        /// <summary>
        /// 加载某个具体的设备下的所有子设备
        /// </summary>
        /// <param name="parent">指定的设备</param>
        public static void  LoadSubDev(DeviceMode parent)
        {
            switch (parent.DevClassID)
            { 
                case 156:
                    CreateLineAnimateDate(parent);
                    break;
                case 200:
                    CreateSubstationAnimateDate(parent);
                    break;
            }
        }

        /// <summary>
        /// 产生某条线路下的模拟数据
        /// </summary>
        /// <param name="parentLine"></param>
        /// <returns></returns>
        public static void CreateLineAnimateDate(DeviceMode parentLine)
        {
             DeviceMode pole1 = new DeviceMode() { DevName = "1#", DevClassID = 158, PrarentDev = parentLine,DevID=1 };
             DeviceMode pole2 = new DeviceMode() { DevName="2#",DevClassID=158,PrarentDev=parentLine,DevID=2};
             DeviceMode breaker = new DeviceMode() { DevName="柱上隔离",DevClassID=102,PrarentDev=parentLine,DevID=1};
             DeviceMode pole3 = new DeviceMode() { DevName="3#",DevClassID=158,PrarentDev=parentLine,DevID=3};
             DeviceMode pole4 = new DeviceMode() { DevName="4#",DevClassID=158,PrarentDev=parentLine,DevID=4};

             parentLine.Children.Add(pole1);
             parentLine.Children.Add(pole2);
             parentLine.Children.Add(breaker);
             parentLine.Children.Add(pole3);
             parentLine.Children.Add(pole4);

        }

        public static void CreateSubstationAnimateDate(DeviceMode prentSubstation)
        {
            DeviceMode bay = new DeviceMode() { DevName="间隔1",DevClassID=137,PrarentDev=prentSubstation,DevID=1};
            DeviceMode bus = new DeviceMode() {DevName="母线1",DevClassID=100,PrarentDev=bay,DevID=1 };
            DeviceMode segment = new DeviceMode() {DevName="开关",DevClassID=102,PrarentDev=bus,DevID=1 };

            prentSubstation.Children.Add(bay);
            bay.Children.Add(bus);
            bus.Children.Add(segment);
        }
        
    }
}
