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
	[Register ("WCFData")]
	partial class WCFData
	{
		[Outlet]
		MonoTouch.UIKit.UIButton gosterX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField userF { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (gosterX != null) {
				gosterX.Dispose ();
				gosterX = null;
			}

			if (userF != null) {
				userF.Dispose ();
				userF = null;
			}
		}
	}
}
