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
	[Register ("iOSViewController")]
	partial class iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton BetterAsyncButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView DownloadedImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton getXMLX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton kayitOldumu { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ResultLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView ResultTextView { get; set; }

		[Action ("UIButton14_TouchUpInside:")]
		partial void UIButton14_TouchUpInside (MonoTouch.Foundation.NSObject sender);

		[Action ("UIButton9_TouchUpInside:")]
		partial void UIButton9_TouchUpInside (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (getXMLX != null) {
				getXMLX.Dispose ();
				getXMLX = null;
			}

			if (BetterAsyncButton != null) {
				BetterAsyncButton.Dispose ();
				BetterAsyncButton = null;
			}

			if (DownloadedImageView != null) {
				DownloadedImageView.Dispose ();
				DownloadedImageView = null;
			}

			if (GetButton != null) {
				GetButton.Dispose ();
				GetButton = null;
			}

			if (kayitOldumu != null) {
				kayitOldumu.Dispose ();
				kayitOldumu = null;
			}

			if (ResultLabel != null) {
				ResultLabel.Dispose ();
				ResultLabel = null;
			}

			if (ResultTextView != null) {
				ResultTextView.Dispose ();
				ResultTextView = null;
			}
		}
	}
}
