using BaoHiemNhanTho.Models;
using DnsClient.Protocol;
using MongoDB.Bson;
using MongoDB.Driver;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BaoHiemNhanTho
{
    public partial class Form1 : Form
    {
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
        public Form1()
        {
            InitializeComponent();
            LoadDataKH();
        }
        private void button1_Click(object sender, EventArgs e)
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

            collection.InsertOne(newKhachHang);
            MessageBox.Show("Đã thêm khách hàng thành công.");
            LoadDataKH();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns.Count > 0)
                {
                    if(dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
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
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtmaKH.Text = "";
            txttenKH.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            cbxgioiTinh.Text = "";
            txtdiaChi.Text = "";
            txtsoDT.Text = "";
            LoadDataKH();
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string maKH = txtmaKH.Text;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");

            var filter = Builders<KhachHang>.Filter.Eq(x => x.MaKhachHang, maKH);
            var result = collection.Find(filter).ToList();

            if (result.Count > 0)
            {
                dataGridView1.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(txtmaKH.Text);
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(txtmaKH.Text);
            form3.ShowDialog();
        }
    }
}
