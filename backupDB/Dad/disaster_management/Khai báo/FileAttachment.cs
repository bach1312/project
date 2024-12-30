using System;
using System.Collections.Generic;

namespace disaster_management.Models
{
    public partial class FileAttachment
    {
        public int FileId { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public string? FileType { get; set; }
        public int? ReportId { get; set; }

        public virtual Report? Report { get; set; }

        public FileAttachment Clone()
        {
            return (FileAttachment)this.MemberwiseClone();
        }
    }
}
