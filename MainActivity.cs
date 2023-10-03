using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using System;

namespace FragmentSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/M3", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button buttonOpenDialog;
        const int TRANSIT_FRAGMENT_OPEN = 4097;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            buttonOpenDialog = FindViewById<Button>(Resource.Id.buttonOpenDialog);
            buttonOpenDialog.Click += (s, e) =>
            {
                CustomDialogFragment customDialogFragment = new(DateTime.Today, DateTime.Today.AddDays(50));
                customDialogFragment.OnResult = (result) =>
                {
                    Log.Debug("Result", result.Confirmed.ToString());
                    customDialogFragment.Dismiss();
                };
                customDialogFragment.Show(SupportFragmentManager, "dialog");
                //AndroidX.Fragment.App.FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();
                //transaction.SetTransition(TRANSIT_FRAGMENT_OPEN);
                //transaction.Add(Android.Resource.Id.Content, customDialogFragment)
                //           .AddToBackStack(null).Commit();
            };
        }
    }
}
