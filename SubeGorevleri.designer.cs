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
	[Register ("SubeGorevleri")]
	partial class SubeGorevleri
	{
		[Outlet]
		MonoTouch.UIKit.UITextField bilgiF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton gosterX { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (bilgiF != null) {
				bilgiF.Dispose ();
				bilgiF = null;
			}

			if (gosterX != null) {
				gosterX.Dispose ();
				gosterX = null;
			}
		}
	}
}
