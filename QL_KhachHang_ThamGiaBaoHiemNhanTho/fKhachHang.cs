using MongoDB.Bson;
using MongoDB.Driver;
using QL_KhachHang_ThamGiaBaoHiemNhanTho.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho
{
    public partial class fKhachHang : Form
    {
        private IMongoCollection<BsonDocument> khachHangCollection;
        private IMongoCollection<BsonDocument> nhanVienCollection;
        private IMongoCollection<BsonDocument> goiBaoHiemCollection;
        private List<BsonDocument> nhanVienList;
        private List<BsonDocument> goiBaoHiemList;
        public void LoadDataKH()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");
            var filter = Builders<KhachHang>.Filter.Empty;
            var documents = collection.Find(filter).ToList();
            var bindingList = new BindingList<KhachHang>(documents);
            dataGridView1.DataSource = bindingList;
        }
        public void LoadDataNhanVien(string maKH)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");
            var filter = Builders<KhachHang>.Filter.Empty;
            var customer = collection.Find(x => x.MaKhachHang == maKH).FirstOrDefault();
            if (customer != null && customer.NhanVien != null && customer.NhanVien.Any())
            {
                var bindingList1 = new BindingList<NhanVien>(customer.NhanVien).ToList();
                dataGridView2.DataSource = bindingList1;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên của khách hàng này.");
                dataGridView2.CancelEdit();
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
            }
        }
        public void LoadDataGoiBaoHiem(string maKH)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");
            var filter = Builders<KhachHang>.Filter.Empty;
            var customer = collection.Find(x => x.MaKhachHang == maKH).FirstOrDefault();
            if (customer != null && customer.GoiBaoHiem != null && customer.GoiBaoHiem.Any())
            {
                var bindingList1 = new BindingList<GoiBaoHiem>(customer.GoiBaoHiem).ToList();
                dataGridView3.DataSource = bindingList1;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin gói bảo hiểm khách hàng đã đăng ký!!!");
                dataGridView3.CancelEdit();
                dataGridView3.Columns.Clear();
                dataGridView3.DataSource = null;
                dataGridView3.Rows.Clear();
            }
        }
        private void LoadAndDisplayNhanVien()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            khachHangCollection = database.GetCollection<BsonDocument>("kh");
            nhanVienCollection = database.GetCollection<BsonDocument>("nv");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var nhanVienList = nhanVienCollection.Find(filter).ToList();

            foreach (var nhanVien in nhanVienList)
            {
                string tenNhanVien = nhanVien.GetValue("tenNhanVien").AsString;
                comboBox1.Items.Add(tenNhanVien);
            }
        }
        private void LoadAndDisplayGoiBaoHiem()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            khachHangCollection = database.GetCollection<BsonDocument>("kh");
            goiBaoHiemCollection = database.GetCollection<BsonDocument>("gbh");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var gbhList = goiBaoHiemCollection.Find(filter).ToList();

            foreach (var goiBaoHiem in gbhList)
            {
                string tengbh = goiBaoHiem.GetValue("tenGoiBaoHiem").AsString;
                comboBox2.Items.Add(tengbh);
            }
        }
        public fKhachHang()
        {
            InitializeComponent();
            LoadDataKH();
            LoadAndDisplayNhanVien();
            LoadAndDisplayGoiBaoHiem();
        }

        private void iconAddTTKH_Click(object sender, EventArgs e)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");

            string maKhachHang = txtmaKH.Text;
            string tenKhachHang = txttenKH.Text;
            DateTime ngaySinh = DateTime.SpecifyKind(DateTime.Parse(dateTimePicker1.Text), DateTimeKind.Utc);
            string diaChi = txtdiaChi.Text;
            string gioiTinh = cbxgioiTinh.SelectedItem.ToString();
            string soDienThoai = txtsoDT.Text;

            var newKhachHang = new KhachHang
            {
                MaKhachHang = maKhachHang,
                TenKhachHang = tenKhachHang,
                NgaySinh = (DateTime)BsonDateTime.Create(ngaySinh),
                DiaChi = diaChi,
                GioiTinh = gioiTinh,
                SoDienThoaiKhachHang = soDienThoai,
                NhanVien = new List<NhanVien>(),
                GoiBaoHiem = new List<GoiBaoHiem>()
            };
            var existingCustomer = collection.Find(customer => customer.MaKhachHang == maKhachHang).FirstOrDefault();

            if (existingCustomer != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khách hàng khác.");
            }
            else
            {
                collection.InsertOne(newKhachHang);
                MessageBox.Show("Đã thêm khách hàng thành công.");
                LoadDataKH();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns.Count > 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        string maKH = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtmaKH.Text = maKH;
                    }
                    else
                    {
                        txtmaKH.Text = "";
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        string tenKH = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txttenKH.Text = tenKH;
                    }
                    else
                    {
                        txttenKH.Text = "";
                    }
                    string dateString = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    DateTime.TryParse(dateString, out DateTime selectedDate);
                    if (selectedDate.Year <= 1)
                    {
                        selectedDate = DateTime.Now;
                    }
                    dateTimePicker1.Value = selectedDate;

                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value != null)
                    {
                        string diaChi = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtdiaChi.Text = diaChi;
                    }
                    else
                    {
                        txtdiaChi.Text = "";
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != null)
                    {
                        string gioiTinh = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        cbxgioiTinh.SelectedItem = gioiTinh;
                    }
                    else
                    {
                        cbxgioiTinh.Text = "";
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        string soDienTHoai = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtsoDT.Text = soDienTHoai;
                    }
                    else
                    {
                        txtsoDT.Text = "";
                    }
                    LoadDataNhanVien(txtmaKH.Text);
                    LoadDataGoiBaoHiem(txtmaKH.Text);
                }
            }
        }

        private void iconUpdate_Click(object sender, EventArgs e)
        {
            string maKH = txtmaKH.Text;
            string tenKhachHang = txttenKH.Text;
            DateTime ngaySinh = DateTime.Parse(dateTimePicker1.Text);
            string diaChi = txtdiaChi.Text;
            string gioiTinh = cbxgioiTinh.SelectedItem.ToString();
            string soDienThoai = txtsoDT.Text;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");

            var filter = Builders<KhachHang>.Filter.Eq(x => x.MaKhachHang, maKH);
            var update = Builders<KhachHang>.Update
                           .Set(x => x.TenKhachHang, tenKhachHang)
                           .Set(x => x.NgaySinh, ngaySinh)
                           .Set(x => x.DiaChi, diaChi)
                           .Set(x => x.GioiTinh, gioiTinh)
                           .Set(x => x.SoDienThoaiKhachHang, soDienThoai);

            var result = collection.UpdateOne(filter, update);

            if (result.ModifiedCount > 0)
            {
                MessageBox.Show("Cập nhật thành công.");
                LoadDataKH();
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng cần cập nhật.");
            }
        }

        private void iconDelete_Click(object sender, EventArgs e)
        {
            string maKH = txtmaKH.Text;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");

            var filter = Builders<KhachHang>.Filter.Eq(x => x.MaKhachHang, maKH);

            var result = collection.DeleteOne(filter);

            if (result.DeletedCount > 0)
            {
                MessageBox.Show("Xóa khách hàng thành công.");
                LoadDataKH();
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng cần xóa.");
            }
        }

        private void iconAddNV_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                var mongoClient = new MongoClient("mongodb://localhost:27017");
                var database = mongoClient.GetDatabase("test");
                nhanVienCollection = database.GetCollection<BsonDocument>("nv");
                var filter1 = Builders<BsonDocument>.Filter.Empty;
                var nhanVienList = nhanVienCollection.Find(filter1).ToList();

                string selectedTenNhanVien = comboBox1.SelectedItem.ToString();
                var selectedNhanVien = nhanVienList.Find(nv => nv.GetValue("tenNhanVien").AsString == selectedTenNhanVien);

                string maKhachHang = txtmaKH.Text;
                var filter = Builders<BsonDocument>.Filter.Eq("maKhachHang", maKhachHang);
                var khachHang = khachHangCollection.Find(filter).FirstOrDefault();

                if (khachHang != null)
                {
                    var nhanVienArray = khachHang.GetValue("nhanVien").AsBsonArray;
                    nhanVienArray.Add(selectedNhanVien);
                    var update = Builders<BsonDocument>.Update.Set("nhanVien", nhanVienArray);
                    khachHangCollection.UpdateOne(filter, update);

                    MessageBox.Show("Thông tin nhân viên đã được thêm vào khách hàng có mã " + maKhachHang);
                    LoadDataNhanVien(maKhachHang);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với mã " + maKhachHang);
                }
            }
        }

        private void iconUpdateNV_Click(object sender, EventArgs e)
        {
           
        }

        private void iconHuyNV_Click(object sender, EventArgs e)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maKhachHang", txtmaKH.Text);

            var khachHang = khachHangCollection.Find(filter).FirstOrDefault();

            if (khachHang != null)
            {
                var nhanVienArray = khachHang["nhanVien"].AsBsonArray;
                var nhanVienToBeRemoved = nhanVienArray.FirstOrDefault(nv => nv["maNhanVien"].AsString == dataGridView2.CurrentRow.Cells[0].Value.ToString());

                if (nhanVienToBeRemoved != null)
                {
                    nhanVienArray.Remove(nhanVienToBeRemoved);

                    var update = Builders<BsonDocument>.Update.Set("nhanVien", nhanVienArray);
                    khachHangCollection.UpdateOne(filter, update);
                    LoadDataNhanVien(txtmaKH.Text);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần xóa.");
                }
            }
            else
            {
                MessageBox.Show(" Không tìm thấy mã khách hàng hoặc mã nhân viên");
            }
        }

        private void iconAddGBH_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                var mongoClient = new MongoClient("mongodb://localhost:27017");
                var database = mongoClient.GetDatabase("test");
                goiBaoHiemCollection = database.GetCollection<BsonDocument>("gbh");
                var filter1 = Builders<BsonDocument>.Filter.Empty;
                var goiBaoHiemList = goiBaoHiemCollection.Find(filter1).ToList();

                string selectedTenGBH = comboBox2.SelectedItem.ToString();
                var selectedGBH = goiBaoHiemList.Find(nv => nv.GetValue("tenGoiBaoHiem").AsString == selectedTenGBH);

                string maKhachHang = txtmaKH.Text;
                var filter = Builders<BsonDocument>.Filter.Eq("maKhachHang", maKhachHang);
                var khachHang = khachHangCollection.Find(filter).FirstOrDefault();

                if (khachHang != null)
                {
                    var goiBaoHiemArray = khachHang.GetValue("GoiBaoHiem").AsBsonArray;
                    DateTime ngayBatDau = DateTime.SpecifyKind(DateTime.Parse(dateTimePicker2.Text), DateTimeKind.Utc);
                    DateTime ngayKetTHuc = DateTime.SpecifyKind(DateTime.Parse(dateTimePicker3.Text), DateTimeKind.Utc);


                    var newGoiBaoHiemDocument = new BsonDocument();

                    newGoiBaoHiemDocument.Add("tenGoiBaoHiem", selectedGBH["tenGoiBaoHiem"]);
                    newGoiBaoHiemDocument.Add("maGoiBaoHiem", selectedGBH["maGoiBaoHiem"]);
                    newGoiBaoHiemDocument.Add("giaGoiBaoHiem", selectedGBH["giaGoiBaoHiem"]);
                    newGoiBaoHiemDocument.Add("moTaGoiBaoHiem", selectedGBH["moTaGoiBaoHiem"]);
                    newGoiBaoHiemDocument.Add("thoiGianBatDau", ngayBatDau);
                    newGoiBaoHiemDocument.Add("thoiGianKetThuc", ngayKetTHuc);

                    goiBaoHiemArray.Add(newGoiBaoHiemDocument);


                    var update = Builders<BsonDocument>.Update.AddToSetEach("GoiBaoHiem", goiBaoHiemArray);
                    khachHangCollection.UpdateOne(filter, update);
                    MessageBox.Show("Thông tin Gói bảo hiểm đã được thêm vào khách hàng có mã " + maKhachHang);
                    LoadDataNhanVien(maKhachHang);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với mã " + maKhachHang);
                }
                LoadDataGoiBaoHiem(txtmaKH.Text);
            }
        }

        private void iconXoaGBH_Click(object sender, EventArgs e)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maKhachHang", txtmaKH.Text);

            var khachHang = khachHangCollection.Find(filter).FirstOrDefault();

            if (khachHang != null)
            {
                var goiBaoHiemArray = khachHang["GoiBaoHiem"].AsBsonArray;
                var goiBaoHiemToBeRemoved = goiBaoHiemArray.FirstOrDefault(nv => nv["maGoiBaoHiem"].AsString == dataGridView3.CurrentRow.Cells[0].Value.ToString());

                if (goiBaoHiemToBeRemoved != null)
                {
                    goiBaoHiemArray.Remove(goiBaoHiemToBeRemoved);

                    var update = Builders<BsonDocument>.Update.Set("GoiBaoHiem", goiBaoHiemArray);
                    khachHangCollection.UpdateOne(filter, update);
                    LoadDataGoiBaoHiem(txtmaKH.Text);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy gói bảo hiểm cần xóa.");
                }
            }
            else
            {
                MessageBox.Show(" Không tìm thấy mã khách hàng hoặc mã gói bảo hiểm");
            }
            
        }
    }
}
