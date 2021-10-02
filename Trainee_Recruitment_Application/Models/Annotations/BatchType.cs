using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trainee_Recruitment_Application.Models.Annotations
{
    public class BatchType
    {
        public int BatchId { get; set; }
        [Required, StringLength(50)]
        public string BatchName { get; set; }
    }
}