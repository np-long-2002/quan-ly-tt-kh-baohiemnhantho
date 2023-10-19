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
    public partial class fDangNhap : Form
    {
        private IMongoCollection<taiKhoan> _userCollection;
        public fDangNhap()
        {
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017/";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");
            _userCollection = database.GetCollection<taiKhoan>("tk");
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            var filter = Builders<taiKhoan>.Filter.Eq(x => x.username, username);
            var user = _userCollection.Find(filter).FirstOrDefault();

            if (user != null && user.password == password)
            {
                var formMain = new Main(user.quyen);
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

        private void btndangKy_Click(object sender, EventArgs e)
        {
            fDangKy formDangKy = new fDangKy();

            formDangKy.Show();

            this.Hide();
        }
    }
}
