using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Reason
    {
        public int ReasonID { get; set; }
        public string title { get; set;}
        public string description { get; set;}
        public DateTime CreatedDate { get; set;}
        public string notes{ get; set;}

        public Reason() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Title: {0}", this.title));
            sb.AppendLine(string.Format("Description: {0}", this.description));
            sb.AppendLine(string.Format("Date: {0:mm-DD-yyyy}", this.CreatedDate));
            sb.AppendLine(string.Format("ID: {0} / Notes: {0}", this.ReasonID, this.notes));
            return sb.ToString();
        }
    }
}
