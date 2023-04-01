using System;


namespace Hw_AsyncCarPlates
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Plates plates = new Plates();
			plates.DownloadJpgsParallel();
			Console.WriteLine(plates);
			Console.ReadKey();
		}
	}
}
