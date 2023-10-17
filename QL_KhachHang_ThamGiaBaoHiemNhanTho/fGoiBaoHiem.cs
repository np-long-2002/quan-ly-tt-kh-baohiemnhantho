using MongoDB.Bson;
using MongoDB.Driver;
using QL_KhachHang_ThamGiaBaoHiemNhanTho.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho
{
    public partial class fGoiBaoHiem : Form
    {
        private ListView listView;
        public void LoadDataGBH()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<GoiBaoHiem>("gbh");
            var filter = Builders<GoiBaoHiem>.Filter.Empty;
            var documents = collection.Find(filter).ToList();
            var bindingList = new BindingList<GoiBaoHiem>(documents);
            dataGridView3.DataSource = bindingList;
        }
        public fGoiBaoHiem()
        {
            InitializeComponent();
            LoadDataGBH();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView3.Columns.Count > 0)
                {
                    if (dataGridView3.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        string maGBH = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtmaNV.Text = maGBH;
                    }
                    else
                    {
                        txtmaNV.Text = "";
                    }
                    if (dataGridView3.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        string tenGBH = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtTenNV.Text = tenGBH;
                    }
                    else
                    {
                        txtTenNV.Text = "";
                    }


                    if (dataGridView3.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        string Gia = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtSDT.Text = Gia;
                    }
                    else
                    {
                        txtSDT.Text = "";
                    }
                    if (dataGridView3.Rows[e.RowIndex].Cells[3].Value != null)
                    {
                        string mota = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtMoTa.Text = mota;
                    }
                    else
                    {
                        txtMoTa.Text = "";
                    }
                }
            }
        }

        private void iconAddNV_Click(object sender, EventArgs e)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<GoiBaoHiem>("gbh");

            string maNhanVien = txtmaNV.Text;
            string tenNhanVien = txtTenNV.Text;
            int soDienThoai = int.Parse(txtSDT.Text);
            string moTa = txtMoTa.Text;

            var newGoiBaoHiem = new GoiBaoHiem
            {
                MaGoiBaoHiem = maNhanVien,
                TenGoiBaoHiem = tenNhanVien,
                GiaGoiBaoHiem = soDienThoai,
                MoTaGoiBaoHiem = moTa,
            };

            collection.InsertOne(newGoiBaoHiem);
            MessageBox.Show("Đã thêm gói bảo hiểm mới thành công.");
            LoadDataGBH();
        }

        private void iconUpdateNV_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtmaNV.Text;
            string tenNhanVien = txtTenNV.Text;
            string soDienThoai = txtSDT.Text;
            string mota = txtMoTa.Text;
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<GoiBaoHiem>("gbh");

            var filter = Builders<GoiBaoHiem>.Filter.Eq(x => x.MaGoiBaoHiem, txtmaNV.Text);
            var update = Builders<GoiBaoHiem>.Update
                           .Set(x => x.TenGoiBaoHiem, tenNhanVien)
                           .Set(x => x.GiaGoiBaoHiem, int.Parse(soDienThoai))
                           .Set(x => x.MoTaGoiBaoHiem, mota);

            var result = collection.UpdateOne(filter, update);

            if (result.ModifiedCount > 0)
            {
                MessageBox.Show("Cập nhật thành công.");
                LoadDataGBH();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần cập nhật.");
            }
        }

        private void iconHuyNV_Click(object sender, EventArgs e)
        {
            string maNV = txtmaNV.Text;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<GoiBaoHiem>("gbh");

            var filter = Builders<GoiBaoHiem>.Filter.Eq(x => x.MaGoiBaoHiem, maNV);

            var result = collection.DeleteOne(filter);

            if (result.DeletedCount > 0)
            {
                MessageBox.Show("Xóa nhân viên thành công.");
                LoadDataGBH();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần xóa.");
            }
        }

        private void iconTKNV_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView = listView1;
            listView.View = View.Details;
            listView.Columns.Add("Tên Khách Hàng", 150);
            listView.Columns.Add("Số Điện Thoại", 150);

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("kh");

            var maNhanVienCanTim = txtmaNV.Text;

            var pipeline = new List<BsonDocument>
            {
                BsonDocument.Parse("{ $match: { 'GoiBaoHiem.maGoiBaoHiem': '" + maNhanVienCanTim + "' } }"),
                BsonDocument.Parse("{ $project: { tenKhachHang: 1, _id: 0 ,soDienThoaiKhachHang:1} }")
            };

            var aggregation = collection.Aggregate<BsonDocument>(pipeline);
            var result = aggregation.ToList();

            if (result.Count > 0)
            {
                foreach (var doc in result)
                {
                    var tenKhachHang = doc.GetValue("tenKhachHang", "").AsString;
                    var soDienThoai = doc.GetValue("soDienThoaiKhachHang", "").AsString;
                    ListViewItem item = new ListViewItem(tenKhachHang);
                    item.SubItems.Add(soDienThoai);
                    listView.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
            }


            var matchStage = new BsonDocument("$match", new BsonDocument("GoiBaoHiem.maGoiBaoHiem", maNhanVienCanTim));
            var countStage = new BsonDocument("$count", "totalCustomers");

            var pipeline1 = new List<BsonDocument> { matchStage, countStage };

            var aggregation1 = collection.Aggregate<BsonDocument>(pipeline1);
            var result1 = aggregation1.FirstOrDefault();

            if (result1 != null && result1.Contains("totalCustomers"))
            {
                int totalCustomers = result1["totalCustomers"].AsInt32;
                count.Text = totalCustomers.ToString();
            }
        }
    }
}
