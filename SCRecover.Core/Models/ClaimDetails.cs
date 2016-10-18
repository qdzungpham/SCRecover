using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRecover.Core.Models
{
    public class ClaimDetails
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string DoB { get; set; }
        public string PolicyNum { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Injury { get; set; }
        public string Cmt { get; set; }
        public string Extra { get; set; }
        public byte[] Bytes { get; set; }
    }
}
