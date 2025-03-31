using System;
using System.Collections.ObjectModel;
using System.Linq;
using FFXIVOpcodeWizard.Models;
using Machina.Infrastructure;

namespace FFXIVOpcodeWizard.ViewModels
{
    public class CaptureModeSelectorViewModel
    {
        public ObservableCollection<RadioItem> CaptureModes { get; set; }

        public NetworkMonitorType SelectedCaptureMode => GetSelectedCaptureMode();

        public void Load()
        {
            CaptureModes = new ObservableCollection<RadioItem>
            {
                new RadioItem { Text = "Sockets (deucalion)", IsChecked = Util.Elevated(), IsEnabled = Util.Elevated(), Tooltip = "Requires Administrator privileges" },
            };
        }

        private NetworkMonitorType GetSelectedCaptureMode()
        {
            var selection = CaptureModes.First(cm => cm.IsChecked).Text;
            return selection switch
            {
                "Sockets" => NetworkMonitorType.RawSocket,
                _ => throw new NotImplementedException(),
            };
        }
    }
}