using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileIO;

namespace MariokartResult
{
	public partial class GameWindow : Form
	{
		public GameWindow()
		{
			InitializeComponent();
		}

		private void GameWindow_Load(object sender, EventArgs e)
		{
			ResultHistory_DataGridView.RowHeadersVisible = false;

			CoursePictureLoad();
		}

		/// <summary>
		/// 現在選択中のコース
		/// </summary>
		private static int SelectCourseNum = 0;

		private static string[] CourseName = {
			"未選択",
			"マリオカートスタジアム",
			"ウォーターパーク",
			"スイーツキャニオン",
			"ドッスンいせき",
			"マリオサーキット",
			"キノピオハーバー",
			"ねじれマンション",
			"ヘイホーこうざん",
			"サンシャインくうこう",
			"ドルフィンみさき",
			"エレクトロドリーム",
			"ワリオスノーマウンテン",
			"スカイガーデン",
			"ホネホネさばく",
			"クッパキャッスル",
			"レインボーロード",
			"GC ヨッシーサーキット" ,
			"エキサイトバイク",
			"ドラゴンロード",
			"ミュートシティ",
			"GC ベビィパーク",
			"GBA チーズランド",
			"ネイチャーロード",
			"どうぶつの森",
			"3DS ネオクッパシティ",
			"GBA リボンロード",
			"リンリンメトロ",
			"ビッグブルー",
			"Wii ワリオこうざん",
			"SFC レインボーロード",
			"ツルツルツイスター",
			"ハイラルサーキット",
			"DS チックタックロック",
			"3DS パックンスライダー",
			"Wii グラグラかざん",
			"N64 レインボーロード",
			"DS ワリオスタジアム",
			"GC シャーベットランド",
			"3DS ミュージックパーク",
			"N64 ヨッシーバレー",
			"GC カラカラさばく",
			"SFC ドーナッツへいや3",
			"N64 ピーチサーキット",
			"3DS DKジャングル",
			"Wii モーモーカントリー",
			"GBA マリオサーキット",
			"DS プクプクビーチ",
			"N64 キノピオハイウェイ",
		 };

		private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
		{

			/*
			if (MessageBox.Show(
				"入力した値は保存されません。終了してもよろしいですか？", "確認",
				MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation
				) == DialogResult.No)
			{
				e.Cancel = true;
			}
			else
			{
				Properties.Settings.Default.Save();
			}
			*/
		}

