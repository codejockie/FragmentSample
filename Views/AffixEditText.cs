using Android.Content;
using Android.Graphics;
using Android.Util;
using AndroidX.AppCompat.Widget;

namespace FragmentSample.Views
{
    internal class AffixEditText : AppCompatEditText, IMarginable
    {
        private const float DEFAULT_PADDING = -1f;
        private float defaultLeftPadding = DEFAULT_PADDING;
        private string _prefix = "";

        public string Prefix
        {
            get => _prefix;
            set
            {
                _prefix = value;
                CalculatePrefix(_prefix);
                RequestLayout();
                Invalidate();
            }
        }

        public AffixEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            var it = context.ObtainStyledAttributes(attrs, Resource.Styleable.AffixEditText);
            _prefix = it.GetString(Resource.Styleable.AffixEditText_prefix) ?? string.Empty;
            it.Recycle();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            CalculatePrefix(_prefix);
        }

        private void CalculatePrefix(string prefix)
        {
            if (defaultLeftPadding == DEFAULT_PADDING)
            {
                var widths = new float[prefix.Length];
                Paint.GetTextWidths(prefix, widths);
                var textWidth = 0f;
                foreach (var width in widths)
                {
                    textWidth += width;
                }
                defaultLeftPadding = CompoundPaddingLeft;
                SetPadding(
                    (int)(textWidth + defaultLeftPadding),
                    PaddingTop, PaddingRight, PaddingBottom
                );
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawText(
                _prefix, defaultLeftPadding,
                GetLineBounds(0, null), Paint
            );
        }
    }
}