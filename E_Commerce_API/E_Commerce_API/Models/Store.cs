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
    [Table("Store")]
    public partial class Store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store()
        {
            Items = new HashSet<Item>();
        }

        public int ID { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public int quantity { get; set; }

        public int? ProductId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }

        public virtual Product Product { get; set; }
    }
}
