using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


// 지역명에 대한 콤보박스 검색을 위해 구조체 선언(검색했으나 모르겠어서 실패)
/*public struct Province
{
    public string[] prov;

    public Province(string[] prov)
    {
        this.prov = {
                     "Seoul", "Gyeonggi", "Busan", 
                     "Gyeongju", "Ulsan", "Bucheon", 
                     "Pohang", "Gwangju"
                    };
    }
};*/

namespace DBManager
{
    public partial class DBMForm : Form
    {
        public DBMForm()
        {
            InitializeComponent();
        }

        // 다른 메뉴에서 사용할 DB Table 이름(현재 open된 테이블)
        string tableName;

        SqlConnection sqlCon = new SqlConnection();     // sql 연결 생성
        SqlCommand sqlCmd = new SqlCommand();           // 커맨드 수행 생성

        // 연결 문자열 확인 -> C:\Users\진녹색비단벌레\source\repos\DBManager\textDB.mdf (파일명 제거)
        string sConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=;Integrated Security=True;Connect Timeout=30";

        //############################## DataBase 열기 ################################
        //
        // 1. file select(.mdf)
        // 2. Connection string 구성
        // 3. DB Open(sqlConnection)
        // 4. SQL Command Object 연결
        // 5. DB Table 정보 read
        // 6. StatusBar : DB name, Table List, 처리결과
        //
        // ############################################################################
        // 데이터베이스 열기
        private void mnuOpenDB_Click(object sender, EventArgs e) 
        {
            try // 에러 처리를 위한 try - catch 문 구성
            {
                // ---------------------- 데이터 베이스 OPEN 동작 ----------------------
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                string nFile = openFileDialog1.FileName; // full name(full path)
                string[] ss = sConn.Split(';'); // 세미콜론 기준으로 문자열을 분할
                
                sqlCon.ConnectionString = $"{ss[0]};{ss[1]}{nFile};{ss[2]};{ss[3]}"; // 세미콜론 기준으로 분할한 문자열과 가변적인 파일명을 함께 붙여 DB 연결
                sqlCon.Open();

                sqlCmd.Connection = sqlCon; // sql 명령 전달하기 위한 연결
                sbPanel1.Text = openFileDialog1.SafeFileName;
                sbPanel1.BackColor = Color.LightSkyBlue;
                // ---------------------------------------------------------------------

                // ----------------- 데이터베이스 스키마 가져오는 작업 -----------------
                DataTable dt = sqlCon.GetSchema("Tables"); // 하나하나의 테이블 값을 가지고 있음

                // DropDownButton에 테이블 리스트를 볼 수 있도록 하는 부분
                for (int i = 0; i < dt.Rows.Count; i++) // table list
                {
                    sbTableName.DropDownItems.Add(dt.Rows[i].ItemArray[2].ToString());
                }

                for (int j = 0; j < dt.Rows.Count; j++) // 삭제할 table list
                {
                    sbDropTable.DropDownItems.Add(dt.Rows[j].ItemArray[2].ToString());
                }
                // ---------------------------------------------------------------------

                sbPanel1.Text = openFileDialog1.SafeFileName;
                sbSqlStatus.Text = "DB opened successfully.";
                sbSqlStatus.BackColor = Color.LightGreen;
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                dbStatusLabel1.Text = "DB open failed.";
            }
        }


