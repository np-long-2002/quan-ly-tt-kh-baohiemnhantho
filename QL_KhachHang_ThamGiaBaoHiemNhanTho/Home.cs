using MongoDB.Bson;
using MongoDB.Driver;
using QL_KhachHang_ThamGiaBaoHiemNhanTho.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho
{
    public partial class Home : Form
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
        public Home()
        {
            InitializeComponent();
            LoadDataKH();
            
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
                        LoadDataNhanVien(maKH);
                        LoadDataGoiBaoHiem(maKH);
                    }
                }
            }
        }

        private void iconBtnTimKiem_Click(object sender, EventArgs e)
        {
            string tenKH = txtTK.Text;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");

            var filter = Builders<KhachHang>.Filter.Regex("tenKhachHang", new BsonRegularExpression(tenKH, "i"));
            var results = collection.Find(filter).ToList();
            
            if (results.Count > 0)
            {
                dataGridView1.DataSource = results;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
            }
        }

        private void iconLoad_Click(object sender, EventArgs e)
        {
            LoadDataKH();
            txtTK.Text = string.Empty;
            string databaseName = "test"; 
            string backupFolderPath = "D:\\NoSQL\\quan-ly-tt-kh-baohiemnhantho"; 
            Process process = new Process();
            process.StartInfo.FileName = "mongodump";
            process.StartInfo.Arguments = $"--db {databaseName} --out {backupFolderPath}";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.Start();
            process.WaitForExit();

            if (process.ExitCode == 0)
            {
                MessageBox.Show("Sao lưu hoàn tất.");
            }
            else
            {
                MessageBox.Show("Sao lưu không thành công.");
            }
        }
    }
}
