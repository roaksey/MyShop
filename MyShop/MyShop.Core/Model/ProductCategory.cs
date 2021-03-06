﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model
{
    public class ProductCategory
    {
        public string Id { get; set; }

        [StringLength(20,ErrorMessage ="NO more than 20 letters")]
         public string Category { get; set; }

        public ProductCategory()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
