using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhachHang_ThamGiaBaoHiemNhanTho
{
    public partial class Main : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private bool isAdmin;
        public Main(bool isAdmin)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel_Left.Controls.Add(leftBorderBtn);
            this.isAdmin = isAdmin;
            CustomizeUI();
            //Form
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                //iconCurrentChildForm.IconChar = currentBtn.IconChar;
                //iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label_Title.Text = childForm.Text;
        }
   
        private void iconHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Home());
        }

        private void iconCus_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new fKhachHang());
        }

        private void iconEmp_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new fNhanVien());
        }

        private void iconGBH_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new fGoiBaoHiem());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new fThongKe());
        }
        private void CustomizeUI()
        {
            if (isAdmin)
            {
                // Cho phép truy cập vào tất cả các chức năng nếu là admin
                // Hiển thị các nút cho trang Nhân Viên và Gói Bảo Hiểm
                iconEmp.Visible = true;
                iconGBH.Visible = true;
                iconButton2.Visible = true;
                iconButton3.Visible = true;
                iconButton1.Visible = true;
            }
            else
            {
                // Chỉ cho phép truy cập vào trang chủ và trang khách hàng nếu không phải admin
                // Ẩn nút cho trang Nhân Viên và Gói Bảo Hiểm
                iconEmp.Visible = false;
                iconGBH.Visible = false;
                iconButton1.Visible = false;
                iconButton2.Visible = false;
            }
        }
        private void LoginSuccess(bool isAdmin)
        {
            // Kiểm tra vai trò của người dùng và điều chỉnh quyền truy cập
            if (isAdmin)
            {
                // Đây là tài khoản admin
                // Cho phép truy cập vào tất cả các chức năng, bao gồm trang Nhân Viên và trang Gói Bảo Hiểm
                ActivateButton(iconEmp, RGBColors.color2);
                ActivateButton(iconGBH, RGBColors.color6);
                OpenChildForm(new fNhanVien());
            }
            else
            {
                // Đây là tài khoản nhân viên hoặc người dùng khác
                // Chỉ cho phép truy cập vào trang chủ và trang khách hàng
                ActivateButton(iconHome, RGBColors.color1);
                ActivateButton(iconCus, RGBColors.color3);
                ActivateButton(iconButton3, RGBColors.color4);
                OpenChildForm(new fKhachHang());
                
            }
        }

        private async void iconButton2_Click(object sender, EventArgs e)
        {
            string databaseName = "test"; 
            string backupFolderPath = "D:\\NoSQL\\quan-ly-tt-kh-baohiemnhantho\\test";
       
            await Task.Run(() => RestoreMongoDB(backupFolderPath, databaseName));

            MessageBox.Show("Phục hồi hoàn tất.");
        }
        private void RestoreMongoDB(string backupFolderPath, string databaseName)
        {
            Process process = new Process();
            process.StartInfo.FileName = "mongorestore";
            process.StartInfo.Arguments = $"--db {databaseName} {backupFolderPath}";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
