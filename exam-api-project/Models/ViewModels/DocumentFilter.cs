using System;

namespace ExamAPI.Models.ViewModels
{
    public class DocumentFilter
    {
        public DateTime PeriodFrom { get; set; }

        public DateTime PeriodTo { get; set; }

        public string documentno { get; set; }
    }
}