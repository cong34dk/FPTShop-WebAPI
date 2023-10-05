using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class QuangCao
    {
        public int Id { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? LinkQuangCao { get; set; }
        public string? MoTa { get; set; }
    }
}
