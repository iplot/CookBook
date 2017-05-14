﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DbLayer.Models.DTO
{
    public class IngredientDto
    {
        public double Amount { get; set; }
        public string Measurement { get; set; }
        public string Name { get; set; }
    }
}
