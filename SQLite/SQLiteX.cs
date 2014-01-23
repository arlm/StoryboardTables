using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;
using Mono.Data.Sqlite;
using System.IO;

namespace MonoTouchData_Hal
{

   class CreateSQLiteAppViewController
   {

   }


 




   public partial class SQLiteX : UIViewController
   {
      public SQLiteX() : base("SQLiteX", null)
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

         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDB.db3");

         olusturX.TouchUpInside+= delegate
         {
            CreateSQLiteDatabase(SQLitePath);

         };
         yazdirX.TouchUpInside+= delegate
         {
            InsertData(SQLitePath);
         };
         guncelleX.TouchUpInside+= delegate
         {
            UpdateData(SQLitePath);
         };
         listeleX.TouchUpInside+= delegate
         {
            SelectData(SQLitePath);
         };
         
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
                     sqlCom.CommandText = "CREATE TABLE Customers (ID INTEGER PRIMARY KEY, FirstName VARCHAR(20), LastName VARCHAR(20))";
                     //veri Ekleme
                          //Update
                     //   sqlCom.CommandText = "UPDATE Customers SET FirstName= 'Haluk' WHERE LastName = @lastName";
                     // sqlCom.Parameters.Add(new SqliteParameter("@lastName","Haluky"));



                     sqlCom.ExecuteNonQuery ();

                     Console.WriteLine(sqlCom.ExecuteNonQuery());
                  }
                  //end using sqlCom

                  sqlCon.Close ();

               }
               //end using sqlCon

               this.bilgiX.Text = "Database created!";


            } else
            {

               this.bilgiX.Text = "Database already exists!";

            }//end if else

         } catch (Exception ex)
         {

            this.bilgiX.Text = String.Format ("Sqlite error: {0}", ex.Message);

         }//end try catch


      }//end void CreateSQLiteDatabase
 


      private void deleteSqLite (string databaseFile)
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
                     sqlCom.CommandText = "CREATE TABLE Customers (ID INTEGER PRIMARY KEY, FirstName VARCHAR(20), LastName VARCHAR(20))";
                     //veri Ekleme
                     //Update
                     //   sqlCom.CommandText = "UPDATE Customers SET FirstName= 'Haluk' WHERE LastName = @lastName";
                     // sqlCom.Parameters.Add(new SqliteParameter("@lastName","Haluky"));



                     sqlCom.ExecuteNonQuery ();

                     Console.WriteLine(sqlCom.ExecuteNonQuery());
                  }
                  //end using sqlCom

                  sqlCon.Close ();

               }
               //end using sqlCon

               this.bilgiX.Text = "Database created!";


            } else
            {

               this.bilgiX.Text = "Database already exists!";

            }//end if else

         } catch (Exception ex)
         {

            this.bilgiX.Text = String.Format ("Sqlite error: {0}", ex.Message);

         }//end try catch


      }//end void CreateSQLiteDatabase




      private void InsertData (string databaseFile)
      {

         try
         {

            if (!File.Exists (databaseFile))
            {

               this.bilgiX.Text = "Database file does not exist. Tap the appropriate button to create it.";
               return;

            }
            //end if

            // Connect to database
            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile)))
            {

               sqlCon.Open ();

               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
               {

                  sqlCom.CommandText = "INSERT INTO Customers (FirstName, LastName) VALUES (@firstName, @lastName)";
                  sqlCom.Parameters.Add (new SqliteParameter ("@firstName", "Haluk"));
                  sqlCom.Parameters.Add (new SqliteParameter ("@lastName", "YILMAZ"));

                  sqlCom.ExecuteNonQuery ();

               }
               //end using sqlCom

               sqlCon.Close ();

            }
            //end using sqlCon

            this.bilgiX.Text = "Customer data inserted.";

         } catch (Exception ex)
         {

            this.bilgiX.Text = String.Format ("Sqlite error: {0}", ex.Message);

         }//end try catch

      }//end void InsertData




      private void UpdateData (string databaseFile)
      {

         try
         {

            if (!File.Exists (databaseFile))
            {

               this.bilgiX.Text = "Database file does not exist. Tap the appropriate button to create it.";
               return;

            }
            //end if

            // Connect to database
            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile))) 
            {

               sqlCon.Open ();

               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon)) 
               {

                  sqlCom.CommandText = "UPDATE Customers SET FirstName = 'Haluk' WHERE LastName = @lastName";
                  sqlCom.Parameters.Add (new SqliteParameter ("@lastName", "Smith"));

                  sqlCom.ExecuteNonQuery ();

               }
               //end using sqlCom

               sqlCon.Close ();

            }
            //end using sqlCon

            this.bilgiX.Text = "Customer data updated.";

         } catch (Exception ex) 
         {

            this.bilgiX.Text = String.Format ("Sqlite error: {0}", ex.Message);

         }
         //end try catch


      }//end void UpdateData




      public void SelectData (string databaseFile)
      {

         try 
         {

            if (!File.Exists (databaseFile)) 
            {

               this.bilgiX.Text = "Database file does not exist. Tap the appropriate button to create it.";
               return;

            }
            //end if

            // Connect to database
            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile))) 
            {

               sqlCon.Open ();

               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon)) 
               {

                  sqlCom.CommandText = "SELECT * FROM Customers WHERE LastName = @lastName";
                  sqlCom.Parameters.Add (new SqliteParameter ("@lastName", "YILMAZ"));

                  // Execute the SELECT statement and retrieve the data
                  using (SqliteDataReader dbReader = sqlCom.ExecuteReader ())
                  {

                     if (dbReader.HasRows)
                     {

                        // Advance through each row
                        while (dbReader.Read ())
                        {

                           this.birinciX.Text += String.Format ("ID: {0}\n", Convert.ToString (dbReader["ID"]));
                           this.birinciX.Text += String.Format ("First name: {0}\n", Convert.ToString (dbReader["FirstName"]));
                           this.ikinciX.Text += String.Format ("Last name: {0}\n", Convert.ToString (dbReader["LastName"]));

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

            this.bilgiX.Text += "Customer data retrieved.\n";

         } catch (Exception ex) 
         {

            this.bilgiX.Text = String.Format ("Sqlite error: {0}", ex.Message);

         }
         //end try catch

      }//end void SelectData
   }
}
