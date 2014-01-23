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
	[Register ("HelpX")]
	partial class HelpX
	{
		[Outlet]
		MonoTouch.UIKit.UITextView mevcutYazi { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField okunacakBolge { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider sesBari { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton StartRecg { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (StartRecg != null) {
				StartRecg.Dispose ();
				StartRecg = null;
			}

			if (okunacakBolge != null) {
				okunacakBolge.Dispose ();
				okunacakBolge = null;
			}

			if (mevcutYazi != null) {
				mevcutYazi.Dispose ();
				mevcutYazi = null;
			}

			if (sesBari != null) {
				sesBari.Dispose ();
				sesBari = null;
			}
		}
	}
}
