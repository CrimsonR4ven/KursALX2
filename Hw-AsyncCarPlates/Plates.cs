using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hw_AsyncCarPlates
{
	public class Plates
	{
		public string[] PlateFiles;
		public int DownloadedData { get; private set; }

		public Plates() 
		{ 
			DownloadedData = 0;
			GetFilesList();
		}

		public void GetFilesList()
		{
			WebClient wb = new WebClient();
			byte[] plateBytes = wb.DownloadData("http://51.91.120.89/TABLICE/");
			DownloadedData += plateBytes.Length;
			PlateFiles = Encoding.Default.GetString(plateBytes).Split('\n');
			Console.WriteLine($"{DownloadedData}B");
		}
		public void DownloadJpgsParallel()
		{
			Parallel.For(0, PlateFiles.Length - 1, i =>
			{
				WebClient wb = new WebClient();
				byte[] temp = wb.DownloadData("http://51.91.120.89/TABLICE/" + PlateFiles[i]);
				DownloadedData += temp.Length;
				Console.WriteLine($"{DownloadedData}B , {PlateFiles[i]}");
				File.WriteAllBytes(PlateFiles[i].Split('.')[0] + ".jpg", temp);
			});
		}
		public override string ToString()
		{
			if ( DownloadedData == 0)
			{
				return "Downloaded data - none";
			}
			else if (DownloadedData < 1024)
			{
				return $"Downloaded data - {DownloadedData}B";
			}
			else if (DownloadedData < 1048576)
			{
				return $"Downloaded data - {DownloadedData / 1024}KB {DownloadedData % 1024}B";
			}
			else 
			{
				return $"Downloaded data - {DownloadedData / 1048576}MB {(DownloadedData % 1048576)/1024}KB {(DownloadedData % 1048576) % 1024}B";
			}
		}
	}
}
