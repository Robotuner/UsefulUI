using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ESIXamarinLib.Behaviors
{

    public static class DigitsAfterDecimalBehavior
    {
        #region AllowableDigitsAfter
        public static readonly BindableProperty AllowableDigitsAfterProperty = BindableProperty.CreateAttached(
                propertyName: "AllowableDigitsAfter", returnType: typeof(int), declaringType: typeof(DigitsAfterDecimalBehavior), defaultValue: 2,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: null);

        public static int GetAllowableDigitsAfter(BindableObject target)
        {
            object result = target.GetValue(AllowableDigitsAfterProperty);
            return (int)result;
        }

        public static void SetAllowableDigitsAfter(BindableObject target, int value)
        {
            target.SetValue(AllowableDigitsAfterProperty, value);
        }
        #endregion

        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(DigitsAfterDecimalBehavior),
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
            // first make sure it is a double or decimal
            bool isValid = decimal.TryParse(args.NewTextValue, out decimal result);
            if (isValid)
            {
                int ndx = args.NewTextValue.IndexOf(".");
                if (ndx >= 0 && ndx < args.NewTextValue.Length - 1)
                {
                    if (sender is Entry entry)
                    {
                        string pattern = string.Format("^\\d*(\\.\\d{{0,{0}}})?$", GetAllowableDigitsAfter(entry));
                        Regex regex = new Regex(pattern);
                        Match match = regex.Match(args.NewTextValue.ToString());
                        isValid = match.Success;
                    }
                }
            }
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }

}
