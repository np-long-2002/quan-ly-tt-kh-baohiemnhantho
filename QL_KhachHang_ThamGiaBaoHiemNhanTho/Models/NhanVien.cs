using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho.Models
{
    [BsonIgnoreExtraElements]
    public class NhanVien
    {
        [BsonElement("maNhanVien")]
        public string MaNhanVien { get; set; }

        [BsonElement("tenNhanVien")]
        public string TenNhanVien { get; set; }

        [BsonElement("soDienThoaiNhanVien")]
        public string SoDienThoaiNhanVien { get; set; }
    }
}
