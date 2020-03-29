using System;

namespace Renamer
{
	public class FileInformation
	{
		public string Path { get; }
		public DateTime CreationDateTime { get; }

		public FileInformation(string path, string extension, DateTime creationDateTime)
		{
			Path = path;
			CreationDateTime = creationDateTime;
		}
	}
}