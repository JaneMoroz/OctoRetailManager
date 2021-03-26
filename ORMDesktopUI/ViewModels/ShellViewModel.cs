using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ORMDesktopUI.EventModels;

namespace ORMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM)
        {

            _events = events;
            _salesVM = salesVM;
            _events.Subscribe(this);
            
            //IoC allows to talk to the container to get an instance, no need to pass the container around
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
        }
    }
}
