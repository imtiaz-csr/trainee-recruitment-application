//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trainee_Recruitment_Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Trainee_Recruitment_Application.Models.Annotations;

    [MetadataType(typeof(TraineeType))]

    public partial class Trainee
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }
        public string Round { get; set; }
        public string Picture { get; set; }
        public int BatchId { get; set; }
    
        public virtual Batch Batch { get; set; }
    }
}
