using Android.Content;
using Android.Util;
using Android.Widget;
using FragmentSample.Views;
using static Android.Renderscripts.Sampler;

namespace FragmentSample.Layouts
{
    internal class PrefixLayout : LinearLayout
    {
        private string _prefix;
        private string _title;
        private readonly TextView textViewTitle;
        private readonly PrefixEditText editTextCurrency;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                textViewTitle.Text = _title;
            }
        }


        public string Prefix
        {
            get => _prefix;
            set
            {
                _prefix = value;
                editTextCurrency.Prefix = _prefix;
            }
        }


        public PrefixLayout(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Inflate(context, Resource.Layout.prefix_layout, this);

            textViewTitle = FindViewById<TextView>(Resource.Id.TextViewTitle);
            editTextCurrency = FindViewById<PrefixEditText>(Resource.Id.EditTextCurrency);

            var it = context.ObtainStyledAttributes(attrs, Resource.Styleable.PrefixLayout);
            Title = it.GetString(Resource.Styleable.PrefixLayout_title) ?? string.Empty;
            Prefix = it.GetString(Resource.Styleable.PrefixLayout_prefix) ?? string.Empty;

            it.Recycle();
        }
    }
}