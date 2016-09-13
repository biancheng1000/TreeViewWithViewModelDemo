using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
  public  class TopLevelDeviceViewModel
    {
        readonly ReadOnlyCollection<DeviceItemViewModel> _devices;

         public TopLevelDeviceViewModel(DeviceMode[] regions)
        {
            _devices = new ReadOnlyCollection<DeviceItemViewModel>(
                (from region in regions
                 select new DeviceItemViewModel(region, null))
                .ToList());
        }

         public ReadOnlyCollection<DeviceItemViewModel> Devices
        {
            get { return _devices; }
        }
    }
}
