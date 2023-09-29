using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;

namespace FragmentSample.Views
{
    internal class PrefixLayout : LinearLayout
    {
        private string _title;
        private readonly TextView textViewTitle;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                textViewTitle.Text = _title;
            }
        }

        public PrefixLayout(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Orientation = Orientation.Vertical;
            Inflate(context, Resource.Layout.layout_prefix, this);

            textViewTitle = FindViewById<TextView>(Resource.Id.TextViewTitle);

            var it = context.ObtainStyledAttributes(attrs, Resource.Styleable.PrefixLayout);
            Title = it.GetString(Resource.Styleable.PrefixLayout_title) ?? string.Empty;

            it.Recycle();
        }

        /** Important:
         * When we add a view as a child to a CustomLayout the method addView(...) is called, we can override this method
         * to customise the way our views are displayed.
         * For example I am overriding addView(...) to adjust the margins of the PrefixableEditText and Spinner
         */
        //public override void AddView(View child, int index, ViewGroup.LayoutParams @params)
        //{
        //    base.AddView(child, index, @params);
        //    AdjustMargins(child, @params);
        //}

        /** Important:
         * In the index param we are using the method getChildCount "childCount" which will return
         * the total number of children in the View, which will be 3.
         * So to ensure our CustomEditText and Spinner appear in position 2 we use "childCount - 1"
         * which equals 2
         * */
        public override void AddView(View child, ViewGroup.LayoutParams @params)
        {
            if (child is IMarginable || child is ISpinner)
            {
                AddView(child, ChildCount - 1, @params);
            }
            else
            {
                base.AddView(child, @params); 
            }
            AdjustMargins(child, @params);
        }

        private void AdjustMargins(View child, ViewGroup.LayoutParams @params)
        {
            if (child is IMarginable)
            {
                var marginParams = @params as MarginLayoutParams;
                marginParams.LeftMargin = Resources.GetDimensionPixelSize(Resource.Dimension.minus_prefix_margin);
                marginParams.RightMargin = Resources.GetDimensionPixelSize(Resource.Dimension.minus_prefix_margin);
            }
            else if (child is ISpinner)
            {
                var marginParams = @params as MarginLayoutParams;
                marginParams.LeftMargin = Resources.GetDimensionPixelSize(Resource.Dimension.minus_spinner_margin);
                marginParams.RightMargin = Resources.GetDimensionPixelSize(Resource.Dimension.minus_spinner_margin);
                marginParams.TopMargin = Resources.GetDimensionPixelSize(Resource.Dimension.minus_spinner_top_margin);
            }
        }
    }
}