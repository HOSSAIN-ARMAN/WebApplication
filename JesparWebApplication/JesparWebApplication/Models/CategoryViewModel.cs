using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jespar.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace JesparWebApplication.Models
{
    public class CategoryViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        [MaxLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        [MinLength(4, ErrorMessage = "Code Length Must be in 4!!")]
        public string Code { set; get; }
        [Required(ErrorMessage = "Input Can Not Be Empty")]
        public string Name { set; get; }

        public List<Category> Categories { set; get; }
    }
}