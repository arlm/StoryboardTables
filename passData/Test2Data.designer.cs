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
	[Register ("Test2Data")]
	partial class Test2Data
	{
		[Outlet]
		MonoTouch.UIKit.UITextField bilgilendiriciT { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton gostericiX { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (gostericiX != null) {
				gostericiX.Dispose ();
				gostericiX = null;
			}

			if (bilgilendiriciT != null) {
				bilgilendiriciT.Dispose ();
				bilgilendiriciT = null;
			}
		}
	}
}
