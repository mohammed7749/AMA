namespace SecureDataProtectionTool.UI;

partial class SettingsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabEncryption;
    private System.Windows.Forms.NumericUpDown numPbkdf2Iterations;
    private System.Windows.Forms.NumericUpDown numSaltLength;
    private System.Windows.Forms.NumericUpDown numKeySize;
    private System.Windows.Forms.CheckBox chkUseAdditionalKey;
    private System.Windows.Forms.CheckBox chkUseUsername;
    private System.Windows.Forms.Label lblPbkdf2Iterations;
    private System.Windows.Forms.Label lblSaltLength;
    private System.Windows.Forms.Label lblKeySize;
    private System.Windows.Forms.TabPage tabSecurity;
    private System.Windows.Forms.NumericUpDown numAutoLockTimeout;
    private System.Windows.Forms.NumericUpDown numClipboardTimeout;
    private System.Windows.Forms.CheckBox chkClearClipboard;
    private System.Windows.Forms.CheckBox chkWipeMemory;
    private System.Windows.Forms.CheckBox chkAutoDelete;
    private System.Windows.Forms.NumericUpDown numWipePasses;
    private System.Windows.Forms.Label lblAutoLockTimeout;
    private System.Windows.Forms.Label lblClipboardTimeout;
    private System.Windows.Forms.Label lblWipePasses;
    private System.Windows.Forms.TabPage tabPasswords;
    private System.Windows.Forms.NumericUpDown numMinPasswordLength;
    private System.Windows.Forms.NumericUpDown numMaxPasswordLength;
    private System.Windows.Forms.CheckBox chkIncludeUppercase;
    private System.Windows.Forms.CheckBox chkIncludeLowercase;
    private System.Windows.Forms.CheckBox chkIncludeNumbers;
    private System.Windows.Forms.CheckBox chkIncludeSymbols;
    private System.Windows.Forms.CheckBox chkExcludeSimilar;
    private System.Windows.Forms.CheckBox chkExcludeAmbiguous;
    private System.Windows.Forms.Label lblMinPasswordLength;
    private System.Windows.Forms.Label lblMaxPasswordLength;
    private System.Windows.Forms.TabPage tabCustomCrypto;
    private System.Windows.Forms.CheckBox chkEnableCustomCrypto;
    private System.Windows.Forms.Label lblSelectedAlgorithm;
    private System.Windows.Forms.ComboBox cmbSelectedAlgorithm;
    private System.Windows.Forms.CheckBox chkEnableMD5;
    private System.Windows.Forms.CheckBox chkEnableDES;
    private System.Windows.Forms.TabPage tabUI;
    private System.Windows.Forms.Label lblTheme;
    private System.Windows.Forms.ComboBox cmbTheme;
    private System.Windows.Forms.Label lblLanguage;
    private System.Windows.Forms.ComboBox cmbLanguage;
    private System.Windows.Forms.CheckBox chkShowToolTips;
    private System.Windows.Forms.CheckBox chkConfirmBeforeExit;
    private System.Windows.Forms.TabPage tabLogging;
    private System.Windows.Forms.CheckBox chkEnableLogging;
    private System.Windows.Forms.NumericUpDown numLogRetentionDays;
    private System.Windows.Forms.CheckBox chkLogToFile;
    private System.Windows.Forms.CheckBox chkLogToDatabase;
    private System.Windows.Forms.Label lblLogRetentionDays;
    private System.Windows.Forms.TabPage tabUserInfo;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label lblAdditionalKey;
    private System.Windows.Forms.TextBox txtAdditionalKey;
    private System.Windows.Forms.Panel panelActions;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.Button btnTestSettings;
    private System.Windows.Forms.Button btnImport;
    private System.Windows.Forms.Button btnExport;
    
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
        lblTitle = new Label();
        panelMain = new Panel();
        panelActions = new Panel();
        btnExport = new Button();
        btnImport = new Button();
        btnTestSettings = new Button();
        btnApply = new Button();
        btnReset = new Button();
        btnCancel = new Button();
        btnSave = new Button();
        tabControl = new TabControl();
        tabEncryption = new TabPage();
        chkUseUsername = new CheckBox();
        chkUseAdditionalKey = new CheckBox();
        numKeySize = new NumericUpDown();
        lblKeySize = new Label();
        numSaltLength = new NumericUpDown();
        lblSaltLength = new Label();
        numPbkdf2Iterations = new NumericUpDown();
        lblPbkdf2Iterations = new Label();
        tabSecurity = new TabPage();
        numWipePasses = new NumericUpDown();
        lblWipePasses = new Label();
        chkAutoDelete = new CheckBox();
        chkWipeMemory = new CheckBox();
        chkClearClipboard = new CheckBox();
        numClipboardTimeout = new NumericUpDown();
        lblClipboardTimeout = new Label();
        numAutoLockTimeout = new NumericUpDown();
        lblAutoLockTimeout = new Label();
        tabPasswords = new TabPage();
        chkExcludeAmbiguous = new CheckBox();
        chkExcludeSimilar = new CheckBox();
        chkIncludeSymbols = new CheckBox();
        chkIncludeNumbers = new CheckBox();
        chkIncludeLowercase = new CheckBox();
        chkIncludeUppercase = new CheckBox();
        numMaxPasswordLength = new NumericUpDown();
        lblMaxPasswordLength = new Label();
        numMinPasswordLength = new NumericUpDown();
        lblMinPasswordLength = new Label();
        tabCustomCrypto = new TabPage();
        chkEnableDES = new CheckBox();
        chkEnableMD5 = new CheckBox();
        cmbSelectedAlgorithm = new ComboBox();
        lblSelectedAlgorithm = new Label();
        chkEnableCustomCrypto = new CheckBox();
        tabUI = new TabPage();
        chkConfirmBeforeExit = new CheckBox();
        chkShowToolTips = new CheckBox();
        cmbLanguage = new ComboBox();
        lblLanguage = new Label();
        cmbTheme = new ComboBox();
        lblTheme = new Label();
        tabLogging = new TabPage();
        chkLogToDatabase = new CheckBox();
        chkLogToFile = new CheckBox();
        numLogRetentionDays = new NumericUpDown();
        lblLogRetentionDays = new Label();
        chkEnableLogging = new CheckBox();
        tabUserInfo = new TabPage();
        txtAdditionalKey = new TextBox();
        lblAdditionalKey = new Label();
        txtUsername = new TextBox();
        lblUsername = new Label();
        panelHeader.SuspendLayout();
        panelMain.SuspendLayout();
        panelActions.SuspendLayout();
        tabControl.SuspendLayout();
        tabEncryption.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numKeySize).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numSaltLength).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPbkdf2Iterations).BeginInit();
        tabSecurity.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numWipePasses).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numClipboardTimeout).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numAutoLockTimeout).BeginInit();
        tabPasswords.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numMaxPasswordLength).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numMinPasswordLength).BeginInit();
        tabCustomCrypto.SuspendLayout();
        tabUI.SuspendLayout();
        tabLogging.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numLogRetentionDays).BeginInit();
        tabUserInfo.SuspendLayout();
        SuspendLayout();
        
        // panelHeader
        panelHeader.BackColor = Color.FromArgb(30, 30, 40);
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(1000, 60);
        panelHeader.TabIndex = 0;
        
        // lblTitle
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1000, 60);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "إعدادات التطبيق";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        
        // panelMain
        panelMain.Controls.Add(panelActions);
        panelMain.Controls.Add(tabControl);
        panelMain.Dock = DockStyle.Fill;
        panelMain.Location = new Point(0, 60);
        panelMain.Name = "panelMain";
        panelMain.Padding = new Padding(20);
        panelMain.Size = new Size(1000, 740);
        panelMain.TabIndex = 1;
        
        // panelActions
        panelActions.Controls.Add(btnExport);
        panelActions.Controls.Add(btnImport);
        panelActions.Controls.Add(btnTestSettings);
        panelActions.Controls.Add(btnApply);
        panelActions.Controls.Add(btnReset);
        panelActions.Controls.Add(btnCancel);
        panelActions.Controls.Add(btnSave);
        panelActions.Dock = DockStyle.Bottom;
        panelActions.Location = new Point(20, 660);
        panelActions.Name = "panelActions";
        panelActions.Size = new Size(960, 60);
        panelActions.TabIndex = 1;
        
        // btnExport
        btnExport.BackColor = Color.FromArgb(40, 167, 69);
        btnExport.FlatStyle = FlatStyle.Flat;
        btnExport.ForeColor = Color.White;
        btnExport.Location = new Point(20, 15);
        btnExport.Name = "btnExport";
        btnExport.Size = new Size(120, 35);
        btnExport.TabIndex = 6;
        btnExport.Text = "تصدير";
        btnExport.UseVisualStyleBackColor = false;
        btnExport.Click += btnExport_Click;
        
        // btnImport
        btnImport.BackColor = Color.FromArgb(0, 123, 255);
        btnImport.FlatStyle = FlatStyle.Flat;
        btnImport.ForeColor = Color.White;
        btnImport.Location = new Point(150, 15);
        btnImport.Name = "btnImport";
        btnImport.Size = new Size(120, 35);
        btnImport.TabIndex = 5;
        btnImport.Text = "استيراد";
        btnImport.UseVisualStyleBackColor = false;
        btnImport.Click += btnImport_Click;
        
        // btnTestSettings
        btnTestSettings.BackColor = Color.FromArgb(23, 162, 184);
        btnTestSettings.FlatStyle = FlatStyle.Flat;
        btnTestSettings.ForeColor = Color.White;
        btnTestSettings.Location = new Point(280, 15);
        btnTestSettings.Name = "btnTestSettings";
        btnTestSettings.Size = new Size(120, 35);
        btnTestSettings.TabIndex = 4;
        btnTestSettings.Text = "اختبار الإعدادات";
        btnTestSettings.UseVisualStyleBackColor = false;
        btnTestSettings.Click += btnTestSettings_Click;
        
        // btnApply
        btnApply.BackColor = Color.FromArgb(255, 193, 7);
        btnApply.Enabled = false;
        btnApply.FlatStyle = FlatStyle.Flat;
        btnApply.ForeColor = Color.Black;
        btnApply.Location = new Point(410, 15);
        btnApply.Name = "btnApply";
        btnApply.Size = new Size(120, 35);
        btnApply.TabIndex = 3;
        btnApply.Text = "تطبيق";
        btnApply.UseVisualStyleBackColor = false;
        
        // btnReset
        btnReset.BackColor = Color.FromArgb(108, 117, 125);
        btnReset.FlatStyle = FlatStyle.Flat;
        btnReset.ForeColor = Color.White;
        btnReset.Location = new Point(540, 15);
        btnReset.Name = "btnReset";
        btnReset.Size = new Size(120, 35);
        btnReset.TabIndex = 2;
        btnReset.Text = "🔄 إعادة تعيين";
        btnReset.UseVisualStyleBackColor = false;
        
        // btnCancel
        btnCancel.BackColor = Color.FromArgb(220, 53, 69);
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.ForeColor = Color.White;
        btnCancel.Location = new Point(670, 15);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 35);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "إلغاء";
        btnCancel.UseVisualStyleBackColor = false;
        
        // btnSave
        btnSave.BackColor = Color.FromArgb(0, 123, 255);
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(800, 15);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(140, 35);
        btnSave.TabIndex = 0;
        btnSave.Text = "💾 حفظ";
        btnSave.UseVisualStyleBackColor = false;
        
        // tabControl
        tabControl.Controls.Add(tabEncryption);
        tabControl.Controls.Add(tabSecurity);
        tabControl.Controls.Add(tabPasswords);
        tabControl.Controls.Add(tabCustomCrypto);
        tabControl.Controls.Add(tabUI);
        tabControl.Controls.Add(tabLogging);
        tabControl.Controls.Add(tabUserInfo);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Location = new Point(20, 20);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(960, 640);
        tabControl.TabIndex = 0;
        
        // tabEncryption
        tabEncryption.Controls.Add(chkUseUsername);
        tabEncryption.Controls.Add(chkUseAdditionalKey);
        tabEncryption.Controls.Add(numKeySize);
        tabEncryption.Controls.Add(lblKeySize);
        tabEncryption.Controls.Add(numSaltLength);
        tabEncryption.Controls.Add(lblSaltLength);
        tabEncryption.Controls.Add(numPbkdf2Iterations);
        tabEncryption.Controls.Add(lblPbkdf2Iterations);
        tabEncryption.Location = new Point(4, 29);
        tabEncryption.Name = "tabEncryption";
        tabEncryption.Padding = new Padding(3);
        tabEncryption.Size = new Size(952, 607);
        tabEncryption.TabIndex = 0;
        tabEncryption.Text = "إعدادات التشفير";
        tabEncryption.UseVisualStyleBackColor = true;
        
        // chkUseUsername
        chkUseUsername.AutoSize = true;
        chkUseUsername.Location = new Point(50, 180);
        chkUseUsername.Name = "chkUseUsername";
        chkUseUsername.Size = new Size(176, 24);
        chkUseUsername.TabIndex = 7;
        chkUseUsername.Text = "استخدام اسم المستخدم";
        chkUseUsername.UseVisualStyleBackColor = true;
        
        // chkUseAdditionalKey
        chkUseAdditionalKey.AutoSize = true;
        chkUseAdditionalKey.Location = new Point(50, 150);
        chkUseAdditionalKey.Name = "chkUseAdditionalKey";
        chkUseAdditionalKey.Size = new Size(163, 24);
        chkUseAdditionalKey.TabIndex = 6;
        chkUseAdditionalKey.Text = "استخدام مفتاح إضافي";
        chkUseAdditionalKey.UseVisualStyleBackColor = true;
        
        // numKeySize
        numKeySize.Location = new Point(50, 120);
        numKeySize.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
        numKeySize.Minimum = new decimal(new int[] { 128, 0, 0, 0 });
        numKeySize.Name = "numKeySize";
        numKeySize.Size = new Size(300, 27);
        numKeySize.TabIndex = 5;
        numKeySize.Value = new decimal(new int[] { 256, 0, 0, 0 });
        
        // lblKeySize
        lblKeySize.AutoSize = true;
        lblKeySize.Location = new Point(50, 95);
        lblKeySize.Name = "lblKeySize";
        lblKeySize.Size = new Size(116, 20);
        lblKeySize.TabIndex = 4;
        lblKeySize.Text = "حجم المفتاح (بت):";
        
        // numSaltLength
        numSaltLength.Location = new Point(50, 65);
        numSaltLength.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
        numSaltLength.Minimum = new decimal(new int[] { 16, 0, 0, 0 });
        numSaltLength.Name = "numSaltLength";
        numSaltLength.Size = new Size(300, 27);
        numSaltLength.TabIndex = 3;
        numSaltLength.Value = new decimal(new int[] { 32, 0, 0, 0 });
        
        // lblSaltLength
        lblSaltLength.AutoSize = true;
        lblSaltLength.Location = new Point(50, 40);
        lblSaltLength.Name = "lblSaltLength";
        lblSaltLength.Size = new Size(111, 20);
        lblSaltLength.TabIndex = 2;
        lblSaltLength.Text = "طول الملح (بايت):";
        
        // numPbkdf2Iterations
        numPbkdf2Iterations.Location = new Point(50, 15);
        numPbkdf2Iterations.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numPbkdf2Iterations.Minimum = new decimal(new int[] { 10000, 0, 0, 0 });
        numPbkdf2Iterations.Name = "numPbkdf2Iterations";
        numPbkdf2Iterations.Size = new Size(300, 27);
        numPbkdf2Iterations.TabIndex = 1;
        numPbkdf2Iterations.Value = new decimal(new int[] { 100000, 0, 0, 0 });
        
        // lblPbkdf2Iterations
        lblPbkdf2Iterations.AutoSize = true;
        lblPbkdf2Iterations.Location = new Point(50, -10);
        lblPbkdf2Iterations.Name = "lblPbkdf2Iterations";
        lblPbkdf2Iterations.Size = new Size(126, 20);
        lblPbkdf2Iterations.TabIndex = 0;
        lblPbkdf2Iterations.Text = "تكرارات PBKDF2:";
        
        // tabSecurity
        tabSecurity.Controls.Add(numWipePasses);
        tabSecurity.Controls.Add(lblWipePasses);
        tabSecurity.Controls.Add(chkAutoDelete);
        tabSecurity.Controls.Add(chkWipeMemory);
        tabSecurity.Controls.Add(chkClearClipboard);
        tabSecurity.Controls.Add(numClipboardTimeout);
        tabSecurity.Controls.Add(lblClipboardTimeout);
        tabSecurity.Controls.Add(numAutoLockTimeout);
        tabSecurity.Controls.Add(lblAutoLockTimeout);
        tabSecurity.Location = new Point(4, 29);
        tabSecurity.Name = "tabSecurity";
        tabSecurity.Padding = new Padding(3);
        tabSecurity.Size = new Size(952, 607);
        tabSecurity.TabIndex = 1;
        tabSecurity.Text = "الأمان";
        tabSecurity.UseVisualStyleBackColor = true;
        
        // numWipePasses
        numWipePasses.Location = new Point(50, 180);
        numWipePasses.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numWipePasses.Name = "numWipePasses";
        numWipePasses.Size = new Size(300, 27);
        numWipePasses.TabIndex = 8;
        numWipePasses.Value = new decimal(new int[] { 3, 0, 0, 0 });
        
        // lblWipePasses
        lblWipePasses.AutoSize = true;
        lblWipePasses.Location = new Point(50, 155);
        lblWipePasses.Name = "lblWipePasses";
        lblWipePasses.Size = new Size(184, 20);
        lblWipePasses.TabIndex = 7;
        lblWipePasses.Text = "عدد مرات الكتابة فوق الملف:";
        
        // chkAutoDelete
        chkAutoDelete.AutoSize = true;
        chkAutoDelete.Location = new Point(50, 125);
        chkAutoDelete.Name = "chkAutoDelete";
        chkAutoDelete.Size = new Size(236, 24);
        chkAutoDelete.TabIndex = 6;
        chkAutoDelete.Text = "حذف الملف الأصلي بعد التشفير";
        chkAutoDelete.UseVisualStyleBackColor = true;
        
        // chkWipeMemory
        chkWipeMemory.AutoSize = true;
        chkWipeMemory.Location = new Point(50, 95);
        chkWipeMemory.Name = "chkWipeMemory";
        chkWipeMemory.Size = new Size(198, 24);
        chkWipeMemory.TabIndex = 5;
        chkWipeMemory.Text = "مسح الذاكرة بعد الاستخدام";
        chkWipeMemory.UseVisualStyleBackColor = true;
        
        // chkClearClipboard
        chkClearClipboard.AutoSize = true;
        chkClearClipboard.Location = new Point(50, 65);
        chkClearClipboard.Name = "chkClearClipboard";
        chkClearClipboard.Size = new Size(204, 24);
        chkClearClipboard.TabIndex = 4;
        chkClearClipboard.Text = "مسح الحافظة بعد الاستخدام";
        chkClearClipboard.UseVisualStyleBackColor = true;
        
        // numClipboardTimeout
        numClipboardTimeout.Location = new Point(50, 35);
        numClipboardTimeout.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
        numClipboardTimeout.Name = "numClipboardTimeout";
        numClipboardTimeout.Size = new Size(300, 27);
        numClipboardTimeout.TabIndex = 3;
        numClipboardTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });
        
        // lblClipboardTimeout
        lblClipboardTimeout.AutoSize = true;
        lblClipboardTimeout.Location = new Point(50, 10);
        lblClipboardTimeout.Name = "lblClipboardTimeout";
        lblClipboardTimeout.Size = new Size(177, 20);
        lblClipboardTimeout.TabIndex = 2;
        lblClipboardTimeout.Text = "مهلة مسح الحافظة (ثانية):";
        
        // numAutoLockTimeout
        numAutoLockTimeout.Location = new Point(50, -15);
        numAutoLockTimeout.Maximum = new decimal(new int[] { 86400, 0, 0, 0 });
        numAutoLockTimeout.Name = "numAutoLockTimeout";
        numAutoLockTimeout.Size = new Size(300, 27);
        numAutoLockTimeout.TabIndex = 1;
        numAutoLockTimeout.Value = new decimal(new int[] { 300, 0, 0, 0 });
        
        // lblAutoLockTimeout
        lblAutoLockTimeout.AutoSize = true;
        lblAutoLockTimeout.Location = new Point(50, -40);
        lblAutoLockTimeout.Name = "lblAutoLockTimeout";
        lblAutoLockTimeout.Size = new Size(185, 20);
        lblAutoLockTimeout.TabIndex = 0;
        lblAutoLockTimeout.Text = "مهلة القفل التلقائي (ثانية):";
        
        // tabPasswords
        tabPasswords.Controls.Add(chkExcludeAmbiguous);
        tabPasswords.Controls.Add(chkExcludeSimilar);
        tabPasswords.Controls.Add(chkIncludeSymbols);
        tabPasswords.Controls.Add(chkIncludeNumbers);
        tabPasswords.Controls.Add(chkIncludeLowercase);
        tabPasswords.Controls.Add(chkIncludeUppercase);
        tabPasswords.Controls.Add(numMaxPasswordLength);
        tabPasswords.Controls.Add(lblMaxPasswordLength);
        tabPasswords.Controls.Add(numMinPasswordLength);
        tabPasswords.Controls.Add(lblMinPasswordLength);
        tabPasswords.Location = new Point(4, 29);
        tabPasswords.Name = "tabPasswords";
        tabPasswords.Size = new Size(952, 607);
        tabPasswords.TabIndex = 2;
        tabPasswords.Text = "كلمات المرور";
        tabPasswords.UseVisualStyleBackColor = true;
        
        // chkExcludeAmbiguous
        chkExcludeAmbiguous.AutoSize = true;
        chkExcludeAmbiguous.Location = new Point(50, 210);
        chkExcludeAmbiguous.Name = "chkExcludeAmbiguous";
        chkExcludeAmbiguous.Size = new Size(191, 24);
        chkExcludeAmbiguous.TabIndex = 9;
        chkExcludeAmbiguous.Text = "استبعاد الأحرف المربكة";
        chkExcludeAmbiguous.UseVisualStyleBackColor = true;
        
        // chkExcludeSimilar
        chkExcludeSimilar.AutoSize = true;
        chkExcludeSimilar.Location = new Point(50, 180);
        chkExcludeSimilar.Name = "chkExcludeSimilar";
        chkExcludeSimilar.Size = new Size(207, 24);
        chkExcludeSimilar.TabIndex = 8;
        chkExcludeSimilar.Text = "استبعاد الأحرف المتشابهة";
        chkExcludeSimilar.UseVisualStyleBackColor = true;
        
        // chkIncludeSymbols
        chkIncludeSymbols.AutoSize = true;
        chkIncludeSymbols.Location = new Point(50, 150);
        chkIncludeSymbols.Name = "chkIncludeSymbols";
        chkIncludeSymbols.Size = new Size(131, 24);
        chkIncludeSymbols.TabIndex = 7;
        chkIncludeSymbols.Text = "تضمين رموز";
        chkIncludeSymbols.UseVisualStyleBackColor = true;
        
        // chkIncludeNumbers
        chkIncludeNumbers.AutoSize = true;
        chkIncludeNumbers.Location = new Point(50, 120);
        chkIncludeNumbers.Name = "chkIncludeNumbers";
        chkIncludeNumbers.Size = new Size(121, 24);
        chkIncludeNumbers.TabIndex = 6;
        chkIncludeNumbers.Text = "تضمين أرقام";
        chkIncludeNumbers.UseVisualStyleBackColor = true;
        
        // chkIncludeLowercase
        chkIncludeLowercase.AutoSize = true;
        chkIncludeLowercase.Location = new Point(50, 90);
        chkIncludeLowercase.Name = "chkIncludeLowercase";
        chkIncludeLowercase.Size = new Size(146, 24);
        chkIncludeLowercase.TabIndex = 5;
        chkIncludeLowercase.Text = "تضمين أحرف صغيرة";
        chkIncludeLowercase.UseVisualStyleBackColor = true;
        
        // chkIncludeUppercase
        chkIncludeUppercase.AutoSize = true;
        chkIncludeUppercase.Location = new Point(50, 60);
        chkIncludeUppercase.Name = "chkIncludeUppercase";
        chkIncludeUppercase.Size = new Size(144, 24);
        chkIncludeUppercase.TabIndex = 4;
        chkIncludeUppercase.Text = "تضمين أحرف كبيرة";
        chkIncludeUppercase.UseVisualStyleBackColor = true;
        
        // numMaxPasswordLength
        numMaxPasswordLength.Location = new Point(50, 35);
        numMaxPasswordLength.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
        numMaxPasswordLength.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
        numMaxPasswordLength.Name = "numMaxPasswordLength";
        numMaxPasswordLength.Size = new Size(300, 27);
        numMaxPasswordLength.TabIndex = 3;
        numMaxPasswordLength.Value = new decimal(new int[] { 24, 0, 0, 0 });
        
        // lblMaxPasswordLength
        lblMaxPasswordLength.AutoSize = true;
        lblMaxPasswordLength.Location = new Point(50, 10);
        lblMaxPasswordLength.Name = "lblMaxPasswordLength";
        lblMaxPasswordLength.Size = new Size(200, 20);
        lblMaxPasswordLength.TabIndex = 2;
        lblMaxPasswordLength.Text = "الحد الأقصى لطول كلمة المرور:";
        
        // numMinPasswordLength
        numMinPasswordLength.Location = new Point(50, -15);
        numMinPasswordLength.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
        numMinPasswordLength.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
        numMinPasswordLength.Name = "numMinPasswordLength";
        numMinPasswordLength.Size = new Size(300, 27);
        numMinPasswordLength.TabIndex = 1;
        numMinPasswordLength.Value = new decimal(new int[] { 12, 0, 0, 0 });
        
        // lblMinPasswordLength
        lblMinPasswordLength.AutoSize = true;
        lblMinPasswordLength.Location = new Point(50, -40);
        lblMinPasswordLength.Name = "lblMinPasswordLength";
        lblMinPasswordLength.Size = new Size(198, 20);
        lblMinPasswordLength.TabIndex = 0;
        lblMinPasswordLength.Text = "الحد الأدنى لطول كلمة المرور:";
        
        // tabCustomCrypto
        tabCustomCrypto.Controls.Add(chkEnableDES);
        tabCustomCrypto.Controls.Add(chkEnableMD5);
        tabCustomCrypto.Controls.Add(cmbSelectedAlgorithm);
        tabCustomCrypto.Controls.Add(lblSelectedAlgorithm);
        tabCustomCrypto.Controls.Add(chkEnableCustomCrypto);
        tabCustomCrypto.Location = new Point(4, 29);
        tabCustomCrypto.Name = "tabCustomCrypto";
        tabCustomCrypto.Size = new Size(952, 607);
        tabCustomCrypto.TabIndex = 3;
        tabCustomCrypto.Text = "التشفير المخصص";
        tabCustomCrypto.UseVisualStyleBackColor = true;
        
        // chkEnableDES
        chkEnableDES.AutoSize = true;
        chkEnableDES.Location = new Point(50, 120);
        chkEnableDES.Name = "chkEnableDES";
        chkEnableDES.Size = new Size(112, 24);
        chkEnableDES.TabIndex = 4;
        chkEnableDES.Text = "تمكين DES";
        chkEnableDES.UseVisualStyleBackColor = true;
        
        // chkEnableMD5
        chkEnableMD5.AutoSize = true;
        chkEnableMD5.Location = new Point(50, 90);
        chkEnableMD5.Name = "chkEnableMD5";
        chkEnableMD5.Size = new Size(118, 24);
        chkEnableMD5.TabIndex = 3;
        chkEnableMD5.Text = "تمكين MD5";
        chkEnableMD5.UseVisualStyleBackColor = true;
        
        // cmbSelectedAlgorithm
        cmbSelectedAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSelectedAlgorithm.Enabled = false;
        cmbSelectedAlgorithm.FormattingEnabled = true;
        cmbSelectedAlgorithm.Items.AddRange(new object[] { "AES256", "AES128", "DES", "TripleDES" });
        cmbSelectedAlgorithm.Location = new Point(50, 60);
        cmbSelectedAlgorithm.Name = "cmbSelectedAlgorithm";
        cmbSelectedAlgorithm.Size = new Size(300, 28);
        cmbSelectedAlgorithm.TabIndex = 2;
        
        // lblSelectedAlgorithm
        lblSelectedAlgorithm.AutoSize = true;
        lblSelectedAlgorithm.Location = new Point(50, 35);
        lblSelectedAlgorithm.Name = "lblSelectedAlgorithm";
        lblSelectedAlgorithm.Size = new Size(131, 20);
        lblSelectedAlgorithm.TabIndex = 1;
        lblSelectedAlgorithm.Text = "الخوارزمية المختارة:";
        
        // chkEnableCustomCrypto
        chkEnableCustomCrypto.AutoSize = true;
        chkEnableCustomCrypto.Location = new Point(50, 10);
        chkEnableCustomCrypto.Name = "chkEnableCustomCrypto";
        chkEnableCustomCrypto.Size = new Size(172, 24);
        chkEnableCustomCrypto.TabIndex = 0;
        chkEnableCustomCrypto.Text = "تمكين التشفير المخصص";
        chkEnableCustomCrypto.UseVisualStyleBackColor = true;
        chkEnableCustomCrypto.CheckedChanged += chkEnableCustomCrypto_CheckedChanged;
        
        // tabUI
        tabUI.Controls.Add(chkConfirmBeforeExit);
        tabUI.Controls.Add(chkShowToolTips);
        tabUI.Controls.Add(cmbLanguage);
        tabUI.Controls.Add(lblLanguage);
        tabUI.Controls.Add(cmbTheme);
        tabUI.Controls.Add(lblTheme);
        tabUI.Location = new Point(4, 29);
        tabUI.Name = "tabUI";
        tabUI.Size = new Size(952, 607);
        tabUI.TabIndex = 4;
        tabUI.Text = "واجهة المستخدم";
        tabUI.UseVisualStyleBackColor = true;
        
        // chkConfirmBeforeExit
        chkConfirmBeforeExit.AutoSize = true;
        chkConfirmBeforeExit.Location = new Point(50, 120);
        chkConfirmBeforeExit.Name = "chkConfirmBeforeExit";
        chkConfirmBeforeExit.Size = new Size(180, 24);
        chkConfirmBeforeExit.TabIndex = 5;
        chkConfirmBeforeExit.Text = "طلب تأكيد قبل الخروج";
        chkConfirmBeforeExit.UseVisualStyleBackColor = true;
        
        // chkShowToolTips
        chkShowToolTips.AutoSize = true;
        chkShowToolTips.Location = new Point(50, 90);
        chkShowToolTips.Name = "chkShowToolTips";
        chkShowToolTips.Size = new Size(156, 24);
        chkShowToolTips.TabIndex = 4;
        chkShowToolTips.Text = "إظهار تلميحات الأدوات";
        chkShowToolTips.UseVisualStyleBackColor = true;
        
        // cmbLanguage
        cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbLanguage.FormattingEnabled = true;
        cmbLanguage.Items.AddRange(new object[] { "ar", "en" });
        cmbLanguage.Location = new Point(50, 60);
        cmbLanguage.Name = "cmbLanguage";
        cmbLanguage.Size = new Size(300, 28);
        cmbLanguage.TabIndex = 3;
        
        // lblLanguage
        lblLanguage.AutoSize = true;
        lblLanguage.Location = new Point(50, 35);
        lblLanguage.Name = "lblLanguage";
        lblLanguage.Size = new Size(48, 20);
        lblLanguage.TabIndex = 2;
        lblLanguage.Text = "اللغة:";
        
        // cmbTheme
        cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTheme.FormattingEnabled = true;
        cmbTheme.Items.AddRange(new object[] { "Dark", "Light", "System" });
        cmbTheme.Location = new Point(50, 10);
        cmbTheme.Name = "cmbTheme";
        cmbTheme.Size = new Size(300, 28);
        cmbTheme.TabIndex = 1;
        
        // lblTheme
        lblTheme.AutoSize = true;
        lblTheme.Location = new Point(50, -15);
        lblTheme.Name = "lblTheme";
        lblTheme.Size = new Size(47, 20);
        lblTheme.TabIndex = 0;
        lblTheme.Text = "السمة:";
        
        // tabLogging
        tabLogging.Controls.Add(chkLogToDatabase);
        tabLogging.Controls.Add(chkLogToFile);
        tabLogging.Controls.Add(numLogRetentionDays);
        tabLogging.Controls.Add(lblLogRetentionDays);
        tabLogging.Controls.Add(chkEnableLogging);
        tabLogging.Location = new Point(4, 29);
        tabLogging.Name = "tabLogging";
        tabLogging.Size = new Size(952, 607);
        tabLogging.TabIndex = 5;
        tabLogging.Text = "السجلات";
        tabLogging.UseVisualStyleBackColor = true;
        
        // chkLogToDatabase
        chkLogToDatabase.AutoSize = true;
        chkLogToDatabase.Enabled = false;
        chkLogToDatabase.Location = new Point(50, 120);
        chkLogToDatabase.Name = "chkLogToDatabase";
        chkLogToDatabase.Size = new Size(179, 24);
        chkLogToDatabase.TabIndex = 4;
        chkLogToDatabase.Text = "التسجيل في قاعدة بيانات";
        chkLogToDatabase.UseVisualStyleBackColor = true;
        
        // chkLogToFile
        chkLogToFile.AutoSize = true;
        chkLogToFile.Enabled = false;
        chkLogToFile.Location = new Point(50, 90);
        chkLogToFile.Name = "chkLogToFile";
        chkLogToFile.Size = new Size(137, 24);
        chkLogToFile.TabIndex = 3;
        chkLogToFile.Text = "التسجيل في ملف";
        chkLogToFile.UseVisualStyleBackColor = true;
        
        // numLogRetentionDays
        numLogRetentionDays.Enabled = false;
        numLogRetentionDays.Location = new Point(50, 60);
        numLogRetentionDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
        numLogRetentionDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numLogRetentionDays.Name = "numLogRetentionDays";
        numLogRetentionDays.Size = new Size(300, 27);
        numLogRetentionDays.TabIndex = 2;
        numLogRetentionDays.Value = new decimal(new int[] { 30, 0, 0, 0 });
        
        // lblLogRetentionDays
        lblLogRetentionDays.AutoSize = true;
        lblLogRetentionDays.Location = new Point(50, 35);
        lblLogRetentionDays.Name = "lblLogRetentionDays";
        lblLogRetentionDays.Size = new Size(214, 20);
        lblLogRetentionDays.TabIndex = 1;
        lblLogRetentionDays.Text = "فترة الاحتفاظ بالسجلات (أيام):";
        
        // chkEnableLogging
        chkEnableLogging.AutoSize = true;
        chkEnableLogging.Location = new Point(50, 10);
        chkEnableLogging.Name = "chkEnableLogging";
        chkEnableLogging.Size = new Size(137, 24);
        chkEnableLogging.TabIndex = 0;
        chkEnableLogging.Text = "تمكين التسجيل";
        chkEnableLogging.UseVisualStyleBackColor = true;
        chkEnableLogging.CheckedChanged += chkEnableLogging_CheckedChanged;
        
        // tabUserInfo
        tabUserInfo.Controls.Add(txtAdditionalKey);
        tabUserInfo.Controls.Add(lblAdditionalKey);
        tabUserInfo.Controls.Add(txtUsername);
        tabUserInfo.Controls.Add(lblUsername);
        tabUserInfo.Location = new Point(4, 29);
        tabUserInfo.Name = "tabUserInfo";
        tabUserInfo.Size = new Size(952, 607);
        tabUserInfo.TabIndex = 6;
        tabUserInfo.Text = "معلومات المستخدم";
        tabUserInfo.UseVisualStyleBackColor = true;
        
        // txtAdditionalKey
        txtAdditionalKey.Location = new Point(50, 65);
        txtAdditionalKey.Name = "txtAdditionalKey";
        txtAdditionalKey.Size = new Size(300, 27);
        txtAdditionalKey.TabIndex = 3;
        
        // lblAdditionalKey
        lblAdditionalKey.AutoSize = true;
        lblAdditionalKey.Location = new Point(50, 40);
        lblAdditionalKey.Name = "lblAdditionalKey";
        lblAdditionalKey.Size = new Size(175, 20);
        lblAdditionalKey.TabIndex = 2;
        lblAdditionalKey.Text = "المفتاح الإضافي الافتراضي:";
        
        // txtUsername
        txtUsername.Location = new Point(50, 15);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(300, 27);
        txtUsername.TabIndex = 1;
        
        // lblUsername
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(50, -10);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(155, 20);
        lblUsername.TabIndex = 0;
        lblUsername.Text = "اسم المستخدم الافتراضي:";
        
        // SettingsForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1000, 800);
        Controls.Add(panelMain);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = null;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SettingsForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = FormStartPosition.CenterParent;
        Text = "إعدادات التطبيق";
        panelHeader.ResumeLayout(false);
        panelMain.ResumeLayout(false);
        panelActions.ResumeLayout(false);
        tabControl.ResumeLayout(false);
        tabEncryption.ResumeLayout(false);
        tabEncryption.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numKeySize).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSaltLength).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPbkdf2Iterations).EndInit();
        tabSecurity.ResumeLayout(false);
        tabSecurity.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numWipePasses).EndInit();
        ((System.ComponentModel.ISupportInitialize)numClipboardTimeout).EndInit();
        ((System.ComponentModel.ISupportInitialize)numAutoLockTimeout).EndInit();
        tabPasswords.ResumeLayout(false);
        tabPasswords.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numMaxPasswordLength).EndInit();
        ((System.ComponentModel.ISupportInitialize)numMinPasswordLength).EndInit();
        tabCustomCrypto.ResumeLayout(false);
        tabCustomCrypto.PerformLayout();
        tabUI.ResumeLayout(false);
        tabUI.PerformLayout();
        tabLogging.ResumeLayout(false);
        tabLogging.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numLogRetentionDays).EndInit();
        tabUserInfo.ResumeLayout(false);
        tabUserInfo.PerformLayout();
        ResumeLayout(false);
    }
}