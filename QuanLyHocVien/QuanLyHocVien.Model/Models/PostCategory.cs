using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
