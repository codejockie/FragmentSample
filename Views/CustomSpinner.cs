using Android.Content;
using Android.Util;
using AndroidX.AppCompat.Widget;

namespace FragmentSample.Views
{
    internal class CustomSpinner : AppCompatSpinner, ISpinner
    {
        public CustomSpinner(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }
    }
}