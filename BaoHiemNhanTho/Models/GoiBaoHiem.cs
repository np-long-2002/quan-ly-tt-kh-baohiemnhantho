using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHiemNhanTho.Models
{
    public class GoiBaoHiem
    {
        [BsonElement("maGoiBaoHiem")]
        public string MaGoiBaoHiem { get; set; }

        [BsonElement("tenGoiBaoHiem")]
        public string TenGoiBaoHiem { get; set; }

        [BsonElement("giaGoiBaoHiem")]
        public decimal GiaGoiBaoHiem { get; set; }

        [BsonElement("thoiGianBatDau")]
        public DateTimeOffset ThoiGianBatDau { get; set; }

        [BsonElement("thoiGianKetThuc")]
        public DateTimeOffset ThoiGianKetThuc { get; set; }

        [BsonElement("moTaGoiBaoHiem")]
        public string MoTaGoiBaoHiem { get; set; }
    }
}
