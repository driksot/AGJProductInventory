﻿namespace AGJProductInventory.API.Models
{
    public class SaveFile
    {
        public List<FileData> Files { get; set; }
    }

    public class FileData
    {
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
    }
}