		private void ResultHistory_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void Rank_TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void NumberOfPeople_TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void Rate_TextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void OK_Button_Click(object sender, EventArgs e)
		{
			ResultHistory_DataGridView.Rows.Add();

			ResultHistory_DataGridView["Index", ResultHistory_DataGridView.RowCount - 1].Value = ResultHistory_DataGridView.RowCount;

			if (Rank_TextBox.Text != "")
			{
				ResultHistory_DataGridView["Rank", ResultHistory_DataGridView.RowCount - 1].Value = int.Parse(Rank_TextBox.Text).ToString();
				if (NumberOfPeople_TextBox.Text != "")
				{
					ResultHistory_DataGridView["Rank", ResultHistory_DataGridView.RowCount - 1].Value += "/" + int.Parse(NumberOfPeople_TextBox.Text).ToString();
				}
			}

			ResultHistory_DataGridView["Course", ResultHistory_DataGridView.RowCount - 1].Value = CourseName[SelectCourseNum];

			float rank;
			if (Rank_TextBox.Text != "" && NumberOfPeople_TextBox.Text != "")
			{
				if (int.Parse(Rank_TextBox.Text) > 0 && int.Parse(NumberOfPeople_TextBox.Text) > 0 && int.Parse(Rank_TextBox.Text) <= int.Parse(NumberOfPeople_TextBox.Text))
				{
					rank = (float)int.Parse(Rank_TextBox.Text) / int.Parse(NumberOfPeople_TextBox.Text);
				}
				else
				{
					rank = 1;
				}
			}
			else
			{
				rank = 1;
			}

			ResultHistory_DataGridView["RankBar", ResultHistory_DataGridView.RowCount - 1].Value = RankProgressBar(ResultHistory_DataGridView.Rows[0].Cells[3].Size.Width, rank);

			ResultHistory_DataGridView["Rate", ResultHistory_DataGridView.RowCount - 1].Value = Rate_TextBox.Text;

			ResultHistory_DataGridView["controller", ResultHistory_DataGridView.RowCount - 1].Value = controllerTextbox.Text;


			// コースが選択されていたら選択解除
			if (SelectCourseNum != 0)
			{
				PictureBox pic;
				Graphics g;
				var myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
				var bmp = new Bitmap(CoursePicture1.Width, CoursePicture1.Height);
				g = Graphics.FromImage(bmp);
				g.ResetTransform();
				g.TranslateTransform(4, 4);
				g.DrawImage(Image.FromStream(myAssembly.GetManifestResourceStream("MariokartResult.Resources." + (SelectCourseNum - 1) + ".png")), new Rectangle(0, 0, 166, 113));
				pic = CoursePictureNum(SelectCourseNum);
				pic.Image = bmp;
				CoursePictureNum(SelectCourseNum, pic);
				CoursePictureRefresh(SelectCourseNum);
			}
			SelectCourseNum = 0;

			// 順位をリセット
			Rank_TextBox.Text = "";
			NumberOfPeople_TextBox.Text = "";
			Rate_TextBox.Text = "";
		}

		/// <summary>
		/// セーブして終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveEndButton_Click(object sender, EventArgs e)
		{
			var historyData = new List<List<string>>
			{
				new List<string>()
			};
			for (var i = 0; i < ResultHistory_DataGridView.ColumnCount; i++)
			{
				historyData[0].Add(ResultHistory_DataGridView.Columns[i].HeaderText);
			}

			for (var i = 0; i < ResultHistory_DataGridView.RowCount; i++)
			{
				historyData.Add(new List<string>());
				for (var j = 0; j < ResultHistory_DataGridView.ColumnCount; j++)
				{
					if (ResultHistory_DataGridView[j, i].Value == null)
					{
						historyData[i + 1].Add("");
					}
					else
					{
						historyData[i + 1].Add(ResultHistory_DataGridView[j, i].Value.ToString());
					}
				}
			}

			csvIO.WriteStrings(DateTime.Now.Ticks.ToString() + ".csv", historyData, ",");
			Close();
		}

		/// <summary>
		/// DataGridView表示用の順位割合のProgressBarの画像を生成します．
		/// </summary>
		/// <param name="width">表示するセルの横幅</param>
		/// <param name="rank">順位割合(0～1)</param>
		/// <returns></returns>
		private Bitmap RankProgressBar(int width, float rank)
		{
			var bmp = new Bitmap(width, 20);
			var g = Graphics.FromImage(bmp);

			g.FillRectangle(Brushes.Blue, 0, 0, width - (width * rank), 20);
			g.Dispose();

			return bmp;
		}

		private void CoursePictureLoad()
		{
			var myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

			for (var i = 0; i < 48; i++)
			{
				var bmp = new Bitmap(CoursePicture1.Width, CoursePicture1.Height);
				var g = Graphics.FromImage(bmp);
				g.ResetTransform();
				g.TranslateTransform(4, 4);
				g.DrawImage(Image.FromStream(myAssembly.GetManifestResourceStream("MariokartResult.Resources." + i + ".png")), new Rectangle(0, 0, 166, 113));
				var pic = CoursePictureNum(i + 1);
				pic.Image = bmp;
				CoursePictureNum(i + 1, pic);
			}
		}

