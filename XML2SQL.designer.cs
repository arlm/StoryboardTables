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
	[Register ("XML2SQL")]
	partial class XML2SQL
	{
		[Outlet]
		MonoTouch.UIKit.UILabel durumT { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton kaydetX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton listeleX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField passF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField subeF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField userF { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (durumT != null) {
				durumT.Dispose ();
				durumT = null;
			}

			if (kaydetX != null) {
				kaydetX.Dispose ();
				kaydetX = null;
			}

			if (listeleX != null) {
				listeleX.Dispose ();
				listeleX = null;
			}

			if (passF != null) {
				passF.Dispose ();
				passF = null;
			}

			if (subeF != null) {
				subeF.Dispose ();
				subeF = null;
			}

			if (userF != null) {
				userF.Dispose ();
				userF = null;
			}
		}
	}
}
