using System;

namespace ExamAPI.Models.ViewModels
{
    public class DocumentViewModel
    {
        public long id { get; set; }

        public string dataareaid { get; set; }

        public string documentno { get; set; }

        public string description { get; set; }

        public DateTime requesteddate { get; set; }

        public int status { get; set; }

        public string userid { get; set; }

        public int? lastactionstatus { get; set; }

        public string lastactionby { get; set; }

        public DateTime? lastactiondatetime { get; set; }
    }
}