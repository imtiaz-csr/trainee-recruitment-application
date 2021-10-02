using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trainee_Recruitment_Application.Models.Annotations
{
    public class TraineeType
    {
        public int TraineeId { get; set; }
        [Required, StringLength(30)]
        public string TraineeName { get; set; }
        [Required, StringLength(20)]
        public string Round { get; set; }
        [Required, StringLength(200)]
        public string Picture { get; set; }
        [Required]
        public int BatchId { get; set; }
    }
}