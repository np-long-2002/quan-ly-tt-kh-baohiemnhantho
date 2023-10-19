using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using QL_KhachHang_ThamGiaBaoHiemNhanTho.Models;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho
{
    public partial class fDangKy : Form
    {
        private IMongoCollection<taiKhoan> _userCollection;
        public fDangKy()
        {
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017/";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");
            _userCollection = database.GetCollection<taiKhoan>("tk");
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string username = txtDkTaiKhoan.Text;
            string password = txtDkMatKhau.Text;

            
            var newUser = new taiKhoan
            {
                username = username,
                password = password,
                quyen = false 
            };

            
            _userCollection.InsertOne(newUser);

            MessageBox.Show("Đăng ký thành công!");

            
            var formDangNhap = new fDangNhap();
            formDangNhap.Show();

            this.Close();
        }
    }
}
