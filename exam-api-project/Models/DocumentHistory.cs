using System;
using System.Text.Json.Serialization;

namespace ExamAPI.Models
{
    public class DocumentHistory
    {
        public long id { get; set; }

        public long documentid { get; set; }

        public int actionstatus { get; set; }

        public string actionby { get; set; }

        public DateTime actiondatetime { get; set; }

        [JsonIgnore]
        public Document Document { get; set; }
    }
}