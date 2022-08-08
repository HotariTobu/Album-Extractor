namespace Album_Extractor
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FromBox = new System.Windows.Forms.TextBox();
            this.ToBox = new System.Windows.Forms.TextBox();
            this.FromBrowse = new System.Windows.Forms.Button();
            this.ToBrowse = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.FromBrowseDialog = new System.Windows.Forms.OpenFileDialog();
            this.ToBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.F = new System.Windows.Forms.NumericUpDown();
            this.S = new System.Windows.Forms.NumericUpDown();
            this.CheckBox = new System.Windows.Forms.CheckBox();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.F)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S)).BeginInit();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FromBox
            // 
            this.FromBox.AllowDrop = true;
            this.FromBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FromBox.Location = new System.Drawing.Point(12, 12);
            this.FromBox.Name = "FromBox";
            this.FromBox.Size = new System.Drawing.Size(391, 19);
            this.FromBox.TabIndex = 2;
            this.FromBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FromBox_DragDrop);
            this.FromBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FromBox_DragEnter);
            // 
            // ToBox
            // 
            this.ToBox.AllowDrop = true;
            this.ToBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToBox.Location = new System.Drawing.Point(12, 37);
            this.ToBox.Name = "ToBox";
            this.ToBox.Size = new System.Drawing.Size(391, 19);
            this.ToBox.TabIndex = 3;
            this.ToBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToBox_DragDrop);
            this.ToBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ToBox_DragEnter);
            // 
            // FromBrowse
            // 
            this.FromBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromBrowse.Location = new System.Drawing.Point(409, 10);
            this.FromBrowse.Name = "FromBrowse";
            this.FromBrowse.Size = new System.Drawing.Size(75, 23);
            this.FromBrowse.TabIndex = 4;
            this.FromBrowse.Text = "参照";
            this.FromBrowse.UseVisualStyleBackColor = true;
            this.FromBrowse.Click += new System.EventHandler(this.FromBrowse_Click);
            // 
            // ToBrowse
            // 
            this.ToBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToBrowse.Location = new System.Drawing.Point(409, 35);
            this.ToBrowse.Name = "ToBrowse";
            this.ToBrowse.Size = new System.Drawing.Size(75, 23);
            this.ToBrowse.TabIndex = 5;
            this.ToBrowse.Text = "参照";
            this.ToBrowse.UseVisualStyleBackColor = true;
            this.ToBrowse.Click += new System.EventHandler(this.ToBrowse_Click);
            // 
            // RunButton
            // 
            this.RunButton.AllowDrop = true;
            this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunButton.Location = new System.Drawing.Point(409, 64);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 6;
            this.RunButton.Text = "スタート";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            this.RunButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.RunButton_DragDrop);
            this.RunButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.RunButton_DragEnter);
            // 
            // FromBrowseDialog
            // 
            this.FromBrowseDialog.FileName = "openFileDialog1";
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.Location = new System.Drawing.Point(12, 66);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(391, 19);
            this.LogBox.TabIndex = 7;
            // 
            // F
            // 
            this.F.Location = new System.Drawing.Point(6, 22);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(120, 19);
            this.F.TabIndex = 8;
            this.F.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.F.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // S
            // 
            this.S.Location = new System.Drawing.Point(132, 22);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(120, 19);
            this.S.TabIndex = 9;
            this.S.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.S.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSize = true;
            this.CheckBox.Location = new System.Drawing.Point(18, 91);
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Size = new System.Drawing.Size(82, 16);
            this.CheckBox.TabIndex = 10;
            this.CheckBox.Text = "高度な設定";
            this.CheckBox.UseVisualStyleBackColor = true;
            this.CheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.S);
            this.GroupBox.Controls.Add(this.F);
            this.GroupBox.Enabled = false;
            this.GroupBox.Location = new System.Drawing.Point(12, 93);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(472, 50);
            this.GroupBox.TabIndex = 11;
            this.GroupBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 155);
            this.Controls.Add(this.CheckBox);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.ToBrowse);
            this.Controls.Add(this.FromBrowse);
            this.Controls.Add(this.ToBox);
            this.Controls.Add(this.FromBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 194);
            this.MinimumSize = new System.Drawing.Size(436, 194);
            this.Name = "MainForm";
            this.Text = "Album-Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.F)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S)).EndInit();
            this.GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FromBox;
        private System.Windows.Forms.TextBox ToBox;
        private System.Windows.Forms.Button FromBrowse;
        private System.Windows.Forms.Button ToBrowse;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.OpenFileDialog FromBrowseDialog;
        private System.Windows.Forms.FolderBrowserDialog ToBrowseDialog;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.NumericUpDown F;
        private System.Windows.Forms.NumericUpDown S;
        private System.Windows.Forms.CheckBox CheckBox;
        private System.Windows.Forms.GroupBox GroupBox;
    }
}

