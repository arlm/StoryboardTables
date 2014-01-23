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
	[Register ("CryptX")]
	partial class CryptX
	{
		[Outlet]
		MonoTouch.UIKit.UIButton dbOlusturX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel durumGostericiT { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ekleX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton listeleX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField passwordF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField usernameF { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (dbOlusturX != null) {
				dbOlusturX.Dispose ();
				dbOlusturX = null;
			}

			if (listeleX != null) {
				listeleX.Dispose ();
				listeleX = null;
			}

			if (durumGostericiT != null) {
				durumGostericiT.Dispose ();
				durumGostericiT = null;
			}

			if (passwordF != null) {
				passwordF.Dispose ();
				passwordF = null;
			}

			if (usernameF != null) {
				usernameF.Dispose ();
				usernameF = null;
			}

			if (ekleX != null) {
				ekleX.Dispose ();
				ekleX = null;
			}
		}
	}
}
