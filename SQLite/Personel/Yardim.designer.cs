// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MonoTouchData_Hal
{
	[Register ("Yardim")]
	partial class Yardim
	{
		[Outlet]
		MonoTouch.UIKit.UITextField aText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField bText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton gonderX { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (aText != null) {
				aText.Dispose ();
				aText = null;
			}

			if (bText != null) {
				bText.Dispose ();
				bText = null;
			}

			if (gonderX != null) {
				gonderX.Dispose ();
				gonderX = null;
			}
		}
	}
}
