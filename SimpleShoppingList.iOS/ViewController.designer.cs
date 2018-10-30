// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SimpleShoppingList.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton button_getlist1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView textview { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (button_getlist1 != null) {
                button_getlist1.Dispose ();
                button_getlist1 = null;
            }

            if (textview != null) {
                textview.Dispose ();
                textview = null;
            }
        }
    }
}