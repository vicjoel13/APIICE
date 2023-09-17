using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DataModels.RoleSystem
{
    public class Inventory : BaseModel
    {


        [ForeignKey(nameof(Store))]
        public int store_id { get; set; }
        public virtual Store Store { get; set; }

        [ForeignKey(nameof(Employee))]
        public int employee_id { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime Date { get; set; }

        public string Flavor { get; set; }
        public bool is_season_flavor { get; set; }

        public int quantity { get; set; }


    }
}
