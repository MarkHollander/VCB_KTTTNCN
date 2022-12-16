using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlud.KTTTNCN.BaoCaoQuanLyChungTus
{
    [Table("BaoCaoQuanLyChungTus")]
    public class BaoCaoQuanLyChungTu : FullAuditedEntity<long>
    {
        //public virtual int SoThuTu { get; set; }
        public virtual string MauSo { get; set; }
        public virtual string KyHieu { get; set; }
        public virtual string MaSoThue { get; set; }
        public virtual string HoVaTen { get; set; }
        public virtual string Email { get; set; }
        public virtual string Status { get; set; }
        public virtual int IdChungTu { get; set;}
        public DateTime NgayLap { get; set; }
        public DateTime NgayDuyet { get; set; }
    }
}
