using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pleaseAnswer.Models
{
    public class PlayerModel
    {
        public int ID { get; set; }

        [Display(Name = "照片")]
        public string Pic { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "学院")]
        public string School { get; set; }

        [Display(Name = "座右铭")]
        public string Motto { get; set; }

        [Display(Name = "得票数")]
        public int Vote { get; set; }
    }
}