using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ESIXamarinLib.Behaviors
{
    public static class RegexValidatorBehavior
    {
        #region Pattern
        public static readonly BindableProperty PatternProperty = BindableProperty.CreateAttached(
                propertyName: "Pattern", returnType: typeof(string), declaringType: typeof(RegexValidatorBehavior), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: null);

        public static string GetPattern(BindableObject target)
        {
            object result = target.GetValue(PatternProperty);
            return (string)result;
        }

        public static void SetPattern(BindableObject target, string value)
        {
            target.SetValue(PatternProperty, value);
        }
        #endregion
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(RegexValidatorBehavior),
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
                Regex regex = new Regex(GetPattern(entry));
                Match match = regex.Match(args.NewTextValue.ToString());
                isValid = match.Success;
            }

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
