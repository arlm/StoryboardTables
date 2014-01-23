using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;
using Mono.Data.Sqlite;

namespace MonoTouchData_Hal
{
   public partial class MainPersonel : UIViewController
   {

      void SqlCheck(string databasef)
      {
         if (!File.Exists(databasef))
         {
            durumT.Text = "DB Mevcut Değil";
         }
         else
            durumT.Text = "DB Mevcut";
      }


      private void CreateSQLiteDatabase (string databaseFile)
      {

         try
         {

            // Check if database already exists
            if (!File.Exists (databaseFile))
            {

               // Create the database
               SqliteConnection.CreateFile (databaseFile);

               // Connect to the database
               using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0};", databaseFile)))
               {
                  sqlCon.Open ();

                  // Create a table
                  using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
                  {
                 
                     sqlCom.CommandText="CREATE TABLE Personel (ID INTEGER PRIMARY KEY, UserName VARCHAR(20), Password VARCHAR (20), Bolum VARCHAR(20), Gorev VARCHAR(20), Isim VARCHAR(20), Telefon VARCHAR(20), Email VARCHAR(20))";

                      sqlCom.ExecuteNonQuery ();

                     Console.WriteLine(sqlCom.ExecuteNonQuery());
                  }
                  //end using sqlCom

                  sqlCon.Close ();

               }
               //end using sqlCon

               this.durumT.Text = "oluştu";


            } else
            {

               this.durumT.Text = "Zaten var";

            }//end if else

         } catch (Exception ex)
         {

            this.durumT.Text = String.Format ("Sqlite error: {0}", ex.Message);

         }//end try catch


      }//end void CreateSQLiteDatabase




      public MainPersonel() : base("MainPersonel", null)
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

         kontrolX.TouchUpInside+= delegate
         {
            SqlCheck(SQLitePath);
         };
         olusturX.TouchUpInside+= delegate
         {
         CreateSQLiteDatabase(SQLitePath) ;

         };




         
         // Perform any additional setup after loading the view, typically from a nib.
      }
   }
}

