﻿namespace ESIXamarinLib.Behaviors
{
    using System.Linq;
    using Xamarin.Forms;

    public class DecimalValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached(
                "AttachBehavior",
                typeof(bool),
                typeof(DecimalValidationBehavior),
                false,
                propertyChanged: OnAttachBehaviorChanged);

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
                entry.Behaviors.Add(new DecimalValidationBehavior());
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
                var toRemove = entry.Behaviors.FirstOrDefault(b => b is DecimalValidationBehavior);
                if (toRemove != null)
                {
                    entry.Behaviors.Remove(toRemove);
                }                
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            decimal result;
            bool isValid = decimal.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
