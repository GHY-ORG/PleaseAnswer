using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pleaseAnswer.Models
{
    public class QuesModel
    {
        public int ID { get; set; }

        [Display(Name = "类别")]
        public string Class { get; set; }

        [Display(Name = "题目")]
        public string Ques { get; set; }

        [Display(Name = "选项A")]
        public string OptionA { get; set; }

        [Display(Name = "选项B")]
        public string OptionB { get; set; }

        [Display(Name = "选项C")]
        public string OptionC { get; set; }

        [Display(Name = "选项D")]
        public string OptionD { get; set; }

        [Display(Name = "答案")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "此题还未作答")]
        public string UserAnswer { get; set; }
    }
}