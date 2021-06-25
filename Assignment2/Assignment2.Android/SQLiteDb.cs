
using Android.OS;
using Assignment2.Droid;
using System;
using Xamarin.Forms;
using System.IO;
using SQLite;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Assignment2.Droid
{
    public class SQLiteDb : ISOLiteDb
    {
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MAP526_A2");

			return new SQLiteAsyncConnection(path);
		}
	}
}
