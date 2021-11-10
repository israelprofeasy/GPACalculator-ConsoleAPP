using APPModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace APPLib.Services.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CourseNameAndCode { get; set; }
        public byte CourseUnit { get; set; }
        public int CourseScore { get; set; }
        public Score ScoreDetails { get; set; }

       
    }
}
