using CsvHelper.Configuration.Attributes;
using Models.DataModels.RoleSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class InventoryCsv
    {
        [Name("Store")]
        public string Store { get; set; }

        [Name(" Date")]
        public string Date { get; set; }

        [Name(" Flavor")]
        public string Flavor { get; set; }

        [Name(" Is Season Flavor")]
        public string Is_Season { get; set; }
        [Name(" Quantity")]
        public string Quantity { get; set; }
        [Name(" Listed By")]
        public string Listed_By { get; set; }

    }
}
