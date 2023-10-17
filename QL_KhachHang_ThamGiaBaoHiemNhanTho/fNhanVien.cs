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
    public partial class fNhanVien : Form
    {
        private ListView listView;
        public void LoadDataNV()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<NhanVien>("nv");
            var filter = Builders<NhanVien>.Filter.Empty;
            var documents = collection.Find(filter).ToList();
            var bindingList = new BindingList<NhanVien>(documents);
            dataGridView1.DataSource = bindingList;
        }
        public fNhanVien()
        {
            InitializeComponent();
            count.Enabled = false;
            LoadDataNV();
        }

        private void iconAddNV_Click(object sender, EventArgs e)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<NhanVien>("nv");

            string maNhanVien = txtmaNV.Text;
            string tenNhanVien = txtTenNV.Text;
            string soDienThoai = txtSDT.Text;

            var newNhanVien = new NhanVien
            {
                MaNhanVien = maNhanVien,
                TenNhanVien = tenNhanVien,
                SoDienThoaiNhanVien = soDienThoai,
            };

            collection.InsertOne(newNhanVien);
            MessageBox.Show("Đã thêm nhân viên mới thành công.");
            LoadDataNV();
        }

        private void iconUpdateNV_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtmaNV.Text;
            string tenNhanVien = txtTenNV.Text;
            string soDienThoai = txtSDT.Text;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<NhanVien>("nv");

            var filter = Builders<NhanVien>.Filter.Eq(x => x.MaNhanVien, txtmaNV.Text);
            var update = Builders<NhanVien>.Update
                           .Set(x => x.TenNhanVien, tenNhanVien)
                           .Set(x => x.SoDienThoaiNhanVien, soDienThoai);

            var result = collection.UpdateOne(filter, update);

            if (result.ModifiedCount > 0)
            {
                MessageBox.Show("Cập nhật thành công.");
                LoadDataNV();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần cập nhật.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns.Count > 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        string maNhanVien = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtmaNV.Text = maNhanVien;
                    }
                    else
                    {
                        txtmaNV.Text = "";
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        string tenNV = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtTenNV.Text = tenNV;
                    }
                    else
                    {
                        txtTenNV.Text = "";
                    }


                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        string soDienTHoai = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtSDT.Text = soDienTHoai;
                    }
                    else
                    {
                        txtSDT.Text = "";
                    }
                }
            }
        }

        private void iconHuyNV_Click(object sender, EventArgs e)
        {
            string maNV = txtmaNV.Text;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<NhanVien>("nv");

            var filter = Builders<NhanVien>.Filter.Eq(x => x.MaNhanVien, maNV);

            var result = collection.DeleteOne(filter);

            if (result.DeletedCount > 0)
            {
                MessageBox.Show("Xóa nhân viên thành công.");
                LoadDataNV();
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
                BsonDocument.Parse("{ $match: { 'nhanVien.maNhanVien': '" + maNhanVienCanTim + "' } }"),
                BsonDocument.Parse("{ $project: { tenKhachHang: 1, _id: 0 ,soDienThoaiKhachHang:1} }")
            };

            var aggregation = collection.Aggregate<BsonDocument>(pipeline);
            var result = aggregation.ToList();

            if(result.Count > 0) 
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
            

            var matchStage = new BsonDocument("$match", new BsonDocument("nhanVien.maNhanVien", maNhanVienCanTim));
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
