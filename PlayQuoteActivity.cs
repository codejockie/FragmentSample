using Android.App;
using Android.OS;
using AndroidX.Fragment.App;

namespace FragmentSample
{
    [Activity(Label = "PlayQuoteActivity")]
    public class PlayQuoteActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                Finish();
            }

            var playId = Intent.Extras.GetInt("current_play_id", 0);

            var detailsFrag = PlayQuoteFragment.NewInstance(playId);
            SupportFragmentManager.BeginTransaction()
                .Add(Android.Resource.Id.Content, detailsFrag)
                .Commit();
        }
    }
}