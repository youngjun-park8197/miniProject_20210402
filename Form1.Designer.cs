
namespace DBManager
{
    partial class DBMForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dbStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbPanel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbSqlStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbTableName = new System.Windows.Forms.ToolStripDropDownButton();
            this.sbDropTable = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMigration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveNewTbl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCol = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearDatagrid = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExecSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExecSelSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEnterKey = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.covid19InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelSqlExec = new System.Windows.Forms.Label();
            this.labelTblCheck = new System.Windows.Forms.Label();
            this.tbDropTblInfo = new System.Windows.Forms.TextBox();
            this.tbSql = new System.Windows.Forms.TextBox();
            this.labelTableShow = new System.Windows.Forms.Label();
            this.btnUpdateTbl = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.covidGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbChartList = new System.Windows.Forms.ComboBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.tbVacRatio = new System.Windows.Forms.TextBox();
            this.lblVacComp = new System.Windows.Forms.Label();
            this.lblVacNum = new System.Windows.Forms.Label();
            this.tbVacNum = new System.Windows.Forms.TextBox();
            this.lblCovPatient = new System.Windows.Forms.Label();
            this.tbCovNum = new System.Windows.Forms.TextBox();
            this.lblNotVac = new System.Windows.Forms.Label();
            this.dataGridNotVac = new System.Windows.Forms.DataGridView();
            this.lblYesVac = new System.Windows.Forms.Label();
            this.dataGridYesVac = new System.Windows.Forms.DataGridView();
            this.lbltoTalNum = new System.Windows.Forms.Label();
            this.tbPTotalNum = new System.Windows.Forms.TextBox();
            this.lblSelecProvNum = new System.Windows.Forms.Label();
            this.tbSelProvNum = new System.Windows.Forms.TextBox();
            this.lblCovidPatients = new System.Windows.Forms.Label();
            this.dataGridCovid19 = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.covidGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotVac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYesVac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCovid19)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbStatusLabel1,
            this.sbPanel1,
            this.sbSqlStatus,
            this.sbTableName,
            this.sbDropTable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 947);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1269, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dbStatusLabel1
            // 
            this.dbStatusLabel1.Name = "dbStatusLabel1";
            this.dbStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // sbPanel1
            // 
            this.sbPanel1.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sbPanel1.Name = "sbPanel1";
            this.sbPanel1.Size = new System.Drawing.Size(59, 17);
            this.sbPanel1.Text = "DB 파일명";
            // 
            // sbSqlStatus
            // 
            this.sbSqlStatus.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sbSqlStatus.ForeColor = System.Drawing.Color.Green;
            this.sbSqlStatus.Name = "sbSqlStatus";
            this.sbSqlStatus.Size = new System.Drawing.Size(87, 17);
            this.sbSqlStatus.Text = "[ DB 열기 상태 ]";
            // 
            // sbTableName
            // 
            this.sbTableName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sbTableName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbTableName.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sbTableName.ForeColor = System.Drawing.Color.Blue;
            this.sbTableName.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbTableName.Name = "sbTableName";
            this.sbTableName.Size = new System.Drawing.Size(111, 20);
            this.sbTableName.Text = "[ DB 테이블 목록 ]";
            this.sbTableName.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.sbTableName.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sbTableName_DropDownItemClicked);
            // 
            // sbDropTable
            // 
            this.sbDropTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbDropTable.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sbDropTable.ForeColor = System.Drawing.Color.OrangeRed;
            this.sbDropTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbDropTable.Name = "sbDropTable";
            this.sbDropTable.Size = new System.Drawing.Size(147, 20);
            this.sbDropTable.Text = "[ 삭제할 DB 테이블 목록 ]";
            this.sbDropTable.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.sbDropTable.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sbDropTable_DropDownItemClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.executeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(223, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripSeparator1,
            this.mnuMigration,
            this.mnuSaveAs,
            this.mnuSaveNewTbl,
            this.toolStripSeparator3,
            this.mnuOpenDB,
            this.mnuCloseDB,
            this.toolStripSeparator4,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fileToolStripMenuItem.Text = "파일";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(171, 22);
            this.mnuNew.Text = "DB 테이블 생성";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuMigration
            // 
            this.mnuMigration.Name = "mnuMigration";
            this.mnuMigration.Size = new System.Drawing.Size(171, 22);
            this.mnuMigration.Text = "DB 테이블 열기";
            this.mnuMigration.Click += new System.EventHandler(this.mnuMigration_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(171, 22);
            this.mnuSaveAs.Text = "다른 이름으로 저장";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // mnuSaveNewTbl
            // 
            this.mnuSaveNewTbl.Name = "mnuSaveNewTbl";
            this.mnuSaveNewTbl.Size = new System.Drawing.Size(171, 22);
            this.mnuSaveNewTbl.Text = "새로운 테이블 저장";
            this.mnuSaveNewTbl.Click += new System.EventHandler(this.mnuSaveNewTbl_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuOpenDB
            // 
            this.mnuOpenDB.Name = "mnuOpenDB";
            this.mnuOpenDB.Size = new System.Drawing.Size(171, 22);
            this.mnuOpenDB.Text = "DB 열기";
            this.mnuOpenDB.Click += new System.EventHandler(this.mnuOpenDB_Click);
            // 
            // mnuCloseDB
            // 
            this.mnuCloseDB.Name = "mnuCloseDB";
            this.mnuCloseDB.Size = new System.Drawing.Size(171, 22);
            this.mnuCloseDB.Text = "DB 닫기";
            this.mnuCloseDB.Click += new System.EventHandler(this.mnuCloseDB_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(171, 22);
            this.mnuExit.Text = "종료";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddCol,
            this.mnuAddRow});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.editToolStripMenuItem.Text = "수정";
            // 
            // mnuAddCol
            // 
            this.mnuAddCol.Name = "mnuAddCol";
            this.mnuAddCol.Size = new System.Drawing.Size(164, 22);
            this.mnuAddCol.Text = "열(Column) 추가";
            this.mnuAddCol.Click += new System.EventHandler(this.mnuAddCol_Click);
            // 
            // mnuAddRow
            // 
            this.mnuAddRow.Name = "mnuAddRow";
            this.mnuAddRow.Size = new System.Drawing.Size(164, 22);
            this.mnuAddRow.Text = "행(Row) 추가";
            this.mnuAddRow.Click += new System.EventHandler(this.mnuAddRow_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearDatagrid});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "보기";
            // 
            // mnuClearDatagrid
            // 
            this.mnuClearDatagrid.Name = "mnuClearDatagrid";
            this.mnuClearDatagrid.Size = new System.Drawing.Size(188, 22);
            this.mnuClearDatagrid.Text = "DataGrid 화면 지우기";
            this.mnuClearDatagrid.Click += new System.EventHandler(this.mnuClearDatagrid_Click);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExecSQL,
            this.mnuExecSelSQL,
            this.toolStripSeparator2,
            this.mnuEnterKey});
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.executeToolStripMenuItem.Text = "실행";
            // 
            // mnuExecSQL
            // 
            this.mnuExecSQL.Name = "mnuExecSQL";
            this.mnuExecSQL.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuExecSQL.Size = new System.Drawing.Size(225, 22);
            this.mnuExecSQL.Text = "SQL문 실행";
            this.mnuExecSQL.Click += new System.EventHandler(this.mnuExecSQL_Click);
            // 
            // mnuExecSelSQL
            // 
            this.mnuExecSelSQL.Name = "mnuExecSelSQL";
            this.mnuExecSelSQL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.mnuExecSelSQL.Size = new System.Drawing.Size(225, 22);
            this.mnuExecSelSQL.Text = "선택된 SQL문 실행";
            this.mnuExecSelSQL.Click += new System.EventHandler(this.mnuExecSelSQL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // mnuEnterKey
            // 
            this.mnuEnterKey.Checked = true;
            this.mnuEnterKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEnterKey.Name = "mnuEnterKey";
            this.mnuEnterKey.Size = new System.Drawing.Size(225, 22);
            this.mnuEnterKey.Text = "SQL문 [ Enter ] 활성화";
            this.mnuEnterKey.Click += new System.EventHandler(this.mnuEnterKey_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.covid19InfoToolStripMenuItem,
            this.internationalInfoToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "도움말";
            // 
            // covid19InfoToolStripMenuItem
            // 
            this.covid19InfoToolStripMenuItem.Name = "covid19InfoToolStripMenuItem";
            this.covid19InfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.covid19InfoToolStripMenuItem.Text = "코로나19 정보";
            this.covid19InfoToolStripMenuItem.Click += new System.EventHandler(this.covid19InfoToolStripMenuItem_Click);
            // 
            // internationalInfoToolStripMenuItem
            // 
            this.internationalInfoToolStripMenuItem.Name = "internationalInfoToolStripMenuItem";
            this.internationalInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.internationalInfoToolStripMenuItem.Text = "코로나 국제 상황";
            this.internationalInfoToolStripMenuItem.Click += new System.EventHandler(this.internationalInfoToolStripMenuItem_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(3, 47);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 27;
            this.dataGrid.Size = new System.Drawing.Size(486, 355);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGrid_CellBeginEdit);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.ValidateNames = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(10, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelSqlExec);
            this.splitContainer1.Panel1.Controls.Add(this.labelTblCheck);
            this.splitContainer1.Panel1.Controls.Add(this.tbDropTblInfo);
            this.splitContainer1.Panel1.Controls.Add(this.tbSql);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelTableShow);
            this.splitContainer1.Panel2.Controls.Add(this.dataGrid);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdateTbl);
            this.splitContainer1.Size = new System.Drawing.Size(704, 405);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 4;
            // 
            // labelSqlExec
            // 
            this.labelSqlExec.AutoSize = true;
            this.labelSqlExec.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelSqlExec.Location = new System.Drawing.Point(3, 31);
            this.labelSqlExec.Name = "labelSqlExec";
            this.labelSqlExec.Size = new System.Drawing.Size(179, 13);
            this.labelSqlExec.TabIndex = 1;
            this.labelSqlExec.Text = "환자 및 백신 접종자 검색 SQL 명령";
            // 
            // labelTblCheck
            // 
            this.labelTblCheck.AutoSize = true;
            this.labelTblCheck.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTblCheck.Location = new System.Drawing.Point(3, 226);
            this.labelTblCheck.Name = "labelTblCheck";
            this.labelTblCheck.Size = new System.Drawing.Size(145, 13);
            this.labelTblCheck.TabIndex = 1;
            this.labelTblCheck.Text = "삭제한 DB 테이블 정보 확인";
            // 
            // tbDropTblInfo
            // 
            this.tbDropTblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDropTblInfo.BackColor = System.Drawing.Color.OldLace;
            this.tbDropTblInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDropTblInfo.Location = new System.Drawing.Point(3, 242);
            this.tbDropTblInfo.Multiline = true;
            this.tbDropTblInfo.Name = "tbDropTblInfo";
            this.tbDropTblInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDropTblInfo.Size = new System.Drawing.Size(201, 160);
            this.tbDropTblInfo.TabIndex = 0;
            this.tbDropTblInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSql_KeyDown);
            // 
            // tbSql
            // 
            this.tbSql.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSql.BackColor = System.Drawing.Color.OldLace;
            this.tbSql.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSql.Location = new System.Drawing.Point(3, 47);
            this.tbSql.Multiline = true;
            this.tbSql.Name = "tbSql";
            this.tbSql.Size = new System.Drawing.Size(201, 160);
            this.tbSql.TabIndex = 0;
            this.tbSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSql_KeyDown);
            // 
            // labelTableShow
            // 
            this.labelTableShow.AutoSize = true;
            this.labelTableShow.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTableShow.Location = new System.Drawing.Point(3, 31);
            this.labelTableShow.Name = "labelTableShow";
            this.labelTableShow.Size = new System.Drawing.Size(156, 13);
            this.labelTableShow.TabIndex = 1;
            this.labelTableShow.Text = "코로나 DB 데이터 테이블 확인";
            // 
            // btnUpdateTbl
            // 
            this.btnUpdateTbl.BackColor = System.Drawing.Color.White;
            this.btnUpdateTbl.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdateTbl.Location = new System.Drawing.Point(393, 3);
            this.btnUpdateTbl.Name = "btnUpdateTbl";
            this.btnUpdateTbl.Size = new System.Drawing.Size(96, 39);
            this.btnUpdateTbl.TabIndex = 10;
            this.btnUpdateTbl.Text = "DB 업데이트";
            this.btnUpdateTbl.UseVisualStyleBackColor = false;
            this.btnUpdateTbl.Click += new System.EventHandler(this.btnUpdateTbl_Click);
            // 
            // covidGraph
            // 
            this.covidGraph.BackColor = System.Drawing.Color.MistyRose;
            this.covidGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.covidGraph.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DottedGrid;
            this.covidGraph.BackImageTransparentColor = System.Drawing.Color.White;
            this.covidGraph.BackSecondaryColor = System.Drawing.Color.White;
            this.covidGraph.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("나눔스퀘어라운드 Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.OldLace;
            chartArea1.Name = "ChartTotal";
            this.covidGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.covidGraph.Legends.Add(legend1);
            this.covidGraph.Location = new System.Drawing.Point(723, 48);
            this.covidGraph.Name = "covidGraph";
            this.covidGraph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.covidGraph.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BackImageTransparentColor = System.Drawing.Color.White;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.ChartArea = "ChartTotal";
            series1.Color = System.Drawing.Color.LightCoral;
            series1.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelForeColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.Name = "전체 인원 수(명)";
            series2.ChartArea = "ChartTotal";
            series2.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "환자 수(명)";
            series3.ChartArea = "ChartTotal";
            series3.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Legend = "Legend1";
            series3.Name = "접종 인원수(명)";
            series4.ChartArea = "ChartTotal";
            series4.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Legend = "Legend1";
            series4.Name = "접종률(%)";
            this.covidGraph.Series.Add(series1);
            this.covidGraph.Series.Add(series2);
            this.covidGraph.Series.Add(series3);
            this.covidGraph.Series.Add(series4);
            this.covidGraph.Size = new System.Drawing.Size(537, 314);
            this.covidGraph.TabIndex = 5;
            this.covidGraph.Text = "CovidGraph";
            this.covidGraph.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            title1.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            title1.Name = "StatusCovid";
            title1.Text = "코로나19 현황표";
            this.covidGraph.Titles.Add(title1);
            // 
            // cbChartList
            // 
            this.cbChartList.BackColor = System.Drawing.Color.OldLace;
            this.cbChartList.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbChartList.FormattingEnabled = true;
            this.cbChartList.Location = new System.Drawing.Point(805, 381);
            this.cbChartList.Name = "cbChartList";
            this.cbChartList.Size = new System.Drawing.Size(82, 21);
            this.cbChartList.TabIndex = 6;
            this.cbChartList.SelectedIndexChanged += new System.EventHandler(this.cbChartList_SelectedIndexChanged);
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProvince.Location = new System.Drawing.Point(802, 365);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(54, 13);
            this.lblProvince.TabIndex = 7;
            this.lblProvince.Text = "지역 선택";
            // 
            // tbVacRatio
            // 
            this.tbVacRatio.BackColor = System.Drawing.Color.OldLace;
            this.tbVacRatio.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVacRatio.Location = new System.Drawing.Point(1085, 430);
            this.tbVacRatio.Name = "tbVacRatio";
            this.tbVacRatio.Size = new System.Drawing.Size(82, 21);
            this.tbVacRatio.TabIndex = 8;
            // 
            // lblVacComp
            // 
            this.lblVacComp.AutoSize = true;
            this.lblVacComp.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVacComp.Location = new System.Drawing.Point(1082, 414);
            this.lblVacComp.Name = "lblVacComp";
            this.lblVacComp.Size = new System.Drawing.Size(109, 13);
            this.lblVacComp.TabIndex = 9;
            this.lblVacComp.Text = "전체 백신 접종률(%)";
            // 
            // lblVacNum
            // 
            this.lblVacNum.AutoSize = true;
            this.lblVacNum.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVacNum.Location = new System.Drawing.Point(942, 414);
            this.lblVacNum.Name = "lblVacNum";
            this.lblVacNum.Size = new System.Drawing.Size(98, 13);
            this.lblVacNum.TabIndex = 9;
            this.lblVacNum.Text = "백신 접종자 수(명)";
            // 
            // tbVacNum
            // 
            this.tbVacNum.BackColor = System.Drawing.Color.OldLace;
            this.tbVacNum.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbVacNum.Location = new System.Drawing.Point(945, 430);
            this.tbVacNum.Name = "tbVacNum";
            this.tbVacNum.Size = new System.Drawing.Size(82, 21);
            this.tbVacNum.TabIndex = 8;
            // 
            // lblCovPatient
            // 
            this.lblCovPatient.AutoSize = true;
            this.lblCovPatient.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCovPatient.Location = new System.Drawing.Point(802, 414);
            this.lblCovPatient.Name = "lblCovPatient";
            this.lblCovPatient.Size = new System.Drawing.Size(73, 13);
            this.lblCovPatient.TabIndex = 9;
            this.lblCovPatient.Text = "확진자 수(명)";
            // 
            // tbCovNum
            // 
            this.tbCovNum.BackColor = System.Drawing.Color.OldLace;
            this.tbCovNum.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCovNum.Location = new System.Drawing.Point(805, 430);
            this.tbCovNum.Name = "tbCovNum";
            this.tbCovNum.Size = new System.Drawing.Size(82, 21);
            this.tbCovNum.TabIndex = 8;
            // 
            // lblNotVac
            // 
            this.lblNotVac.AutoSize = true;
            this.lblNotVac.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNotVac.Location = new System.Drawing.Point(272, 469);
            this.lblNotVac.Name = "lblNotVac";
            this.lblNotVac.Size = new System.Drawing.Size(76, 13);
            this.lblNotVac.TabIndex = 9;
            this.lblNotVac.Text = "미접종자 현황";
            // 
            // dataGridNotVac
            // 
            this.dataGridNotVac.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGridNotVac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridNotVac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNotVac.Location = new System.Drawing.Point(10, 485);
            this.dataGridNotVac.Name = "dataGridNotVac";
            this.dataGridNotVac.RowTemplate.Height = 23;
            this.dataGridNotVac.Size = new System.Drawing.Size(600, 200);
            this.dataGridNotVac.TabIndex = 11;
            // 
            // lblYesVac
            // 
            this.lblYesVac.AutoSize = true;
            this.lblYesVac.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblYesVac.Location = new System.Drawing.Point(924, 469);
            this.lblYesVac.Name = "lblYesVac";
            this.lblYesVac.Size = new System.Drawing.Size(65, 13);
            this.lblYesVac.TabIndex = 9;
            this.lblYesVac.Text = "접종자 현황";
            // 
            // dataGridYesVac
            // 
            this.dataGridYesVac.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGridYesVac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridYesVac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYesVac.Location = new System.Drawing.Point(652, 485);
            this.dataGridYesVac.Name = "dataGridYesVac";
            this.dataGridYesVac.RowTemplate.Height = 23;
            this.dataGridYesVac.Size = new System.Drawing.Size(600, 200);
            this.dataGridYesVac.TabIndex = 11;
            // 
            // lbltoTalNum
            // 
            this.lbltoTalNum.AutoSize = true;
            this.lbltoTalNum.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbltoTalNum.Location = new System.Drawing.Point(1082, 365);
            this.lbltoTalNum.Name = "lbltoTalNum";
            this.lbltoTalNum.Size = new System.Drawing.Size(76, 13);
            this.lbltoTalNum.TabIndex = 9;
            this.lbltoTalNum.Text = "총 인구 수(명)";
            // 
            // tbPTotalNum
            // 
            this.tbPTotalNum.BackColor = System.Drawing.Color.OldLace;
            this.tbPTotalNum.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPTotalNum.Location = new System.Drawing.Point(1085, 381);
            this.tbPTotalNum.Name = "tbPTotalNum";
            this.tbPTotalNum.Size = new System.Drawing.Size(82, 21);
            this.tbPTotalNum.TabIndex = 8;
            // 
            // lblSelecProvNum
            // 
            this.lblSelecProvNum.AutoSize = true;
            this.lblSelecProvNum.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelecProvNum.Location = new System.Drawing.Point(942, 365);
            this.lblSelecProvNum.Name = "lblSelecProvNum";
            this.lblSelecProvNum.Size = new System.Drawing.Size(109, 13);
            this.lblSelecProvNum.TabIndex = 9;
            this.lblSelecProvNum.Text = "선택지역 인구 수(명)";
            // 
            // tbSelProvNum
            // 
            this.tbSelProvNum.BackColor = System.Drawing.Color.OldLace;
            this.tbSelProvNum.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSelProvNum.Location = new System.Drawing.Point(945, 381);
            this.tbSelProvNum.Name = "tbSelProvNum";
            this.tbSelProvNum.Size = new System.Drawing.Size(82, 21);
            this.tbSelProvNum.TabIndex = 8;
            // 
            // lblCovidPatients
            // 
            this.lblCovidPatients.AutoSize = true;
            this.lblCovidPatients.Font = new System.Drawing.Font("나눔스퀘어라운드 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCovidPatients.Location = new System.Drawing.Point(599, 705);
            this.lblCovidPatients.Name = "lblCovidPatients";
            this.lblCovidPatients.Size = new System.Drawing.Size(65, 13);
            this.lblCovidPatients.TabIndex = 9;
            this.lblCovidPatients.Text = "확진자 현황";
            // 
            // dataGridCovid19
            // 
            this.dataGridCovid19.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGridCovid19.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridCovid19.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCovid19.Location = new System.Drawing.Point(319, 721);
            this.dataGridCovid19.Name = "dataGridCovid19";
            this.dataGridCovid19.RowTemplate.Height = 23;
            this.dataGridCovid19.Size = new System.Drawing.Size(600, 200);
            this.dataGridCovid19.TabIndex = 11;
            // 
            // DBMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1269, 969);
            this.Controls.Add(this.dataGridYesVac);
            this.Controls.Add(this.dataGridCovid19);
            this.Controls.Add(this.dataGridNotVac);
            this.Controls.Add(this.lblYesVac);
            this.Controls.Add(this.lblCovidPatients);
            this.Controls.Add(this.lblNotVac);
            this.Controls.Add(this.lblSelecProvNum);
            this.Controls.Add(this.lbltoTalNum);
            this.Controls.Add(this.lblCovPatient);
            this.Controls.Add(this.lblVacNum);
            this.Controls.Add(this.lblVacComp);
            this.Controls.Add(this.tbSelProvNum);
            this.Controls.Add(this.tbPTotalNum);
            this.Controls.Add(this.tbCovNum);
            this.Controls.Add(this.tbVacNum);
            this.Controls.Add(this.tbVacRatio);
            this.Controls.Add(this.lblProvince);
            this.Controls.Add(this.cbChartList);
            this.Controls.Add(this.covidGraph);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DBMForm";
            this.Text = "Covid19 DataBase v1.0";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.covidGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNotVac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYesVac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCovid19)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMigration;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenDB;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripStatusLabel dbStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExecSQL;
        private System.Windows.Forms.ToolStripMenuItem mnuExecSelSQL;
        private System.Windows.Forms.ToolStripStatusLabel sbPanel1;
        private System.Windows.Forms.ToolStripStatusLabel sbSqlStatus;
        private System.Windows.Forms.ToolStripDropDownButton sbTableName;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCol;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuEnterKey;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveNewTbl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearDatagrid;
        private System.Windows.Forms.ToolStripDropDownButton sbDropTable;
        private System.Windows.Forms.TextBox tbSql;
        private System.Windows.Forms.TextBox tbDropTblInfo;
        private System.Windows.Forms.Label labelTblCheck;
        private System.Windows.Forms.Label labelSqlExec;
        private System.Windows.Forms.Label labelTableShow;
        private System.Windows.Forms.ToolStripMenuItem covid19InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalInfoToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart covidGraph;
        private System.Windows.Forms.ComboBox cbChartList;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.TextBox tbVacRatio;
        private System.Windows.Forms.Label lblVacComp;
        private System.Windows.Forms.Label lblVacNum;
        private System.Windows.Forms.TextBox tbVacNum;
        private System.Windows.Forms.Label lblCovPatient;
        private System.Windows.Forms.TextBox tbCovNum;
        private System.Windows.Forms.Button btnUpdateTbl;
        private System.Windows.Forms.Label lblNotVac;
        private System.Windows.Forms.DataGridView dataGridNotVac;
        private System.Windows.Forms.Label lblYesVac;
        private System.Windows.Forms.DataGridView dataGridYesVac;
        private System.Windows.Forms.Label lbltoTalNum;
        private System.Windows.Forms.TextBox tbPTotalNum;
        private System.Windows.Forms.Label lblSelecProvNum;
        private System.Windows.Forms.TextBox tbSelProvNum;
        private System.Windows.Forms.Label lblCovidPatients;
        private System.Windows.Forms.DataGridView dataGridCovid19;
    }
}

