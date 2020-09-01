using UsefulUI.iOS.Renderers;
using UsefulUI.Models;
using ObjCRuntime;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SelectAllEntry), typeof(SelectAllEntryRenderer))]
namespace UsefulUI.iOS.Renderers
{
    public class SelectAllEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var nativeTextField = (UITextField)Control;
                nativeTextField.EditingDidBegin += (object sender, EventArgs eIos) =>
                {
                    nativeTextField.PerformSelector(new Selector("selectAll"), null, 0.0f);
                };
            }
        }
    }
}