		/// <summary>
		/// コース画像をクリックされたときの処理。
		/// </summary>
		/// <param name="num">コース番号</param>
		private void ClickPicture(int num)
		{
			PictureBox pic;
			Graphics g;

			// 他にコースが選択されていたら選択解除
			if (SelectCourseNum != 0)
			{
				var myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
				var bmp = new Bitmap(CoursePicture1.Width, CoursePicture1.Height);
				g = Graphics.FromImage(bmp);
				g.ResetTransform();
				g.TranslateTransform(4, 4);
				g.DrawImage(Image.FromStream(myAssembly.GetManifestResourceStream("MariokartResult.Resources." + (SelectCourseNum - 1) + ".png")), new Rectangle(0, 0, 166, 113));
				pic = CoursePictureNum(SelectCourseNum);
				pic.Image = bmp;
				CoursePictureNum(SelectCourseNum, pic);
				CoursePictureRefresh(SelectCourseNum);
			}
			pic = CoursePictureNum(num);
			g = Graphics.FromImage(pic.Image);
			g.DrawLine(new Pen(Color.FromArgb(0, 255, 255), 4), 2, 4, 174, 4);
			g.DrawLine(new Pen(Color.FromArgb(0, 255, 255), 4), 4, 4, 4, 118);
			g.DrawLine(new Pen(Color.FromArgb(0, 255, 255), 4), 2, 118, 174, 118);
			g.DrawLine(new Pen(Color.FromArgb(0, 255, 255), 4), 170, 4, 170, 118);
			CoursePictureNum(num, pic);
			CoursePictureRefresh(num);
			SelectCourseNum = num;
		}

		private void CoursePicture1_Click(object sender, EventArgs e)
		{
			ClickPicture(1);
		}

		private void CoursePicture2_Click(object sender, EventArgs e)
		{
			ClickPicture(2);
		}

		private void CoursePicture3_Click(object sender, EventArgs e)
		{
			ClickPicture(3);
		}

		private void CoursePicture4_Click(object sender, EventArgs e)
		{
			ClickPicture(4);
		}

		private void CoursePicture5_Click(object sender, EventArgs e)
		{
			ClickPicture(5);
		}

		private void CoursePicture6_Click(object sender, EventArgs e)
		{
			ClickPicture(6);
		}

		private void CoursePicture7_Click(object sender, EventArgs e)
		{
			ClickPicture(7);
		}

		private void CoursePicture8_Click(object sender, EventArgs e)
		{
			ClickPicture(8);
		}

		private void CoursePicture9_Click(object sender, EventArgs e)
		{
			ClickPicture(9);
		}

		private void CoursePicture10_Click(object sender, EventArgs e)
		{
			ClickPicture(10);
		}

		private void CoursePicture11_Click(object sender, EventArgs e)
		{
			ClickPicture(11);
		}

		private void CoursePicture12_Click(object sender, EventArgs e)
		{
			ClickPicture(12);
		}

		private void CoursePicture13_Click(object sender, EventArgs e)
		{
			ClickPicture(13);
		}

		private void CoursePicture14_Click(object sender, EventArgs e)
		{
			ClickPicture(14);
		}

		private void CoursePicture15_Click(object sender, EventArgs e)
		{
			ClickPicture(15);
		}

		private void CoursePicture16_Click(object sender, EventArgs e)
		{
			ClickPicture(16);
		}

		private void CoursePicture17_Click(object sender, EventArgs e)
		{
			ClickPicture(17);
		}

		private void CoursePicture18_Click(object sender, EventArgs e)
		{
			ClickPicture(18);
		}

		private void CoursePicture19_Click(object sender, EventArgs e)
		{
			ClickPicture(19);
		}

		private void CoursePicture20_Click(object sender, EventArgs e)
		{
			ClickPicture(20);
		}

		private void CoursePicture21_Click(object sender, EventArgs e)
		{
			ClickPicture(21);
		}

		private void CoursePicture22_Click(object sender, EventArgs e)
		{
			ClickPicture(22);
		}

		private void CoursePicture23_Click(object sender, EventArgs e)
		{
			ClickPicture(23);
		}

