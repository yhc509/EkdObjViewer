namespace EkdObjViewer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.background = new System.Windows.Forms.PictureBox();
            this.SpeedSelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveBattleButton = new System.Windows.Forms.Button();
            this.Face = new System.Windows.Forms.PictureBox();
            this.FaceLarge = new System.Windows.Forms.PictureBox();
            this.PmapObj = new System.Windows.Forms.PictureBox();
            this.SavePmapButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.BgSelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Face)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PmapObj)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Location = new System.Drawing.Point(237, 147);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(210, 280);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.background.TabIndex = 14;
            this.background.TabStop = false;
            // 
            // SpeedSelectBox
            // 
            this.SpeedSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpeedSelectBox.FormattingEnabled = true;
            this.SpeedSelectBox.Items.AddRange(new object[] {
            "x0.5",
            "x1.0",
            "x2.0",
            "x4.0"});
            this.SpeedSelectBox.Location = new System.Drawing.Point(309, 11);
            this.SpeedSelectBox.Name = "SpeedSelectBox";
            this.SpeedSelectBox.Size = new System.Drawing.Size(138, 20);
            this.SpeedSelectBox.TabIndex = 16;
            this.SpeedSelectBox.SelectedIndexChanged += new System.EventHandler(this.SpeedSelectBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "재생속도";
            // 
            // SaveBattleButton
            // 
            this.SaveBattleButton.Location = new System.Drawing.Point(238, 50);
            this.SaveBattleButton.Name = "SaveBattleButton";
            this.SaveBattleButton.Size = new System.Drawing.Size(209, 35);
            this.SaveBattleButton.TabIndex = 18;
            this.SaveBattleButton.Text = "전투조형 샘플 저장";
            this.SaveBattleButton.UseVisualStyleBackColor = true;
            this.SaveBattleButton.Click += new System.EventHandler(this.SaveGIFButton_Click);
            // 
            // Face
            // 
            this.Face.Location = new System.Drawing.Point(52, 16);
            this.Face.Name = "Face";
            this.Face.Size = new System.Drawing.Size(120, 120);
            this.Face.TabIndex = 19;
            this.Face.TabStop = false;
            // 
            // FaceLarge
            // 
            this.FaceLarge.Location = new System.Drawing.Point(16, 156);
            this.FaceLarge.Name = "FaceLarge";
            this.FaceLarge.Size = new System.Drawing.Size(196, 280);
            this.FaceLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FaceLarge.TabIndex = 21;
            this.FaceLarge.TabStop = false;
            // 
            // PmapObj
            // 
            this.PmapObj.BackColor = System.Drawing.SystemColors.Control;
            this.PmapObj.Location = new System.Drawing.Point(455, 3);
            this.PmapObj.Name = "PmapObj";
            this.PmapObj.Size = new System.Drawing.Size(640, 456);
            this.PmapObj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PmapObj.TabIndex = 22;
            this.PmapObj.TabStop = false;
            // 
            // SavePmapButton
            // 
            this.SavePmapButton.Location = new System.Drawing.Point(238, 91);
            this.SavePmapButton.Name = "SavePmapButton";
            this.SavePmapButton.Size = new System.Drawing.Size(209, 35);
            this.SavePmapButton.TabIndex = 23;
            this.SavePmapButton.Text = "평상조형 샘플 저장";
            this.SavePmapButton.UseVisualStyleBackColor = true;
            this.SavePmapButton.Click += new System.EventHandler(this.SavePmapButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.정보ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1119, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.파일ToolStripMenuItem.Text = "열기 (&O)";
            this.파일ToolStripMenuItem.Click += new System.EventHandler(this.파일ToolStripMenuItem_Click);
            // 
            // 정보ToolStripMenuItem
            // 
            this.정보ToolStripMenuItem.Name = "정보ToolStripMenuItem";
            this.정보ToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.정보ToolStripMenuItem.Text = "정보 (&I)";
            this.정보ToolStripMenuItem.Click += new System.EventHandler(this.정보ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BgSelector);
            this.panel1.Controls.Add(this.Face);
            this.panel1.Controls.Add(this.PmapObj);
            this.panel1.Controls.Add(this.SavePmapButton);
            this.panel1.Controls.Add(this.background);
            this.panel1.Controls.Add(this.FaceLarge);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SpeedSelectBox);
            this.panel1.Controls.Add(this.SaveBattleButton);
            this.panel1.Location = new System.Drawing.Point(9, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 467);
            this.panel1.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "배경";
            // 
            // BgSelector
            // 
            this.BgSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BgSelector.ForeColor = System.Drawing.Color.Black;
            this.BgSelector.FormattingEnabled = true;
            this.BgSelector.Location = new System.Drawing.Point(309, 433);
            this.BgSelector.Name = "BgSelector";
            this.BgSelector.Size = new System.Drawing.Size(138, 20);
            this.BgSelector.TabIndex = 24;
            this.BgSelector.SelectedIndexChanged += new System.EventHandler(this.BgSelector_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 499);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "조조전 조형 뷰어";
            this.Load += new System.EventHandler(this.MainForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Face)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PmapObj)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.ComboBox SpeedSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveBattleButton;
        private System.Windows.Forms.PictureBox Face;
        private System.Windows.Forms.PictureBox FaceLarge;
        private System.Windows.Forms.PictureBox PmapObj;
        private System.Windows.Forms.Button SavePmapButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BgSelector;
    }
}

