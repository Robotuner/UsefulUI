using Android.Content;
using UsefulUI.Models;
using UsefulUI.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SelectAllEntry), typeof(SelectAllEntryRenderer))]
namespace UsefulUI.Renderers
{
    public class SelectAllEntryRenderer : EntryRenderer
    {
        public SelectAllEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            //if (this.Control != null)
            //{
            //    Control.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
            //    Control.TextAlignment = Android.Views.TextAlignment.TextStart;
            //}
            if (e.OldElement == null)
            {
                var nativeEditText = (global::Android.Widget.EditText)Control;
                nativeEditText.SetSelectAllOnFocus(true);
            }

        }
    }
}