using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputingAllAboutCat.Model
{
    public class Fact
    {
        [Key]
        [HiddenInput]
        [Required]
        public int FactID { get; set; }

        public string FactText { get; set; }
    }
}
