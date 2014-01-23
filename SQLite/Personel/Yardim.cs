using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Mono.Data.Sqlite;
using System.IO;

namespace MonoTouchData_Hal
{
   public partial class Yardim : UIViewController
   {
      public Yardim() : base("Yardim", null)
      {
      }

      public override void DidReceiveMemoryWarning()
      {
         // Releases the view if it doesn't have a superview.
         base.DidReceiveMemoryWarning();
         
         // Release any cached data, images, etc that aren't in use.
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PersonelDBXX.db3");

         gonderX.TouchUpInside+= delegate(object sender, EventArgs e)
         {
            SelectData(SQLitePath);
         };
         
         // Perform any additional setup after loading the view, typically from a nib.
      }


      public void SelectData (string databaseFile)
      {

         try 
         {

            if (!File.Exists (databaseFile)) 
            {

               this.aText.Text = "Database file does not exist. Tap the appropriate button to create it.";
               return;

            }
            //end if

            // Connect to database
            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile))) 
            {

               sqlCon.Open ();

               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon)) 
               {

                  sqlCom.CommandText = "SELECT * FROM Personel";

                  // Execute the SELECT statement and retrieve the data
                  using (SqliteDataReader dbReader = sqlCom.ExecuteReader ())
                  {

                     if (dbReader.HasRows)
                     {

                        // Advance through each row
                        while (dbReader.Read ())
                        {

                           this.aText.Text += String.Format ("ID: {0}\n", Convert.ToString (dbReader["ID"]));
                           this.aText.Text += String.Format ("First name: {0}\n", Convert.ToString (dbReader["UserName"]));
                           this.bText.Text += String.Format ("Last name: {0}\n", Convert.ToString (dbReader["Password"]));

                        }
                        //end while

                     }
                     //end if

                  }//end using dbReader

               }
               //end using sqlCom

               sqlCon.Close ();

            }
            //end using sqlCon


         } catch (Exception ex)
         {


         }
      }
   }
}

