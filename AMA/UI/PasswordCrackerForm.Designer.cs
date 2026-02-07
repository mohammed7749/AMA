namespace SecureDataProtectionTool.UI;

partial class PasswordCrackerForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
    private System.Windows.Forms.GroupBox grpAttackType;
    private System.Windows.Forms.GroupBox grpTarget;
    private System.Windows.Forms.GroupBox grpOptions;
    private System.Windows.Forms.GroupBox grpWordlist;
    private System.Windows.Forms.GroupBox grpProgress;
    private System.Windows.Forms.GroupBox grpResults;
    private System.Windows.Forms.Label lblTargetHash;
    private System.Windows.Forms.Label lblAlgorithm;
    private System.Windows.Forms.Label lblMinLength;
    private System.Windows.Forms.Label lblMaxLength;
    private System.Windows.Forms.Label lblCharset;
    private System.Windows.Forms.Label lblWordlistFile;
    private System.Windows.Forms.RadioButton radDictionary;
    private System.Windows.Forms.RadioButton radBruteForce;
    private System.Windows.Forms.RadioButton radHash;
    private System.Windows.Forms.Button btnLoadWordlist;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.Button btnGenerateCommon;
    private System.Windows.Forms.Button btnClearWordlist;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.ComboBox cmbAlgorithm;
    private System.Windows.Forms.ComboBox cmbCharset;
    private System.Windows.Forms.NumericUpDown numMinLength;
    private System.Windows.Forms.NumericUpDown numMaxLength;
    private System.Windows.Forms.TextBox txtTargetHash;
    private System.Windows.Forms.TextBox txtWordlistFile;
    private System.Windows.Forms.TextBox txtResults;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label lblAttempts;
    private System.Windows.Forms.Label lblSpeed;
    private System.Windows.Forms.Label lblElapsed;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label lblWordlistCount;
    private System.Windows.Forms.TableLayoutPanel tableLayoutTop;
    private System.Windows.Forms.TableLayoutPanel tableLayoutControls;
    private System.Windows.Forms.TableLayoutPanel tableLayoutProgress;
    private System.Windows.Forms.TableLayoutPanel tableLayoutButtons;
    
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
        this.components = new System.ComponentModel.Container();
        this.panelHeader = new System.Windows.Forms.Panel();
        this.lblTitle = new System.Windows.Forms.Label();
        this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
        this.tableLayoutTop = new System.Windows.Forms.TableLayoutPanel();
        this.grpAttackType = new System.Windows.Forms.GroupBox();
        this.radHash = new System.Windows.Forms.RadioButton();
        this.radBruteForce = new System.Windows.Forms.RadioButton();
        this.radDictionary = new System.Windows.Forms.RadioButton();
        this.tableLayoutControls = new System.Windows.Forms.TableLayoutPanel();
        this.grpTarget = new System.Windows.Forms.GroupBox();
        this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
        this.lblAlgorithm = new System.Windows.Forms.Label();
        this.txtTargetHash = new System.Windows.Forms.TextBox();
        this.lblTargetHash = new System.Windows.Forms.Label();
        this.grpOptions = new System.Windows.Forms.GroupBox();
        this.numMaxLength = new System.Windows.Forms.NumericUpDown();
        this.lblMaxLength = new System.Windows.Forms.Label();
        this.numMinLength = new System.Windows.Forms.NumericUpDown();
        this.lblMinLength = new System.Windows.Forms.Label();
        this.cmbCharset = new System.Windows.Forms.ComboBox();
        this.lblCharset = new System.Windows.Forms.Label();
        this.grpWordlist = new System.Windows.Forms.GroupBox();
        this.lblWordlistCount = new System.Windows.Forms.Label();
        this.btnClearWordlist = new System.Windows.Forms.Button();
        this.btnGenerateCommon = new System.Windows.Forms.Button();
        this.btnBrowse = new System.Windows.Forms.Button();
        this.btnLoadWordlist = new System.Windows.Forms.Button();
        this.txtWordlistFile = new System.Windows.Forms.TextBox();
        this.lblWordlistFile = new System.Windows.Forms.Label();
        this.tableLayoutProgress = new System.Windows.Forms.TableLayoutPanel();
        this.grpProgress = new System.Windows.Forms.GroupBox();
        this.lblStatus = new System.Windows.Forms.Label();
        this.lblElapsed = new System.Windows.Forms.Label();
        this.lblSpeed = new System.Windows.Forms.Label();
        this.lblAttempts = new System.Windows.Forms.Label();
        this.progressBar = new System.Windows.Forms.ProgressBar();
        this.grpResults = new System.Windows.Forms.GroupBox();
        this.txtResults = new System.Windows.Forms.TextBox();
        this.tableLayoutButtons = new System.Windows.Forms.TableLayoutPanel();
        this.btnStart = new System.Windows.Forms.Button();
        this.btnStop = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.panelHeader.SuspendLayout();
        this.tableLayoutMain.SuspendLayout();
        this.tableLayoutTop.SuspendLayout();
        this.grpAttackType.SuspendLayout();
        this.tableLayoutControls.SuspendLayout();
        this.grpTarget.SuspendLayout();
        this.grpOptions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numMaxLength)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numMinLength)).BeginInit();
        this.grpWordlist.SuspendLayout();
        this.tableLayoutProgress.SuspendLayout();
        this.grpProgress.SuspendLayout();
        this.grpResults.SuspendLayout();
        this.tableLayoutButtons.SuspendLayout();
        this.SuspendLayout();
        // 
        // panelHeader
        // 
        this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.panelHeader.Controls.Add(this.lblTitle);
        this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelHeader.Location = new System.Drawing.Point(0, 0);
        this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
        this.panelHeader.Name = "panelHeader";
        this.panelHeader.Size = new System.Drawing.Size(1000, 60);
        this.panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.White;
        this.lblTitle.Location = new System.Drawing.Point(0, 0);
        this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(1000, 60);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "اختبار قوة كلمات المرور";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // tableLayoutMain
        // 
        this.tableLayoutMain.ColumnCount = 1;
        this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutMain.Controls.Add(this.tableLayoutTop, 0, 0);
        this.tableLayoutMain.Controls.Add(this.tableLayoutProgress, 0, 1);
        this.tableLayoutMain.Controls.Add(this.grpResults, 0, 2);
        this.tableLayoutMain.Controls.Add(this.tableLayoutButtons, 0, 3);
        this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutMain.Location = new System.Drawing.Point(0, 60);
        this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(0);
        this.tableLayoutMain.Name = "tableLayoutMain";
        this.tableLayoutMain.RowCount = 4;
        this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
        this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
        this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
        this.tableLayoutMain.Size = new System.Drawing.Size(1000, 740);
        this.tableLayoutMain.TabIndex = 1;
        // 
        // tableLayoutTop
        // 
        this.tableLayoutTop.ColumnCount = 2;
        this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        this.tableLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
        this.tableLayoutTop.Controls.Add(this.grpAttackType, 0, 0);
        this.tableLayoutTop.Controls.Add(this.tableLayoutControls, 1, 0);
        this.tableLayoutTop.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutTop.Location = new System.Drawing.Point(10, 10);
        this.tableLayoutTop.Margin = new System.Windows.Forms.Padding(10);
        this.tableLayoutTop.Name = "tableLayoutTop";
        this.tableLayoutTop.RowCount = 1;
        this.tableLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutTop.Size = new System.Drawing.Size(980, 165);
        this.tableLayoutTop.TabIndex = 0;
        // 
        // grpAttackType
        // 
        this.grpAttackType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpAttackType.Controls.Add(this.radHash);
        this.grpAttackType.Controls.Add(this.radBruteForce);
        this.grpAttackType.Controls.Add(this.radDictionary);
        this.grpAttackType.ForeColor = System.Drawing.Color.White;
        this.grpAttackType.Location = new System.Drawing.Point(3, 3);
        this.grpAttackType.Name = "grpAttackType";
        this.grpAttackType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpAttackType.Size = new System.Drawing.Size(288, 159);
        this.grpAttackType.TabIndex = 0;
        this.grpAttackType.TabStop = false;
        this.grpAttackType.Text = "نوع الهجوم";
        // 
        // radHash
        // 
        this.radHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.radHash.AutoSize = true;
        this.radHash.Location = new System.Drawing.Point(30, 90);
        this.radHash.Name = "radHash";
        this.radHash.Size = new System.Drawing.Size(252, 24);
        this.radHash.TabIndex = 2;
        this.radHash.Text = "تجزئة";
        this.radHash.UseVisualStyleBackColor = true;
        // 
        // radBruteForce
        // 
        this.radBruteForce.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.radBruteForce.AutoSize = true;
        this.radBruteForce.Location = new System.Drawing.Point(30, 60);
        this.radBruteForce.Name = "radBruteForce";
        this.radBruteForce.Size = new System.Drawing.Size(252, 24);
        this.radBruteForce.TabIndex = 1;
        this.radBruteForce.Text = "هجوم القوة الغاشمة";
        this.radBruteForce.UseVisualStyleBackColor = true;
        // 
        // radDictionary
        // 
        this.radDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.radDictionary.AutoSize = true;
        this.radDictionary.Checked = true;
        this.radDictionary.Location = new System.Drawing.Point(30, 30);
        this.radDictionary.Name = "radDictionary";
        this.radDictionary.Size = new System.Drawing.Size(252, 24);
        this.radDictionary.TabIndex = 0;
        this.radDictionary.TabStop = true;
        this.radDictionary.Text = "هجوم القاموس";
        this.radDictionary.UseVisualStyleBackColor = true;
        // 
        // tableLayoutControls
        // 
        this.tableLayoutControls.ColumnCount = 1;
        this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutControls.Controls.Add(this.grpTarget, 0, 0);
        this.tableLayoutControls.Controls.Add(this.grpWordlist, 0, 2);
        this.tableLayoutControls.Controls.Add(this.grpOptions, 0, 1);
        this.tableLayoutControls.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutControls.Location = new System.Drawing.Point(297, 3);
        this.tableLayoutControls.Name = "tableLayoutControls";
        this.tableLayoutControls.RowCount = 3;
        this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        this.tableLayoutControls.Size = new System.Drawing.Size(680, 159);
        this.tableLayoutControls.TabIndex = 1;
        // 
        // grpTarget
        // 
        this.grpTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpTarget.Controls.Add(this.cmbAlgorithm);
        this.grpTarget.Controls.Add(this.lblAlgorithm);
        this.grpTarget.Controls.Add(this.txtTargetHash);
        this.grpTarget.Controls.Add(this.lblTargetHash);
        this.grpTarget.ForeColor = System.Drawing.Color.White;
        this.grpTarget.Location = new System.Drawing.Point(3, 3);
        this.grpTarget.Name = "grpTarget";
        this.grpTarget.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpTarget.Size = new System.Drawing.Size(674, 47);
        this.grpTarget.TabIndex = 0;
        this.grpTarget.TabStop = false;
        this.grpTarget.Text = "الهدف";
        // 
        // cmbAlgorithm
        // 
        this.cmbAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbAlgorithm.FormattingEnabled = true;
        this.cmbAlgorithm.Items.AddRange(new object[] {
        "MD5",
        "SHA1",
        "SHA256",
        "SHA384",
        "SHA512"});
        this.cmbAlgorithm.Location = new System.Drawing.Point(480, 25);
        this.cmbAlgorithm.Name = "cmbAlgorithm";
        this.cmbAlgorithm.Size = new System.Drawing.Size(150, 28);
        this.cmbAlgorithm.TabIndex = 3;
        // 
        // lblAlgorithm
        // 
        this.lblAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblAlgorithm.AutoSize = true;
        this.lblAlgorithm.Location = new System.Drawing.Point(635, 28);
        this.lblAlgorithm.Name = "lblAlgorithm";
        this.lblAlgorithm.Size = new System.Drawing.Size(110, 20);
        this.lblAlgorithm.TabIndex = 2;
        this.lblAlgorithm.Text = "خوارزمية التجزئة:";
        this.lblAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // txtTargetHash
        // 
        this.txtTargetHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtTargetHash.Location = new System.Drawing.Point(20, 25);
        this.txtTargetHash.Name = "txtTargetHash";
        this.txtTargetHash.Size = new System.Drawing.Size(300, 27);
        this.txtTargetHash.TabIndex = 1;
        // 
        // lblTargetHash
        // 
        this.lblTargetHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblTargetHash.AutoSize = true;
        this.lblTargetHash.Location = new System.Drawing.Point(330, 28);
        this.lblTargetHash.Name = "lblTargetHash";
        this.lblTargetHash.Size = new System.Drawing.Size(125, 20);
        this.lblTargetHash.TabIndex = 0;
        this.lblTargetHash.Text = "التجزئة المستهدفة:";
        this.lblTargetHash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // grpOptions
        // 
        this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpOptions.Controls.Add(this.numMaxLength);
        this.grpOptions.Controls.Add(this.lblMaxLength);
        this.grpOptions.Controls.Add(this.numMinLength);
        this.grpOptions.Controls.Add(this.lblMinLength);
        this.grpOptions.Controls.Add(this.cmbCharset);
        this.grpOptions.Controls.Add(this.lblCharset);
        this.grpOptions.ForeColor = System.Drawing.Color.White;
        this.grpOptions.Location = new System.Drawing.Point(3, 56);
        this.grpOptions.Name = "grpOptions";
        this.grpOptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpOptions.Size = new System.Drawing.Size(674, 47);
        this.grpOptions.TabIndex = 1;
        this.grpOptions.TabStop = false;
        this.grpOptions.Text = "خيارات الهجوم";
        // 
        // numMaxLength
        // 
        this.numMaxLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.numMaxLength.Location = new System.Drawing.Point(480, 15);
        this.numMaxLength.Minimum = new decimal(new int[] {
        1,
        0,
        0,
        0});
        this.numMaxLength.Name = "numMaxLength";
        this.numMaxLength.Size = new System.Drawing.Size(120, 27);
        this.numMaxLength.TabIndex = 5;
        this.numMaxLength.Value = new decimal(new int[] {
        6,
        0,
        0,
        0});
        // 
        // lblMaxLength
        // 
        this.lblMaxLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblMaxLength.AutoSize = true;
        this.lblMaxLength.Location = new System.Drawing.Point(605, 18);
        this.lblMaxLength.Name = "lblMaxLength";
        this.lblMaxLength.Size = new System.Drawing.Size(132, 20);
        this.lblMaxLength.TabIndex = 4;
        this.lblMaxLength.Text = "الحد الأقصى للطول:";
        this.lblMaxLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // numMinLength
        // 
        this.numMinLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.numMinLength.Location = new System.Drawing.Point(300, 15);
        this.numMinLength.Minimum = new decimal(new int[] {
        1,
        0,
        0,
        0});
        this.numMinLength.Name = "numMinLength";
        this.numMinLength.Size = new System.Drawing.Size(120, 27);
        this.numMinLength.TabIndex = 3;
        this.numMinLength.Value = new decimal(new int[] {
        1,
        0,
        0,
        0});
        // 
        // lblMinLength
        // 
        this.lblMinLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblMinLength.AutoSize = true;
        this.lblMinLength.Location = new System.Drawing.Point(425, 18);
        this.lblMinLength.Name = "lblMinLength";
        this.lblMinLength.Size = new System.Drawing.Size(126, 20);
        this.lblMinLength.TabIndex = 2;
        this.lblMinLength.Text = "الحد الأدنى للطول:";
        this.lblMinLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cmbCharset
        // 
        this.cmbCharset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.cmbCharset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbCharset.FormattingEnabled = true;
        this.cmbCharset.Items.AddRange(new object[] {
        "أرقام فقط (0-9)",
        "أحرف صغيرة (a-z)",
        "أحرف كبيرة وصغيرة (a-zA-Z)",
        "أحرف وأرقام (a-zA-Z0-9)",
        "كل الأحرف (a-zA-Z0-9!@#$%^&*)"});
        this.cmbCharset.Location = new System.Drawing.Point(20, 15);
        this.cmbCharset.Name = "cmbCharset";
        this.cmbCharset.Size = new System.Drawing.Size(200, 28);
        this.cmbCharset.TabIndex = 1;
        // 
        // lblCharset
        // 
        this.lblCharset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblCharset.AutoSize = true;
        this.lblCharset.Location = new System.Drawing.Point(230, 18);
        this.lblCharset.Name = "lblCharset";
        this.lblCharset.Size = new System.Drawing.Size(110, 20);
        this.lblCharset.TabIndex = 0;
        this.lblCharset.Text = "مجموعة الأحرف:";
        this.lblCharset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // grpWordlist
        // 
        this.grpWordlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpWordlist.Controls.Add(this.lblWordlistCount);
        this.grpWordlist.Controls.Add(this.btnClearWordlist);
        this.grpWordlist.Controls.Add(this.btnGenerateCommon);
        this.grpWordlist.Controls.Add(this.btnBrowse);
        this.grpWordlist.Controls.Add(this.btnLoadWordlist);
        this.grpWordlist.Controls.Add(this.txtWordlistFile);
        this.grpWordlist.Controls.Add(this.lblWordlistFile);
        this.grpWordlist.ForeColor = System.Drawing.Color.White;
        this.grpWordlist.Location = new System.Drawing.Point(3, 109);
        this.grpWordlist.Name = "grpWordlist";
        this.grpWordlist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpWordlist.Size = new System.Drawing.Size(674, 47);
        this.grpWordlist.TabIndex = 2;
        this.grpWordlist.TabStop = false;
        this.grpWordlist.Text = "قائمة الكلمات";
        // 
        // lblWordlistCount
        // 
        this.lblWordlistCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblWordlistCount.AutoSize = true;
        this.lblWordlistCount.Location = new System.Drawing.Point(535, 18);
        this.lblWordlistCount.Name = "lblWordlistCount";
        this.lblWordlistCount.Size = new System.Drawing.Size(93, 20);
        this.lblWordlistCount.TabIndex = 6;
        this.lblWordlistCount.Text = "عدد الكلمات: 0";
        this.lblWordlistCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnClearWordlist
        // 
        this.btnClearWordlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        this.btnClearWordlist.Location = new System.Drawing.Point(20, 15);
        this.btnClearWordlist.Name = "btnClearWordlist";
        this.btnClearWordlist.Size = new System.Drawing.Size(120, 25);
        this.btnClearWordlist.TabIndex = 5;
        this.btnClearWordlist.Text = "مسح القائمة";
        this.btnClearWordlist.UseVisualStyleBackColor = true;
        // 
        // btnGenerateCommon
        // 
        this.btnGenerateCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        this.btnGenerateCommon.Location = new System.Drawing.Point(150, 15);
        this.btnGenerateCommon.Name = "btnGenerateCommon";
        this.btnGenerateCommon.Size = new System.Drawing.Size(140, 25);
        this.btnGenerateCommon.TabIndex = 4;
        this.btnGenerateCommon.Text = "توليد كلمات شائعة";
        this.btnGenerateCommon.UseVisualStyleBackColor = true;
        // 
        // btnBrowse
        // 
        this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        this.btnBrowse.Location = new System.Drawing.Point(300, 15);
        this.btnBrowse.Name = "btnBrowse";
        this.btnBrowse.Size = new System.Drawing.Size(100, 25);
        this.btnBrowse.TabIndex = 3;
        this.btnBrowse.Text = "استعراض...";
        this.btnBrowse.UseVisualStyleBackColor = true;
        // 
        // btnLoadWordlist
        // 
        this.btnLoadWordlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        this.btnLoadWordlist.Location = new System.Drawing.Point(410, 15);
        this.btnLoadWordlist.Name = "btnLoadWordlist";
        this.btnLoadWordlist.Size = new System.Drawing.Size(120, 25);
        this.btnLoadWordlist.TabIndex = 2;
        this.btnLoadWordlist.Text = "تحميل القائمة";
        this.btnLoadWordlist.UseVisualStyleBackColor = true;
        // 
        // txtWordlistFile
        // 
        this.txtWordlistFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtWordlistFile.Location = new System.Drawing.Point(20, 15);
        this.txtWordlistFile.Name = "txtWordlistFile";
        this.txtWordlistFile.ReadOnly = true;
        this.txtWordlistFile.Size = new System.Drawing.Size(250, 27);
        this.txtWordlistFile.TabIndex = 1;
        // 
        // lblWordlistFile
        // 
        this.lblWordlistFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.lblWordlistFile.AutoSize = true;
        this.lblWordlistFile.Location = new System.Drawing.Point(280, 18);
        this.lblWordlistFile.Name = "lblWordlistFile";
        this.lblWordlistFile.Size = new System.Drawing.Size(132, 20);
        this.lblWordlistFile.TabIndex = 0;
        this.lblWordlistFile.Text = "ملف قائمة الكلمات:";
        this.lblWordlistFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // tableLayoutProgress
        // 
        this.tableLayoutProgress.ColumnCount = 1;
        this.tableLayoutProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutProgress.Controls.Add(this.grpProgress, 0, 0);
        this.tableLayoutProgress.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutProgress.Location = new System.Drawing.Point(10, 195);
        this.tableLayoutProgress.Margin = new System.Windows.Forms.Padding(10);
        this.tableLayoutProgress.Name = "tableLayoutProgress";
        this.tableLayoutProgress.RowCount = 1;
        this.tableLayoutProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutProgress.Size = new System.Drawing.Size(980, 91);
        this.tableLayoutProgress.TabIndex = 1;
        // 
        // grpProgress
        // 
        this.grpProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpProgress.Controls.Add(this.lblStatus);
        this.grpProgress.Controls.Add(this.lblElapsed);
        this.grpProgress.Controls.Add(this.lblSpeed);
        this.grpProgress.Controls.Add(this.lblAttempts);
        this.grpProgress.Controls.Add(this.progressBar);
        this.grpProgress.ForeColor = System.Drawing.Color.White;
        this.grpProgress.Location = new System.Drawing.Point(3, 3);
        this.grpProgress.Name = "grpProgress";
        this.grpProgress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpProgress.Size = new System.Drawing.Size(974, 85);
        this.grpProgress.TabIndex = 0;
        this.grpProgress.TabStop = false;
        this.grpProgress.Text = "التقدم";
        // 
        // lblStatus
        // 
        this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.lblStatus.AutoSize = true;
        this.lblStatus.Location = new System.Drawing.Point(835, 55);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(71, 20);
        this.lblStatus.TabIndex = 4;
        this.lblStatus.Text = "الحالة: جاهز";
        this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblElapsed
        // 
        this.lblElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.lblElapsed.AutoSize = true;
        this.lblElapsed.Location = new System.Drawing.Point(715, 55);
        this.lblElapsed.Name = "lblElapsed";
        this.lblElapsed.Size = new System.Drawing.Size(94, 20);
        this.lblElapsed.TabIndex = 3;
        this.lblElapsed.Text = "الوقت: 00:00";
        this.lblElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblSpeed
        // 
        this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.lblSpeed.AutoSize = true;
        this.lblSpeed.Location = new System.Drawing.Point(595, 55);
        this.lblSpeed.Name = "lblSpeed";
        this.lblSpeed.Size = new System.Drawing.Size(94, 20);
        this.lblSpeed.TabIndex = 2;
        this.lblSpeed.Text = "السرعة: 0/ثانية";
        this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblAttempts
        // 
        this.lblAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.lblAttempts.AutoSize = true;
        this.lblAttempts.Location = new System.Drawing.Point(475, 55);
        this.lblAttempts.Name = "lblAttempts";
        this.lblAttempts.Size = new System.Drawing.Size(94, 20);
        this.lblAttempts.TabIndex = 1;
        this.lblAttempts.Text = "المحاولات: 0";
        this.lblAttempts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // progressBar
        // 
        this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.progressBar.Location = new System.Drawing.Point(20, 30);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(934, 20);
        this.progressBar.TabIndex = 0;
        // 
        // grpResults
        // 
        this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpResults.Controls.Add(this.txtResults);
        this.grpResults.ForeColor = System.Drawing.Color.White;
        this.grpResults.Location = new System.Drawing.Point(10, 306);
        this.grpResults.Margin = new System.Windows.Forms.Padding(10);
        this.grpResults.Name = "grpResults";
        this.grpResults.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpResults.Size = new System.Drawing.Size(980, 303);
        this.grpResults.TabIndex = 2;
        this.grpResults.TabStop = false;
        this.grpResults.Text = "النتائج";
        // 
        // txtResults
        // 
        this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtResults.Font = new System.Drawing.Font("Consolas", 9F);
        this.txtResults.Location = new System.Drawing.Point(20, 30);
        this.txtResults.Multiline = true;
        this.txtResults.Name = "txtResults";
        this.txtResults.ReadOnly = true;
        this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.txtResults.Size = new System.Drawing.Size(940, 257);
        this.txtResults.TabIndex = 0;
        // 
        // tableLayoutButtons
        // 
        this.tableLayoutButtons.ColumnCount = 4;
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutButtons.Controls.Add(this.btnStart, 0, 0);
        this.tableLayoutButtons.Controls.Add(this.btnStop, 1, 0);
        this.tableLayoutButtons.Controls.Add(this.btnClear, 2, 0);
        this.tableLayoutButtons.Controls.Add(this.btnClose, 3, 0);
        this.tableLayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutButtons.Location = new System.Drawing.Point(10, 629);
        this.tableLayoutButtons.Margin = new System.Windows.Forms.Padding(10);
        this.tableLayoutButtons.Name = "tableLayoutButtons";
        this.tableLayoutButtons.RowCount = 1;
        this.tableLayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutButtons.Size = new System.Drawing.Size(980, 91);
        this.tableLayoutButtons.TabIndex = 3;
        // 
        // btnStart
        // 
        this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
        this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnStart.ForeColor = System.Drawing.Color.White;
        this.btnStart.Location = new System.Drawing.Point(738, 3);
        this.btnStart.Name = "btnStart";
        this.btnStart.Size = new System.Drawing.Size(239, 85);
        this.btnStart.TabIndex = 0;
        this.btnStart.Text = "▶ بدء الهجوم";
        this.btnStart.UseVisualStyleBackColor = false;
        // 
        // btnStop
        // 
        this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
        this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnStop.Enabled = false;
        this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnStop.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnStop.ForeColor = System.Drawing.Color.White;
        this.btnStop.Location = new System.Drawing.Point(493, 3);
        this.btnStop.Name = "btnStop";
        this.btnStop.Size = new System.Drawing.Size(239, 85);
        this.btnStop.TabIndex = 1;
        this.btnStop.Text = "⏹ إيقاف";
        this.btnStop.UseVisualStyleBackColor = false;
        // 
        // btnClear
        // 
        this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
        this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnClear.ForeColor = System.Drawing.Color.White;
        this.btnClear.Location = new System.Drawing.Point(248, 3);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(239, 85);
        this.btnClear.TabIndex = 2;
        this.btnClear.Text = "مسح النتائج";
        this.btnClear.UseVisualStyleBackColor = false;
        // 
        // btnClose
        // 
        this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
        this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(3, 3);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(239, 85);
        this.btnClose.TabIndex = 3;
        this.btnClose.Text = "إغلاق";
        this.btnClose.UseVisualStyleBackColor = false;
        // 
        // PasswordCrackerForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
        this.ClientSize = new System.Drawing.Size(1000, 800);
        this.Controls.Add(this.tableLayoutMain);
        this.Controls.Add(this.panelHeader);
        this.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ForeColor = System.Drawing.Color.White;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MaximizeBox = true;
        this.MinimizeBox = true;
        this.MinimumSize = new System.Drawing.Size(1024, 700);
        this.Name = "PasswordCrackerForm";
        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.RightToLeftLayout = true;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "اختبار قوة كلمات المرور";
        this.panelHeader.ResumeLayout(false);
        this.tableLayoutMain.ResumeLayout(false);
        this.tableLayoutTop.ResumeLayout(false);
        this.grpAttackType.ResumeLayout(false);
        this.grpAttackType.PerformLayout();
        this.tableLayoutControls.ResumeLayout(false);
        this.grpTarget.ResumeLayout(false);
        this.grpTarget.PerformLayout();
        this.grpOptions.ResumeLayout(false);
        this.grpOptions.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numMaxLength)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numMinLength)).EndInit();
        this.grpWordlist.ResumeLayout(false);
        this.grpWordlist.PerformLayout();
        this.tableLayoutProgress.ResumeLayout(false);
        this.grpProgress.ResumeLayout(false);
        this.grpProgress.PerformLayout();
        this.grpResults.ResumeLayout(false);
        this.grpResults.PerformLayout();
        this.tableLayoutButtons.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}