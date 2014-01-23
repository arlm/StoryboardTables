//using System;
//using System.Drawing;
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
//using System.Collections.Generic;
//using System.IO;
//using Mono.Data.Sqlite;
//
//namespace MonoTouchData_Hal
//{
//   public partial class KayitEkle : UIViewController
//   {
//      public KayitEkle() : base("KayitEkle", null)
//      {
//      }
//      private string selectedColor;
//
//      public override void DidReceiveMemoryWarning()
//      {
//         // Releases the view if it doesn't have a superview.
//         base.DidReceiveMemoryWarning();
//         
//         // Release any cached data, images, etc that aren't in use.
//      }
//
//
//      private readonly IList<string> colors = new List<string>
//      {
//
//         "Y Şube",
//         "U Şube",
//         "Z Şube",
//         "Genel Müdürlük",
//         "Merkez"
//      };
//
//      private readonly IList<string> gorevler = new List<string>
//      {
//
//         "Müdür",
//         "Amir",
//         "Memur",
//         "Sözleşmeli Memur",
//         "Mühendis"
//      };
//
//
//      public override void ViewDidLoad ()
//      {
//         base.ViewDidLoad ();
//
//         // Perform any additional setup after loading the view, typically from a nib.
//         this.SetupPicker();
//         SetupPickerX();
//
//
//         kaydetX.TouchUpInside+= delegate
//         {
//            if(kullaniciAdi.Text!=null && parola.Text!= null && departmanX.Text!= null && gorevX.Text!= null && telefon.Text!= null && email.Text!= null && isim.Text!= null)
//            
//            {   string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PersonelDBXX.db3");
//            
//               InsertData(SQLitePath);
//            }
//
//            else
//
//               new UIAlertView("boş yer var girilecek", "ddd", null, "OK", null).Show();
//
//
//         };
//
//
//            }
//
//      public override void ViewDidUnload ()
//      {
//         base.ViewDidUnload ();
//
//         // Clear any references to subviews of the main view in order tæo
//         // allow the Garbage Collector to collect them sooner.
//         //
//         // e.g. myOutlet.Dispose (); myOutlet = null;
//
//         ReleaseDesignerOutlets ();
//      }
//
//      public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
//      {
//         // Return true for supported orientations
//         return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
//      }
//
//      private void SetupPicker()
//      {
//         // Setup the picker and model
//         PickerModel model = new PickerModel(this.colors);
//         model.PickerChanged += (sender, e) => {
//            this.departmanX.Text = e.SelectedValue;
//         };
//
//         UIPickerView picker = new UIPickerView();
//         picker.ShowSelectionIndicator = true;
//         picker.Model = model;
//
//         // Setup the toolbar
//         UIToolbar toolbar = new UIToolbar();
//         toolbar.BarStyle = UIBarStyle.Black;
//         toolbar.Translucent = true;
//         toolbar.SizeToFit();
//
//
//         // Create a 'done' button for the toolbar and add it to the toolbar
//         UIBarButtonItem doneButton = new UIBarButtonItem("Tamam", UIBarButtonItemStyle.Done,
//            (s, e) => {
//               this.departmanX.Text += selectedColor;
//               this.departmanX.ResignFirstResponder();
//            });
//         toolbar.SetItems(new UIBarButtonItem[]{doneButton}, true);
//
//         // Tell the textbox to use the picker for input
//         this.departmanX.InputView = picker;
//
//         // Display the toolbar over the pickers
//         this.departmanX.InputAccessoryView = toolbar;
//      }
//
//
//      private void SetupPickerX()
//      {
//         // Setup the picker and model
//         PickerModel model = new PickerModel(this.gorevler);
//         model.PickerChanged += (sender, e) => {
//            this.gorevX.Text = e.SelectedValue;
//         };
//
//         UIPickerView picker = new UIPickerView();
//         picker.ShowSelectionIndicator = true;
//         picker.Model = model;
//
//         // Setup the toolbar
//         UIToolbar toolbar = new UIToolbar();
//         toolbar.BarStyle = UIBarStyle.Black;
//         toolbar.Translucent = true;
//         toolbar.SizeToFit();
//
//
//         // Create a 'done' button for the toolbar and add it to the toolbar
//         UIBarButtonItem doneButton = new UIBarButtonItem("Tamam", UIBarButtonItemStyle.Done,
//            (s, e) => {
//               this.gorevX.Text += selectedColor;
//               this.gorevX.ResignFirstResponder();
//            });
//         toolbar.SetItems(new UIBarButtonItem[]{doneButton}, true);
//
//         // Tell the textbox to use the picker for input
//         this.gorevX.InputView = picker;
//
//         // Display the toolbar over the pickers
//         this.gorevX.InputAccessoryView = toolbar;
//      }
//
//
//      private void InsertData (string databaseFile)
//      {
//
//         try
//         {
//
//            if (!File.Exists (databaseFile))
//            {
//
//               this.durumT.Text = "Database file does not exist. Tap the appropriate button to create it.";
//               return;
//
//            }
//            //end if
//
//            // Connect to database
//            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile)))
//            {
//
//               sqlCon.Open ();
//
//               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
//               {
//
//                  sqlCom.CommandText = "INSERT INTO Personel (UserName, Password,Bolum,Gorev,Isim,Telefon,Email) VALUES (@username, @password,@bolum,@gorev,@isim,@telefon,@email)";
//                  sqlCom.Parameters.Add (new SqliteParameter ("@username",kullaniciAdi.Text ));
//                  sqlCom.Parameters.Add (new SqliteParameter ("@password", parola.Text));
//                  sqlCom.Parameters.Add (new SqliteParameter ("@bolum", departmanX.Text));
//                  sqlCom.Parameters.Add (new SqliteParameter ("@gorev", gorevX.Text));
//                  sqlCom.Parameters.Add (new SqliteParameter ("@isim", isim.Text));
//                  sqlCom.Parameters.Add (new SqliteParameter ("@telefon", telefon.Text));
//                  sqlCom.Parameters.Add (new SqliteParameter ("@email", email.Text));
//
//
//
//
//
//                  sqlCom.ExecuteNonQuery ();
//
//               }
//               //end using sqlCom
//
//               sqlCon.Close ();
//
//            }
//            //end using sqlCon
//
//            this.durumT.Text = "Veri Girildi.";
//
//         } catch (Exception ex)
//         {
//
//            this.durumT.Text = String.Format ("Sqlite hatası: {0}", ex.Message);
//
//         }//end try catch
//
//      }//end void InsertData
//
//
//
//   }
//
//
//}
//
