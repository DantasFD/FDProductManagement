using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace FDProductManagement.Service.ViewModels
{
    public class BrandViewModel
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
