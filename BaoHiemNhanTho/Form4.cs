using BaoHiemNhanTho.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoHiemNhanTho
{

    public partial class Form4 : Form
    {
        private IMongoCollection<BsonDocument> khachHangCollection;
        private IMongoCollection<BsonDocument> nhanVienCollection;
        private string maKhachHang;
        public Form4(string maKhachHang)
        {
            this.maKhachHang = maKhachHang;
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            khachHangCollection = database.GetCollection<BsonDocument>("kh");
            nhanVienCollection = database.GetCollection<BsonDocument>("nv");
            LoadAndDisplayNhanVien();

        }
        private void LoadAndDisplayNhanVien()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var nhanVienList = nhanVienCollection.Find(filter).ToList();
            
            foreach (var nhanVien in nhanVienList)
            {
                string tenNhanVien = nhanVien.GetValue("tenNhanVien").AsString;
                Button nhanVienButton = new Button
                {
                    Text = tenNhanVien,
                    Tag = nhanVien 
                };
                nhanVienButton.Click += NhanVienButton_Click;
                nhanVienButton.Width = 150;
                nhanVienButton.Height = 100;
                flowLayoutPanel1.Controls.Add(nhanVienButton);
            }
        }

        private void NhanVienButton_Click(object sender, EventArgs e)
        {
            Button nhanVienButton = (Button)sender;
            var nhanVien = (BsonDocument)nhanVienButton.Tag;
            var filter = Builders<BsonDocument>.Filter.Eq("maKhachHang", maKhachHang);
            var khachHang = khachHangCollection.Find(filter).FirstOrDefault();

            if (khachHang != null)
            {
                var nhanVienArray = khachHang.GetValue("nhanVien").AsBsonArray;
                nhanVienArray.Add(nhanVien);
                var update = Builders<BsonDocument>.Update.Set("nhanVien", nhanVienArray);
                khachHangCollection.UpdateOne(filter, update);

                MessageBox.Show("Thông tin nhân viên đã được thêm vào khách hàng có mã " + maKhachHang);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng với mã " + maKhachHang);
            }
        }

    }
}
