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
        public string Code { set; get; }
        public string Name { set; get; }
    }
}