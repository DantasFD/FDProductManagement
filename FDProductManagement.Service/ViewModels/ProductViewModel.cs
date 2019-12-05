using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FDProductManagement.Service.ViewModels
{
    public class ProductViewModel
    {

        [Key]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "fabricationDate")]
        public string FabricationDate { get; set; }

        [JsonProperty(PropertyName = "warrantyExpireDate")]
        public string WarrantyExpireDate { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public BrandViewModel Brand { get; set; }

        public Guid BrandId { get; set; }
    }
}
