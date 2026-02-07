namespace SecureDataProtectionTool.UI;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.Label lblSystemInfo;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private System.Windows.Forms.Button btnFileEncryption;
    private System.Windows.Forms.Button btnFileDecryption;
    private System.Windows.Forms.Button btnTextEncryption;
    private System.Windows.Forms.Button btnTextDecryption;
    private System.Windows.Forms.Button btnLogs;
    private System.Windows.Forms.Button btnSettings;
    private System.Windows.Forms.Button btnPasswordGenerator;
    private System.Windows.Forms.Button btnPasswordCracker;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Panel panelStatus;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label lblStats;
    private System.Windows.Forms.Label lblLockStatus;
    private System.Windows.Forms.ProgressBar progressBarLock;
    private System.Windows.Forms.Timer timerUpdate;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.LinkLabel linkLabelHelp;
    private System.Windows.Forms.Button btnAbout;
    private System.Windows.Forms.PictureBox pictureBoxLogo;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        panelHeader = new Panel();
        pictureBoxLogo = new PictureBox();
        lblTitle = new Label();
        lblVersion = new Label();
        lblSystemInfo = new Label();
        btnAbout = new Button();
        panelButtons = new Panel();
        tableLayoutPanel = new TableLayoutPanel();
        btnFileEncryption = new Button();
        btnFileDecryption = new Button();
        btnTextEncryption = new Button();
        btnTextDecryption = new Button();
        btnLogs = new Button();
        btnSettings = new Button();
        btnPasswordGenerator = new Button();
        btnPasswordCracker = new Button();
        btnExit = new Button();
        panelStatus = new Panel();
        lblStatus = new Label();
        lblStats = new Label();
        lblLockStatus = new Label();
        progressBarLock = new ProgressBar();
        linkLabelHelp = new LinkLabel();
        timerUpdate = new System.Windows.Forms.Timer(components);
        toolTip = new ToolTip(components);
        panelHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
        panelButtons.SuspendLayout();
        tableLayoutPanel.SuspendLayout();
        panelStatus.SuspendLayout();
        SuspendLayout();
        
        // panelHeader
        panelHeader.BackColor = Color.FromArgb(30, 30, 40);
        panelHeader.Controls.Add(pictureBoxLogo);
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Controls.Add(lblVersion);
        panelHeader.Controls.Add(lblSystemInfo);
        panelHeader.Controls.Add(btnAbout);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(1200, 120);
        panelHeader.TabIndex = 0;
        
        // pictureBoxLogo
        pictureBoxLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        pictureBoxLogo.Image = null;
        pictureBoxLogo.Location = new Point(20, 20);
        pictureBoxLogo.Name = "pictureBoxLogo";
        pictureBoxLogo.Size = new Size(80, 80);
        pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBoxLogo.TabIndex = 0;
        pictureBoxLogo.TabStop = false;
        
        // lblTitle
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(120, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(800, 40);
        lblTitle.TabIndex = 1;
        lblTitle.Text = "أداة حماية الملفات والبيانات الآمنة";
        lblTitle.TextAlign = ContentAlignment.MiddleRight;
        
        // lblVersion
        lblVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblVersion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblVersion.ForeColor = Color.LightGray;
        lblVersion.Location = new Point(120, 60);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new Size(800, 25);
        lblVersion.TabIndex = 2;
        lblVersion.Text = "الإصدار: 1.0.0 | .NET 8.0";
        lblVersion.TextAlign = ContentAlignment.MiddleRight;
        
        // lblSystemInfo
        lblSystemInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblSystemInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblSystemInfo.ForeColor = Color.LightGray;
        lblSystemInfo.Location = new Point(120, 85);
        lblSystemInfo.Name = "lblSystemInfo";
        lblSystemInfo.Size = new Size(800, 25);
        lblSystemInfo.TabIndex = 3;
        lblSystemInfo.Text = "النظام: Windows | الذاكرة: 0 MB";
        lblSystemInfo.TextAlign = ContentAlignment.MiddleRight;
        
        // btnAbout
        btnAbout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAbout.BackColor = Color.FromArgb(60, 60, 80);
        btnAbout.FlatStyle = FlatStyle.Flat;
        btnAbout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnAbout.ForeColor = Color.White;
        btnAbout.Location = new Point(1040, 20);
        btnAbout.Name = "btnAbout";
        btnAbout.Size = new Size(140, 35);
        btnAbout.TabIndex = 4;
        btnAbout.Text = "حول التطبيق";
        btnAbout.UseVisualStyleBackColor = false;
        btnAbout.Click += btnAbout_Click;
        
        // panelButtons
        panelButtons.BackColor = Color.FromArgb(40, 40, 50);
        panelButtons.Controls.Add(tableLayoutPanel);
        panelButtons.Dock = DockStyle.Fill;
        panelButtons.Location = new Point(0, 120);
        panelButtons.Name = "panelButtons";
        panelButtons.Padding = new Padding(40, 20, 40, 20);
        panelButtons.Size = new Size(1200, 530);
        panelButtons.TabIndex = 1;
        
        // tableLayoutPanel
        tableLayoutPanel.ColumnCount = 2;
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel.Controls.Add(btnFileEncryption, 0, 0);
        tableLayoutPanel.Controls.Add(btnFileDecryption, 1, 0);
        tableLayoutPanel.Controls.Add(btnTextEncryption, 0, 1);
        tableLayoutPanel.Controls.Add(btnTextDecryption, 1, 1);
        tableLayoutPanel.Controls.Add(btnLogs, 0, 2);
        tableLayoutPanel.Controls.Add(btnSettings, 1, 2);
        tableLayoutPanel.Controls.Add(btnPasswordGenerator, 0, 3);
        tableLayoutPanel.Controls.Add(btnPasswordCracker, 1, 3);
        tableLayoutPanel.Controls.Add(btnExit, 0, 4);
        tableLayoutPanel.Dock = DockStyle.Fill;
        tableLayoutPanel.Location = new Point(40, 20);
        tableLayoutPanel.Name = "tableLayoutPanel";
        tableLayoutPanel.RowCount = 5;
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel.Size = new Size(1120, 490);
        tableLayoutPanel.TabIndex = 0;
        
        // btnFileEncryption
        btnFileEncryption.BackColor = Color.FromArgb(0, 123, 255);
        btnFileEncryption.Dock = DockStyle.Fill;
        btnFileEncryption.FlatStyle = FlatStyle.Flat;
        btnFileEncryption.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnFileEncryption.ForeColor = Color.White;
        btnFileEncryption.Image = null;
        btnFileEncryption.ImageAlign = ContentAlignment.MiddleLeft;
        btnFileEncryption.Location = new Point(3, 3);
        btnFileEncryption.Margin = new Padding(3, 3, 10, 10);
        btnFileEncryption.Name = "btnFileEncryption";
        btnFileEncryption.Size = new Size(547, 88);
        btnFileEncryption.TabIndex = 0;
        btnFileEncryption.Text = "🔒 تشفير الملفات";
        btnFileEncryption.TextAlign = ContentAlignment.MiddleRight;
        btnFileEncryption.UseVisualStyleBackColor = false;
        btnFileEncryption.Click += btnFileEncryption_Click;
        
        // btnFileDecryption
        btnFileDecryption.BackColor = Color.FromArgb(40, 167, 69);
        btnFileDecryption.Dock = DockStyle.Fill;
        btnFileDecryption.FlatStyle = FlatStyle.Flat;
        btnFileDecryption.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnFileDecryption.ForeColor = Color.White;
        btnFileDecryption.Image = null;
        btnFileDecryption.ImageAlign = ContentAlignment.MiddleLeft;
        btnFileDecryption.Location = new Point(560, 3);
        btnFileDecryption.Margin = new Padding(10, 3, 3, 10);
        btnFileDecryption.Name = "btnFileDecryption";
        btnFileDecryption.Size = new Size(557, 88);
        btnFileDecryption.TabIndex = 1;
        btnFileDecryption.Text = "🔓 فك تشفير الملفات";
        btnFileDecryption.TextAlign = ContentAlignment.MiddleRight;
        btnFileDecryption.UseVisualStyleBackColor = false;
        btnFileDecryption.Click += btnFileDecryption_Click;
        
        // btnTextEncryption
        btnTextEncryption.BackColor = Color.FromArgb(111, 66, 193);
        btnTextEncryption.Dock = DockStyle.Fill;
        btnTextEncryption.FlatStyle = FlatStyle.Flat;
        btnTextEncryption.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnTextEncryption.ForeColor = Color.White;
        btnTextEncryption.Image = null;
        btnTextEncryption.ImageAlign = ContentAlignment.MiddleLeft;
        btnTextEncryption.Location = new Point(3, 101);
        btnTextEncryption.Margin = new Padding(3, 0, 10, 10);
        btnTextEncryption.Name = "btnTextEncryption";
        btnTextEncryption.Size = new Size(547, 88);
        btnTextEncryption.TabIndex = 2;
        btnTextEncryption.Text = "🔒 تشفير النصوص";
        btnTextEncryption.TextAlign = ContentAlignment.MiddleRight;
        btnTextEncryption.UseVisualStyleBackColor = false;
        btnTextEncryption.Click += btnTextEncryption_Click;
        
        // btnTextDecryption
        btnTextDecryption.BackColor = Color.FromArgb(255, 193, 7);
        btnTextDecryption.Dock = DockStyle.Fill;
        btnTextDecryption.FlatStyle = FlatStyle.Flat;
        btnTextDecryption.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnTextDecryption.ForeColor = Color.Black;
        btnTextDecryption.Image = null;
        btnTextDecryption.ImageAlign = ContentAlignment.MiddleLeft;
        btnTextDecryption.Location = new Point(560, 101);
        btnTextDecryption.Margin = new Padding(10, 0, 3, 10);
        btnTextDecryption.Name = "btnTextDecryption";
        btnTextDecryption.Size = new Size(557, 88);
        btnTextDecryption.TabIndex = 3;
        btnTextDecryption.Text = "🔓 فك تشفير النصوص";
        btnTextDecryption.TextAlign = ContentAlignment.MiddleRight;
        btnTextDecryption.UseVisualStyleBackColor = false;
        btnTextDecryption.Click += btnTextDecryption_Click;
        
        // btnLogs
        btnLogs.BackColor = Color.FromArgb(108, 117, 125);
        btnLogs.Dock = DockStyle.Fill;
        btnLogs.FlatStyle = FlatStyle.Flat;
        btnLogs.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnLogs.ForeColor = Color.White;
        btnLogs.Image = null;
        btnLogs.ImageAlign = ContentAlignment.MiddleLeft;
        btnLogs.Location = new Point(3, 199);
        btnLogs.Margin = new Padding(3, 0, 10, 10);
        btnLogs.Name = "btnLogs";
        btnLogs.Size = new Size(547, 88);
        btnLogs.TabIndex = 4;
        btnLogs.Text = "📊 سجلات النظام";
        btnLogs.TextAlign = ContentAlignment.MiddleRight;
        btnLogs.UseVisualStyleBackColor = false;
        btnLogs.Click += btnLogs_Click;
        
        // btnSettings
        btnSettings.BackColor = Color.FromArgb(23, 162, 184);
        btnSettings.Dock = DockStyle.Fill;
        btnSettings.FlatStyle = FlatStyle.Flat;
        btnSettings.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnSettings.ForeColor = Color.White;
        btnSettings.Image = null;
        btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
        btnSettings.Location = new Point(560, 199);
        btnSettings.Margin = new Padding(10, 0, 3, 10);
        btnSettings.Name = "btnSettings";
        btnSettings.Size = new Size(557, 88);
        btnSettings.TabIndex = 5;
        btnSettings.Text = "⚙️ الإعدادات";
        btnSettings.TextAlign = ContentAlignment.MiddleRight;
        btnSettings.UseVisualStyleBackColor = false;
        btnSettings.Click += btnSettings_Click;
        
        // btnPasswordGenerator
        btnPasswordGenerator.BackColor = Color.FromArgb(255, 193, 7);
        btnPasswordGenerator.Dock = DockStyle.Fill;
        btnPasswordGenerator.FlatStyle = FlatStyle.Flat;
        btnPasswordGenerator.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnPasswordGenerator.ForeColor = Color.Black;
        btnPasswordGenerator.Image = null;
        btnPasswordGenerator.ImageAlign = ContentAlignment.MiddleLeft;
        btnPasswordGenerator.Location = new Point(3, 297);
        btnPasswordGenerator.Margin = new Padding(3, 0, 10, 10);
        btnPasswordGenerator.Name = "btnPasswordGenerator";
        btnPasswordGenerator.Size = new Size(547, 88);
        btnPasswordGenerator.TabIndex = 6;
        btnPasswordGenerator.Text = "🔑 توليد كلمات المرور";
        btnPasswordGenerator.TextAlign = ContentAlignment.MiddleRight;
        btnPasswordGenerator.UseVisualStyleBackColor = false;
        btnPasswordGenerator.Click += btnPasswordGenerator_Click;
        
        // btnPasswordCracker
        btnPasswordCracker.BackColor = Color.FromArgb(220, 53, 69);
        btnPasswordCracker.Dock = DockStyle.Fill;
        btnPasswordCracker.FlatStyle = FlatStyle.Flat;
        btnPasswordCracker.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnPasswordCracker.ForeColor = Color.White;
        btnPasswordCracker.Image = null;
        btnPasswordCracker.ImageAlign = ContentAlignment.MiddleLeft;
        btnPasswordCracker.Location = new Point(560, 297);
        btnPasswordCracker.Margin = new Padding(10, 0, 3, 10);
        btnPasswordCracker.Name = "btnPasswordCracker";
        btnPasswordCracker.Size = new Size(557, 88);
        btnPasswordCracker.TabIndex = 7;
        btnPasswordCracker.Text = "🔓 اختبار قوة كلمات المرور";
        btnPasswordCracker.TextAlign = ContentAlignment.MiddleRight;
        btnPasswordCracker.UseVisualStyleBackColor = false;
        btnPasswordCracker.Click += btnPasswordCracker_Click;
        
        // btnExit
        btnExit.BackColor = Color.FromArgb(52, 58, 64);
        tableLayoutPanel.SetColumnSpan(btnExit, 2);
        btnExit.Dock = DockStyle.Fill;
        btnExit.FlatStyle = FlatStyle.Flat;
        btnExit.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnExit.ForeColor = Color.White;
        btnExit.Image = null;
        btnExit.ImageAlign = ContentAlignment.MiddleLeft;
        btnExit.Location = new Point(3, 395);
        btnExit.Margin = new Padding(3, 0, 3, 3);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(1114, 92);
        btnExit.TabIndex = 8;
        btnExit.Text = "🚪 خروج";
        btnExit.TextAlign = ContentAlignment.MiddleRight;
        btnExit.UseVisualStyleBackColor = false;
        btnExit.Click += btnExit_Click;
        
        // panelStatus
        panelStatus.BackColor = Color.FromArgb(30, 30, 40);
        panelStatus.Controls.Add(lblStatus);
        panelStatus.Controls.Add(lblStats);
        panelStatus.Controls.Add(lblLockStatus);
        panelStatus.Controls.Add(progressBarLock);
        panelStatus.Controls.Add(linkLabelHelp);
        panelStatus.Dock = DockStyle.Bottom;
        panelStatus.Location = new Point(0, 650);
        panelStatus.Name = "panelStatus";
        panelStatus.Size = new Size(1200, 50);
        panelStatus.TabIndex = 2;
        
        // lblStatus
        lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblStatus.ForeColor = Color.White;
        lblStatus.Location = new Point(20, 15);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(300, 20);
        lblStatus.TabIndex = 0;
        lblStatus.Text = "الحالة: جاهز";
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        
        // lblStats
        lblStats.Anchor = AnchorStyles.Bottom;
        lblStats.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblStats.ForeColor = Color.LightGray;
        lblStats.Location = new Point(400, 15);
        lblStats.Name = "lblStats";
        lblStats.Size = new Size(400, 20);
        lblStats.TabIndex = 1;
        lblStats.Text = "آخر 7 أيام: 0 ✓ | 0 ✗";
        lblStats.TextAlign = ContentAlignment.MiddleCenter;
        
        // lblLockStatus
        lblLockStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        lblLockStatus.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblLockStatus.ForeColor = Color.Yellow;
        lblLockStatus.Location = new Point(780, 5);
        lblLockStatus.Name = "lblLockStatus";
        lblLockStatus.Size = new Size(200, 15);
        lblLockStatus.TabIndex = 2;
        lblLockStatus.Text = "سيتم القفل بعد: 300 ثانية";
        lblLockStatus.TextAlign = ContentAlignment.MiddleRight;
        
        // progressBarLock
        progressBarLock.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        progressBarLock.Location = new Point(780, 25);
        progressBarLock.Name = "progressBarLock";
        progressBarLock.Size = new Size(200, 15);
        progressBarLock.Style = ProgressBarStyle.Continuous;
        progressBarLock.TabIndex = 3;
        
        // linkLabelHelp
        linkLabelHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        linkLabelHelp.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        linkLabelHelp.LinkColor = Color.FromArgb(0, 123, 255);
        linkLabelHelp.Location = new Point(1020, 15);
        linkLabelHelp.Name = "linkLabelHelp";
        linkLabelHelp.Size = new Size(160, 20);
        linkLabelHelp.TabIndex = 4;
        linkLabelHelp.TabStop = true;
        linkLabelHelp.Text = "مساعدة ودعم فني";
        linkLabelHelp.TextAlign = ContentAlignment.MiddleRight;
        linkLabelHelp.LinkClicked += linkLabelHelp_LinkClicked;
        
        // timerUpdate
        timerUpdate.Interval = 1000;
        timerUpdate.Tick += timerUpdate_Tick;
        timerUpdate.Enabled = true;
        
        // MainForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(25, 25, 35);
        ClientSize = new Size(1200, 700);
        Controls.Add(panelButtons);
        Controls.Add(panelStatus);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        FormBorderStyle = FormBorderStyle.Sizable;
        Icon = null;
        MaximizeBox = true;
        MinimizeBox = true;
        MinimumSize = new Size(1024, 700);
        Name = "MainForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "أداة حماية الملفات والبيانات الآمنة";
        FormClosing += MainForm_FormClosing;
        panelHeader.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
        panelButtons.ResumeLayout(false);
        tableLayoutPanel.ResumeLayout(false);
        panelStatus.ResumeLayout(false);
        ResumeLayout(false);
    }
}