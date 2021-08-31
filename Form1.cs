using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace cs_form_framework_net_json_datagridview
{
    public partial class Form1 : Form
    {
        private class Syain
        {
            public String 社員コード { get; set; }
            public String 氏名 { get; set; }
            public String フリガナ { get; set; }
            public String 所属 { get; set; }
            private string _性別;
            public string 性別
            {
                get
                {
                    if (this._性別 == "0")
                    {
                        return "男";
                    }
                    else
                    {
                        return "女";
                    }
                }
                set
                {
                    this._性別 = value;
                }
            }
            public int 給与 { get; set; }
            public int? 手当 { get; set; }
            public String 管理者 { get; set; }

            public String 作成日 { get; set; }
            public String 更新日 { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "社員コード";
            dataGridView1.Columns[1].Name = "氏名";
            dataGridView1.Columns[2].Name = "フリガナ";
            dataGridView1.Columns[3].Name = "所属";
            dataGridView1.Columns[4].Name = "性別";
            dataGridView1.Columns[5].Name = "給与";
            dataGridView1.Columns[6].Name = "手当";
            dataGridView1.Columns[7].Name = "管理者";
            dataGridView1.Columns[8].Name = "作成日";
            dataGridView1.Columns[9].Name = "更新日";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // インターネットアクセス用クラス( WebClient )
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.GetEncoding("utf-8");

            Uri uri = new Uri("https://lightbox.sakura.ne.jp/demo/json/syain_json.php");

            string json = webClient.DownloadString(uri);

            Syain[] data = JsonConvert.DeserializeObject<Syain[]>(json);

            // 行をクリア
            dataGridView1.Rows.Clear();

            // 一行ぶんのデータの配列用
            ArrayList al = new ArrayList();

            // 一覧
            foreach ( Syain row in data )
            {
                // １行のクリア
                al.Clear();
                al.Add(row.社員コード);
                al.Add(row.氏名);
                al.Add(row.フリガナ);
                al.Add(row.所属);
                al.Add(row.性別);
                al.Add(row.給与);
                al.Add(row.手当);
                al.Add(row.管理者);
                al.Add(row.作成日);
                al.Add(row.更新日);
                // １行をセット
                dataGridView1.Rows.Add(al.ToArray());
            }

            // 値の長さでカラム幅の自動調整
            dataGridView1.AutoResizeColumns();
        }
    }
}
