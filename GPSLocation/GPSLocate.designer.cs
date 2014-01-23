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
	partial class GPSLocate
	{
		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem checkIt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblAltitude { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblCourse { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblDistanceToParis { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblLatitude { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblLongitude { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblMagneticHeading { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblSpeed { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LblTrueHeading { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (checkIt != null) {
				checkIt.Dispose ();
				checkIt = null;
			}

			if (LblAltitude != null) {
				LblAltitude.Dispose ();
				LblAltitude = null;
			}

			if (LblCourse != null) {
				LblCourse.Dispose ();
				LblCourse = null;
			}

			if (LblDistanceToParis != null) {
				LblDistanceToParis.Dispose ();
				LblDistanceToParis = null;
			}

			if (LblLatitude != null) {
				LblLatitude.Dispose ();
				LblLatitude = null;
			}

			if (LblLongitude != null) {
				LblLongitude.Dispose ();
				LblLongitude = null;
			}

			if (LblMagneticHeading != null) {
				LblMagneticHeading.Dispose ();
				LblMagneticHeading = null;
			}

			if (LblSpeed != null) {
				LblSpeed.Dispose ();
				LblSpeed = null;
			}

			if (LblTrueHeading != null) {
				LblTrueHeading.Dispose ();
				LblTrueHeading = null;
			}
		}
	}
}
