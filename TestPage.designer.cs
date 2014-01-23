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
	[Register ("TestPage")]
	partial class TestPage
	{
		[Outlet]
		MonoTouch.UIKit.UITextField girisXX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton gondericiXX { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (girisXX != null) {
				girisXX.Dispose ();
				girisXX = null;
			}

			if (gondericiXX != null) {
				gondericiXX.Dispose ();
				gondericiXX = null;
			}
		}
	}
}
