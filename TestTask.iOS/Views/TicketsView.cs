using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace TestTask.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class TicketsView : MvxViewController
    {
        public TicketsView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<TicketsView, Core.ViewModels.TicketsViewModel>();
            set.Apply();
        }
    }
}