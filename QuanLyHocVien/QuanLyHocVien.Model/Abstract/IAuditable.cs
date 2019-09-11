using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        string UpdatedBy { get; set; }

        [MaxLength(256)]
        string MetaKeyword { get; set; }

        [MaxLength(256)]
        string MetaDescription { get; set; }

        bool Status { get; set; }

    }
}
