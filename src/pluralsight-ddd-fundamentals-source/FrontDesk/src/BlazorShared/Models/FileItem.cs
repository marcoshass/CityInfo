﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models
{
    public class FileItem
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public long Size { get; set; }
        public string Ext { get; set; }
        public string Type { get; set; }
        public string DataBase64 { get; set; }
    }
}
