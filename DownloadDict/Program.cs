using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DownloadDict
  {
  static class Program
    {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
      {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      Application.Run( new Form1() );
      }
    }
  }

/*
class ParallelHttpRequests
{
	static void Main()
	{
		var count = 300;
		var root = "http://files.kenegozi.com/temp/";

		ServicePointManager.DefaultConnectionLimit = 1000;

		var watch = Stopwatch.StartNew();
		for (var i = 0; i < count; ++i)
		{
			var client = new WebClient();
			var url = string.Format("{0}file{1:0000}.txt", root, i);
			client.DownloadString(url);
		}
		Console.WriteLine("for loop: " + watch.Elapsed);

		watch = Stopwatch.StartNew();
		Parallel.For(0, count, i =>
		{
			var client = new WebClient();
			var url = string.Format("{0}file{1:0000}.txt", root, i);
			client.DownloadString(url);
		});
		Console.WriteLine("parallel: " + watch.Elapsed);

		watch = Stopwatch.StartNew();
		var completed = new CountdownEvent(count);
		for (var i = 0; i < count; ++i)
		{
			var client = new WebClient();
			client.DownloadStringCompleted += (s, e) => completed.Signal();

			var url = string.Format("{0}file{1:0000}.txt", root, i);
			client.DownloadStringAsync(new Uri(url));
		}
		completed.Wait();
		Console.WriteLine("async: " + watch.Elapsed);
	}

}
*/