﻿using QuanLyHocVien.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Model.Models
{
    [Table("CourseCategories")]
    public class CourseCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cate_ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Cate_Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Cate_Alias { get; set; }

        [MaxLength(500)]
        public string Cate_Description { get; set; }

        [MaxLength(256)]
        public string Cate_Image { get; set; }

        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
