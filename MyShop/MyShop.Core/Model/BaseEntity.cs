﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Model
{
   public  abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DateCreated = DateTime.Now;

        }
    }
}