		private void CoursePicture24_Click(object sender, EventArgs e)
		{
			ClickPicture(24);
		}

		private void CoursePicture25_Click(object sender, EventArgs e)
		{
			ClickPicture(25);
		}

		private void CoursePicture26_Click(object sender, EventArgs e)
		{
			ClickPicture(26);
		}

		private void CoursePicture27_Click(object sender, EventArgs e)
		{
			ClickPicture(27);
		}

		private void CoursePicture28_Click(object sender, EventArgs e)
		{
			ClickPicture(28);
		}

		private void CoursePicture29_Click(object sender, EventArgs e)
		{
			ClickPicture(29);
		}

		private void CoursePicture30_Click(object sender, EventArgs e)
		{
			ClickPicture(30);
		}

		private void CoursePicture31_Click(object sender, EventArgs e)
		{
			ClickPicture(31);
		}

		private void CoursePicture32_Click(object sender, EventArgs e)
		{
			ClickPicture(32);
		}

		private void CoursePicture33_Click(object sender, EventArgs e)
		{
			ClickPicture(33);
		}

		private void CoursePicture34_Click(object sender, EventArgs e)
		{
			ClickPicture(34);
		}

		private void CoursePicture35_Click(object sender, EventArgs e)
		{
			ClickPicture(35);
		}

		private void CoursePicture36_Click(object sender, EventArgs e)
		{
			ClickPicture(36);
		}

		private void CoursePicture37_Click(object sender, EventArgs e)
		{
			ClickPicture(37);
		}

		private void CoursePicture38_Click(object sender, EventArgs e)
		{
			ClickPicture(38);
		}

		private void CoursePicture39_Click(object sender, EventArgs e)
		{
			ClickPicture(39);
		}

		private void CoursePicture40_Click(object sender, EventArgs e)
		{
			ClickPicture(40);
		}

		private void CoursePicture41_Click(object sender, EventArgs e)
		{
			ClickPicture(41);
		}

		private void CoursePicture42_Click(object sender, EventArgs e)
		{
			ClickPicture(42);
		}

		private void CoursePicture43_Click(object sender, EventArgs e)
		{
			ClickPicture(43);
		}

		private void CoursePicture44_Click(object sender, EventArgs e)
		{
			ClickPicture(44);
		}

		private void CoursePicture45_Click(object sender, EventArgs e)
		{
			ClickPicture(45);
		}

		private void CoursePicture46_Click(object sender, EventArgs e)
		{
			ClickPicture(46);
		}

		private void CoursePicture47_Click(object sender, EventArgs e)
		{
			ClickPicture(47);
		}

		private void CoursePicture48_Click(object sender, EventArgs e)
		{
			ClickPicture(48);
		}

