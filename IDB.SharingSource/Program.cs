// //HalukYILMAZ IDB Genel Müdürlüğü İçin Hazırlamıştır
using System;
using PushSharp;
using PushSharp.Apple;
using System.IO;

namespace IDB.SharingSource
{
   class MainClass
   {
      public static void Main(string[] args)
      {
         var pushBroker = new PushBroker();


         var cert = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.
            BaseDirectory, "idbCert.p12"));



         var appleSettings = new ApplePushChannelSettings(cert, "idbmobile");



         var n = new AppleNotification().ForDeviceToken("7ced312b754878f6971c1169f02fcec3e33bc6b92ccade4921b54961fa03f93b")
            .WithAlert("IDB Push Test").WithBadge(3);

         pushBroker.RegisterAppleService(appleSettings);


         pushBroker.QueueNotification(n);

         pushBroker.StopAllServices();      
      }
   }
}
