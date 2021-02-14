using System;
using System.ComponentModel.DataAnnotations;

namespace ZantosMvc.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Link { get; set; }
    }
}