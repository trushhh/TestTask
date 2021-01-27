using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
using TestTask.Core.ViewModels;

namespace TestTask.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "First View")]
    public class TicketsView : MvxActivity<TicketsViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TicketsView);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetActionBar(toolbar);
            
            ActionBar.Title = "Tickets List";
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            ViewModel.NavigateToAddTicketCommand.Execute();
            return base.OnMenuItemSelected(featureId, item);
        }
    }
}