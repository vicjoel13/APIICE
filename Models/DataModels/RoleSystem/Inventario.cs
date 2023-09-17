using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels.RoleSystem
{
    public class Inventario : BaseModel
    {
        public int store_id { get; set; }
        public DateTime Date { get; set; }

        public string Flavor { get; set; }
        public bool is_season_flavor { get; set; }

        public int quantity { get; set; }
    }
}
