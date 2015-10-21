using AppStudio.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftHel10World.DataProviders.Hel10
{
    public class Hel10Schema : SchemaBase
    {
        public string Title { get; set; }

        public string Summary { get; set; }

        public string Author { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Level { get; set; }

        public string Room { get; set; }

        public string Category { get; set; }
    }
}
