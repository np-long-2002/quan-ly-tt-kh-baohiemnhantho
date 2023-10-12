﻿using BaoHiemNhanTho.Models;
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
    public partial class Form2 : Form
    {
        private string maKhachHang;
        public void LoadDataNhanVien(string maKH)
        {
            Form1 fr = new Form1();
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");
            var filter = Builders<KhachHang>.Filter.Empty;
            var customer = collection.Find(x => x.MaKhachHang == maKH).FirstOrDefault();
            if (customer != null && customer.NhanVien != null && customer.NhanVien.Any()) 
            {
                var bindingList1 = new BindingList<NhanVien>(customer.NhanVien).ToList();
                dataGridView1.DataSource = bindingList1;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng hoặc danh sách nhân viên.");
                Form4 form4 = new Form4(maKH);
                form4.ShowDialog();
                var bindingList1 = new BindingList<NhanVien>(customer.NhanVien).ToList();
                dataGridView1.DataSource = bindingList1;
            }
                
        }
        public Form2(string maKH)
        {
            InitializeComponent();
            this.maKhachHang = maKH;
            LoadDataNhanVien(maKH);
        }
    }
}
