using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InventoryManagement.Core.Models
{
    public class LoadResultResponse
    {
        //
        // Summary:
        //     A resulting dataset.
        public IEnumerable data { get; set; }
        //
        // Summary:
        //     The total number of data objects in the resulting dataset.
        [DefaultValue(-1)]
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int totalCount { get; set; }
        //
        // Summary:
        //     The number of top-level groups in the resulting dataset.
        [DefaultValue(-1)]
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int groupCount { get; set; }
        //
        // Summary:
        //     Total summary calculation results.
        //[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object[] summary { get; set; }
    }
}
