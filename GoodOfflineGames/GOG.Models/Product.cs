﻿using System;
using System.Runtime.Serialization;

using GOG.Interfaces.Models;

namespace GOG.Models
{
    [DataContract]
    public class Product: ProductCore, IProduct, IEquatable<Product>
    {
        [DataMember(Name = "customAttributes")]
        public string[] CustomAttributes { get; set; }
        [DataMember(Name = "price")]
        public IPrice Price { get; set; }
        [DataMember(Name = "isDiscounted")]
        public bool IsDiscounted { get; set; }
        [DataMember(Name = "isInDevelopment")]
        public bool IsInDevelopment { get; set; }
        [DataMember(Name = "releaseDate")]
        public long ReleaseDate { get; set; }
        [DataMember(Name = "availability")]
        public IAvailability Availability { get; set; }
        [DataMember(Name = "salesVisibility")]
        public ISalesVisibility SalesVisibility { get; set; }
        [DataMember(Name = "buyable")]
        public bool Buyable { get; set; }
        [DataMember(Name = "image")]
        public string Image { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "supportUrl")]
        public string SupportUrl { get; set; }
        [DataMember(Name = "forumUrl")]
        public string ForumUrl { get; set; }
        [DataMember(Name = "worksOn")]
        public IWorksOn WorksOn { get; set; }
        [DataMember(Name = "category")]
        public string Category { get; set; }
        [DataMember(Name = "originalCategory")]
        public string OriginalCategory { get; set; }
        [DataMember(Name = "rating")]
        public int Rating { get; set; }
        [DataMember(Name = "type")]
        public int Type { get; set; }
        [DataMember(Name = "isComingSoon")]
        public bool IsComingSoon { get; set; }
        [DataMember(Name = "isPriceVisible")]
        public bool IsPriceVisible { get; set; }
        [DataMember(Name = "isMovie")]
        public bool IsMovie { get; set; }
        [DataMember(Name = "isGame")]
        public bool IsGame { get; set; }
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        public bool Equals(Product other)
        {
            return Id.Equals(other.Id);
        }
    }
}
