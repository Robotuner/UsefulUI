using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ESIXamarinLib.Behaviors
{
    public static class DigitsBeforeDecimalBehavior
    {
        #region AllowableDigitsBefore
        public static readonly BindableProperty AllowableDigitsBeforeProperty = BindableProperty.CreateAttached(
                propertyName: "AllowableDigitsBefore", returnType: typeof(int), declaringType: typeof(DigitsBeforeDecimalBehavior), defaultValue: 2,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnAllowableDigitsChanged);

        private static void OnAllowableDigitsChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        public static int GetAllowableDigitsBefore(BindableObject target)
        {
            object result = target.GetValue(AllowableDigitsBeforeProperty);
            return (int)result;
        }

        public static void SetAllowableDigitsBefore(BindableObject target, int value)
        {
            target.SetValue(AllowableDigitsBeforeProperty, value);
        }
        #endregion

        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(DigitsBeforeDecimalBehavior),
                false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = false;
            if (sender is Entry entry)
            {
                string pattern = string.Format("^\\d{{0,{0}}}(\\.\\d*)?$", GetAllowableDigitsBefore(entry));
                Regex regex = new Regex(pattern);
                Match match = regex.Match(args.NewTextValue.ToString());
                isValid = match.Success;
            }

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
