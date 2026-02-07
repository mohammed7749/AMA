namespace SecureDataProtectionTool.UI;

partial class LogsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.GroupBox grpFilters;
    private System.Windows.Forms.GroupBox grpLogs;
    private System.Windows.Forms.GroupBox grpAuditLogs;
    private System.Windows.Forms.Label lblDateFrom;
    private System.Windows.Forms.Label lblDateTo;
    private System.Windows.Forms.Label lblLevel;
    private System.Windows.Forms.Label lblOperation;
    private System.Windows.Forms.Label lblSource;
    private System.Windows.Forms.DateTimePicker dtpFrom;
    private System.Windows.Forms.DateTimePicker dtpTo;
    private System.Windows.Forms.ComboBox cmbLevel;
    private System.Windows.Forms.TextBox txtOperation;
    private System.Windows.Forms.ComboBox cmbSource;
    private System.Windows.Forms.CheckBox chkSuccessOnly;
    private System.Windows.Forms.CheckBox chkErrorsOnly;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Button btnClearFilters;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.Button btnClearLogs;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.ListView lstLogs;
    private System.Windows.Forms.ColumnHeader colLogTime;
    private System.Windows.Forms.ColumnHeader colLogLevel;
    private System.Windows.Forms.ColumnHeader colLogOperation;
    private System.Windows.Forms.ColumnHeader colLogMessage;
    private System.Windows.Forms.ColumnHeader colLogUser;
    private System.Windows.Forms.ColumnHeader colLogSource;
    private System.Windows.Forms.ColumnHeader colLogSuccess;
    private System.Windows.Forms.ListView lstAuditLogs;
    private System.Windows.Forms.ColumnHeader colAuditTime;
    private System.Windows.Forms.ColumnHeader colAuditOperation;
    private System.Windows.Forms.ColumnHeader colAuditMessage;
    private System.Windows.Forms.ColumnHeader colAuditUser;
    private System.Windows.Forms.ColumnHeader colAuditDetails;
    private System.Windows.Forms.Label lblLogCount;
    private System.Windows.Forms.Label lblAuditCount;
    private System.Windows.Forms.Button btnStats;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Panel panelButtons;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilters;
    
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
        panelHeader = new System.Windows.Forms.Panel();
        lblTitle = new System.Windows.Forms.Label();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        grpFilters = new System.Windows.Forms.GroupBox();
        tableLayoutPanelFilters = new System.Windows.Forms.TableLayoutPanel();
        lblDateFrom = new System.Windows.Forms.Label();
        dtpFrom = new System.Windows.Forms.DateTimePicker();
        lblDateTo = new System.Windows.Forms.Label();
        dtpTo = new System.Windows.Forms.DateTimePicker();
        lblLevel = new System.Windows.Forms.Label();
        cmbLevel = new System.Windows.Forms.ComboBox();
        lblOperation = new System.Windows.Forms.Label();
        txtOperation = new System.Windows.Forms.TextBox();
        lblSource = new System.Windows.Forms.Label();
        cmbSource = new System.Windows.Forms.ComboBox();
        chkSuccessOnly = new System.Windows.Forms.CheckBox();
        chkErrorsOnly = new System.Windows.Forms.CheckBox();
        btnSearch = new System.Windows.Forms.Button();
        grpLogs = new System.Windows.Forms.GroupBox();
        lstLogs = new System.Windows.Forms.ListView();
        colLogTime = new System.Windows.Forms.ColumnHeader();
        colLogLevel = new System.Windows.Forms.ColumnHeader();
        colLogOperation = new System.Windows.Forms.ColumnHeader();
        colLogMessage = new System.Windows.Forms.ColumnHeader();
        colLogUser = new System.Windows.Forms.ColumnHeader();
        colLogSource = new System.Windows.Forms.ColumnHeader();
        colLogSuccess = new System.Windows.Forms.ColumnHeader();
        lblLogCount = new System.Windows.Forms.Label();
        grpAuditLogs = new System.Windows.Forms.GroupBox();
        lstAuditLogs = new System.Windows.Forms.ListView();
        colAuditTime = new System.Windows.Forms.ColumnHeader();
        colAuditOperation = new System.Windows.Forms.ColumnHeader();
        colAuditMessage = new System.Windows.Forms.ColumnHeader();
        colAuditUser = new System.Windows.Forms.ColumnHeader();
        colAuditDetails = new System.Windows.Forms.ColumnHeader();
        lblAuditCount = new System.Windows.Forms.Label();
        panelButtons = new System.Windows.Forms.Panel();
        btnStats = new System.Windows.Forms.Button();
        btnRefresh = new System.Windows.Forms.Button();
        btnClearFilters = new System.Windows.Forms.Button();
        btnExport = new System.Windows.Forms.Button();
        btnClearLogs = new System.Windows.Forms.Button();
        btnClose = new System.Windows.Forms.Button();
        panelHeader.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        grpFilters.SuspendLayout();
        tableLayoutPanelFilters.SuspendLayout();
        grpLogs.SuspendLayout();
        grpAuditLogs.SuspendLayout();
        panelButtons.SuspendLayout();
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
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTitle.ForeColor = System.Drawing.Color.White;
        lblTitle.Location = new System.Drawing.Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(1200, 60);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "سجلات النظام والتدقيق";
        lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(grpFilters, 0, 0);
        tableLayoutPanel1.Controls.Add(grpLogs, 0, 1);
        tableLayoutPanel1.Controls.Add(grpAuditLogs, 0, 2);
        tableLayoutPanel1.Controls.Add(panelButtons, 0, 3);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 60);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        tableLayoutPanel1.Size = new System.Drawing.Size(1200, 820);
        tableLayoutPanel1.TabIndex = 1;
        // 
        // grpFilters
        // 
        grpFilters.Controls.Add(tableLayoutPanelFilters);
        grpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
        grpFilters.Location = new System.Drawing.Point(10, 3);
        grpFilters.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
        grpFilters.Name = "grpFilters";
        grpFilters.Size = new System.Drawing.Size(1180, 184);
        grpFilters.TabIndex = 1;
        grpFilters.TabStop = false;
        grpFilters.Text = "مرشحات البحث";
        // 
        // tableLayoutPanelFilters
        // 
        tableLayoutPanelFilters.ColumnCount = 4;
        tableLayoutPanelFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.6660986F));
        tableLayoutPanelFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.134583F));
        tableLayoutPanelFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.601362F));
        tableLayoutPanelFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.597956F));
        tableLayoutPanelFilters.Controls.Add(lblDateFrom, 0, 0);
        tableLayoutPanelFilters.Controls.Add(dtpFrom, 1, 0);
        tableLayoutPanelFilters.Controls.Add(lblDateTo, 2, 0);
        tableLayoutPanelFilters.Controls.Add(dtpTo, 3, 0);
        tableLayoutPanelFilters.Controls.Add(lblLevel, 0, 1);
        tableLayoutPanelFilters.Controls.Add(cmbLevel, 1, 1);
        tableLayoutPanelFilters.Controls.Add(lblOperation, 2, 1);
        tableLayoutPanelFilters.Controls.Add(txtOperation, 3, 1);
        tableLayoutPanelFilters.Controls.Add(lblSource, 0, 2);
        tableLayoutPanelFilters.Controls.Add(cmbSource, 1, 2);
        tableLayoutPanelFilters.Controls.Add(chkSuccessOnly, 2, 2);
        tableLayoutPanelFilters.Controls.Add(chkErrorsOnly, 3, 2);
        tableLayoutPanelFilters.Controls.Add(btnSearch, 3, 3);
        tableLayoutPanelFilters.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanelFilters.Location = new System.Drawing.Point(3, 23);
        tableLayoutPanelFilters.Name = "tableLayoutPanelFilters";
        tableLayoutPanelFilters.RowCount = 4;
        tableLayoutPanelFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.050632F));
        tableLayoutPanelFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.316456F));
        tableLayoutPanelFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanelFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tableLayoutPanelFilters.Size = new System.Drawing.Size(1174, 158);
        tableLayoutPanelFilters.TabIndex = 13;
        // 
        // lblDateFrom
        // 
        lblDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Right;
        lblDateFrom.AutoSize = true;
        lblDateFrom.Location = new System.Drawing.Point(1087, 9);
        lblDateFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
        lblDateFrom.Name = "lblDateFrom";
        lblDateFrom.Size = new System.Drawing.Size(65, 20);
        lblDateFrom.TabIndex = 0;
        lblDateFrom.Text = "من تاريخ:";
        lblDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // dtpFrom
        // 
        dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        dtpFrom.Location = new System.Drawing.Point(705, 5);
        dtpFrom.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        dtpFrom.Name = "dtpFrom";
        dtpFrom.Size = new System.Drawing.Size(369, 27);
        dtpFrom.TabIndex = 1;
        // 
        // lblDateTo
        // 
        lblDateTo.Anchor = System.Windows.Forms.AnchorStyles.Right;
        lblDateTo.AutoSize = true;
        lblDateTo.Location = new System.Drawing.Point(327, 9);
        lblDateTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
        lblDateTo.Name = "lblDateTo";
        lblDateTo.Size = new System.Drawing.Size(68, 20);
        lblDateTo.TabIndex = 2;
        lblDateTo.Text = "إلى تاريخ:";
        lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // dtpTo
        // 
        dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        dtpTo.Location = new System.Drawing.Point(10, 5);
        dtpTo.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        dtpTo.Name = "dtpTo";
        dtpTo.Size = new System.Drawing.Size(304, 27);
        dtpTo.TabIndex = 3;
        // 
        // lblLevel
        // 
        lblLevel.Anchor = System.Windows.Forms.AnchorStyles.Right;
        lblLevel.AutoSize = true;
        lblLevel.Location = new System.Drawing.Point(1087, 48);
        lblLevel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
        lblLevel.Name = "lblLevel";
        lblLevel.Size = new System.Drawing.Size(67, 20);
        lblLevel.TabIndex = 4;
        lblLevel.Text = "المستوى:";
        lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cmbLevel
        // 
        cmbLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbLevel.FormattingEnabled = true;
        cmbLevel.Items.AddRange(new object[] { "الكل", "معلومات", "تحذير", "خطأ", "أمان", "تدقيق" });
        cmbLevel.Location = new System.Drawing.Point(705, 44);
        cmbLevel.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        cmbLevel.Name = "cmbLevel";
        cmbLevel.Size = new System.Drawing.Size(369, 28);
        cmbLevel.TabIndex = 5;
        // 
        // lblOperation
        // 
        lblOperation.Anchor = System.Windows.Forms.AnchorStyles.Right;
        lblOperation.AutoSize = true;
        lblOperation.Location = new System.Drawing.Point(327, 48);
        lblOperation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
        lblOperation.Name = "lblOperation";
        lblOperation.Size = new System.Drawing.Size(57, 20);
        lblOperation.TabIndex = 6;
        lblOperation.Text = "العملية:";
        lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // txtOperation
        // 
        txtOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        txtOperation.Location = new System.Drawing.Point(10, 44);
        txtOperation.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        txtOperation.Name = "txtOperation";
        txtOperation.Size = new System.Drawing.Size(304, 27);
        txtOperation.TabIndex = 7;
        // 
        // lblSource
        // 
        lblSource.Anchor = System.Windows.Forms.AnchorStyles.Right;
        lblSource.AutoSize = true;
        lblSource.Location = new System.Drawing.Point(1087, 87);
        lblSource.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
        lblSource.Name = "lblSource";
        lblSource.Size = new System.Drawing.Size(59, 20);
        lblSource.TabIndex = 8;
        lblSource.Text = "المصدر:";
        lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // cmbSource
        // 
        cmbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
        cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSource.FormattingEnabled = true;
        cmbSource.Items.AddRange(new object[] { "الكل", "التطبيق", "الأمان", "التدقيق" });
        cmbSource.Location = new System.Drawing.Point(705, 83);
        cmbSource.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        cmbSource.Name = "cmbSource";
        cmbSource.Size = new System.Drawing.Size(369, 28);
        cmbSource.TabIndex = 9;
        // 
        // chkSuccessOnly
        // 
        chkSuccessOnly.Anchor = System.Windows.Forms.AnchorStyles.Left;
        chkSuccessOnly.AutoSize = true;
        chkSuccessOnly.Location = new System.Drawing.Point(518, 85);
        chkSuccessOnly.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        chkSuccessOnly.Name = "chkSuccessOnly";
        chkSuccessOnly.Size = new System.Drawing.Size(167, 24);
        chkSuccessOnly.TabIndex = 10;
        chkSuccessOnly.Text = "العمليات الناجحة فقط";
        chkSuccessOnly.UseVisualStyleBackColor = true;
        // 
        // chkErrorsOnly
        // 
        chkErrorsOnly.Anchor = System.Windows.Forms.AnchorStyles.Left;
        chkErrorsOnly.AutoSize = true;
        chkErrorsOnly.Location = new System.Drawing.Point(205, 85);
        chkErrorsOnly.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        chkErrorsOnly.Name = "chkErrorsOnly";
        chkErrorsOnly.Size = new System.Drawing.Size(109, 24);
        chkErrorsOnly.TabIndex = 11;
        chkErrorsOnly.Text = "الأخطاء فقط";
        chkErrorsOnly.UseVisualStyleBackColor = true;
        // 
        // btnSearch
        // 
        btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
        btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)123)), ((int)((byte)255)));
        btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnSearch.ForeColor = System.Drawing.Color.White;
        btnSearch.Location = new System.Drawing.Point(60, 122);
        btnSearch.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(254, 31);
        btnSearch.TabIndex = 12;
        btnSearch.Text = "بحث";
        btnSearch.UseVisualStyleBackColor = false;
        btnSearch.Click += btnSearch_Click;
        // 
        // grpLogs
        // 
        grpLogs.Controls.Add(lstLogs);
        grpLogs.Controls.Add(lblLogCount);
        grpLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        grpLogs.Location = new System.Drawing.Point(10, 193);
        grpLogs.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
        grpLogs.Name = "grpLogs";
        grpLogs.Size = new System.Drawing.Size(1180, 274);
        grpLogs.TabIndex = 2;
        grpLogs.TabStop = false;
        grpLogs.Text = "سجلات النظام";
        // 
        // lstLogs
        // 
        lstLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colLogTime, colLogLevel, colLogOperation, colLogMessage, colLogUser, colLogSource, colLogSuccess });
        lstLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        lstLogs.FullRowSelect = true;
        lstLogs.GridLines = true;
        lstLogs.Location = new System.Drawing.Point(3, 23);
        lstLogs.Name = "lstLogs";
        lstLogs.Size = new System.Drawing.Size(1174, 225);
        lstLogs.TabIndex = 0;
        lstLogs.UseCompatibleStateImageBehavior = false;
        lstLogs.View = System.Windows.Forms.View.Details;
        // 
        // colLogTime
        // 
        colLogTime.Name = "colLogTime";
        colLogTime.Text = "الوقت";
        colLogTime.Width = 120;
        // 
        // colLogLevel
        // 
        colLogLevel.Name = "colLogLevel";
        colLogLevel.Text = "المستوى";
        colLogLevel.Width = 80;
        // 
        // colLogOperation
        // 
        colLogOperation.Name = "colLogOperation";
        colLogOperation.Text = "العملية";
        colLogOperation.Width = 120;
        // 
        // colLogMessage
        // 
        colLogMessage.Name = "colLogMessage";
        colLogMessage.Text = "الرسالة";
        colLogMessage.Width = 300;
        // 
        // colLogUser
        // 
        colLogUser.Name = "colLogUser";
        colLogUser.Text = "المستخدم";
        colLogUser.Width = 100;
        // 
        // colLogSource
        // 
        colLogSource.Name = "colLogSource";
        colLogSource.Text = "المصدر";
        colLogSource.Width = 100;
        // 
        // colLogSuccess
        // 
        colLogSuccess.Name = "colLogSuccess";
        colLogSuccess.Text = "الناجحة";
        colLogSuccess.Width = 80;
        // 
        // lblLogCount
        // 
        lblLogCount.Dock = System.Windows.Forms.DockStyle.Bottom;
        lblLogCount.Location = new System.Drawing.Point(3, 248);
        lblLogCount.Name = "lblLogCount";
        lblLogCount.Size = new System.Drawing.Size(1174, 23);
        lblLogCount.TabIndex = 1;
        lblLogCount.Text = "عدد السجلات: 0";
        lblLogCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // grpAuditLogs
        // 
        grpAuditLogs.Controls.Add(lstAuditLogs);
        grpAuditLogs.Controls.Add(lblAuditCount);
        grpAuditLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        grpAuditLogs.Location = new System.Drawing.Point(10, 473);
        grpAuditLogs.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
        grpAuditLogs.Name = "grpAuditLogs";
        grpAuditLogs.Size = new System.Drawing.Size(1180, 274);
        grpAuditLogs.TabIndex = 3;
        grpAuditLogs.TabStop = false;
        grpAuditLogs.Text = "سجلات التدقيق";
        // 
        // lstAuditLogs
        // 
        lstAuditLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colAuditTime, colAuditOperation, colAuditMessage, colAuditUser, colAuditDetails });
        lstAuditLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        lstAuditLogs.FullRowSelect = true;
        lstAuditLogs.GridLines = true;
        lstAuditLogs.Location = new System.Drawing.Point(3, 23);
        lstAuditLogs.Name = "lstAuditLogs";
        lstAuditLogs.Size = new System.Drawing.Size(1174, 225);
        lstAuditLogs.TabIndex = 0;
        lstAuditLogs.UseCompatibleStateImageBehavior = false;
        lstAuditLogs.View = System.Windows.Forms.View.Details;
        // 
        // colAuditTime
        // 
        colAuditTime.Name = "colAuditTime";
        colAuditTime.Text = "الوقت";
        colAuditTime.Width = 120;
        // 
        // colAuditOperation
        // 
        colAuditOperation.Name = "colAuditOperation";
        colAuditOperation.Text = "العملية";
        colAuditOperation.Width = 120;
        // 
        // colAuditMessage
        // 
        colAuditMessage.Name = "colAuditMessage";
        colAuditMessage.Text = "الرسالة";
        colAuditMessage.Width = 400;
        // 
        // colAuditUser
        // 
        colAuditUser.Name = "colAuditUser";
        colAuditUser.Text = "المستخدم";
        colAuditUser.Width = 120;
        // 
        // colAuditDetails
        // 
        colAuditDetails.Name = "colAuditDetails";
        colAuditDetails.Text = "التفاصيل";
        colAuditDetails.Width = 150;
        // 
        // lblAuditCount
        // 
        lblAuditCount.Dock = System.Windows.Forms.DockStyle.Bottom;
        lblAuditCount.Location = new System.Drawing.Point(3, 248);
        lblAuditCount.Name = "lblAuditCount";
        lblAuditCount.Size = new System.Drawing.Size(1174, 23);
        lblAuditCount.TabIndex = 1;
        lblAuditCount.Text = "عدد سجلات التدقيق: 0";
        lblAuditCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(btnStats);
        panelButtons.Controls.Add(btnRefresh);
        panelButtons.Controls.Add(btnClearFilters);
        panelButtons.Controls.Add(btnExport);
        panelButtons.Controls.Add(btnClearLogs);
        panelButtons.Controls.Add(btnClose);
        panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        panelButtons.Location = new System.Drawing.Point(3, 753);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new System.Drawing.Size(1194, 64);
        panelButtons.TabIndex = 4;
        // 
        // btnStats
        // 
        btnStats.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnStats.BackColor = System.Drawing.Color.FromArgb(((int)((byte)23)), ((int)((byte)162)), ((int)((byte)184)));
        btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnStats.ForeColor = System.Drawing.Color.White;
        btnStats.Location = new System.Drawing.Point(4, 12);
        btnStats.Name = "btnStats";
        btnStats.Size = new System.Drawing.Size(150, 40);
        btnStats.TabIndex = 4;
        btnStats.Text = "إحصائيات";
        btnStats.UseVisualStyleBackColor = false;
        btnStats.Click += btnStats_Click;
        // 
        // btnRefresh
        // 
        btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnRefresh.ForeColor = System.Drawing.Color.White;
        btnRefresh.Location = new System.Drawing.Point(160, 12);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new System.Drawing.Size(150, 40);
        btnRefresh.TabIndex = 5;
        btnRefresh.Text = "🔄 تحديث";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += BtnRefresh_Click;
        // 
        // btnClearFilters
        // 
        btnClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)((byte)108)), ((int)((byte)117)), ((int)((byte)125)));
        btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnClearFilters.ForeColor = System.Drawing.Color.White;
        btnClearFilters.Location = new System.Drawing.Point(316, 12);
        btnClearFilters.Name = "btnClearFilters";
        btnClearFilters.Size = new System.Drawing.Size(150, 40);
        btnClearFilters.TabIndex = 6;
        btnClearFilters.Text = "مسح المرشحات";
        btnClearFilters.UseVisualStyleBackColor = false;
        btnClearFilters.Click += BtnClearFilters_Click;
        // 
        // btnExport
        // 
        btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnExport.BackColor = System.Drawing.Color.FromArgb(((int)((byte)40)), ((int)((byte)167)), ((int)((byte)69)));
        btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnExport.ForeColor = System.Drawing.Color.White;
        btnExport.Location = new System.Drawing.Point(472, 12);
        btnExport.Name = "btnExport";
        btnExport.Size = new System.Drawing.Size(150, 40);
        btnExport.TabIndex = 7;
        btnExport.Text = "📤 تصدير";
        btnExport.UseVisualStyleBackColor = false;
        btnExport.Click += BtnExport_Click;
        // 
        // btnClearLogs
        // 
        btnClearLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnClearLogs.BackColor = System.Drawing.Color.FromArgb(((int)((byte)220)), ((int)((byte)53)), ((int)((byte)69)));
        btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClearLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnClearLogs.ForeColor = System.Drawing.Color.White;
        btnClearLogs.Location = new System.Drawing.Point(628, 12);
        btnClearLogs.Name = "btnClearLogs";
        btnClearLogs.Size = new System.Drawing.Size(150, 40);
        btnClearLogs.TabIndex = 8;
        btnClearLogs.Text = "🗑️ مسح السجلات";
        btnClearLogs.UseVisualStyleBackColor = false;
        btnClearLogs.Click += BtnClearLogs_Click;
        // 
        // btnClose
        // 
        btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        btnClose.BackColor = System.Drawing.Color.FromArgb(((int)((byte)52)), ((int)((byte)58)), ((int)((byte)64)));
        btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnClose.ForeColor = System.Drawing.Color.White;
        btnClose.Location = new System.Drawing.Point(784, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(150, 40);
        btnClose.TabIndex = 9;
        btnClose.Text = "إغلاق";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += BtnClose_Click;
        // 
        // LogsForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)25)), ((int)((byte)25)), ((int)((byte)35)));
        ClientSize = new System.Drawing.Size(1200, 880);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(panelHeader);
        Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        ForeColor = System.Drawing.Color.White;
        MinimumSize = new System.Drawing.Size(1024, 700);
        RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "سجلات النظام والتدقيق";
        panelHeader.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        grpFilters.ResumeLayout(false);
        tableLayoutPanelFilters.ResumeLayout(false);
        tableLayoutPanelFilters.PerformLayout();
        grpLogs.ResumeLayout(false);
        grpAuditLogs.ResumeLayout(false);
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }
}