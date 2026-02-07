namespace SecureDataProtectionTool.UI;

partial class FileEncryptionForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.GroupBox grpInput;
    private System.Windows.Forms.TextBox txtInputPath;
    private System.Windows.Forms.Button btnBrowseInput;
    private System.Windows.Forms.Button btnOpenInput;
    private System.Windows.Forms.Label lblInputPath;
    private System.Windows.Forms.GroupBox grpOutput;
    private System.Windows.Forms.TextBox txtOutputPath;
    private System.Windows.Forms.Button btnBrowseOutput;
    private System.Windows.Forms.Button btnOpenOutput;
    private System.Windows.Forms.Label lblOutputPath;
    private System.Windows.Forms.GroupBox grpSecurity;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSecurity;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblConfirmPassword;
    private System.Windows.Forms.TextBox txtConfirmPassword;
    private System.Windows.Forms.CheckBox chkShowPassword;
    private System.Windows.Forms.CheckBox chkAutoDelete;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.CheckBox chkUseUsername;
    private System.Windows.Forms.Label lblAdditionalKey;
    private System.Windows.Forms.TextBox txtAdditionalKey;
    private System.Windows.Forms.CheckBox chkUseAdditionalKey;
    private System.Windows.Forms.CheckBox chkAutoGeneratePath;
    private System.Windows.Forms.Label lblPasswordStrength;
    private System.Windows.Forms.ProgressBar progressPasswordStrength;
    private System.Windows.Forms.Label lblClipboardTimeout;
    private System.Windows.Forms.GroupBox grpActions;
    private System.Windows.Forms.Button btnEncrypt;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnGeneratePassword;
    private System.Windows.Forms.Button btnAnalyzeFile;
    private System.Windows.Forms.GroupBox grpProgress;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label lblProgress;
    private System.Windows.Forms.Label lblSpeed;
    private System.Windows.Forms.Label lblFileInfo;
    private System.Windows.Forms.Label lblFileSize;
    private System.Windows.Forms.GroupBox grpMetadata;
    private System.Windows.Forms.Panel pnlMetadata;
    private System.Windows.Forms.Label lblFileName;
    private System.Windows.Forms.Label lblFileSizeInfo;
    private System.Windows.Forms.Label lblFileDate;
    private System.Windows.Forms.Label lblAlgorithm;
    private System.Windows.Forms.Label lblKeySize;
    private System.Windows.Forms.Label lblEncryptionTime;
    private System.Windows.Forms.Label lblVersion;
    private System.Windows.Forms.GroupBox grpHistory;
    private System.Windows.Forms.ListView lstProcessedFiles;
    private System.Windows.Forms.ColumnHeader colOperation;
    private System.Windows.Forms.ColumnHeader colInputPath;
    private System.Windows.Forms.ColumnHeader colOutputPath;
    private System.Windows.Forms.ColumnHeader colDuration;
    private System.Windows.Forms.ColumnHeader colStatus;
    private System.Windows.Forms.ToolTip toolTip;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        panelHeader = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        panelMain = new System.Windows.Forms.Panel();
        tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
        grpInput = new System.Windows.Forms.GroupBox();
        lblInputPath = new System.Windows.Forms.Label();
        txtInputPath = new System.Windows.Forms.TextBox();
        btnBrowseInput = new System.Windows.Forms.Button();
        btnOpenInput = new System.Windows.Forms.Button();
        grpOutput = new System.Windows.Forms.GroupBox();
        lblOutputPath = new System.Windows.Forms.Label();
        txtOutputPath = new System.Windows.Forms.TextBox();
        btnBrowseOutput = new System.Windows.Forms.Button();
        btnOpenOutput = new System.Windows.Forms.Button();
        grpSecurity = new System.Windows.Forms.GroupBox();
        tableLayoutPanelSecurity = new System.Windows.Forms.TableLayoutPanel();
        lblPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        lblConfirmPassword = new System.Windows.Forms.Label();
        txtConfirmPassword = new System.Windows.Forms.TextBox();
        chkShowPassword = new System.Windows.Forms.CheckBox();
        chkAutoDelete = new System.Windows.Forms.CheckBox();
        lblUsername = new System.Windows.Forms.Label();
        txtUsername = new System.Windows.Forms.TextBox();
        chkUseUsername = new System.Windows.Forms.CheckBox();
        lblAdditionalKey = new System.Windows.Forms.Label();
        txtAdditionalKey = new System.Windows.Forms.TextBox();
        chkUseAdditionalKey = new System.Windows.Forms.CheckBox();
        chkAutoGeneratePath = new System.Windows.Forms.CheckBox();
        lblPasswordStrength = new System.Windows.Forms.Label();
        progressPasswordStrength = new System.Windows.Forms.ProgressBar();
        lblClipboardTimeout = new System.Windows.Forms.Label();
        grpActions = new System.Windows.Forms.GroupBox();
        btnEncrypt = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        btnClear = new System.Windows.Forms.Button();
        btnGeneratePassword = new System.Windows.Forms.Button();
        btnAnalyzeFile = new System.Windows.Forms.Button();
        grpProgress = new System.Windows.Forms.GroupBox();
        progressBar = new System.Windows.Forms.ProgressBar();
        lblProgress = new System.Windows.Forms.Label();
        lblSpeed = new System.Windows.Forms.Label();
        lblFileInfo = new System.Windows.Forms.Label();
        lblFileSize = new System.Windows.Forms.Label();
        grpMetadata = new System.Windows.Forms.GroupBox();
        pnlMetadata = new System.Windows.Forms.Panel();
        lblFileName = new System.Windows.Forms.Label();
        lblFileSizeInfo = new System.Windows.Forms.Label();
        lblFileDate = new System.Windows.Forms.Label();
        lblAlgorithm = new System.Windows.Forms.Label();
        lblKeySize = new System.Windows.Forms.Label();
        lblEncryptionTime = new System.Windows.Forms.Label();
        lblVersion = new System.Windows.Forms.Label();
        grpHistory = new System.Windows.Forms.GroupBox();
        lstProcessedFiles = new System.Windows.Forms.ListView();
        colOperation = new System.Windows.Forms.ColumnHeader();
        colInputPath = new System.Windows.Forms.ColumnHeader();
        colOutputPath = new System.Windows.Forms.ColumnHeader();
        colDuration = new System.Windows.Forms.ColumnHeader();
        colStatus = new System.Windows.Forms.ColumnHeader();
        toolTip = new System.Windows.Forms.ToolTip(components);
        panelHeader.SuspendLayout();
        panelMain.SuspendLayout();
        tableLayoutPanelMain.SuspendLayout();
        grpInput.SuspendLayout();
        grpOutput.SuspendLayout();
        grpSecurity.SuspendLayout();
        tableLayoutPanelSecurity.SuspendLayout();
        grpActions.SuspendLayout();
        grpProgress.SuspendLayout();
        grpMetadata.SuspendLayout();
        pnlMetadata.SuspendLayout();
        grpHistory.SuspendLayout();
        SuspendLayout();
        // 
        // panelHeader
        // 
        panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)30)), ((int)((byte)40)));
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        panelHeader.Location = new System.Drawing.Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new System.Drawing.Size(1200, 60);
        panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTitle.ForeColor = System.Drawing.Color.White;
        lblTitle.Location = new System.Drawing.Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(1200, 60);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "تشفير الملفات";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panelMain
        // 
        panelMain.AutoScroll = true;
        panelMain.Controls.Add(tableLayoutPanelMain);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 60);
        panelMain.Name = "panelMain";
        panelMain.Padding = new System.Windows.Forms.Padding(20);
        panelMain.Size = new System.Drawing.Size(1200, 740);
        panelMain.TabIndex = 1;
        // 
        // tableLayoutPanelMain
        // 
        tableLayoutPanelMain.ColumnCount = 2;
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanelMain.Controls.Add(grpInput, 0, 0);
        tableLayoutPanelMain.Controls.Add(grpOutput, 1, 0);
        tableLayoutPanelMain.Controls.Add(grpSecurity, 0, 1);
        tableLayoutPanelMain.Controls.Add(grpActions, 0, 2);
        tableLayoutPanelMain.Controls.Add(grpProgress, 0, 3);
        tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelMain.Location = new System.Drawing.Point(20, 20);
        tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        tableLayoutPanelMain.RowCount = 6;
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(1160, 700);
        tableLayoutPanelMain.TabIndex = 0;
        // 
        // grpInput
        // 
        grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpInput, 2);
        grpInput.Controls.Add(lblInputPath);
        grpInput.Controls.Add(txtInputPath);
        grpInput.Controls.Add(btnBrowseInput);
        grpInput.Controls.Add(btnOpenInput);
        grpInput.Location = new System.Drawing.Point(3, 3);
        grpInput.Name = "grpInput";
        grpInput.Size = new System.Drawing.Size(1154, 114);
        grpInput.TabIndex = 0;
        grpInput.TabStop = false;
        grpInput.Text = "المدخلات";
        // 
        // lblInputPath
        // 
        lblInputPath.AutoSize = true;
        lblInputPath.Location = new System.Drawing.Point(20, 30);
        lblInputPath.Name = "lblInputPath";
        lblInputPath.Size = new System.Drawing.Size(146, 20);
        lblInputPath.TabIndex = 0;
        lblInputPath.Text = "مسار الملف أو المجلد:";
        // 
        // txtInputPath
        // 
        txtInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtInputPath.Location = new System.Drawing.Point(180, 30);
        txtInputPath.Name = "txtInputPath";
        txtInputPath.Size = new System.Drawing.Size(800, 27);
        txtInputPath.TabIndex = 1;
        txtInputPath.TextChanged += txtInputPath_TextChanged;
        // 
        // btnBrowseInput
        // 
        btnBrowseInput.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnBrowseInput.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnBrowseInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnBrowseInput.ForeColor = System.Drawing.Color.White;
        btnBrowseInput.Location = new System.Drawing.Point(990, 28);
        btnBrowseInput.Name = "btnBrowseInput";
        btnBrowseInput.Size = new System.Drawing.Size(80, 30);
        btnBrowseInput.TabIndex = 2;
        btnBrowseInput.Text = "📂 استعراض";
        btnBrowseInput.UseVisualStyleBackColor = false;
        btnBrowseInput.Click += BtnBrowseInput_Click;
        // 
        // btnOpenInput
        // 
        btnOpenInput.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnOpenInput.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnOpenInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnOpenInput.ForeColor = System.Drawing.Color.White;
        btnOpenInput.Location = new System.Drawing.Point(1070, 28);
        btnOpenInput.Name = "btnOpenInput";
        btnOpenInput.Size = new System.Drawing.Size(70, 30);
        btnOpenInput.TabIndex = 3;
        btnOpenInput.Text = "📄 فتح";
        btnOpenInput.UseVisualStyleBackColor = false;
        btnOpenInput.Click += BtnOpenInput_Click;
        // 
        // grpOutput
        // 
        grpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpOutput, 2);
        grpOutput.Controls.Add(lblOutputPath);
        grpOutput.Controls.Add(txtOutputPath);
        grpOutput.Controls.Add(btnBrowseOutput);
        grpOutput.Controls.Add(btnOpenOutput);
        grpOutput.Location = new System.Drawing.Point(3, 123);
        grpOutput.Name = "grpOutput";
        grpOutput.Size = new System.Drawing.Size(1154, 174);
        grpOutput.TabIndex = 1;
        grpOutput.TabStop = false;
        grpOutput.Text = "المخرجات";
        // 
        // lblOutputPath
        // 
        lblOutputPath.AutoSize = true;
        lblOutputPath.Location = new System.Drawing.Point(20, 30);
        lblOutputPath.Name = "lblOutputPath";
        lblOutputPath.Size = new System.Drawing.Size(88, 20);
        lblOutputPath.TabIndex = 0;
        lblOutputPath.Text = "مسار الإخراج:";
        // 
        // txtOutputPath
        // 
        txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtOutputPath.Location = new System.Drawing.Point(180, 30);
        txtOutputPath.Name = "txtOutputPath";
        txtOutputPath.Size = new System.Drawing.Size(800, 27);
        txtOutputPath.TabIndex = 1;
        txtOutputPath.TextChanged += txtOutputPath_TextChanged;
        // 
        // btnBrowseOutput
        // 
        btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnBrowseOutput.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnBrowseOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnBrowseOutput.ForeColor = System.Drawing.Color.White;
        btnBrowseOutput.Location = new System.Drawing.Point(990, 28);
        btnBrowseOutput.Name = "btnBrowseOutput";
        btnBrowseOutput.Size = new System.Drawing.Size(80, 30);
        btnBrowseOutput.TabIndex = 2;
        btnBrowseOutput.Text = "📂 استعراض";
        btnBrowseOutput.UseVisualStyleBackColor = false;
        btnBrowseOutput.Click += BtnBrowseOutput_Click;
        // 
        // btnOpenOutput
        // 
        btnOpenOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnOpenOutput.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnOpenOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnOpenOutput.ForeColor = System.Drawing.Color.White;
        btnOpenOutput.Location = new System.Drawing.Point(1070, 28);
        btnOpenOutput.Name = "btnOpenOutput";
        btnOpenOutput.Size = new System.Drawing.Size(70, 30);
        btnOpenOutput.TabIndex = 3;
        btnOpenOutput.Text = "📄 فتح";
        btnOpenOutput.UseVisualStyleBackColor = false;
        btnOpenOutput.Click += BtnOpenOutput_Click;
        // 
        // grpSecurity
        // 
        grpSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpSecurity, 2);
        grpSecurity.Controls.Add(tableLayoutPanelSecurity);
        grpSecurity.Location = new System.Drawing.Point(3, 303);
        grpSecurity.Name = "grpSecurity";
        grpSecurity.Size = new System.Drawing.Size(1154, 119);
        grpSecurity.TabIndex = 2;
        grpSecurity.TabStop = false;
        grpSecurity.Text = "إعدادات الأمان";
        // 
        // tableLayoutPanelSecurity
        // 
        tableLayoutPanelSecurity.ColumnCount = 4;
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.Controls.Add(lblPassword, 0, 0);
        tableLayoutPanelSecurity.Controls.Add(txtPassword, 0, 1);
        tableLayoutPanelSecurity.Controls.Add(lblConfirmPassword, 1, 0);
        tableLayoutPanelSecurity.Controls.Add(txtConfirmPassword, 1, 1);
        tableLayoutPanelSecurity.Controls.Add(chkShowPassword, 0, 2);
        tableLayoutPanelSecurity.Controls.Add(chkAutoDelete, 1, 2);
        tableLayoutPanelSecurity.Controls.Add(lblUsername, 2, 0);
        tableLayoutPanelSecurity.Controls.Add(txtUsername, 2, 1);
        tableLayoutPanelSecurity.Controls.Add(chkUseUsername, 2, 2);
        tableLayoutPanelSecurity.Controls.Add(lblAdditionalKey, 3, 0);
        tableLayoutPanelSecurity.Controls.Add(txtAdditionalKey, 3, 1);
        tableLayoutPanelSecurity.Controls.Add(chkUseAdditionalKey, 3, 2);
        tableLayoutPanelSecurity.Controls.Add(chkAutoGeneratePath, 0, 4);
        tableLayoutPanelSecurity.Controls.Add(lblPasswordStrength, 0, 5);
        tableLayoutPanelSecurity.Controls.Add(progressPasswordStrength, 1, 5);
        tableLayoutPanelSecurity.Controls.Add(lblClipboardTimeout, 3, 5);
        tableLayoutPanelSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelSecurity.Location = new System.Drawing.Point(3, 23);
        tableLayoutPanelSecurity.Name = "tableLayoutPanelSecurity";
        tableLayoutPanelSecurity.RowCount = 6;
        tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
        tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
        tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
        tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
        tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
        tableLayoutPanelSecurity.Size = new System.Drawing.Size(1148, 93);
        tableLayoutPanelSecurity.TabIndex = 0;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new System.Drawing.Point(1062, 0);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new System.Drawing.Size(83, 20);
        lblPassword.TabIndex = 0;
        lblPassword.Text = "كلمة المرور:";
        // 
        // txtPassword
        // 
        txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtPassword.Location = new System.Drawing.Point(864, 28);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new System.Drawing.Size(281, 27);
        txtPassword.TabIndex = 1;
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.TextChanged += txtPassword_TextChanged;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Location = new System.Drawing.Point(741, 0);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new System.Drawing.Size(117, 20);
        lblConfirmPassword.TabIndex = 2;
        lblConfirmPassword.Text = "تأكيد كلمة المرور:";
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtConfirmPassword.Location = new System.Drawing.Point(577, 28);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Size = new System.Drawing.Size(281, 27);
        txtConfirmPassword.TabIndex = 3;
        txtConfirmPassword.UseSystemPasswordChar = true;
        // 
        // chkShowPassword
        // 
        chkShowPassword.AutoSize = true;
        chkShowPassword.Location = new System.Drawing.Point(1004, 63);
        chkShowPassword.Name = "chkShowPassword";
        chkShowPassword.Size = new System.Drawing.Size(141, 24);
        chkShowPassword.TabIndex = 4;
        chkShowPassword.Text = "إظهار كلمة المرور";
        chkShowPassword.UseVisualStyleBackColor = true;
        chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
        // 
        // chkAutoDelete
        // 
        chkAutoDelete.AutoSize = true;
        chkAutoDelete.Location = new System.Drawing.Point(627, 63);
        chkAutoDelete.Name = "chkAutoDelete";
        chkAutoDelete.Size = new System.Drawing.Size(231, 24);
        chkAutoDelete.TabIndex = 5;
        chkAutoDelete.Text = "حذف الملف الأصلي بعد التشفير";
        chkAutoDelete.UseVisualStyleBackColor = true;
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new System.Drawing.Point(410, 0);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new System.Drawing.Size(161, 20);
        lblUsername.TabIndex = 6;
        lblUsername.Text = "اسم المستخدم (اختياري):";
        // 
        // txtUsername
        // 
        txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtUsername.Enabled = false;
        txtUsername.Location = new System.Drawing.Point(290, 28);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new System.Drawing.Size(281, 27);
        txtUsername.TabIndex = 7;
        // 
        // chkUseUsername
        // 
        chkUseUsername.AutoSize = true;
        chkUseUsername.Location = new System.Drawing.Point(392, 63);
        chkUseUsername.Name = "chkUseUsername";
        chkUseUsername.Size = new System.Drawing.Size(179, 24);
        chkUseUsername.TabIndex = 8;
        chkUseUsername.Text = "استخدام اسم المستخدم";
        chkUseUsername.UseVisualStyleBackColor = true;
        chkUseUsername.CheckedChanged += ChkUseUsername_CheckedChanged;
        // 
        // lblAdditionalKey
        // 
        lblAdditionalKey.AutoSize = true;
        lblAdditionalKey.Location = new System.Drawing.Point(114, 0);
        lblAdditionalKey.Name = "lblAdditionalKey";
        lblAdditionalKey.Size = new System.Drawing.Size(170, 20);
        lblAdditionalKey.TabIndex = 9;
        lblAdditionalKey.Text = "المفتاح الإضافي (اختياري):";
        // 
        // txtAdditionalKey
        // 
        txtAdditionalKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtAdditionalKey.Enabled = false;
        txtAdditionalKey.Location = new System.Drawing.Point(3, 28);
        txtAdditionalKey.Name = "txtAdditionalKey";
        txtAdditionalKey.Size = new System.Drawing.Size(281, 27);
        txtAdditionalKey.TabIndex = 10;
        // 
        // chkUseAdditionalKey
        // 
        chkUseAdditionalKey.AutoSize = true;
        chkUseAdditionalKey.Location = new System.Drawing.Point(114, 63);
        chkUseAdditionalKey.Name = "chkUseAdditionalKey";
        chkUseAdditionalKey.Size = new System.Drawing.Size(170, 24);
        chkUseAdditionalKey.TabIndex = 11;
        chkUseAdditionalKey.Text = "استخدام مفتاح إضافي";
        chkUseAdditionalKey.UseVisualStyleBackColor = true;
        chkUseAdditionalKey.CheckedChanged += ChkUseAdditionalKey_CheckedChanged;
        // 
        // chkAutoGeneratePath
        // 
        chkAutoGeneratePath.AutoSize = true;
        chkAutoGeneratePath.Checked = true;
        chkAutoGeneratePath.CheckState = System.Windows.Forms.CheckState.Checked;
        tableLayoutPanelSecurity.SetColumnSpan(chkAutoGeneratePath, 2);
        chkAutoGeneratePath.Location = new System.Drawing.Point(963, 103);
        chkAutoGeneratePath.Name = "chkAutoGeneratePath";
        chkAutoGeneratePath.Size = new System.Drawing.Size(182, 24);
        chkAutoGeneratePath.TabIndex = 12;
        chkAutoGeneratePath.Text = "توليد مسار الإخراج تلقائياً";
        chkAutoGeneratePath.UseVisualStyleBackColor = true;
        chkAutoGeneratePath.CheckedChanged += ChkAutoGeneratePath_CheckedChanged;
        // 
        // lblPasswordStrength
        // 
        lblPasswordStrength.AutoSize = true;
        lblPasswordStrength.Location = new System.Drawing.Point(1024, 130);
        lblPasswordStrength.Name = "lblPasswordStrength";
        lblPasswordStrength.Size = new System.Drawing.Size(121, 20);
        lblPasswordStrength.TabIndex = 13;
        lblPasswordStrength.Text = "قوة كلمة المرور: -";
        // 
        // progressPasswordStrength
        // 
        progressPasswordStrength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelSecurity.SetColumnSpan(progressPasswordStrength, 2);
        progressPasswordStrength.Location = new System.Drawing.Point(290, 133);
        progressPasswordStrength.Name = "progressPasswordStrength";
        progressPasswordStrength.Size = new System.Drawing.Size(568, 12);
        progressPasswordStrength.TabIndex = 14;
        // 
        // lblClipboardTimeout
        // 
        lblClipboardTimeout.AutoSize = true;
        lblClipboardTimeout.Location = new System.Drawing.Point(228, 130);
        lblClipboardTimeout.Name = "lblClipboardTimeout";
        lblClipboardTimeout.Size = new System.Drawing.Size(56, 20);
        lblClipboardTimeout.TabIndex = 15;
        lblClipboardTimeout.Text = "30 ثانية";
        // 
        // grpActions
        // 
        grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpActions, 2);
        grpActions.Controls.Add(btnEncrypt);
        grpActions.Controls.Add(btnCancel);
        grpActions.Controls.Add(btnClear);
        grpActions.Controls.Add(btnGeneratePassword);
        grpActions.Controls.Add(btnAnalyzeFile);
        grpActions.Location = new System.Drawing.Point(3, 428);
        grpActions.Name = "grpActions";
        grpActions.Size = new System.Drawing.Size(1154, 69);
        grpActions.TabIndex = 3;
        grpActions.TabStop = false;
        grpActions.Text = "الإجراءات الرئيسية";
        // 
        // btnEncrypt
        // 
        btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnEncrypt.ForeColor = System.Drawing.Color.White;
        btnEncrypt.Location = new System.Drawing.Point(870, 30);
        btnEncrypt.Name = "btnEncrypt";
        btnEncrypt.Size = new System.Drawing.Size(120, 40);
        btnEncrypt.TabIndex = 0;
        btnEncrypt.Text = "🔒 تشفير";
        btnEncrypt.UseVisualStyleBackColor = false;
        btnEncrypt.Click += BtnEncrypt_Click;
        // 
        // btnCancel
        // 
        btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)53)), ((int)((byte)69)));
        btnCancel.Enabled = false;
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCancel.ForeColor = System.Drawing.Color.White;
        btnCancel.Location = new System.Drawing.Point(740, 30);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(120, 40);
        btnCancel.TabIndex = 2;
        btnCancel.Text = "❌ إلغاء";
        btnCancel.UseVisualStyleBackColor = false;
        btnCancel.Click += BtnCancel_Click;
        // 
        // btnClear
        // 
        btnClear.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClear.ForeColor = System.Drawing.Color.White;
        btnClear.Location = new System.Drawing.Point(20, 30);
        btnClear.Name = "btnClear";
        btnClear.Size = new System.Drawing.Size(120, 40);
        btnClear.TabIndex = 3;
        btnClear.Text = "🗑️ مسح الكل";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += BtnClear_Click;
        // 
        // btnGeneratePassword
        // 
        btnGeneratePassword.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)193)), ((int)((byte)7)));
        btnGeneratePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnGeneratePassword.ForeColor = System.Drawing.Color.Black;
        btnGeneratePassword.Location = new System.Drawing.Point(150, 30);
        btnGeneratePassword.Name = "btnGeneratePassword";
        btnGeneratePassword.Size = new System.Drawing.Size(150, 40);
        btnGeneratePassword.TabIndex = 4;
        btnGeneratePassword.Text = "🔑 توليد كلمة مرور";
        btnGeneratePassword.UseVisualStyleBackColor = false;
        btnGeneratePassword.Click += BtnGeneratePassword_Click;
        // 
        // btnAnalyzeFile
        // 
        btnAnalyzeFile.BackColor = System.Drawing.Color.FromArgb(((int)((byte)111)), ((int)((byte)66)), ((int)((byte)193)));
        btnAnalyzeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnAnalyzeFile.ForeColor = System.Drawing.Color.White;
        btnAnalyzeFile.Location = new System.Drawing.Point(310, 30);
        btnAnalyzeFile.Name = "btnAnalyzeFile";
        btnAnalyzeFile.Size = new System.Drawing.Size(120, 40);
        btnAnalyzeFile.TabIndex = 5;
        btnAnalyzeFile.Text = "📊 تحليل الملف";
        btnAnalyzeFile.UseVisualStyleBackColor = false;
        btnAnalyzeFile.Click += BtnAnalyzeFile_Click;
        // 
        // grpProgress
        // 
        grpProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpProgress, 2);
        grpProgress.Controls.Add(progressBar);
        grpProgress.Controls.Add(lblProgress);
        grpProgress.Controls.Add(lblSpeed);
        grpProgress.Controls.Add(lblFileInfo);
        grpProgress.Controls.Add(lblFileSize);
        grpProgress.Controls.Add(grpMetadata);
        grpProgress.Controls.Add(grpHistory);
        grpProgress.Location = new System.Drawing.Point(3, 503);
        grpProgress.Name = "grpProgress";
        grpProgress.Size = new System.Drawing.Size(1154, 174);
        grpProgress.TabIndex = 4;
        grpProgress.TabStop = false;
        grpProgress.Text = "التقدم";
        // 
        // progressBar
        // 
        progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        progressBar.Location = new System.Drawing.Point(20, 30);
        progressBar.Name = "progressBar";
        progressBar.Size = new System.Drawing.Size(1110, 16);
        progressBar.TabIndex = 0;
        // 
        // lblProgress
        // 
        lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        lblProgress.AutoSize = true;
        lblProgress.Location = new System.Drawing.Point(1065, 7);
        lblProgress.Name = "lblProgress";
        lblProgress.Size = new System.Drawing.Size(29, 20);
        lblProgress.TabIndex = 1;
        lblProgress.Text = "0%";
        // 
        // lblSpeed
        // 
        lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        lblSpeed.AutoSize = true;
        lblSpeed.Location = new System.Drawing.Point(900, 70);
        lblSpeed.Name = "lblSpeed";
        lblSpeed.Size = new System.Drawing.Size(0, 20);
        lblSpeed.TabIndex = 2;
        // 
        // lblFileInfo
        // 
        lblFileInfo.AutoSize = true;
        lblFileInfo.Location = new System.Drawing.Point(20, 70);
        lblFileInfo.Name = "lblFileInfo";
        lblFileInfo.Size = new System.Drawing.Size(0, 20);
        lblFileInfo.TabIndex = 3;
        // 
        // lblFileSize
        // 
        lblFileSize.AutoSize = true;
        lblFileSize.Location = new System.Drawing.Point(200, 70);
        lblFileSize.Name = "lblFileSize";
        lblFileSize.Size = new System.Drawing.Size(0, 20);
        lblFileSize.TabIndex = 4;
        // 
        // grpMetadata
        // 
        grpMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        grpMetadata.Controls.Add(pnlMetadata);
        grpMetadata.Location = new System.Drawing.Point(591, 52);
        grpMetadata.Name = "grpMetadata";
        grpMetadata.Size = new System.Drawing.Size(557, 105);
        grpMetadata.TabIndex = 5;
        grpMetadata.TabStop = false;
        grpMetadata.Text = "معلومات الملف";
        // 
        // pnlMetadata
        // 
        pnlMetadata.BackColor = System.Drawing.Color.FromArgb(((int)((byte)240)), ((int)((byte)240)), ((int)((byte)240)));
        pnlMetadata.Controls.Add(lblFileName);
        pnlMetadata.Controls.Add(lblFileSizeInfo);
        pnlMetadata.Controls.Add(lblFileDate);
        pnlMetadata.Controls.Add(lblAlgorithm);
        pnlMetadata.Controls.Add(lblKeySize);
        pnlMetadata.Controls.Add(lblEncryptionTime);
        pnlMetadata.Controls.Add(lblVersion);
        pnlMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlMetadata.Location = new System.Drawing.Point(3, 23);
        pnlMetadata.Name = "pnlMetadata";
        pnlMetadata.Padding = new System.Windows.Forms.Padding(10);
        pnlMetadata.Size = new System.Drawing.Size(551, 79);
        pnlMetadata.TabIndex = 0;
        // 
        // lblFileName
        // 
        lblFileName.AutoSize = true;
        lblFileName.Location = new System.Drawing.Point(10, 14);
        lblFileName.Name = "lblFileName";
        lblFileName.Size = new System.Drawing.Size(57, 20);
        lblFileName.TabIndex = 0;
        lblFileName.Text = "الاسم: -";
        // 
        // lblFileSizeInfo
        // 
        lblFileSizeInfo.AutoSize = true;
        lblFileSizeInfo.Location = new System.Drawing.Point(100, 14);
        lblFileSizeInfo.Name = "lblFileSizeInfo";
        lblFileSizeInfo.Size = new System.Drawing.Size(58, 20);
        lblFileSizeInfo.TabIndex = 1;
        lblFileSizeInfo.Text = "الحجم: -";
        // 
        // lblFileDate
        // 
        lblFileDate.AutoSize = true;
        lblFileDate.Location = new System.Drawing.Point(200, 14);
        lblFileDate.Name = "lblFileDate";
        lblFileDate.Size = new System.Drawing.Size(61, 20);
        lblFileDate.TabIndex = 2;
        lblFileDate.Text = "التاريخ: -";
        // 
        // lblAlgorithm
        // 
        lblAlgorithm.AutoSize = true;
        lblAlgorithm.Location = new System.Drawing.Point(10, 34);
        lblAlgorithm.Name = "lblAlgorithm";
        lblAlgorithm.Size = new System.Drawing.Size(84, 20);
        lblAlgorithm.TabIndex = 3;
        lblAlgorithm.Text = "الخوارزمية: -";
        // 
        // lblKeySize
        // 
        lblKeySize.AutoSize = true;
        lblKeySize.Location = new System.Drawing.Point(120, 34);
        lblKeySize.Name = "lblKeySize";
        lblKeySize.Size = new System.Drawing.Size(97, 20);
        lblKeySize.TabIndex = 4;
        lblKeySize.Text = "حجم المفتاح: -";
        // 
        // lblEncryptionTime
        // 
        lblEncryptionTime.AutoSize = true;
        lblEncryptionTime.Location = new System.Drawing.Point(260, 34);
        lblEncryptionTime.Name = "lblEncryptionTime";
        lblEncryptionTime.Size = new System.Drawing.Size(102, 20);
        lblEncryptionTime.TabIndex = 5;
        lblEncryptionTime.Text = "وقت التشفير: -";
        // 
        // lblVersion
        // 
        lblVersion.AutoSize = true;
        lblVersion.Location = new System.Drawing.Point(400, 34);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new System.Drawing.Size(68, 20);
        lblVersion.TabIndex = 6;
        lblVersion.Text = "الإصدار: -";
        // 
        // grpHistory
        // 
        grpHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        grpHistory.Controls.Add(lstProcessedFiles);
        grpHistory.Location = new System.Drawing.Point(6, 62);
        grpHistory.Name = "grpHistory";
        grpHistory.Size = new System.Drawing.Size(574, 105);
        grpHistory.TabIndex = 6;
        grpHistory.TabStop = false;
        grpHistory.Text = "سجل العمليات";
        // 
        // lstProcessedFiles
        // 
        lstProcessedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colOperation, colInputPath, colOutputPath, colDuration, colStatus });
        lstProcessedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
        lstProcessedFiles.FullRowSelect = true;
        lstProcessedFiles.GridLines = true;
        lstProcessedFiles.Location = new System.Drawing.Point(3, 23);
        lstProcessedFiles.Name = "lstProcessedFiles";
        lstProcessedFiles.Size = new System.Drawing.Size(568, 79);
        lstProcessedFiles.TabIndex = 0;
        lstProcessedFiles.UseCompatibleStateImageBehavior = false;
        lstProcessedFiles.View = System.Windows.Forms.View.Details;
        lstProcessedFiles.DoubleClick += lstProcessedFiles_DoubleClick;
        // 
        // colOperation
        // 
        colOperation.Name = "colOperation";
        colOperation.Text = "العملية";
        colOperation.Width = 100;
        // 
        // colInputPath
        // 
        colInputPath.Name = "colInputPath";
        colInputPath.Text = "مسار الإدخال";
        colInputPath.Width = 120;
        // 
        // colOutputPath
        // 
        colOutputPath.Name = "colOutputPath";
        colOutputPath.Text = "مسار الإخراج";
        colOutputPath.Width = 120;
        // 
        // colDuration
        // 
        colDuration.Name = "colDuration";
        colDuration.Text = "المدة";
        colDuration.Width = 70;
        // 
        // colStatus
        // 
        colStatus.Name = "colStatus";
        colStatus.Text = "الحالة";
        // 
        // toolTip
        // 
        toolTip.AutomaticDelay = 250;
        toolTip.Popup += toolTip_Popup;
        // 
        // FileEncryptionForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(1200, 800);
        Controls.Add(panelMain);
        Controls.Add(panelHeader);
        Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        MinimumSize = new System.Drawing.Size(1000, 700);
        RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "تشفير الملفات";
        panelHeader.ResumeLayout(false);
        panelMain.ResumeLayout(false);
        tableLayoutPanelMain.ResumeLayout(false);
        grpInput.ResumeLayout(false);
        grpInput.PerformLayout();
        grpOutput.ResumeLayout(false);
        grpOutput.PerformLayout();
        grpSecurity.ResumeLayout(false);
        tableLayoutPanelSecurity.ResumeLayout(false);
        tableLayoutPanelSecurity.PerformLayout();
        grpActions.ResumeLayout(false);
        grpProgress.ResumeLayout(false);
        grpProgress.PerformLayout();
        grpMetadata.ResumeLayout(false);
        pnlMetadata.ResumeLayout(false);
        pnlMetadata.PerformLayout();
        grpHistory.ResumeLayout(false);
        ResumeLayout(false);
    }
}