		/// <summary>
		/// 指定した値のCoursePictureの内容を読み書きします。
		/// </summary>
		/// <param name="num">CoursePictureの後の数字</param>
		/// <param name="pictureBox">書き込む内容</param>
		private void CoursePictureNum(int num, PictureBox pictureBox)
		{
			switch (num)
			{
				case 1:
					CoursePicture1 = pictureBox;
					break;
				case 2:
					CoursePicture2 = pictureBox;
					break;
				case 3:
					CoursePicture3 = pictureBox;
					break;
				case 4:
					CoursePicture4 = pictureBox;
					break;
				case 5:
					CoursePicture5 = pictureBox;
					break;
				case 6:
					CoursePicture6 = pictureBox;
					break;
				case 7:
					CoursePicture7 = pictureBox;
					break;
				case 8:
					CoursePicture8 = pictureBox;
					break;
				case 9:
					CoursePicture9 = pictureBox;
					break;
				case 10:
					CoursePicture10 = pictureBox;
					break;
				case 11:
					CoursePicture11 = pictureBox;
					break;
				case 12:
					CoursePicture12 = pictureBox;
					break;
				case 13:
					CoursePicture13 = pictureBox;
					break;
				case 14:
					CoursePicture14 = pictureBox;
					break;
				case 15:
					CoursePicture15 = pictureBox;
					break;
				case 16:
					CoursePicture16 = pictureBox;
					break;
				case 17:
					CoursePicture17 = pictureBox;
					break;
				case 18:
					CoursePicture18 = pictureBox;
					break;
				case 19:
					CoursePicture19 = pictureBox;
					break;
				case 20:
					CoursePicture20 = pictureBox;
					break;
				case 21:
					CoursePicture21 = pictureBox;
					break;
				case 22:
					CoursePicture22 = pictureBox;
					break;
				case 23:
					CoursePicture23 = pictureBox;
					break;
				case 24:
					CoursePicture24 = pictureBox;
					break;
				case 25:
					CoursePicture25 = pictureBox;
					break;
				case 26:
					CoursePicture26 = pictureBox;
					break;
				case 27:
					CoursePicture27 = pictureBox;
					break;
				case 28:
					CoursePicture28 = pictureBox;
					break;
				case 29:
					CoursePicture29 = pictureBox;
					break;
				case 30:
					CoursePicture30 = pictureBox;
					break;
				case 31:
					CoursePicture31 = pictureBox;
					break;
				case 32:
					CoursePicture32 = pictureBox;
					break;
				case 33:
					CoursePicture33 = pictureBox;
					break;
				case 34:
					CoursePicture34 = pictureBox;
					break;
				case 35:
					CoursePicture35 = pictureBox;
					break;
				case 36:
					CoursePicture36 = pictureBox;
					break;
				case 37:
					CoursePicture37 = pictureBox;
					break;
				case 38:
					CoursePicture38 = pictureBox;
					break;
				case 39:
					CoursePicture39 = pictureBox;
					break;
				case 40:
					CoursePicture40 = pictureBox;
					break;
				case 41:
					CoursePicture41 = pictureBox;
					break;
				case 42:
					CoursePicture42 = pictureBox;
					break;
				case 43:
					CoursePicture43 = pictureBox;
					break;
				case 44:
					CoursePicture44 = pictureBox;
					break;
				case 45:
					CoursePicture45 = pictureBox;
					break;
				case 46:
					CoursePicture46 = pictureBox;
					break;
				case 47:
					CoursePicture47 = pictureBox;
					break;
				case 48:
					CoursePicture48 = pictureBox;
					break;

			}
		}

		/// <summary>
		/// 指定した値のCoursePictureの内容を読み書きします。
		/// </summary>
		/// <param name="num">CoursePictureの後の数字</param>
		/// <returns></returns>
		private PictureBox CoursePictureNum(int num)
		{
			switch (num)
			{
				case 1:
					return CoursePicture1;
				case 2:
					return CoursePicture2;
				case 3:
					return CoursePicture3;
				case 4:
					return CoursePicture4;
				case 5:
					return CoursePicture5;
				case 6:
					return CoursePicture6;
				case 7:
					return CoursePicture7;
				case 8:
					return CoursePicture8;
				case 9:
					return CoursePicture9;
				case 10:
					return CoursePicture10;
				case 11:
					return CoursePicture11;
				case 12:
					return CoursePicture12;
				case 13:
					return CoursePicture13;
				case 14:
					return CoursePicture14;
				case 15:
					return CoursePicture15;
				case 16:
					return CoursePicture16;
				case 17:
					return CoursePicture17;
				case 18:
					return CoursePicture18;
				case 19:
					return CoursePicture19;
				case 20:
					return CoursePicture20;
				case 21:
					return CoursePicture21;
				case 22:
					return CoursePicture22;
				case 23:
					return CoursePicture23;
				case 24:
					return CoursePicture24;
				case 25:
					return CoursePicture25;
				case 26:
					return CoursePicture26;
				case 27:
					return CoursePicture27;
				case 28:
					return CoursePicture28;
				case 29:
					return CoursePicture29;
				case 30:
					return CoursePicture30;
				case 31:
					return CoursePicture31;
				case 32:
					return CoursePicture32;
				case 33:
					return CoursePicture33;
				case 34:
					return CoursePicture34;
				case 35:
					return CoursePicture35;
				case 36:
					return CoursePicture36;
				case 37:
					return CoursePicture37;
				case 38:
					return CoursePicture38;
				case 39:
					return CoursePicture39;
				case 40:
					return CoursePicture40;
				case 41:
					return CoursePicture41;
				case 42:
					return CoursePicture42;
				case 43:
					return CoursePicture43;
				case 44:
					return CoursePicture44;
				case 45:
					return CoursePicture45;
				case 46:
					return CoursePicture46;
				case 47:
					return CoursePicture47;
				case 48:
					return CoursePicture48;
				default:
					break;
			}

			return null;
		}


