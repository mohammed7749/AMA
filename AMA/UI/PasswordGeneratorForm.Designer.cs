namespace SecureDataProtectionTool.UI;

partial class PasswordGeneratorForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
    private System.Windows.Forms.GroupBox grpPassword;
    private System.Windows.Forms.GroupBox grpPassphrase;
    private System.Windows.Forms.GroupBox grpGenerated;
    private System.Windows.Forms.Label lblLength;
    private System.Windows.Forms.Label lblPasswordCount;
    private System.Windows.Forms.Label lblWordCount;
    private System.Windows.Forms.Label lblSeparator;
    private System.Windows.Forms.Label lblLanguage;
    private System.Windows.Forms.CheckBox chkUppercase;
    private System.Windows.Forms.CheckBox chkLowercase;
    private System.Windows.Forms.CheckBox chkNumbers;
    private System.Windows.Forms.CheckBox chkSymbols;
    private System.Windows.Forms.CheckBox chkExcludeAmbiguous;
    private System.Windows.Forms.CheckBox chkExcludeSimilar;
    private System.Windows.Forms.CheckBox chkUseArabic;
    private System.Windows.Forms.CheckBox chkCapitalize;
    private System.Windows.Forms.CheckBox chkIncludeNumber;
    private System.Windows.Forms.CheckBox chkIncludeSymbol;
    private System.Windows.Forms.Button btnGeneratePassword;
    private System.Windows.Forms.Button btnGeneratePassphrase;
    private System.Windows.Forms.Button btnGenerateMultiple;
    private System.Windows.Forms.Button btnGeneratePIN;
    private System.Windows.Forms.Button btnCopyPassword;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnEvaluate;
    private System.Windows.Forms.RadioButton radPassword;
    private System.Windows.Forms.RadioButton radPassphrase;
    private System.Windows.Forms.RadioButton radPIN;
    private System.Windows.Forms.NumericUpDown numLength;
    private System.Windows.Forms.NumericUpDown numPasswordCount;
    private System.Windows.Forms.NumericUpDown numWordCount;
    private System.Windows.Forms.ComboBox cmbLanguage;
    private System.Windows.Forms.TextBox txtSeparator;
    private System.Windows.Forms.TextBox txtGeneratedPassword;
    private System.Windows.Forms.Label lblStrength;
    private System.Windows.Forms.ProgressBar progressStrength;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.TableLayoutPanel tableLayoutOptions;
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
        this.tableLayoutOptions = new System.Windows.Forms.TableLayoutPanel();
        this.grpPassword = new System.Windows.Forms.GroupBox();
        this.chkUseArabic = new System.Windows.Forms.CheckBox();
        this.chkExcludeSimilar = new System.Windows.Forms.CheckBox();
        this.chkExcludeAmbiguous = new System.Windows.Forms.CheckBox();
        this.chkSymbols = new System.Windows.Forms.CheckBox();
        this.chkNumbers = new System.Windows.Forms.CheckBox();
        this.chkLowercase = new System.Windows.Forms.CheckBox();
        this.chkUppercase = new System.Windows.Forms.CheckBox();
        this.numPasswordCount = new System.Windows.Forms.NumericUpDown();
        this.lblPasswordCount = new System.Windows.Forms.Label();
        this.numLength = new System.Windows.Forms.NumericUpDown();
        this.lblLength = new System.Windows.Forms.Label();
        this.grpPassphrase = new System.Windows.Forms.GroupBox();
        this.cmbLanguage = new System.Windows.Forms.ComboBox();
        this.lblLanguage = new System.Windows.Forms.Label();
        this.txtSeparator = new System.Windows.Forms.TextBox();
        this.lblSeparator = new System.Windows.Forms.Label();
        this.chkIncludeSymbol = new System.Windows.Forms.CheckBox();
        this.chkIncludeNumber = new System.Windows.Forms.CheckBox();
        this.chkCapitalize = new System.Windows.Forms.CheckBox();
        this.numWordCount = new System.Windows.Forms.NumericUpDown();
        this.lblWordCount = new System.Windows.Forms.Label();
        this.grpGenerated = new System.Windows.Forms.GroupBox();
        this.txtGeneratedPassword = new System.Windows.Forms.TextBox();
        this.btnCopyPassword = new System.Windows.Forms.Button();
        this.btnEvaluate = new System.Windows.Forms.Button();
        this.lblStrength = new System.Windows.Forms.Label();
        this.progressStrength = new System.Windows.Forms.ProgressBar();
        this.tableLayoutButtons = new System.Windows.Forms.TableLayoutPanel();
        this.btnGeneratePassword = new System.Windows.Forms.Button();
        this.btnGeneratePassphrase = new System.Windows.Forms.Button();
        this.btnGenerateMultiple = new System.Windows.Forms.Button();
        this.btnGeneratePIN = new System.Windows.Forms.Button();
        this.radPassword = new System.Windows.Forms.RadioButton();
        this.radPassphrase = new System.Windows.Forms.RadioButton();
        this.radPIN = new System.Windows.Forms.RadioButton();
        this.btnClear = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        this.panelHeader.SuspendLayout();
        this.tableLayoutMain.SuspendLayout();
        this.tableLayoutOptions.SuspendLayout();
        this.grpPassword.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPasswordCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
        this.grpPassphrase.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numWordCount)).BeginInit();
        this.grpGenerated.SuspendLayout();
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
        this.panelHeader.Size = new System.Drawing.Size(900, 60);
        this.panelHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblTitle.ForeColor = System.Drawing.Color.White;
        this.lblTitle.Location = new System.Drawing.Point(0, 0);
        this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(900, 60);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "توليد كلمات مرور آمنة";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // tableLayoutMain
        // 
        this.tableLayoutMain.ColumnCount = 1;
        this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutMain.Controls.Add(this.tableLayoutOptions, 0, 0);
        this.tableLayoutMain.Controls.Add(this.grpGenerated, 0, 1);
        this.tableLayoutMain.Controls.Add(this.tableLayoutButtons, 0, 2);
        this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutMain.Location = new System.Drawing.Point(0, 60);
        this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(0);
        this.tableLayoutMain.Name = "tableLayoutMain";
        this.tableLayoutMain.RowCount = 3;
        this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
        this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
        this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tableLayoutMain.Size = new System.Drawing.Size(900, 560);
        this.tableLayoutMain.TabIndex = 1;
        // 
        // tableLayoutOptions
        // 
        this.tableLayoutOptions.ColumnCount = 2;
        this.tableLayoutOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutOptions.Controls.Add(this.grpPassword, 0, 0);
        this.tableLayoutOptions.Controls.Add(this.grpPassphrase, 1, 0);
        this.tableLayoutOptions.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutOptions.Location = new System.Drawing.Point(10, 10);
        this.tableLayoutOptions.Margin = new System.Windows.Forms.Padding(10);
        this.tableLayoutOptions.Name = "tableLayoutOptions";
        this.tableLayoutOptions.RowCount = 1;
        this.tableLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutOptions.Size = new System.Drawing.Size(880, 194);
        this.tableLayoutOptions.TabIndex = 0;
        // 
        // grpPassword
        // 
        this.grpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpPassword.Controls.Add(this.chkUseArabic);
        this.grpPassword.Controls.Add(this.chkExcludeSimilar);
        this.grpPassword.Controls.Add(this.chkExcludeAmbiguous);
        this.grpPassword.Controls.Add(this.chkSymbols);
        this.grpPassword.Controls.Add(this.chkNumbers);
        this.grpPassword.Controls.Add(this.chkLowercase);
        this.grpPassword.Controls.Add(this.chkUppercase);
        this.grpPassword.Controls.Add(this.numPasswordCount);
        this.grpPassword.Controls.Add(this.lblPasswordCount);
        this.grpPassword.Controls.Add(this.numLength);
        this.grpPassword.Controls.Add(this.lblLength);
        this.grpPassword.ForeColor = System.Drawing.Color.White;
        this.grpPassword.Location = new System.Drawing.Point(3, 3);
        this.grpPassword.Name = "grpPassword";
        this.grpPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpPassword.Size = new System.Drawing.Size(434, 188);
        this.grpPassword.TabIndex = 0;
        this.grpPassword.TabStop = false;
        this.grpPassword.Text = "خيارات كلمة المرور";
        // 
        // chkUseArabic
        // 
        this.chkUseArabic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkUseArabic.AutoSize = true;
        this.chkUseArabic.Location = new System.Drawing.Point(30, 200);
        this.chkUseArabic.Name = "chkUseArabic";
        this.chkUseArabic.Size = new System.Drawing.Size(150, 24);
        this.chkUseArabic.TabIndex = 10;
        this.chkUseArabic.Text = "استخدام الأحرف العربية";
        this.chkUseArabic.UseVisualStyleBackColor = true;
        // 
        // chkExcludeSimilar
        // 
        this.chkExcludeSimilar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkExcludeSimilar.AutoSize = true;
        this.chkExcludeSimilar.Location = new System.Drawing.Point(200, 170);
        this.chkExcludeSimilar.Name = "chkExcludeSimilar";
        this.chkExcludeSimilar.Size = new System.Drawing.Size(180, 24);
        this.chkExcludeSimilar.TabIndex = 9;
        this.chkExcludeSimilar.Text = "استبعاد الأحرف المتشابهة";
        this.chkExcludeSimilar.UseVisualStyleBackColor = true;
        // 
        // chkExcludeAmbiguous
        // 
        this.chkExcludeAmbiguous.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkExcludeAmbiguous.AutoSize = true;
        this.chkExcludeAmbiguous.Location = new System.Drawing.Point(30, 170);
        this.chkExcludeAmbiguous.Name = "chkExcludeAmbiguous";
        this.chkExcludeAmbiguous.Size = new System.Drawing.Size(170, 24);
        this.chkExcludeAmbiguous.TabIndex = 8;
        this.chkExcludeAmbiguous.Text = "استبعاد الأحرف المربكة";
        this.chkExcludeAmbiguous.UseVisualStyleBackColor = true;
        // 
        // chkSymbols
        // 
        this.chkSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkSymbols.AutoSize = true;
        this.chkSymbols.Location = new System.Drawing.Point(200, 140);
        this.chkSymbols.Name = "chkSymbols";
        this.chkSymbols.Size = new System.Drawing.Size(60, 24);
        this.chkSymbols.TabIndex = 7;
        this.chkSymbols.Text = "رموز";
        this.chkSymbols.UseVisualStyleBackColor = true;
        // 
        // chkNumbers
        // 
        this.chkNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkNumbers.AutoSize = true;
        this.chkNumbers.Location = new System.Drawing.Point(30, 140);
        this.chkNumbers.Name = "chkNumbers";
        this.chkNumbers.Size = new System.Drawing.Size(60, 24);
        this.chkNumbers.TabIndex = 6;
        this.chkNumbers.Text = "أرقام";
        this.chkNumbers.UseVisualStyleBackColor = true;
        // 
        // chkLowercase
        // 
        this.chkLowercase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkLowercase.AutoSize = true;
        this.chkLowercase.Location = new System.Drawing.Point(200, 110);
        this.chkLowercase.Name = "chkLowercase";
        this.chkLowercase.Size = new System.Drawing.Size(90, 24);
        this.chkLowercase.TabIndex = 5;
        this.chkLowercase.Text = "أحرف صغيرة";
        this.chkLowercase.UseVisualStyleBackColor = true;
        // 
        // chkUppercase
        // 
        this.chkUppercase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkUppercase.AutoSize = true;
        this.chkUppercase.Location = new System.Drawing.Point(30, 110);
        this.chkUppercase.Name = "chkUppercase";
        this.chkUppercase.Size = new System.Drawing.Size(90, 24);
        this.chkUppercase.TabIndex = 4;
        this.chkUppercase.Text = "أحرف كبيرة";
        this.chkUppercase.UseVisualStyleBackColor = true;
        // 
        // numPasswordCount
        // 
        this.numPasswordCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.numPasswordCount.Location = new System.Drawing.Point(30, 70);
        this.numPasswordCount.Minimum = new decimal(new int[] {
        1,
        0,
        0,
        0});
        this.numPasswordCount.Name = "numPasswordCount";
        this.numPasswordCount.Size = new System.Drawing.Size(120, 27);
        this.numPasswordCount.TabIndex = 3;
        this.numPasswordCount.Value = new decimal(new int[] {
        5,
        0,
        0,
        0});
        // 
        // lblPasswordCount
        // 
        this.lblPasswordCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.lblPasswordCount.AutoSize = true;
        this.lblPasswordCount.Location = new System.Drawing.Point(160, 73);
        this.lblPasswordCount.Name = "lblPasswordCount";
        this.lblPasswordCount.Size = new System.Drawing.Size(120, 20);
        this.lblPasswordCount.TabIndex = 2;
        this.lblPasswordCount.Text = "عدد كلمات المرور:";
        this.lblPasswordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // numLength
        // 
        this.numLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.numLength.Location = new System.Drawing.Point(30, 35);
        this.numLength.Maximum = new decimal(new int[] {
        128,
        0,
        0,
        0});
        this.numLength.Minimum = new decimal(new int[] {
        8,
        0,
        0,
        0});
        this.numLength.Name = "numLength";
        this.numLength.Size = new System.Drawing.Size(120, 27);
        this.numLength.TabIndex = 1;
        this.numLength.Value = new decimal(new int[] {
        16,
        0,
        0,
        0});
        // 
        // lblLength
        // 
        this.lblLength.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.lblLength.AutoSize = true;
        this.lblLength.Location = new System.Drawing.Point(160, 38);
        this.lblLength.Name = "lblLength";
        this.lblLength.Size = new System.Drawing.Size(45, 20);
        this.lblLength.TabIndex = 0;
        this.lblLength.Text = "الطول:";
        this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // grpPassphrase
        // 
        this.grpPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpPassphrase.Controls.Add(this.cmbLanguage);
        this.grpPassphrase.Controls.Add(this.lblLanguage);
        this.grpPassphrase.Controls.Add(this.txtSeparator);
        this.grpPassphrase.Controls.Add(this.lblSeparator);
        this.grpPassphrase.Controls.Add(this.chkIncludeSymbol);
        this.grpPassphrase.Controls.Add(this.chkIncludeNumber);
        this.grpPassphrase.Controls.Add(this.chkCapitalize);
        this.grpPassphrase.Controls.Add(this.numWordCount);
        this.grpPassphrase.Controls.Add(this.lblWordCount);
        this.grpPassphrase.ForeColor = System.Drawing.Color.White;
        this.grpPassphrase.Location = new System.Drawing.Point(443, 3);
        this.grpPassphrase.Name = "grpPassphrase";
        this.grpPassphrase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpPassphrase.Size = new System.Drawing.Size(434, 188);
        this.grpPassphrase.TabIndex = 1;
        this.grpPassphrase.TabStop = false;
        this.grpPassphrase.Text = "خيارات عبارة المرور";
        // 
        // cmbLanguage
        // 
        this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbLanguage.FormattingEnabled = true;
        this.cmbLanguage.Items.AddRange(new object[] {
        "الإنجليزية",
        "العربية"});
        this.cmbLanguage.Location = new System.Drawing.Point(30, 200);
        this.cmbLanguage.Name = "cmbLanguage";
        this.cmbLanguage.Size = new System.Drawing.Size(250, 28);
        this.cmbLanguage.TabIndex = 8;
        // 
        // lblLanguage
        // 
        this.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.lblLanguage.AutoSize = true;
        this.lblLanguage.Location = new System.Drawing.Point(290, 203);
        this.lblLanguage.Name = "lblLanguage";
        this.lblLanguage.Size = new System.Drawing.Size(45, 20);
        this.lblLanguage.TabIndex = 7;
        this.lblLanguage.Text = "اللغة:";
        this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // txtSeparator
        // 
        this.txtSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtSeparator.Location = new System.Drawing.Point(30, 160);
        this.txtSeparator.Name = "txtSeparator";
        this.txtSeparator.Size = new System.Drawing.Size(100, 27);
        this.txtSeparator.TabIndex = 6;
        this.txtSeparator.Text = "-";
        // 
        // lblSeparator
        // 
        this.lblSeparator.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.lblSeparator.AutoSize = true;
        this.lblSeparator.Location = new System.Drawing.Point(140, 163);
        this.lblSeparator.Name = "lblSeparator";
        this.lblSeparator.Size = new System.Drawing.Size(45, 20);
        this.lblSeparator.TabIndex = 5;
        this.lblSeparator.Text = "الفاصل:";
        this.lblSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // chkIncludeSymbol
        // 
        this.chkIncludeSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkIncludeSymbol.AutoSize = true;
        this.chkIncludeSymbol.Location = new System.Drawing.Point(200, 130);
        this.chkIncludeSymbol.Name = "chkIncludeSymbol";
        this.chkIncludeSymbol.Size = new System.Drawing.Size(100, 24);
        this.chkIncludeSymbol.TabIndex = 4;
        this.chkIncludeSymbol.Text = "إضافة رمز";
        this.chkIncludeSymbol.UseVisualStyleBackColor = true;
        // 
        // chkIncludeNumber
        // 
        this.chkIncludeNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkIncludeNumber.AutoSize = true;
        this.chkIncludeNumber.Location = new System.Drawing.Point(30, 130);
        this.chkIncludeNumber.Name = "chkIncludeNumber";
        this.chkIncludeNumber.Size = new System.Drawing.Size(100, 24);
        this.chkIncludeNumber.TabIndex = 3;
        this.chkIncludeNumber.Text = "إضافة رقم";
        this.chkIncludeNumber.UseVisualStyleBackColor = true;
        // 
        // chkCapitalize
        // 
        this.chkCapitalize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.chkCapitalize.AutoSize = true;
        this.chkCapitalize.Location = new System.Drawing.Point(30, 100);
        this.chkCapitalize.Name = "chkCapitalize";
        this.chkCapitalize.Size = new System.Drawing.Size(100, 24);
        this.chkCapitalize.TabIndex = 2;
        this.chkCapitalize.Text = "حروف كبيرة";
        this.chkCapitalize.UseVisualStyleBackColor = true;
        // 
        // numWordCount
        // 
        this.numWordCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.numWordCount.Location = new System.Drawing.Point(30, 35);
        this.numWordCount.Minimum = new decimal(new int[] {
        3,
        0,
        0,
        0});
        this.numWordCount.Name = "numWordCount";
        this.numWordCount.Size = new System.Drawing.Size(120, 27);
        this.numWordCount.TabIndex = 1;
        this.numWordCount.Value = new decimal(new int[] {
        4,
        0,
        0,
        0});
        // 
        // lblWordCount
        // 
        this.lblWordCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.lblWordCount.AutoSize = true;
        this.lblWordCount.Location = new System.Drawing.Point(160, 38);
        this.lblWordCount.Name = "lblWordCount";
        this.lblWordCount.Size = new System.Drawing.Size(80, 20);
        this.lblWordCount.TabIndex = 0;
        this.lblWordCount.Text = "عدد الكلمات:";
        this.lblWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // grpGenerated
        // 
        this.grpGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.grpGenerated.Controls.Add(this.txtGeneratedPassword);
        this.grpGenerated.Controls.Add(this.btnCopyPassword);
        this.grpGenerated.Controls.Add(this.btnEvaluate);
        this.grpGenerated.Controls.Add(this.lblStrength);
        this.grpGenerated.Controls.Add(this.progressStrength);
        this.grpGenerated.ForeColor = System.Drawing.Color.White;
        this.grpGenerated.Location = new System.Drawing.Point(10, 224);
        this.grpGenerated.Margin = new System.Windows.Forms.Padding(10);
        this.grpGenerated.Name = "grpGenerated";
        this.grpGenerated.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.grpGenerated.Size = new System.Drawing.Size(880, 194);
        this.grpGenerated.TabIndex = 1;
        this.grpGenerated.TabStop = false;
        this.grpGenerated.Text = "كلمة المرور المولدة";
        // 
        // txtGeneratedPassword
        // 
        this.txtGeneratedPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtGeneratedPassword.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtGeneratedPassword.Location = new System.Drawing.Point(20, 30);
        this.txtGeneratedPassword.Multiline = true;
        this.txtGeneratedPassword.Name = "txtGeneratedPassword";
        this.txtGeneratedPassword.ReadOnly = true;
        this.txtGeneratedPassword.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtGeneratedPassword.Size = new System.Drawing.Size(840, 120);
        this.txtGeneratedPassword.TabIndex = 0;
        // 
        // btnCopyPassword
        // 
        this.btnCopyPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnCopyPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
        this.btnCopyPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCopyPassword.ForeColor = System.Drawing.Color.White;
        this.btnCopyPassword.Location = new System.Drawing.Point(720, 155);
        this.btnCopyPassword.Name = "btnCopyPassword";
        this.btnCopyPassword.Size = new System.Drawing.Size(140, 30);
        this.btnCopyPassword.TabIndex = 1;
        this.btnCopyPassword.Text = "نسخ";
        this.btnCopyPassword.UseVisualStyleBackColor = false;
        // 
        // btnEvaluate
        // 
        this.btnEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnEvaluate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
        this.btnEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEvaluate.ForeColor = System.Drawing.Color.White;
        this.btnEvaluate.Location = new System.Drawing.Point(560, 155);
        this.btnEvaluate.Name = "btnEvaluate";
        this.btnEvaluate.Size = new System.Drawing.Size(140, 30);
        this.btnEvaluate.TabIndex = 2;
        this.btnEvaluate.Text = "تقييم القوة";
        this.btnEvaluate.UseVisualStyleBackColor = false;
        // 
        // lblStrength
        // 
        this.lblStrength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.lblStrength.AutoSize = true;
        this.lblStrength.Location = new System.Drawing.Point(200, 160);
        this.lblStrength.Name = "lblStrength";
        this.lblStrength.Size = new System.Drawing.Size(51, 20);
        this.lblStrength.TabIndex = 3;
        this.lblStrength.Text = "القوة: -";
        this.lblStrength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // progressStrength
        // 
        this.progressStrength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.progressStrength.Location = new System.Drawing.Point(20, 160);
        this.progressStrength.Name = "progressStrength";
        this.progressStrength.Size = new System.Drawing.Size(170, 20);
        this.progressStrength.TabIndex = 4;
        // 
        // tableLayoutButtons
        // 
        this.tableLayoutButtons.ColumnCount = 7;
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
        this.tableLayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
        this.tableLayoutButtons.Controls.Add(this.btnGeneratePassword, 0, 0);
        this.tableLayoutButtons.Controls.Add(this.btnGeneratePassphrase, 1, 0);
        this.tableLayoutButtons.Controls.Add(this.btnGenerateMultiple, 2, 0);
        this.tableLayoutButtons.Controls.Add(this.btnGeneratePIN, 3, 0);
        this.tableLayoutButtons.Controls.Add(this.radPassword, 4, 0);
        this.tableLayoutButtons.Controls.Add(this.radPassphrase, 5, 0);
        this.tableLayoutButtons.Controls.Add(this.radPIN, 6, 0);
        this.tableLayoutButtons.Controls.Add(this.btnClear, 0, 1);
        this.tableLayoutButtons.Controls.Add(this.btnClose, 1, 1);
        this.tableLayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutButtons.Location = new System.Drawing.Point(10, 438);
        this.tableLayoutButtons.Margin = new System.Windows.Forms.Padding(10);
        this.tableLayoutButtons.Name = "tableLayoutButtons";
        this.tableLayoutButtons.RowCount = 2;
        this.tableLayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutButtons.Size = new System.Drawing.Size(880, 102);
        this.tableLayoutButtons.TabIndex = 2;
        // 
        // btnGeneratePassword
        // 
        this.btnGeneratePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
        this.btnGeneratePassword.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnGeneratePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGeneratePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnGeneratePassword.ForeColor = System.Drawing.Color.White;
        this.btnGeneratePassword.Location = new System.Drawing.Point(756, 3);
        this.btnGeneratePassword.Name = "btnGeneratePassword";
        this.btnGeneratePassword.Size = new System.Drawing.Size(121, 45);
        this.btnGeneratePassword.TabIndex = 0;
        this.btnGeneratePassword.Text = "توليد كلمة مرور";
        this.btnGeneratePassword.UseVisualStyleBackColor = false;
        // 
        // btnGeneratePassphrase
        // 
        this.btnGeneratePassphrase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
        this.btnGeneratePassphrase.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnGeneratePassphrase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGeneratePassphrase.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnGeneratePassphrase.ForeColor = System.Drawing.Color.White;
        this.btnGeneratePassphrase.Location = new System.Drawing.Point(629, 3);
        this.btnGeneratePassphrase.Name = "btnGeneratePassphrase";
        this.btnGeneratePassphrase.Size = new System.Drawing.Size(121, 45);
        this.btnGeneratePassphrase.TabIndex = 1;
        this.btnGeneratePassphrase.Text = "توليد عبارة مرور";
        this.btnGeneratePassphrase.UseVisualStyleBackColor = false;
        // 
        // btnGenerateMultiple
        // 
        this.btnGenerateMultiple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
        this.btnGenerateMultiple.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnGenerateMultiple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGenerateMultiple.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnGenerateMultiple.ForeColor = System.Drawing.Color.White;
        this.btnGenerateMultiple.Location = new System.Drawing.Point(502, 3);
        this.btnGenerateMultiple.Name = "btnGenerateMultiple";
        this.btnGenerateMultiple.Size = new System.Drawing.Size(121, 45);
        this.btnGenerateMultiple.TabIndex = 2;
        this.btnGenerateMultiple.Text = "توليد متعدد";
        this.btnGenerateMultiple.UseVisualStyleBackColor = false;
        // 
        // btnGeneratePIN
        // 
        this.btnGeneratePIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
        this.btnGeneratePIN.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnGeneratePIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGeneratePIN.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnGeneratePIN.ForeColor = System.Drawing.Color.White;
        this.btnGeneratePIN.Location = new System.Drawing.Point(375, 3);
        this.btnGeneratePIN.Name = "btnGeneratePIN";
        this.btnGeneratePIN.Size = new System.Drawing.Size(121, 45);
        this.btnGeneratePIN.TabIndex = 3;
        this.btnGeneratePIN.Text = "توليد PIN";
        this.btnGeneratePIN.UseVisualStyleBackColor = false;
        // 
        // radPassword
        // 
        this.radPassword.AutoSize = true;
        this.radPassword.Checked = true;
        this.radPassword.Dock = System.Windows.Forms.DockStyle.Fill;
        this.radPassword.Location = new System.Drawing.Point(248, 3);
        this.radPassword.Name = "radPassword";
        this.radPassword.Size = new System.Drawing.Size(121, 45);
        this.radPassword.TabIndex = 4;
        this.radPassword.TabStop = true;
        this.radPassword.Text = "كلمة مرور";
        this.radPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.radPassword.UseVisualStyleBackColor = true;
        // 
        // radPassphrase
        // 
        this.radPassphrase.AutoSize = true;
        this.radPassphrase.Dock = System.Windows.Forms.DockStyle.Fill;
        this.radPassphrase.Location = new System.Drawing.Point(121, 3);
        this.radPassphrase.Name = "radPassphrase";
        this.radPassphrase.Size = new System.Drawing.Size(121, 45);
        this.radPassphrase.TabIndex = 5;
        this.radPassphrase.Text = "عبارة مرور";
        this.radPassphrase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.radPassphrase.UseVisualStyleBackColor = true;
        // 
        // radPIN
        // 
        this.radPIN.AutoSize = true;
        this.radPIN.Dock = System.Windows.Forms.DockStyle.Fill;
        this.radPIN.Location = new System.Drawing.Point(3, 3);
        this.radPIN.Name = "radPIN";
        this.radPIN.Size = new System.Drawing.Size(112, 45);
        this.radPIN.TabIndex = 6;
        this.radPIN.Text = "PIN";
        this.radPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.radPIN.UseVisualStyleBackColor = true;
        // 
        // btnClear
        // 
        this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
        this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnClear.ForeColor = System.Drawing.Color.White;
        this.btnClear.Location = new System.Drawing.Point(756, 54);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(121, 45);
        this.btnClear.TabIndex = 7;
        this.btnClear.Text = "مسح";
        this.btnClear.UseVisualStyleBackColor = false;
        // 
        // btnClose
        // 
        this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
        this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnClose.ForeColor = System.Drawing.Color.White;
        this.btnClose.Location = new System.Drawing.Point(629, 54);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(121, 45);
        this.btnClose.TabIndex = 8;
        this.btnClose.Text = "إغلاق";
        this.btnClose.UseVisualStyleBackColor = false;
        // 
        // PasswordGeneratorForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
        this.ClientSize = new System.Drawing.Size(900, 620);
        this.Controls.Add(this.tableLayoutMain);
        this.Controls.Add(this.panelHeader);
        this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.Color.White;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MaximizeBox = true;
        this.MinimizeBox = true;
        this.MinimumSize = new System.Drawing.Size(1024, 700);
        this.Name = "PasswordGeneratorForm";
        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.RightToLeftLayout = true;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "توليد كلمات مرور آمنة";
        this.panelHeader.ResumeLayout(false);
        this.tableLayoutMain.ResumeLayout(false);
        this.tableLayoutOptions.ResumeLayout(false);
        this.grpPassword.ResumeLayout(false);
        this.grpPassword.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numPasswordCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
        this.grpPassphrase.ResumeLayout(false);
        this.grpPassphrase.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numWordCount)).EndInit();
        this.grpGenerated.ResumeLayout(false);
        this.grpGenerated.PerformLayout();
        this.tableLayoutButtons.ResumeLayout(false);
        this.tableLayoutButtons.PerformLayout();
        this.ResumeLayout(false);

    }
}