        // ############################# DB 테이블 열기 ###############################
        //
        //  파일 선택해서 열기 후 테이블을 하단부 리스트에서 선택
        //  선택하고 dataGrid에 출력
        //  그리드의 헤더부터 출력
        //  셀에 값을 넣어줌
        //  선택할 때마다 그리드를 clear시켜서 새로운 테이블 선택 시 새롭게 보여줌
        //
        // ############################################################################
        // column을 생성 후 각각의 셀에 해당하는 값을 분리해서 넣어줌
        private void mnuMigration_Click(object sender, EventArgs e)
        {
            ClearAllGrid();

            DialogResult rst = openFileDialog1.ShowDialog();
            if (rst != DialogResult.OK) return;
            string nFile = openFileDialog1.FileName; // full name(full path)
            StreamReader sr = new StreamReader(nFile);

            string buf = sr.ReadLine();
            if (buf == null) return;

            string[] str = buf.Split(',');

            for (int i = 0; i < str.Length; i++) // 헤더텍스트 열 추가
            {
                dataGrid.Columns.Add(str[i], str[i]);
            }

            while (true)
            {
                buf = sr.ReadLine();
                if (buf == null) break;

                str = buf.Split(',');

                int ridx = dataGrid.Rows.Add(); // 행에 값 추가
                for (int i = 0; i < str.Length; i++)
                {
                    // 텍스트 속성에 값을 넣어줌(string 타입), cell[i].Value는 오브젝트 속성, Row기준으로 cell을 가져올 수 있음
                    dataGrid.Rows[ridx].Cells[i].Value = str[i];
                }
            }
        }

