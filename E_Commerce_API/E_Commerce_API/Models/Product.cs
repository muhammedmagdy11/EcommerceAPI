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
    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Items = new HashSet<Item>();
            Stores = new HashSet<Store>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Create_Date { get; set; }

        public int Stock { get; set; }

        public int? OrderID { get; set; }

        public int? Category_Id { get; set; }

        public string Material { get; set; }

        public string brand { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }

        public virtual Order Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
