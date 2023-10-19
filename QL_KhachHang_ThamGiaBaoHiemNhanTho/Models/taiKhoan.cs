using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho.Models
{
    class taiKhoan
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("Quyen")]
        public Boolean quyen { get; set; }
    }
}

