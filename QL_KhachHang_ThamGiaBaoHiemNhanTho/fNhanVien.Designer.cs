namespace QL_KhachHang_ThamGiaBaoHiemNhanTho
{
    partial class fNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconTKNV = new FontAwesome.Sharp.IconButton();
            this.iconHuyNV = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.iconUpdateNV = new FontAwesome.Sharp.IconButton();
            this.iconAddNV = new FontAwesome.Sharp.IconButton();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.txtmaNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 303);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(419, 303);
            this.dataGridView1.TabIndex = 48;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "maNhanVien";
            this.Column1.HeaderText = "Mã Nhân Viên";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tenNhanVien";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên Nhân Viên";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "soDienThoaiNhanVien";
            this.dataGridViewTextBoxColumn2.HeaderText = "Số Điện Thoại";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.iconTKNV);
            this.panel2.Controls.Add(this.iconHuyNV);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.iconUpdateNV);
            this.panel2.Controls.Add(this.iconAddNV);
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.txtTenNV);
            this.panel2.Controls.Add(this.txtmaNV);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 216);
            this.panel2.TabIndex = 50;
            // 
            // iconTKNV
            // 
            this.iconTKNV.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.iconTKNV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconTKNV.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconTKNV.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconTKNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconTKNV.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconTKNV.IconColor = System.Drawing.Color.Black;
            this.iconTKNV.IconSize = 25;
            this.iconTKNV.Location = new System.Drawing.Point(333, 129);
            this.iconTKNV.Name = "iconTKNV";
            this.iconTKNV.Rotation = 0D;
            this.iconTKNV.Size = new System.Drawing.Size(70, 60);
            this.iconTKNV.TabIndex = 71;
            this.iconTKNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconTKNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconTKNV.UseVisualStyleBackColor = false;
            this.iconTKNV.Click += new System.EventHandler(this.iconTKNV_Click);
            // 
            // iconHuyNV
            // 
            this.iconHuyNV.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.iconHuyNV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconHuyNV.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconHuyNV.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconHuyNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconHuyNV.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.iconHuyNV.IconColor = System.Drawing.Color.Black;
            this.iconHuyNV.IconSize = 25;
            this.iconHuyNV.Location = new System.Drawing.Point(232, 129);
            this.iconHuyNV.Name = "iconHuyNV";
            this.iconHuyNV.Rotation = 0D;
            this.iconHuyNV.Size = new System.Drawing.Size(70, 60);
            this.iconHuyNV.TabIndex = 70;
            this.iconHuyNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconHuyNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconHuyNV.UseVisualStyleBackColor = false;
            this.iconHuyNV.Click += new System.EventHandler(this.iconHuyNV_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(19, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 19);
            this.label5.TabIndex = 58;
            this.label5.Text = "Số Điện Thoại";
            // 
            // iconUpdateNV
            // 
            this.iconUpdateNV.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.iconUpdateNV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconUpdateNV.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconUpdateNV.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconUpdateNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconUpdateNV.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.iconUpdateNV.IconColor = System.Drawing.Color.Black;
            this.iconUpdateNV.IconSize = 25;
            this.iconUpdateNV.Location = new System.Drawing.Point(123, 129);
            this.iconUpdateNV.Name = "iconUpdateNV";
            this.iconUpdateNV.Rotation = 0D;
            this.iconUpdateNV.Size = new System.Drawing.Size(70, 60);
            this.iconUpdateNV.TabIndex = 69;
            this.iconUpdateNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconUpdateNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconUpdateNV.UseVisualStyleBackColor = false;
            this.iconUpdateNV.Click += new System.EventHandler(this.iconUpdateNV_Click);
            // 
            // iconAddNV
            // 
            this.iconAddNV.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.iconAddNV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconAddNV.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconAddNV.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.iconAddNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconAddNV.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconAddNV.IconColor = System.Drawing.Color.Black;
            this.iconAddNV.IconSize = 25;
            this.iconAddNV.Location = new System.Drawing.Point(16, 129);
            this.iconAddNV.Name = "iconAddNV";
            this.iconAddNV.Rotation = 0D;
            this.iconAddNV.Size = new System.Drawing.Size(70, 60);
            this.iconAddNV.TabIndex = 68;
            this.iconAddNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconAddNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconAddNV.UseVisualStyleBackColor = false;
            this.iconAddNV.Click += new System.EventHandler(this.iconAddNV_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(160, 81);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(223, 22);
            this.txtSDT.TabIndex = 57;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(160, 43);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(223, 22);
            this.txtTenNV.TabIndex = 56;
            // 
            // txtmaNV
            // 
            this.txtmaNV.Location = new System.Drawing.Point(160, 8);
            this.txtmaNV.Name = "txtmaNV";
            this.txtmaNV.Size = new System.Drawing.Size(223, 22);
            this.txtmaNV.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(21, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 54;
            this.label4.Text = "Tên Nhân Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 53;
            this.label3.Text = "Mã Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 51;
            this.label1.Text = "Danh Sách Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 19);
            this.label2.TabIndex = 52;
            this.label2.Text = "Thông Tin Nhân Viên";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView1);
            this.panel3.Location = new System.Drawing.Point(469, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(479, 553);
            this.panel3.TabIndex = 53;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(479, 553);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(465, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 19);
            this.label6.TabIndex = 54;
            this.label6.Text = "Danh Sách Khách Hàng";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(666, 6);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(52, 22);
            this.count.TabIndex = 55;
            // 
            // fNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1116, 609);
            this.Controls.Add(this.count);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "fNhanVien";
            this.Text = "Quản Lý Nhân Viên";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtmaNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconHuyNV;
        private FontAwesome.Sharp.IconButton iconUpdateNV;
        private FontAwesome.Sharp.IconButton iconAddNV;
        private FontAwesome.Sharp.IconButton iconTKNV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox count;
    }
}