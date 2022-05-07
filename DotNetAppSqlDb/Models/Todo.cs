using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetAppSqlDb.Models
{
    public class Todo
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public List<TodoDetail> details { get; set; }

    }

    public class TodoDetail
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int year { get; set; }
        public float value { get; set; }
        public string country { get; set; }

        public Todo commodity { get; set; }

    }
}