        // 저장하기 
        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() != DialogResult.OK) return; 
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default); // 있으면 append, 없으면 생략
            string buf = "";

            // ----------------- 데이터그리드의 열에 해당하는 값 -----------------
            for (int i = 0; i < dataGrid.ColumnCount; i++)
            {
                buf += dataGrid.Columns[i].HeaderText;
                if (i < dataGrid.ColumnCount - 1) buf += ", ";
            }
            sw.Write(buf + "\r\n");
            // -------------------------------------------------------------------

            // ----------------- 데이터그리드의 행에 해당하는 값 -----------------
            for (int j = 0; j < dataGrid.RowCount; j++)
            {
                buf = "";
                for(int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    buf += dataGrid.Rows[j].Cells[i].Value;
                    if (i < dataGrid.ColumnCount - 1) buf += ", ";
                }
                sw.Write(buf += "\r\n");
            }
            // -------------------------------------------------------------------
        }

        // 데이터베이스 닫기
        private void mnuCloseDB_Click(object sender, EventArgs e)
        {
            sqlCon.Close();

            sbPanel1.Text = "DB File Name";
            dbStatusLabel1.BackColor = Color.LightGray;
            dbStatusLabel1.Text = "DB Closed";

            sbTableName.DropDownItems.Clear();
        }


        // ############################ DataBase 업데이트 #############################
        //
        //   데이터베이스 업데이트는 테이블의 전체 값 수정X
        //   수정 가능하도록 설정할 수 있지만 검색 속도의 저하 발생
        //   가장 첫번째 열의 값을 유니크 키로 설정하여 검색
        //   검색한 키 값의 행에서 속성 값을 수정 후 업데이트
        //
        // ############################################################################
        private void btnUpdateTbl_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++) // 행의 수 만큼 탐색
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++) // 열의 수 만큼 탐색
                {
                    string sTip = dataGrid.Rows[i].Cells[j].ToolTipText;
                    
                    if (sTip == ".") // update [Table] set [field] = [CellText] where [1st_column_name] = [1st_column.celltext]
                    {
                        string tblName = tableName; // 테이블명
                        string fldName = dataGrid.Columns[j].HeaderText; // 가장 상단 열의 속성(column에 인덱스를 부여하면 column에 대한 속성을 불러올 수 있음)
                        string celText = dataGrid.Rows[i].Cells[j].Value.ToString(); // 행의 값
                        string keyName = dataGrid.Columns[0].HeaderText; // 가장 상단의 첫번째(인덱스는 0) 속성값
                        object keyText = dataGrid.Rows[i].Cells[0].Value; // 행의 가장 첫번째 속성값(id 값)
                        string sql = $"update {tblName} set {fldName}=N'{celText}' where {keyName}={keyText}"; // N : 디폴트 지시자
                        runSql(sql);
                    }
                }
            }
        }


        // ############################ 신규 테이블 생성 #############################
        //
        //   column 헤더 존재(테이블의 가장 상단)
        //   row 데이터들이 존재
        //   nchar(20)로 가져올 예정
        //   id라는 필드가 있다면, int로 설정해도 무방
        //
        // ###########################################################################
        private void mnuSaveNewTbl_Click(object sender, EventArgs e) // 새로운 테이블 저장
        {
            ColinputFrm dlg = new ColinputFrm("생성할 테이블명을 입력하세요 : ");

            if (dlg.ShowDialog() != DialogResult.OK) return;
            
            string tableName = dlg.sInput;
            string sql = $"Create table {tableName} (";
            for (int i = 0; i < dataGrid.ColumnCount; i++) // 경계 조건에 대한 고려 필요
            {
                sql += $"{dataGrid.Columns[i].HeaderText} varchar(32)";  // 위 Create table에 이어서 nchar(20)에 해당하는 sql 명령문까지 추가
                if (i < dataGrid.ColumnCount - 1) sql += ",";
            }
            sql += ")";

            runSql(sql); // 신규 테이블 생성

            /*
            insert into [TableName] values (
                [col_val_1], [col_val_2], ...
            )
            */
            for(int i = 0; i < dataGrid.RowCount; i++)
            {
                sql = $"insert into {tableName} values (";
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    sql += $"'{dataGrid.Rows[i].Cells[j].Value}'"; // 각 셀에 있는 값은 오브젝트 타입, 보간문자열에서는 그대로 작성
                    if (j < dataGrid.ColumnCount - 1) sql += ",";
                }
                sql += ")";
                runSql(sql);
            }
        }


        // ###################### UI 하단부 DropDownItems 구현 #######################
        //
        //   좌 : DropDownItems의 리스트 중 선택한 테이블의 dataGrid에 출력
        //   우 : DropDownItems의 리스트 중 선택한 테이블의 삭제 수행
        //   선택한 테이블에 대해 그래프의 우측 지역 선택에 해당하는 comboBox로 지역 값 전달하여 출력
        //   콤보박스 리스트 값들에 대한 중복 제거 함수 구현
        //
        // ###########################################################################
        // 하단부 table list의 패널 상에서 dropdown 클릭 시 리스트 출력
        int colCovidx = 6; // 테이블 내 Covid19 확진 여부 열(column)의 인덱스
        int colVacidx = 5; // 테이블 내 Vaccine 접종 여부 열(column)의 인덱스
        int colProvidx = 4; // 테이블 내 지역명 검색 확인 열(column)의 인덱스
        private void sbTableName_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbTableName.Text = e.ClickedItem.Text;
            string sqlcom = $"select * from {sbTableName.Text}";
            runSql(sqlcom);

            List<string> provList = new List<string>(); // 콤보박스에 넣을 리스트 생성

            provList.Clear(); // 초기 provList 리스트 정리

            // 콤보박스에 데이터 출력(DB 테이블 내 '지역 선택'의 지역리스트 : 중복 제거 필요)
            // 이중 for문 구현 시 탐색 시간 증가로 인한 고정 인덱스 4(Province 열)로 부여하여 처리
            for (int i = 0; !dataGrid.Rows.Contains(null); i++) // 행 탐색(row의 값이 null이 발생할 때까지)
            {
                if (dataGrid.Columns[colProvidx].HeaderText == "Province") // 테이블 내 컬럼의 값 중 Province에 해당하는 열을 검색
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break; // 데이터에 대한 Null 검증을 수행(toString() : Null을 문자열로 인식하려는 시도 오류)
                    string provDatas = dataGrid.Rows[i].Cells[colProvidx].Value.ToString(); // 지역(Province)에 해당하는 지역명 값들
                    provList.Add("전체");
                    provList.Add(provDatas); // 리스트에 전달받은 지역명 값을 추가
                }
            }

            provList = provList.Distinct().ToList(); // 리스트 내 값들에 대한 중복 제거

            cbChartList.Items.Clear(); // 실제 지역명 값이 들어갈 콤보 박스를 초기 정리
            cbChartList.Items.AddRange(provList.ToArray()); // provList의 범위만큼 cbChartList에 넣어줌
            cbChartList.Sorted = true; // 콤보박스 리스트 정렬 
        }
        // 테이블 table list에서 선택한 데이터베이스 테이블 삭제 : [삭제테이블명] + [날짜 / 시간] 확인 텍스트 출력
        private void sbDropTable_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbTableName.DropDownItems.Remove(e.ClickedItem); // sbTableName의 DropDownitem 목록에서 삭제

            sbDropTable.Text = e.ClickedItem.Text;
            string sqlcom = $"drop table {sbDropTable.Text}";
            runSql(sqlcom);
            
            if (e.ClickedItem.Selected)
            {
                DateTime rmDate = DateTime.Now;
                tbDropTblInfo.Text += $"\r\nTableName : {e.ClickedItem.Text}\r\nRemove Time : " + rmDate.ToString() + "\r\n";
            }
            
            sbDropTable.DropDownItems.Remove(e.ClickedItem); // sbDropTable의 DropDownitem 목록에서 삭제
        }


        // ####################### 확진 및 접종 현황 확인 기능 ########################
        //
        //   전체 인구수 / 확진자 수 / 백신접종자 수 / 접종률 등 계산 처리 구현
        //   지역별 상이한 결과 출력 확인
        //   향후 추가하게 될 지역명을 구조체 형태로 구현하는 법 추가 필요
        //   헤더텍스트에 대한 배열 인덱스를 구조체로 선언하여 개별 선언이 없도록 처리 필요
        //
        // ############################################################################
        // 콤보박스에서 지역을 선택했을 때 그래프로 출력
        private void cbChartList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearComSelGrid(); // 하단부 모든 데이터 그리드 Clear
            graphSettings(); // 그래프 기본 설정
            int covCount = 0; // 확진자 수 체크 변수
            int vacCount = 0; // 백신접종자 수 체크 변수
            double vacRatio = 0.0f; // 백신접종률 결과 변수 초기화

           

            // 지역명 정보를 prov라는 문자열 배열 선언 후 비교 예정
            string[] prov = {"전체", "Seoul", "Gyeonggi",
                                 "Busan", "Gyeongju", "Ulsan",
                                 "Bucheon", "Pohang", "Gwangju"};

            // 지역에 대한 선택적 정보 출력 기능 구현 부분
            // ************************************************** "전체" **************************************************
            if (prov[0] == cbChartList.SelectedItem.ToString()) // cbChartList 콤보박스에서 선택한 지역명이 있으면,
            {
                ClearGraphSeries();
                // 전체 인구 수
                tbPTotalNum.Text = dataGrid.Rows.Count.ToString();
                int totalPeople = dataGrid.Rows.Count; // covidNumCount 메소드로 넘겨줄 전체 인구수 변수(그래프 표현을 위해)

                // 전체 확진자 수 = 테이블의 행의 수(들어가있는 데이터 기반)
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 전체 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 전체 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)dataGrid.Rows.Count) * 100; // (백신접종자 수 / 전체인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N")
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O")
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O")
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------

                // --------------------------- 코로나19 현황표 [전체] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(totalPeople);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************


            // ************************************************* "Seoul" **************************************************
            if (prov[1] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int seoulNum = 0; // 서울시 인구 변수 초기화
                                  // 서울시 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[1]) seoulNum += 1; // "서울시" 인구 수 계산
                }
                tbSelProvNum.Text = seoulNum.ToString();

                // 서울시 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[1] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") 
                        covCount += 1; // 서울시 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 서울시 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[1] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 서울시 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)seoulNum) * 100; // (백신접종자 수 / 서울시 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[1])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[1])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[1])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------------- 코로나19 현황표 [서울시] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(seoulNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************


            // ************************************************ "Gyeonggi" ************************************************
            if (prov[2] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int gyeonggiNum = 0; // 서울시 인구 변수 초기화
                // 경기도 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[2]) gyeonggiNum += 1; // "경기도" 인구 수 계산
                }
                tbSelProvNum.Text = gyeonggiNum.ToString();

                // 경기도 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[2] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 경기도 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 경기도 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[2] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 경기도 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)gyeonggiNum) * 100; // (백신접종자 수 / 경기도 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[2])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[2])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[2])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------

                // --------------------------- 코로나19 현황표 [경기도] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(gyeonggiNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************


            // ************************************************* "Busan" **************************************************
            if (prov[3] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int busanNum = 0; // 서울시 인구 변수 초기화
                // 부산시 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[3]) busanNum += 1; // "부산시" 인구 수 계산
                }
                tbSelProvNum.Text = busanNum.ToString();

                // 부산시 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[3] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 부산시 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 부산시 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[3] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 부산시 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)busanNum) * 100; // (백신접종자 수 / 부산시 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[3])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[3])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[3])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------
                
                // --------------------------- 코로나19 현황표 [부산시] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(busanNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------

            }
            // ************************************************************************************************************


            // ************************************************ "Gyeongju" ************************************************
            if (prov[4] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int gyeongjuNum = 0; // 서울시 인구 변수 초기화
                // 경주시 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[4]) gyeongjuNum += 1; // "경주시" 인구 수 계산
                }
                tbSelProvNum.Text = gyeongjuNum.ToString();

                // 경주시 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[4] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 경주시 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 경주시 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[4] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 경주시 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)gyeongjuNum) * 100; // (백신접종자 수 / 경주시 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[4])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[4])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[4])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------

                // --------------------------- 코로나19 현황표 [경주시] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(gyeongjuNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************


            // ************************************************* "Ulsan" **************************************************
            if (prov[5] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int ulsanNum = 0; // 서울시 인구 변수 초기화
                // 울산시 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[5]) ulsanNum += 1; // "울산시" 인구 수 계산
                }
                tbSelProvNum.Text = ulsanNum.ToString();

                // 울산시 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[5] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 울산시 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 울산시 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[5] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 울산시 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)ulsanNum) * 100; // (백신접종자 수 / 울산시 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[5])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[5])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[5])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------

                // --------------------------- 코로나19 현황표 [울산시] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(ulsanNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************


            // ************************************************ "Bucheon" *************************************************
            if (prov[6] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int bucheonNum = 0; // 부천시 인구 변수 초기화
                // 부천시 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[6]) bucheonNum += 1; // "부천시" 인구 수 계산
                }
                tbSelProvNum.Text = bucheonNum.ToString();

                // 부천시 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[6] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 부천시 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 부천시 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[6] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 부천시 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)bucheonNum) * 100; // (백신접종자 수 / 부천시 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[6])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[6])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[6])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------

                // --------------------------- 코로나19 현황표 [부천시] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(bucheonNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************


            // ************************************************ "Pohang" **************************************************
            if (prov[7] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int pohangNum = 0; // 서울시 인구 변수 초기화
                // 포항시 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[7]) pohangNum += 1; // "포항시" 인구 수 계산
                }
                tbSelProvNum.Text = pohangNum.ToString();

                // 포항시 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[7] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 포항시 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 포항시 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[7] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 포항시 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)pohangNum) * 100; // (백신접종자 수 / 포항시 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[7])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[7])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[7])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------
                
                // --------------------------- 코로나19 현황표 [포항시] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(pohangNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************


            // ************************************************ "Gwangju" *************************************************
            if (prov[8] == cbChartList.SelectedItem.ToString())
            {
                ClearGraphSeries();
                int gwangjuNum = 0; // 서울시 인구 변수 초기화
                // 광주시 인구 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colProvidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[8]) gwangjuNum += 1; // "광주시" 인구 수 계산
                }
                tbSelProvNum.Text = gwangjuNum.ToString();

                // 광주시 확진자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[8] && dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O") covCount += 1; // 광주시 확진자 수 count
                }
                tbCovNum.Text = covCount.ToString(); // 확진자수 텍스트 박스에 출력

                // 광주시 백신접종자 수
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[8] && dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O") vacCount += 1; // 백신접종자 수 count
                }
                tbVacNum.Text = vacCount.ToString();

                // 광주시 백신 접종률 - 소수점 표현 처리 필요(Math.Truncate 함수 활용)
                vacRatio = ((double)vacCount / (double)gwangjuNum) * 100; // (백신접종자 수 / 광주시 인구 수) * 100
                vacRatio = Math.Truncate(vacRatio * 10) / 10; // 소수점 2자리 이하 버림
                tbVacRatio.Text = vacRatio.ToString();

                // -------------------- [ 미접종자 현황 ] 데이터그리드뷰에 출력 --------------------
                // 첫번째 헤더텍스트 열을 찍어내는 부분(열이 없으면 행도 없음을 주의!)
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridNotVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "N" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[8])
                    {
                        int ridx = dataGridNotVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridNotVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "N" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridNotVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 접종자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridYesVac.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colVacidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colVacidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[8])
                    {
                        int ridx = dataGridYesVac.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridYesVac.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------


                // --------------------- [ 확진자 현황 ] 데이터그리드뷰에 출력 ---------------------
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    dataGridCovid19.Columns.Add(dataGrid.Rows[0].Cells[i].Value.ToString(), dataGrid.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if (dataGrid.Rows[i].Cells[colCovidx].Value == null) break;
                    if (dataGrid.Rows[i].Cells[colCovidx].Value.ToString() == "O" && dataGrid.Rows[i].Cells[colProvidx].Value.ToString() == prov[8])
                    {
                        int ridx = dataGridCovid19.Rows.Add(); // 행 추가
                        for (int j = 0; j < dataGridYesVac.Columns.Count; j++)
                        {
                            // dataGrid 테이블 내 접종여부 "Y" 인 행을 dataGridNotVac 테이블 행에 추가
                            dataGridCovid19.Rows[ridx].Cells[j].Value = dataGrid.Rows[i].Cells[j].Value;
                        }
                    }
                }
                // ---------------------------------------------------------------------------------

                // --------------------------- 코로나19 현황표 [광주시] 출력 -------------------------
                // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString()); // 출력되지 않아서 구현 점검 필요
                covidGraph.Series[0].Points.Add(gwangjuNum);
                covidGraph.Series[1].Points.Add(covCount);
                covidGraph.Series[2].Points.Add(vacCount);
                covidGraph.Series[3].Points.Add(vacRatio);
                // ---------------------------------------------------------------------------------
            }
            // ************************************************************************************************************
        }


        // ######################### 각종 DB 관련 기능들 모음 #########################
        //   메뉴의 열(column) 추가 기능
        //   메뉴의 행(row) 추가 기능
        //   SQL 실행 
        //   선택한 SQL 실행
        //   SQL 명령문 가져오기
        //   메뉴의 엔터키 활성 여부
        //   엔터키 사용 여부 체크박스 
        //   데이터그리드 각 셀마다의 수정
        //   현재의 dataGrid를 clear 해주는 메소드
        //   SQL 질의 수행, 각각에 대한 에러 처리도 함수형태로 에러처리 구현 후 호출하는 방식으로 적용
        //   현재의 dataGrid를 clear 해주는 메소드
        //   그래프의 series를 clear 해주는 메소드
        //   메뉴 구성 중 "도움말"의 코로나19 정보 관련 링크 연결(정부 사이트)
        //   메뉴 구성 중 "도움말"의 코로나19 국제 상황 링크 연결(정부 사이트)
        //   개별지역 그래프 구성 메소드
        // ############################################################################
        // 메뉴의 열(column) 추가 기능
        private void mnuAddCol_Click(object sender, EventArgs e)
        {
            ColinputFrm cif = new ColinputFrm("Input Column name");
            DialogResult rst = cif.ShowDialog();

            if (rst == DialogResult.OK)
            {
                string str = cif.sInput;
                dataGrid.Columns.Add(str, str);
            }
        }

        // 메뉴의 행(row) 추가 기능
        private void mnuAddRow_Click(object sender, EventArgs e)
        {
            dataGrid.Rows.Add();
        }

        // SQL 실행 
        private void mnuExecSQL_Click(object sender, EventArgs e)
        {
            runSql(tbSql.Text);
        }
        
        // 선택한 SQL 실행
        private void mnuExecSelSQL_Click(object sender, EventArgs e)
        {
            runSql(tbSql.Text);
        }

        // SQL 명령문 가져오기
        public string GetToken(int index, char deli, string str)
        
        {
            string[] Strs = str.Split(deli); // string을 받아서 split을 수행
            string rst = Strs[index];
            return rst;
        }

        // 메뉴의 엔터키 활성 여부
        private void mnuEnterKey_Click(object sender, EventArgs e)
        {
            mnuEnterKey.Checked = !mnuEnterKey.Checked;
        }
        
        // 엔터키 사용 여부 체크박스 
        private void tbSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mnuEnterKey.Checked) return;
            if (e.KeyCode != Keys.Enter) return;

            string str = tbSql.Text; // sql의 텍스트 박스에 작성한 sql 명령을 문자열로 받고
            string[] sArr = str.Split('\n'); // 받은 문자열에 대해 \n 줄바꿈 문자(엔터를 치는)를 기준으로 명령별로 나누는 작업
            int Len = sArr.Length; // 명령에 대한 길이를 계산
            string sql = sArr[Len - 1].Trim();
            runSql(sql);
        }

        // 데이터그리드 각 셀마다의 수정
        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "."; // 셀을 수정했음을 알려주는 용도(값 변환X)
        }

        // 하단 현황판의 그리드들만을 clear 해주는 메소드
        private void ClearComSelGrid()
        {
            dataGridCovid19.Rows.Clear();
            dataGridCovid19.Columns.Clear();
            dataGridNotVac.Rows.Clear();
            dataGridNotVac.Columns.Clear();
            dataGridYesVac.Rows.Clear();
            dataGridYesVac.Columns.Clear();
        }

        // 데이터그리드 뷰 클리어
        private void mnuClearDatagrid_Click(object sender, EventArgs e)
        {
            ClearAllGrid();
        }
         
        // SQL 질의 수행, 각각에 대한 에러 처리도 함수형태로 에러처리 구현 후 호출하는 방식으로 적용
        int runSql(string strSql)  // 입력받은 SQL 쿼리문 (string sql)
        {
            /*  
            아래 내용을 runSql 함수로 구현하여 적용(정석적인 구현)
            string sql = tbSql.Text;        // tbSql 텍스트 박스에 담긴 모든 문자열을 sql로 선언
            sqlCmd.CommandText = sql;       // 수행해야할 sql 커맨드를 저장
            sqlCmd.ExecuteNonQuery();       // select 문을 제외, 리턴값이 없음          
            sqlCmd.ExecuteReader();
            */

            // 예외처리 필요
            try
            {
                string sql = strSql.Trim(); // while space 제거(공백을 제거한 사본을 전달)
                sqlCmd.CommandText = sql; // 커맨드 텍스트로 넣어줌

                // ex) select * from fStatus : [0]select / [1]* / [2]from / [3]fStatus
                if (GetToken(0, ' ', sql).ToUpper() == "SELECT") // select 문자 이면
                {
                    ClearAllGrid(); // dataGrid에 있는 row와 column을 clear 해주는 메소드
                    SqlDataReader sr = sqlCmd.ExecuteReader(); // 메소드 수행 (ExecuteReader)
                    tableName = GetToken(3, ' ', sql); // select문의 테이블 명을 저장


                    for (int i = 0; i < sr.FieldCount; i++) // 헤더 처리 부분
                    {
                        dataGrid.Columns.Add(sr.GetName(i), sr.GetName(i)); // 각각의 컬럼에 추가될 때마다 argument 전달
                    }

                    for (int i = 0; sr.Read(); i++) // 다음줄로 이동하여 읽을 줄을 선택(하나의 레코드를 읽음)
                    {
                        int ridx = dataGrid.Rows.Add();
                        for (int j = 0; j < sr.FieldCount; j++) // column 별로 데이터를 setting
                        {
                            object str = sr.GetValue(j); // 읽어와야할 필드의 개수를 알고있으므로, 
                            dataGrid.Rows[ridx].Cells[j].Value = str; // 비정형 데이터의 오브젝트 타입으로 되어있는 value 값
                            // buf += $" {str} ";             // object는 타입이 없기 때문에 보간 문자열을 적용해서 가져옴(buf에)
                        }   // 모든 필드에 대해 한줄로 형성 완료, 출력 필요
                        // tbSql.Text += $"\r\n{buf}";
                    }
                    sr.Close();
                }
                else
                {
                    sqlCmd.ExecuteNonQuery(); // select 문을 제외, 리턴값이 없음 (update, insert, delete, create ...)
                }

                sqlCmd.CommandText = sql; // ex) insert into fStatus values (1, 2, 3, 4)

                sbSqlStatus.Text = "Success";
                sbSqlStatus.BackColor = Color.LightGreen;
            }
            catch (SqlException e3)
            {
                MessageBox.Show(e3.Message);
                sbSqlStatus.Text = "Failed";
                sbSqlStatus.BackColor = Color.Red;
            }
            catch (InvalidOperationException e4)
            {
                MessageBox.Show(e4.Message);
                sbSqlStatus.Text = "Failed";
                sbSqlStatus.BackColor = Color.Red;
            }
            return 0;
        }

        // 현재의 dataGrid를 clear 해주는 메소드
        private void ClearAllGrid()
        {
            dataGrid.Rows.Clear();  // dataGrid의 테이블 clear
            dataGrid.Columns.Clear();
        }

        // 그래프의 series를 clear 해주는 메소드
        private void ClearGraphSeries()
        {
            for (int i = 0; i < covidGraph.Series.Count; i++)
            {
                covidGraph.Series[i].Points.Clear();
            }
        }

        private void btnGraphShow_Click(object sender, EventArgs e)
        {
            // --------------------------- 코로나19 현황표 [전체] 출력 -------------------------
            // covidGraph.ChartAreas[0].AxisX.CustomLabels.Add(0.5f, 0.5f, cbChartList.SelectedItem.ToString());
            // covidGraph.Series[0].Points.Add();
            // ---------------------------------------------------------------------------------
        }

        // 메뉴 구성 중 "도움말"의 코로나19 정보 관련 링크 연결(정부 사이트)
        private void covid19InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ncov.mohw.go.kr/baroView.do");
        }

        // 메뉴 구성 중 "도움말"의 코로나19 국제 상황 링크 연결(정부 사이트)
        private void internationalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ncov.mohw.go.kr/bdBoardList_Real.do?brdId=1&brdGubun=14&ncvContSeq=&contSeq=&board_id=&gubun=");
        }

        // 개별지역 그래프 구성 메소드
        private void graphSettings()
        {
            covidGraph.ChartAreas[0].AxisY.Maximum = 120;
            covidGraph.ChartAreas[0].AxisX.Title = cbChartList.SelectedItem.ToString();
        }
    }
}
