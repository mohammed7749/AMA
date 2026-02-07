namespace SecureDataProtectionTool.UI;

partial class TextDecryptionForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.GroupBox grpInput;
    private System.Windows.Forms.Label lblInputText;
    private System.Windows.Forms.TextBox txtInputText;
    private System.Windows.Forms.Label lblInputLength;
    private System.Windows.Forms.Button btnCopyInput;
    private System.Windows.Forms.Button btnPasteInput;
    private System.Windows.Forms.GroupBox grpOutput;
    private System.Windows.Forms.Label lblOutputText;
    private System.Windows.Forms.TextBox txtOutputText;
    private System.Windows.Forms.Label lblOutputLength;
    private System.Windows.Forms.Button btnCopyOutput;
    private System.Windows.Forms.GroupBox grpSecurity;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSecurity;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label lblAdditionalKey;
    private System.Windows.Forms.TextBox txtAdditionalKey;
    private System.Windows.Forms.CheckBox chkUseUsername;
    private System.Windows.Forms.CheckBox chkUseAdditionalKey;
    private System.Windows.Forms.CheckBox chkShowPassword;
    private System.Windows.Forms.CheckBox chkAutoClearClipboard;
    private System.Windows.Forms.Label lblClipboardTimeout;
    private System.Windows.Forms.GroupBox grpActions;
    private System.Windows.Forms.Button btnDecrypt;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnAnalyzeText;
    private System.Windows.Forms.GroupBox grpProgress;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label lblProgress;
    private System.Windows.Forms.GroupBox grpHistory;
    private System.Windows.Forms.ListView lstHistory;
    private System.Windows.Forms.ColumnHeader colTime;
    private System.Windows.Forms.ColumnHeader colOperation;
    private System.Windows.Forms.ColumnHeader colInputText;
    private System.Windows.Forms.ColumnHeader colOutputText;
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
    
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        panelHeader = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        panelMain = new System.Windows.Forms.Panel();
        tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
        grpInput = new System.Windows.Forms.GroupBox();
        lblInputText = new System.Windows.Forms.Label();
        txtInputText = new System.Windows.Forms.TextBox();
        lblInputLength = new System.Windows.Forms.Label();
        btnCopyInput = new System.Windows.Forms.Button();
        btnPasteInput = new System.Windows.Forms.Button();
        grpOutput = new System.Windows.Forms.GroupBox();
        lblOutputText = new System.Windows.Forms.Label();
        txtOutputText = new System.Windows.Forms.TextBox();
        lblOutputLength = new System.Windows.Forms.Label();
        btnCopyOutput = new System.Windows.Forms.Button();
        grpSecurity = new System.Windows.Forms.GroupBox();
        tableLayoutPanelSecurity = new System.Windows.Forms.TableLayoutPanel();
        lblPassword = new System.Windows.Forms.Label();
        txtPassword = new System.Windows.Forms.TextBox();
        lblUsername = new System.Windows.Forms.Label();
        txtUsername = new System.Windows.Forms.TextBox();
        lblAdditionalKey = new System.Windows.Forms.Label();
        txtAdditionalKey = new System.Windows.Forms.TextBox();
        chkUseUsername = new System.Windows.Forms.CheckBox();
        chkUseAdditionalKey = new System.Windows.Forms.CheckBox();
        chkShowPassword = new System.Windows.Forms.CheckBox();
        chkAutoClearClipboard = new System.Windows.Forms.CheckBox();
        lblClipboardTimeout = new System.Windows.Forms.Label();
        grpActions = new System.Windows.Forms.GroupBox();
        btnDecrypt = new System.Windows.Forms.Button();
        btnClear = new System.Windows.Forms.Button();
        btnAnalyzeText = new System.Windows.Forms.Button();
        grpProgress = new System.Windows.Forms.GroupBox();
        progressBar = new System.Windows.Forms.ProgressBar();
        lblProgress = new System.Windows.Forms.Label();
        grpHistory = new System.Windows.Forms.GroupBox();
        lstHistory = new System.Windows.Forms.ListView();
        colTime = new System.Windows.Forms.ColumnHeader();
        colOperation = new System.Windows.Forms.ColumnHeader();
        colInputText = new System.Windows.Forms.ColumnHeader();
        colOutputText = new System.Windows.Forms.ColumnHeader();
        colDuration = new System.Windows.Forms.ColumnHeader();
        colStatus = new System.Windows.Forms.ColumnHeader();
        toolTip = new System.Windows.Forms.ToolTip(components);
        
        // TextDecryptionForm
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(1200, 800);
        Controls.Add(panelMain);
        Controls.Add(panelHeader);
        Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        MinimumSize = new System.Drawing.Size(1000, 700);
        Name = "TextDecryptionForm";
        RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "فك تشفير النصوص";
        
        // panelHeader
        panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)30)), ((int)((byte)40)));
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        panelHeader.Location = new System.Drawing.Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new System.Drawing.Size(1200, 60);
        panelHeader.TabIndex = 0;
        
        // lblTitle
        lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTitle.ForeColor = System.Drawing.Color.White;
        lblTitle.Location = new System.Drawing.Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(1200, 60);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "فك تشفير النصوص";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        
        // panelMain
        panelMain.AutoScroll = true;
        panelMain.Controls.Add(tableLayoutPanelMain);
        panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        panelMain.Location = new System.Drawing.Point(0, 60);
        panelMain.Name = "panelMain";
        panelMain.Padding = new System.Windows.Forms.Padding(20);
        panelMain.Size = new System.Drawing.Size(1200, 740);
        panelMain.TabIndex = 1;
        
        // tableLayoutPanelMain
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
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tableLayoutPanelMain.Size = new System.Drawing.Size(1160, 700);
        tableLayoutPanelMain.TabIndex = 0;
        
        // grpInput
        grpInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        grpInput.Controls.Add(lblInputText);
        grpInput.Controls.Add(txtInputText);
        grpInput.Controls.Add(lblInputLength);
        grpInput.Controls.Add(btnCopyInput);
        grpInput.Controls.Add(btnPasteInput);
        grpInput.Location = new System.Drawing.Point(3, 3);
        grpInput.Name = "grpInput";
        grpInput.Size = new System.Drawing.Size(574, 174);
        grpInput.TabIndex = 0;
        grpInput.TabStop = false;
        grpInput.Text = "المدخلات";
        
        // lblInputText
        lblInputText.AutoSize = true;
        lblInputText.Location = new System.Drawing.Point(20, 30);
        lblInputText.Name = "lblInputText";
        lblInputText.Size = new System.Drawing.Size(85, 20);
        lblInputText.TabIndex = 0;
        lblInputText.Text = "النص المدخل:";
        
        // txtInputText
        txtInputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        txtInputText.Location = new System.Drawing.Point(20, 60);
        txtInputText.Multiline = true;
        txtInputText.Name = "txtInputText";
        txtInputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtInputText.Size = new System.Drawing.Size(534, 80);
        txtInputText.TabIndex = 1;
        txtInputText.TextChanged += txtInputText_TextChanged;
        
        // lblInputLength
        lblInputLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        lblInputLength.AutoSize = true;
        lblInputLength.ForeColor = System.Drawing.Color.Green;
        lblInputLength.Location = new System.Drawing.Point(20, 145);
        lblInputLength.Name = "lblInputLength";
        lblInputLength.Size = new System.Drawing.Size(58, 20);
        lblInputLength.TabIndex = 2;
        lblInputLength.Text = "0 حرف";
        
        // btnCopyInput
        btnCopyInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        btnCopyInput.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnCopyInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCopyInput.ForeColor = System.Drawing.Color.White;
        btnCopyInput.Location = new System.Drawing.Point(434, 140);
        btnCopyInput.Name = "btnCopyInput";
        btnCopyInput.Size = new System.Drawing.Size(120, 30);
        btnCopyInput.TabIndex = 3;
        btnCopyInput.Text = "📋 نسخ النص";
        btnCopyInput.UseVisualStyleBackColor = false;
        btnCopyInput.Click += BtnCopyInput_Click;
        
        // btnPasteInput
        btnPasteInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        btnPasteInput.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnPasteInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnPasteInput.ForeColor = System.Drawing.Color.White;
        btnPasteInput.Location = new System.Drawing.Point(304, 140);
        btnPasteInput.Name = "btnPasteInput";
        btnPasteInput.Size = new System.Drawing.Size(120, 30);
        btnPasteInput.TabIndex = 4;
        btnPasteInput.Text = "📋 لصق نص";
        btnPasteInput.UseVisualStyleBackColor = false;
        btnPasteInput.Click += BtnPasteInput_Click;
        
        // grpOutput
        grpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        grpOutput.Controls.Add(lblOutputText);
        grpOutput.Controls.Add(txtOutputText);
        grpOutput.Controls.Add(lblOutputLength);
        grpOutput.Controls.Add(btnCopyOutput);
        grpOutput.Location = new System.Drawing.Point(583, 3);
        grpOutput.Name = "grpOutput";
        grpOutput.Size = new System.Drawing.Size(574, 174);
        grpOutput.TabIndex = 1;
        grpOutput.TabStop = false;
        grpOutput.Text = "المخرجات";
        
        // lblOutputText
        lblOutputText.AutoSize = true;
        lblOutputText.Location = new System.Drawing.Point(20, 30);
        lblOutputText.Name = "lblOutputText";
        lblOutputText.Size = new System.Drawing.Size(86, 20);
        lblOutputText.TabIndex = 0;
        lblOutputText.Text = "النص الناتج:";
        
        // txtOutputText
        txtOutputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        txtOutputText.Location = new System.Drawing.Point(20, 60);
        txtOutputText.Multiline = true;
        txtOutputText.Name = "txtOutputText";
        txtOutputText.ReadOnly = true;
        txtOutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtOutputText.Size = new System.Drawing.Size(534, 80);
        txtOutputText.TabIndex = 1;
        txtOutputText.TextChanged += txtOutputText_TextChanged;
        
        // lblOutputLength
        lblOutputLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        lblOutputLength.AutoSize = true;
        lblOutputLength.ForeColor = System.Drawing.Color.Green;
        lblOutputLength.Location = new System.Drawing.Point(20, 145);
        lblOutputLength.Name = "lblOutputLength";
        lblOutputLength.Size = new System.Drawing.Size(58, 20);
        lblOutputLength.TabIndex = 2;
        lblOutputLength.Text = "0 حرف";
        
        // btnCopyOutput
        btnCopyOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        btnCopyOutput.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnCopyOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCopyOutput.ForeColor = System.Drawing.Color.White;
        btnCopyOutput.Location = new System.Drawing.Point(434, 140);
        btnCopyOutput.Name = "btnCopyOutput";
        btnCopyOutput.Size = new System.Drawing.Size(120, 30);
        btnCopyOutput.TabIndex = 3;
        btnCopyOutput.Text = "📋 نسخ الناتج";
        btnCopyOutput.UseVisualStyleBackColor = false;
        btnCopyOutput.Click += BtnCopyOutput_Click;
        
        // grpSecurity
        grpSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpSecurity, 2);
        grpSecurity.Controls.Add(tableLayoutPanelSecurity);
        grpSecurity.Location = new System.Drawing.Point(3, 183);
        grpSecurity.Name = "grpSecurity";
        grpSecurity.Size = new System.Drawing.Size(1154, 119);
        grpSecurity.TabIndex = 2;
        grpSecurity.TabStop = false;
        grpSecurity.Text = "إعدادات الأمان";
        
        // tableLayoutPanelSecurity
        tableLayoutPanelSecurity.ColumnCount = 4;
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelSecurity.Controls.Add(lblPassword, 0, 0);
        tableLayoutPanelSecurity.Controls.Add(txtPassword, 0, 1);
        tableLayoutPanelSecurity.Controls.Add(lblUsername, 2, 0);
        tableLayoutPanelSecurity.Controls.Add(txtUsername, 2, 1);
        tableLayoutPanelSecurity.Controls.Add(lblAdditionalKey, 3, 0);
        tableLayoutPanelSecurity.Controls.Add(txtAdditionalKey, 3, 1);
        tableLayoutPanelSecurity.Controls.Add(chkUseUsername, 2, 2);
        tableLayoutPanelSecurity.Controls.Add(chkUseAdditionalKey, 3, 2);
        tableLayoutPanelSecurity.Controls.Add(chkShowPassword, 0, 2);
        tableLayoutPanelSecurity.Controls.Add(chkAutoClearClipboard, 1, 2);
        tableLayoutPanelSecurity.Controls.Add(lblClipboardTimeout, 1, 3);
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
        
        // lblPassword
        lblPassword.AutoSize = true;
        lblPassword.Location = new System.Drawing.Point(1062, 0);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new System.Drawing.Size(83, 20);
        lblPassword.TabIndex = 0;
        lblPassword.Text = "كلمة المرور:";
        
        // txtPassword
        txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtPassword.Location = new System.Drawing.Point(864, 28);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new System.Drawing.Size(281, 27);
        txtPassword.TabIndex = 1;
        txtPassword.UseSystemPasswordChar = true;
        txtPassword.TextChanged += txtPassword_TextChanged;
        
        // lblUsername
        lblUsername.AutoSize = true;
        lblUsername.Location = new System.Drawing.Point(410, 0);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new System.Drawing.Size(161, 20);
        lblUsername.TabIndex = 4;
        lblUsername.Text = "اسم المستخدم (اختياري):";
        
        // txtUsername
        txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtUsername.Enabled = false;
        txtUsername.Location = new System.Drawing.Point(290, 28);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new System.Drawing.Size(281, 27);
        txtUsername.TabIndex = 5;
        
        // lblAdditionalKey
        lblAdditionalKey.AutoSize = true;
        lblAdditionalKey.Location = new System.Drawing.Point(114, 0);
        lblAdditionalKey.Name = "lblAdditionalKey";
        lblAdditionalKey.Size = new System.Drawing.Size(170, 20);
        lblAdditionalKey.TabIndex = 6;
        lblAdditionalKey.Text = "المفتاح الإضافي (اختياري):";
        
        // txtAdditionalKey
        txtAdditionalKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtAdditionalKey.Enabled = false;
        txtAdditionalKey.Location = new System.Drawing.Point(3, 28);
        txtAdditionalKey.Name = "txtAdditionalKey";
        txtAdditionalKey.Size = new System.Drawing.Size(281, 27);
        txtAdditionalKey.TabIndex = 7;
        
        // chkUseUsername
        chkUseUsername.AutoSize = true;
        chkUseUsername.Location = new System.Drawing.Point(392, 63);
        chkUseUsername.Name = "chkUseUsername";
        chkUseUsername.Size = new System.Drawing.Size(176, 24);
        chkUseUsername.TabIndex = 8;
        chkUseUsername.Text = "استخدام اسم المستخدم";
        chkUseUsername.UseVisualStyleBackColor = true;
        chkUseUsername.CheckedChanged += ChkUseUsername_CheckedChanged;
        
        // chkUseAdditionalKey
        chkUseAdditionalKey.AutoSize = true;
        chkUseAdditionalKey.Location = new System.Drawing.Point(114, 63);
        chkUseAdditionalKey.Name = "chkUseAdditionalKey";
        chkUseAdditionalKey.Size = new System.Drawing.Size(163, 24);
        chkUseAdditionalKey.TabIndex = 9;
        chkUseAdditionalKey.Text = "استخدام مفتاح إضافي";
        chkUseAdditionalKey.UseVisualStyleBackColor = true;
        chkUseAdditionalKey.CheckedChanged += ChkUseAdditionalKey_CheckedChanged;
        
        // chkShowPassword
        chkShowPassword.AutoSize = true;
        chkShowPassword.Location = new System.Drawing.Point(1004, 63);
        chkShowPassword.Name = "chkShowPassword";
        chkShowPassword.Size = new System.Drawing.Size(141, 24);
        chkShowPassword.TabIndex = 10;
        chkShowPassword.Text = "إظهار كلمة المرور";
        chkShowPassword.UseVisualStyleBackColor = true;
        chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
        
        // chkAutoClearClipboard
        chkAutoClearClipboard.AutoSize = true;
        chkAutoClearClipboard.Location = new System.Drawing.Point(627, 63);
        chkAutoClearClipboard.Name = "chkAutoClearClipboard";
        chkAutoClearClipboard.Size = new System.Drawing.Size(205, 24);
        chkAutoClearClipboard.TabIndex = 12;
        chkAutoClearClipboard.Text = "مسح الحافظة تلقائياً بعد";
        chkAutoClearClipboard.UseVisualStyleBackColor = true;
        chkAutoClearClipboard.CheckedChanged += ChkAutoClearClipboard_CheckedChanged;
        
        // lblClipboardTimeout
        lblClipboardTimeout.AutoSize = true;
        lblClipboardTimeout.Location = new System.Drawing.Point(836, 93);
        lblClipboardTimeout.Name = "lblClipboardTimeout";
        lblClipboardTimeout.Size = new System.Drawing.Size(60, 20);
        lblClipboardTimeout.TabIndex = 11;
        lblClipboardTimeout.Text = "30 ثانية";
        
        // grpActions
        grpActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpActions, 2);
        grpActions.Controls.Add(btnDecrypt);
        grpActions.Controls.Add(btnClear);
        grpActions.Controls.Add(btnAnalyzeText);
        grpActions.Location = new System.Drawing.Point(3, 308);
        grpActions.Name = "grpActions";
        grpActions.Size = new System.Drawing.Size(1154, 69);
        grpActions.TabIndex = 3;
        grpActions.TabStop = false;
        grpActions.Text = "الإجراءات الرئيسية";
        
        // btnDecrypt
        btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
        btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnDecrypt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnDecrypt.ForeColor = System.Drawing.Color.White;
        btnDecrypt.Location = new System.Drawing.Point(870, 30);
        btnDecrypt.Name = "btnDecrypt";
        btnDecrypt.Size = new System.Drawing.Size(120, 40);
        btnDecrypt.TabIndex = 0;
        btnDecrypt.Text = "🔓 فك التشفير";
        btnDecrypt.UseVisualStyleBackColor = false;
        btnDecrypt.Click += BtnDecrypt_Click;
        
        // btnClear
        btnClear.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClear.ForeColor = System.Drawing.Color.White;
        btnClear.Location = new System.Drawing.Point(20, 30);
        btnClear.Name = "btnClear";
        btnClear.Size = new System.Drawing.Size(120, 40);
        btnClear.TabIndex = 1;
        btnClear.Text = "🗑️ مسح الكل";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += BtnClear_Click;
        
        // btnAnalyzeText
        btnAnalyzeText.BackColor = System.Drawing.Color.FromArgb(((int)((byte)111)), ((int)((byte)66)), ((int)((byte)193)));
        btnAnalyzeText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnAnalyzeText.ForeColor = System.Drawing.Color.White;
        btnAnalyzeText.Location = new System.Drawing.Point(150, 30);
        btnAnalyzeText.Name = "btnAnalyzeText";
        btnAnalyzeText.Size = new System.Drawing.Size(120, 40);
        btnAnalyzeText.TabIndex = 2;
        btnAnalyzeText.Text = "📊 تحليل النص";
        btnAnalyzeText.UseVisualStyleBackColor = false;
        btnAnalyzeText.Click += btnAnalyzeText_Click;
        
        // grpProgress
        grpProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanelMain.SetColumnSpan(grpProgress, 2);
        grpProgress.Controls.Add(progressBar);
        grpProgress.Controls.Add(lblProgress);
        grpProgress.Controls.Add(grpHistory);
        grpProgress.Location = new System.Drawing.Point(3, 383);
        grpProgress.Name = "grpProgress";
        grpProgress.Size = new System.Drawing.Size(1154, 174);
        grpProgress.TabIndex = 4;
        grpProgress.TabStop = false;
        grpProgress.Text = "التقدم";
        
        // progressBar
        progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        progressBar.Location = new System.Drawing.Point(20, 30);
        progressBar.Name = "progressBar";
        progressBar.Size = new System.Drawing.Size(1110, 16);
        progressBar.TabIndex = 0;
        
        // lblProgress
        lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        lblProgress.AutoSize = true;
        lblProgress.Location = new System.Drawing.Point(1065, 7);
        lblProgress.Name = "lblProgress";
        lblProgress.Size = new System.Drawing.Size(29, 20);
        lblProgress.TabIndex = 1;
        lblProgress.Text = "0%";
        
        // grpHistory
        grpHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        grpHistory.Controls.Add(lstHistory);
        grpHistory.Location = new System.Drawing.Point(6, 62);
        grpHistory.Name = "grpHistory";
        grpHistory.Size = new System.Drawing.Size(1142, 105);
        grpHistory.TabIndex = 2;
        grpHistory.TabStop = false;
        grpHistory.Text = "سجل العمليات";
        
        // lstHistory
        lstHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        lstHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colTime,
            colOperation,
            colInputText,
            colOutputText,
            colDuration,
            colStatus});
        lstHistory.FullRowSelect = true;
        lstHistory.GridLines = true;
        lstHistory.Location = new System.Drawing.Point(6, 26);
        lstHistory.Name = "lstHistory";
        lstHistory.Size = new System.Drawing.Size(500, 73);
        lstHistory.TabIndex = 0;
        lstHistory.UseCompatibleStateImageBehavior = false;
        lstHistory.View = System.Windows.Forms.View.Details;
        lstHistory.DoubleClick += lstHistory_DoubleClick;
        
        // colTime
        colTime.Text = "الوقت";
        colTime.Width = 100;
        
        // colOperation
        colOperation.Text = "العملية";
        colOperation.Width = 100;
        
        // colInputText
        colInputText.Text = "النص المدخل";
        colInputText.Width = 300;
        
        // colOutputText
        colOutputText.Text = "النص الناتج";
        colOutputText.Width = 300;
        
        // colDuration
        colDuration.Text = "المدة";
        colDuration.Width = 100;
        
        // colStatus
        colStatus.Text = "الحالة";
        colStatus.Width = 100;
        
        // toolTip
        toolTip.AutomaticDelay = 250;
        
        ResumeLayout(false);
    }
}