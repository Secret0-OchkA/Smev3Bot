using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smev_Bot.Model
{
    enum Zone
    {
        UnknowZone,
        Fed,
        Reg,
    }

    internal class SearchParams
    {
        public string name { get; set; }
        public string apclication { get; set; }
        public Zone zone { get; set; }
        public bool displayProdRequest { get; set; }
        public bool displayTestRequest { get; set; }

        public string? version { get; set; }
        public string? id { get; set; }
        public string? subject { get; set; }
        public string? serviceOwner { get; set; }

        public SearchParams()
        {
            name = "";
            apclication = "";
            zone = Zone.UnknowZone;
            displayProdRequest = false;
            displayTestRequest = false;

            version = "";
            id = "";
            subject = "";
            serviceOwner = "";
        }
    }
}