		private void CoursePictureRefresh(int num)
		{
			switch (num)
			{
				case 1:
					CoursePicture1.Refresh();
					break;
				case 2:
					CoursePicture2.Refresh();
					break;
				case 3:
					CoursePicture3.Refresh();
					break;
				case 4:
					CoursePicture4.Refresh();
					break;
				case 5:
					CoursePicture5.Refresh();
					break;
				case 6:
					CoursePicture6.Refresh();
					break;
				case 7:
					CoursePicture7.Refresh();
					break;
				case 8:
					CoursePicture8.Refresh();
					break;
				case 9:
					CoursePicture9.Refresh();
					break;
				case 10:
					CoursePicture10.Refresh();
					break;
				case 11:
					CoursePicture11.Refresh();
					break;
				case 12:
					CoursePicture12.Refresh();
					break;
				case 13:
					CoursePicture13.Refresh();
					break;
				case 14:
					CoursePicture14.Refresh();
					break;
				case 15:
					CoursePicture15.Refresh();
					break;
				case 16:
					CoursePicture16.Refresh();
					break;
				case 17:
					CoursePicture17.Refresh();
					break;
				case 18:
					CoursePicture18.Refresh();
					break;
				case 19:
					CoursePicture19.Refresh();
					break;
				case 20:
					CoursePicture20.Refresh();
					break;
				case 21:
					CoursePicture21.Refresh();
					break;
				case 22:
					CoursePicture22.Refresh();
					break;
				case 23:
					CoursePicture23.Refresh();
					break;
				case 24:
					CoursePicture24.Refresh();
					break;
				case 25:
					CoursePicture25.Refresh();
					break;
				case 26:
					CoursePicture26.Refresh();
					break;
				case 27:
					CoursePicture27.Refresh();
					break;
				case 28:
					CoursePicture28.Refresh();
					break;
				case 29:
					CoursePicture29.Refresh();
					break;
				case 30:
					CoursePicture30.Refresh();
					break;
				case 31:
					CoursePicture31.Refresh();
					break;
				case 32:
					CoursePicture32.Refresh();
					break;
				case 33:
					CoursePicture33.Refresh();
					break;
				case 34:
					CoursePicture34.Refresh();
					break;
				case 35:
					CoursePicture35.Refresh();
					break;
				case 36:
					CoursePicture36.Refresh();
					break;
				case 37:
					CoursePicture37.Refresh();
					break;
				case 38:
					CoursePicture38.Refresh();
					break;
				case 39:
					CoursePicture39.Refresh();
					break;
				case 40:
					CoursePicture40.Refresh();
					break;
				case 41:
					CoursePicture41.Refresh();
					break;
				case 42:
					CoursePicture42.Refresh();
					break;
				case 43:
					CoursePicture43.Refresh();
					break;
				case 44:
					CoursePicture44.Refresh();
					break;
				case 45:
					CoursePicture45.Refresh();
					break;
				case 46:
					CoursePicture46.Refresh();
					break;
				case 47:
					CoursePicture47.Refresh();
					break;
				case 48:
					CoursePicture48.Refresh();
					break;

			}
		}
	}
}
