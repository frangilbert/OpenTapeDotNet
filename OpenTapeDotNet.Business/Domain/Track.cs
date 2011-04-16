using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTapeDotNet.Business.Domain
{
    public class Track
    {
        public string Filename { get; set; }
        public string Track { get; set; }
        public string Location { get; set; }
        public string Meta { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Info { get; set; }
    }
}
