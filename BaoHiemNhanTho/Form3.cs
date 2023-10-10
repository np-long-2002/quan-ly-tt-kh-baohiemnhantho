using BaoHiemNhanTho.Models;
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
    public partial class Form3 : Form
    {
        private string maKhachHang;
        public void LoadDataGoiBaoHiem(string maKH)
        {
            Form1 fr = new Form1();
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<KhachHang>("kh");
            var filter = Builders<KhachHang>.Filter.Empty;
            var customer = collection.Find(x => x.MaKhachHang == maKH).FirstOrDefault();
            if (customer != null && customer.GoiBaoHiem != null && customer.GoiBaoHiem.Any())
            {
                var bindingList1 = new BindingList<GoiBaoHiem>(customer.GoiBaoHiem).ToList();
                dataGridView1.DataSource = bindingList1;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng hoặc danh sách nhân viên.");
            }
        }
        public Form3(string maKH)
        {
            InitializeComponent();
            this.maKhachHang = maKH;
            LoadDataGoiBaoHiem(maKH);
        }
    }
}
