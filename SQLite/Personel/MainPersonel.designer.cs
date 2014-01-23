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
	[Register ("MainPersonel")]
	partial class MainPersonel
	{
		[Outlet]
		MonoTouch.UIKit.UILabel durumT { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton kontrolX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton olusturX { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (kontrolX != null) {
				kontrolX.Dispose ();
				kontrolX = null;
			}

			if (olusturX != null) {
				olusturX.Dispose ();
				olusturX = null;
			}

			if (durumT != null) {
				durumT.Dispose ();
				durumT = null;
			}
		}
	}
}
