using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue(0)]
        public long Like { get; set; }
    }
}