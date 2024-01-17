using System;
using System.Collections.Generic;

namespace ExamAPI.Models
{
    public class Document
    {
        public Document()
        {
            Histories = new List<DocumentHistory>();
        }

        public long id { get; set; }

        public string dataareaid { get; set; }

        public string documentno { get; set; }

        public string description { get; set; }

        public DateTime requesteddate { get; set; }

        public int status { get; set; }

        public string createdby { get; set; }

        public DateTime createddatetime { get; set; }

        public string modifiedby { get; set; }

        public DateTime? modifieddatetime { get; set; }

        public List<DocumentHistory> Histories { get; set; }
    }
}