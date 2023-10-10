using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHiemNhanTho.Models
{
    public class KhachHang
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("maKhachHang")]
        public string MaKhachHang { get; set; }

        [BsonElement("tenKhachHang")]
        public string TenKhachHang { get; set; }

        [BsonElement("ngaySinh")]
        public DateTime NgaySinh { get; set; }

        [BsonElement("diaChi")]
        public string DiaChi { get; set; }

        [BsonElement("gioiTinh")]
        public string GioiTinh { get; set; }

        [BsonElement("soDienThoaiKhachHang")]
        public string SoDienThoaiKhachHang { get; set; }

        [BsonElement("nhanVien")]
        public List<NhanVien> NhanVien { get; set; }

        [BsonElement("GoiBaoHiem")]
        public List<GoiBaoHiem> GoiBaoHiem { get; set; }
    }
}
