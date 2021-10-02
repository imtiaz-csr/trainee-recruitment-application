using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Trainee_Recruitment_Application.Attributes;

namespace Trainee_Recruitment_Application.ViewModels
{
    public class TraineeVM
    {
        public int TraineeId { get; set; }
        [Required, StringLength(40)]
        public string TraineeName { get; set; }
        [Required, ValidRound(ErrorMessage = "Use R45")]
        public string Round { get; set; }

        public HttpPostedFileBase Picture { get; set; }
        [Required]
        public int BatchId { get; set; }
    }
}