using System.Collections.Generic;

namespace Foundation.Dto
{
    public class MailDto
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public List<string> ToEmailss { get; set; }
    }
}
