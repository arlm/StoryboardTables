// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace StoryboardTables
{
	[Register ("testxc")]
	partial class testxc
	{
		[Outlet]
		MonoTouch.UIKit.UIButton baslat { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView bilgiField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel durumF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem getListTX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView resimField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (baslat != null) {
				baslat.Dispose ();
				baslat = null;
			}

			if (bilgiField != null) {
				bilgiField.Dispose ();
				bilgiField = null;
			}

			if (getListTX != null) {
				getListTX.Dispose ();
				getListTX = null;
			}

			if (resimField != null) {
				resimField.Dispose ();
				resimField = null;
			}

			if (durumF != null) {
				durumF.Dispose ();
				durumF = null;
			}
		}
	}
}
