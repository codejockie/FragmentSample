using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace FragmentSample
{
    [Activity(Label = "CustomDialogFragment")]
    public class CustomDialogFragment : AndroidX.Fragment.App.DialogFragment
    {
        Button buttonCancel, buttonContinue;
        private readonly DateTime _expirationDate;
        private readonly DateTime _minRequiredDate;
        TextView expirationDateView, minRequiredDateView, daysShortView;

        // Flag to tell Android not to provide a title.
        private const int FEATURE_NO_TITLE = 1;
        public Action<Result> OnResult { get; set; }

        public CustomDialogFragment(DateTime expDate, DateTime minRequiredDate)
        {
            _expirationDate = expDate;
            _minRequiredDate = minRequiredDate;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.dialog_custom, container, false);

            buttonCancel = view.FindViewById<Button>(Resource.Id.buttonCancel);
            buttonContinue = view.FindViewById<Button>(Resource.Id.buttonContinue);
            expirationDateView = view.FindViewById<TextView>(Resource.Id.dialogExpirationDate);
            minRequiredDateView = view.FindViewById<TextView>(Resource.Id.dialogMinRequiredDate);
            daysShortView = view.FindViewById<TextView>(Resource.Id.dialogDaysShort);

            var daysShort = (_minRequiredDate - _expirationDate).Days;
            expirationDateView.Text = _expirationDate.ToString("MM/dd/yy");
            minRequiredDateView.Text = _minRequiredDate.ToString("MM/dd/yy");
            daysShortView.Text = daysShort.ToString();

            buttonCancel.Click += (s, e) =>
            {
                OnResult(new Result(false));
            };
            buttonContinue.Click += (s, e) =>
            {
                OnResult(new Result(true));
            };

            return view;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            Dialog dialog = base.OnCreateDialog(savedInstanceState);
            dialog.RequestWindowFeature(FEATURE_NO_TITLE);
            return dialog;
        }

        public record Result(bool Confirmed);
    }
}