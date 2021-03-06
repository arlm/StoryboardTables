// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using System.Security.Cryptography;

namespace StoryboardTables
{
   public class PickerChangedEventArgs : EventArgs
   {
      public string SelectedValue {get; set;}
   }

   public class PickerModel : UIPickerViewModel
   {
      private readonly IList<string> values;

      public event EventHandler<PickerChangedEventArgs> PickerChanged;

      public PickerModel(IList<string> values)
      {
         this.values = values;
      }

      public override int GetComponentCount (UIPickerView picker)
      {
         return 1;
      }

      public override int GetRowsInComponent (UIPickerView picker, int component)
      {
         return values.Count;
      }

      public override string GetTitle (UIPickerView picker, int row, int component)
      {
         return values[row];
      }

      public override float GetRowHeight (UIPickerView picker, int component)
      {
         return 40f;
      }

      public override void Selected (UIPickerView picker, int row, int component)
      {
         if (this.PickerChanged != null)
         {
            this.PickerChanged(this, new PickerChangedEventArgs{SelectedValue = values[row]});
         }
      }
   }

  

	public partial class MainX : UIViewController
	{


   private readonly IList<string> colors = new List<string>
   {

         "Sistem",
         "Personel Girişi",
         "Normal Veri Erişimi",
         "Kriptolanmış Veri",
         "Veri İndirme",
         "Kayıt Modülü",
         "Güvenlik Kontrolü",
         "Döküman Gösterimi",
         "GPS Kontrolü"
   };

   private string selectedColor;


      public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
      {
         if(segue.Identifier=="SegueGPS")

         {}



      }
		public MainX (IntPtr handle) : base (handle)
		{
      }


      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
         anamenulogosu.Image = UIImage.FromFile("2.jpg");

         // Perform any additional setup after loading the view, typically from a nib.
         this.SetupPicker();

         modulSec.Text = "Seçim Gerçekleştirmek için buraya dokunun";

         Bismillahirahmanirrahim.TouchUpInside+= delegate
         {
            if (modulSec.Text=="GPS Kontrolü")
               this.PerformSegue("SegueGPS",this);
            else if (modulSec.Text=="Normal Veri Erişimi")
               this.PerformSegue("segueNormalData",this);
            else if (modulSec.Text=="Personel Girişi")
               this.PerformSegue("SegueGiris",this);
            else if(modulSec.Text=="Kriptolanmış Veri")
               this.PerformSegue("segueCrypt",this);
            else if (modulSec.Text=="Döküman Gösterimi")
               this.PerformSegue("dokGoster",this);
         };



         idbHelp.Clicked+= delegate
         {
            new UIAlertView("Hoşgeldiniz","Lütfen Yardım Almak için İletişim Modülünü kullanın",null,"OK",null).Show();
         };


      }
      [Obsolete ("Deprecated in iOS 6.0")]
      public override void ViewDidUnload()
      {
         base.ViewDidUnload();
         ReleaseDesignerOutlets ();

      }

      public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
      {
         // Return true for supported orientations
         return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
      }

      private void SetupPicker()
      {
         // Setup the picker and model
         PickerModel model = new PickerModel(this.colors);
         model.PickerChanged += (sender, e) => {
            this.selectedColor = e.SelectedValue;
         };

         UIPickerView picker = new UIPickerView();
         picker.ShowSelectionIndicator = true;
         picker.Model = model;
         http://www.windowsphone.com/tr-tr/store/app/anl%C4%B1k-hava-durumu/b26e9109-01c5-4e2d-9914-7ee19d2a0aa0?signin=truehttp://www.windowsphone.com/tr-tr/store/app/anl%C4%B1k-hava-durumu/b26e9109-01c5-4e2d-9914-7ee19d2a0aa0?signin=true
         // Setup the toolbar
         UIToolbar toolbar = new UIToolbar();
         toolbar.BarStyle = UIBarStyle.Black;
         toolbar.Translucent = true;
         toolbar.SizeToFit();

         // Create a 'done' button for the toolbar and add it to the toolbar
         UIBarButtonItem doneButton = new UIBarButtonItem("Tamam", UIBarButtonItemStyle.Done,
            (s, e) => {
               this.modulSec.Text = selectedColor;
               this.modulSec.ResignFirstResponder();
            });
         toolbar.SetItems(new UIBarButtonItem[]{doneButton}, true);

         // Tell the textbox to use the picker for input
         this.modulSec.InputView = picker;

         // Display the toolbar over the pickers
         this.modulSec.InputAccessoryView = toolbar;
      }
   }
}