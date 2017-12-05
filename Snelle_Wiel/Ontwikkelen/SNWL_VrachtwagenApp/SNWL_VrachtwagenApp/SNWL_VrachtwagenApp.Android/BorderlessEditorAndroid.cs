using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SNWL_VrachtwagenApp.Droid;
using SNWL_VrachtwagenApp;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEditor), typeof(BorderlessEditorAndroid))]
namespace SNWL_VrachtwagenApp.Droid
{
    public class BorderlessEditorAndroid : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                base.OnElementChanged(e);
                Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}