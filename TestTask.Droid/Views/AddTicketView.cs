using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;
//using MvvmCross.Plugins.Color.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.Core.ViewModels;

namespace TestTask.Droid.Views
{
    [Activity(Label = "AddTicketView")]
    public class AddTicketView : MvxActivity<AddTicketViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.AddTicketView);
            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetActionBar(toolbar);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.Title = "Add Ticket";

            MvxRecyclerView mvxRV = FindViewById<MvxRecyclerView>(Resource.Id.PriorityList);
            GridLayoutManager layoutManager = new GridLayoutManager(this, 3, GridLayoutManager.Vertical, false);
            mvxRV.SetLayoutManager(layoutManager);

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

    }
}