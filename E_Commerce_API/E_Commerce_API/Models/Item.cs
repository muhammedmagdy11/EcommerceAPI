namespace E_Commerce_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Newtonsoft.Json;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    [JsonObject(IsReference = false)]
    [Table("Item")]
    public partial class Item
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public int? Order_Id { get; set; }

        public int? ProductId { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public int? StoretId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public virtual Store Store { get; set; }
    }
}
