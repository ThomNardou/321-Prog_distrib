using ntp;
using System;
using System.Net;
using System.Net.Sockets;

string ntpServer = "0.ch.pool.ntp.org";

byte[] ntpData = new byte[48];
ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

IPEndPoint ntpEndPoint = new IPEndPoint(Dns.GetHostAddresses(ntpServer)[0], 123);

UdpClient ntpClient = new UdpClient();

ntpClient.Connect(ntpEndPoint);

ntpClient.Send(ntpData, ntpData.Length);

ntpData = ntpClient.Receive(ref ntpEndPoint);

DateTime ntpTime = NtpPacket.ToDateTime(ntpData);

Console.WriteLine("- " + ntpTime.ToString("dddd, dd MMMM yyyy"));
Console.WriteLine("- " + ntpTime.ToString("dd.MM.yyyy HH:mm:ss"));
Console.WriteLine("- " + ntpTime.ToString("dd.MM.yyyy"));












Console.WriteLine("\n\n=========================================================================================================\n\n");

DateTime nowLocal = DateTime.Now;
double difference = (nowLocal - ntpTime).TotalSeconds;
Console.WriteLine("La différence est de : " + difference.ToString() + " secondes");

Console.WriteLine("\n\n=========================================================================================================\n\n");

DateTime realTime = ntpTime.AddSeconds(difference);
Console.WriteLine("Vraie heure : " + realTime.ToString());

Console.WriteLine("\n\n=========================================================================================================\n\n");

DateTime utcTime = realTime.ToUniversalTime();
Console.WriteLine("Heure en UTC : " + utcTime.ToString());

Console.WriteLine("\n\n=========================================================================================================\n\n");

DateTime localTime = realTime.ToLocalTime();
Console.WriteLine("Heure en local : " + utcTime.ToString());

Console.WriteLine("\n\n=========================================================================================================\n\n");

DateTime gmtTime = realTime.ToUniversalTime().AddHours(-1);
Console.WriteLine("Heure en GMT : " + gmtTime.ToString());

Console.WriteLine("\n\n=========================================================================================================\n\n");

DateTime gmtToLocalTime = realTime.ToUniversalTime().AddHours(-1).ToLocalTime();
Console.WriteLine("Heure en GMT to Local : " + gmtToLocalTime.ToString());

Console.WriteLine("\n\n=========================================================================================================\n\n");
ntpClient.Close();
