namespace ESIXamarinLib.Behaviors
{
    using System.Linq;
    using Xamarin.Forms;

    public class SelectOnEntryBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached(
                "AttachBehavior",
                typeof(bool),
                typeof(SelectOnEntryBehavior),
                false,
                propertyChanged: OnSelectOnEntryChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnSelectOnEntryChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.Behaviors.Add(new SelectOnEntryBehavior());
                entry.Focused += Entry_Focused;
            }
            else
            {
                entry.Focused -= Entry_Focused;
                var toRemove = entry.Behaviors.FirstOrDefault(b => b is SelectOnEntryBehavior);
                if (toRemove != null)
                {
                    entry.Behaviors.Remove(toRemove);
                }
            }
        }

        static void Entry_Focused(object sender, FocusEventArgs e)
        {
            // This doesnt work.  Use custom renderer instead
            // https://stackoverflow.com/questions/54033712/xamarin-forms-how-to-select-all-text-on-focus-with-entry?rq=1
            //
            if (sender is Entry entry)
            {
                if (!string.IsNullOrEmpty(entry.Text))
                {
                    entry.CursorPosition = 0; // entry.Text.Length;  
                    entry.SelectionLength = entry.Text.Length;
                }
            
            }
        }
    }


    /// iOS custom Renderer
    //public class SelectAllEntryRender : EntryRenderer
    //{
    //    protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    //    {
    //        base.OnElementChanged(e);
    //        if (Control != null)
    //        {
    //            var nativeTextField = (UITextField)Control;
    //            nativeTextField.EditDidBegin += (object sender, EventArgs eIos) =>
    //            {
    //                nativeTextField.PerformSelector(new Selector("selectAll"), null, 0.0f);
    //            };
    //        }
    //    }
    //}

    /// Android custom Renderer
    //public class CustomNumEntry : EntryRenderer
    //{
    //    public CustomNumEntry(Context context) : base(context)
    //    {
    //    }
    //    protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    //    {
    //        base.OnElementChanged(e);
    //        if (this.Control != null)
    //        {
    //            Control.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
    //            Control.TextAlignment = Android.Views.TextAlignment.Center;
    //        }
    //        if (e.OldElement == null)
    //        {
    //            var nativeEditText = (global::Android.Widget.EditText)Control;
    //            nativeEditText.SetSelectAllOnFocus(true);
    //        }

    //    }
    //}
}
