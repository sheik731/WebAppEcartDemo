//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppEcartDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class item
    {
        public System.Guid itemid { get; set; }
        public int categoryid { get; set; }
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public string description { get; set; }
        public string imagepath { get; set; }
        public decimal itemprice { get; set; }
    }
}