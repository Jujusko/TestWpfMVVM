﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWpfTutor6.DBModel
{
    public class Tranzaction
    {
        [Key]
        public int Id { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
