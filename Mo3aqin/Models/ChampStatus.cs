using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mo3aqin.Models
{
    public class ChampStatus
    {
        public int ChampStatusId { get; set; }
        [ForeignKey("Championship")]
        public int ChampId { get; set; }
        public byte ChampInvChek { get; set; }
        public string ChampInvLink { get; set; }
        public byte RegNumChek { get; set; }
        public byte NominationPlayerChek { get; set; }
        public string RegNumlink { get; set; }
        public byte DelegChek { get; set; }
        public byte SportFreeTimeChek { get; set; }
        public byte AddresTheauthChek { get; set; }
        public byte PayOfFeesChek { get; set; }
        public byte RegByNamesChek { get; set; }
        public string RegByNamesLink { get; set; }
        public byte PromisChek { get; set; }
        public byte BookTicketChek { get; set; }
        public string BookTicketLink { get; set; }
        public byte ResidenceChek { get; set; }
        public byte VisaChek { get; set; }
        public byte FinancialChek { get; set; }
        public byte PRChek { get; set; }
        public byte UniformChek { get; set; }
        public byte ResultsChek { get; set; }
        public string ResultsLink { get; set; }
        public byte RePortChek { get; set; }
        public Championship Championship { get; set; }

    }
}
