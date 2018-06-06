using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileIO
{
	/// <summary>
	/// テキスト形式(Unicode)でのファイル読み書き
	/// </summary>
	class TextIO
	{
		/// <summary>
		/// 1行ごとのList形式でファイルの内容を読み取ります。outで参照渡しすることで戻り値はファイルの有無のbool値になります。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <returns>ファイルの内容(ファイルが存在しない場合はnull)</returns>
		public static List<string> ReadStrings(string FilePath)
		{
			// ファイルが存在しない場合、nullを返す。
			if (!File.Exists(FilePath))
			{
				return null;
			}
			using (StreamReader file = new StreamReader(FilePath, Encoding.Unicode))
			{
				string line = "";
				List<string> list = new List<string>();
				while ((line = file.ReadLine()) != null)
				{
					list.Add(line);
				}

				return list;
			}
		}

		/// <summary>
		/// 1行ごとのList形式でファイルの内容を読み取ります。outで参照渡しすることで戻り値はファイルの有無のbool値になります。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">ファイルの内容</param>
		/// <returns>ファイルの有無(成功:true, 失敗:false)</returns>
		public static bool ReadStrings(string FilePath, out List<string> strings)
		{
			strings = new List<string>(); // 空のListを作成する

			// ファイルが存在しない場合、falseを返す。
			if (!File.Exists(FilePath))
			{
				return false;
			}

			using (StreamReader file = new StreamReader(FilePath, Encoding.Unicode))
			{
				string line = "";
				while ((line = file.ReadLine()) != null)
				{
					strings.Add(line);
				}

				return true;
			}
		}


		/// <summary>
		/// ファイルに書き込みます。appendを指定しない場合、データはファイルに追加されます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容(1行ごとのstring配列)</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, string[] strings)
		{
			using (StreamWriter file = new StreamWriter(FilePath, true, Encoding.Unicode))
			{
				for (int i = 0; i < strings.Length; i++)
				{
					file.WriteLine(strings[i]);
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容(1行ごとのstring配列)</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, string[] strings, bool append)
		{
			using (StreamWriter file = new StreamWriter(FilePath, append, Encoding.Unicode))
			{
				for (int i = 0; i < strings.Length; i++)
				{
					file.WriteLine(strings[i]);
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。appendを指定しない場合、データはファイルに追加されます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容(1行ごとのList形式)</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, List<string> strings)
		{
			using (StreamWriter file = new StreamWriter(FilePath, true, Encoding.Unicode))
			{
				string[] line = strings.ToArray();
				for (int i = 0; i < line.Length; i++)
				{
					file.WriteLine(line[i]);
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容(1行ごとのList形式)</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, List<string> strings, bool append)
		{
			using (StreamWriter file = new StreamWriter(FilePath, append, Encoding.Unicode))
			{
				string[] line = strings.ToArray();
				for (int i = 0; i < line.Length; i++)
				{
					file.WriteLine(line[i]);
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。appendを指定しない場合、データはファイルに追加されます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, string strings)
		{
			using (StreamWriter file = new StreamWriter(FilePath, true, Encoding.Unicode))
			{
				if (strings != "")
				{
					file.WriteLine(strings);
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, string strings, bool append)
		{
			using (StreamWriter file = new StreamWriter(FilePath, append, Encoding.Unicode))
			{
				if (strings != "")
				{
					file.WriteLine(strings);
				}
			}

			return;
		}


		/// <summary>
		/// ファイルの末尾に文字列を追加します。
		/// また、末尾に改行コードを書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルパス</param>
		/// <param name="AddString">追加する文字列</param>
		/// <returns></returns>
		[Obsolete("このメソッドの使用は推薦しません。代わりに WriteStrings() の使用を推薦します。")]
		public static void AddString(string FilePath, string AddString)
		{
			using (StreamWriter file = new StreamWriter(FilePath, true, Encoding.Unicode))
			{
				file.WriteLine(AddString);
			}

			return;
		}

		/// <summary>
		/// ファイルの末尾に文字列を追加します。
		/// また、末尾に改行コードを書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルパス</param>
		/// <param name="AddString">追加する文字列</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		[Obsolete("このメソッドの使用は推薦しません。代わりに WriteStrings() の使用を推薦します。")]
		public static void AddString(string FilePath, string AddString, bool append)
		{
			using (StreamWriter file = new StreamWriter(FilePath, append, Encoding.Unicode))
			{
				file.WriteLine(AddString);
			}

			return;
		}
	}

	class csvIO
	{
		/// <summary>
		/// csvファイルを読み込み，stringの2次元Listで返します．
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="delimiter">区切り文字</param>
		/// <returns>ファイルの内容(ファイルが存在しない場合はnull)</returns>
		public static List<List<string>> ReadStrings(string FilePath, string delimiter)
		{
			// ファイルが存在しない場合、nullを返す。
			if (!File.Exists(FilePath))
			{
				return null;
			}

			List<List<string>> list = new List<List<string>>();

			using (StreamReader file = new StreamReader(FilePath, Encoding.Unicode))
			{
				string line = "";

				while ((line = file.ReadLine()) != null)
				{
					list.Add(new List<string>());
					int i = 0;
					while (true)
					{
						if (line.IndexOf(delimiter, i) == -1)
						{
							list[list.Count - 1].Add(line.Substring(i, line.Length - i));
							break;
						}
						else
						{
							list[list.Count - 1].Add(line.Substring(i, line.IndexOf(delimiter, i) - i));
						}
						// 次のセルの開始地点を検索
						i = line.IndexOf(delimiter, i) + delimiter.Length;

					}
				}
			}

			return list;
		}

		/// <summary>
		/// ファイルに書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容</param>
		/// <param name="delimiter">区切り文字</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, List<List<string>> strings, string delimiter, bool append)
		{
			using (StreamWriter file = new StreamWriter(FilePath, append, Encoding.Unicode))
			{
				if (strings != null)
				{
					for (int i = 0; i < strings.Count; i++)
					{
						for (int j = 0; j < strings[i].Count; j++)
						{
							if (j != 0)
							{
								file.Write(delimiter);
							}
							file.Write(strings[i][j]);
						}
						file.WriteLine();
					}
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容</param>
		/// <param name="delimiter">区切り文字</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, string[][] strings, string delimiter, bool append)
		{
			using (StreamWriter file = new StreamWriter(FilePath, append, Encoding.Unicode))
			{
				if (strings != null)
				{
					for (int i = 0; i < strings.Length; i++)
					{
						for (int j = 0; j < strings[i].Length; j++)
						{
							if (j != 0)
							{
								file.Write(delimiter);
							}
							file.Write(strings[i][j]);
						}
						file.WriteLine();
					}
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容</param>
		/// <param name="delimiter">区切り文字</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, List<List<string>> strings, string delimiter)
		{
			using (StreamWriter file = new StreamWriter(FilePath, true, Encoding.Unicode))
			{
				if (strings != null)
				{
					for (int i = 0; i < strings.Count; i++)
					{
						for (int j = 0; j < strings[i].Count; j++)
						{
							if (j != 0)
							{
								file.Write(delimiter);
							}
							file.Write(strings[i][j]);
						}
						file.WriteLine();
					}
				}
			}

			return;
		}

		/// <summary>
		/// ファイルに書き込みます。
		/// </summary>
		/// <param name="FilePath">ファイルへのパス</param>
		/// <param name="strings">書き込み内容</param>
		/// <param name="delimiter">区切り文字</param>
		/// <param name="append">データをファイルに追加する場合は true、ファイルを上書きする場合は false。</param>
		/// <returns></returns>
		public static void WriteStrings(string FilePath, string[][] strings, string delimiter)
		{
			using (StreamWriter file = new StreamWriter(FilePath, true, Encoding.Unicode))
			{
				if (strings != null)
				{
					for (int i = 0; i < strings.Length; i++)
					{
						for (int j = 0; j < strings[i].Length; j++)
						{
							if (j != 0)
							{
								file.Write(delimiter);
							}
							file.Write(strings[i][j]);
						}
						file.WriteLine();
					}
				}
			}

			return;
		}
	}


	/// <summary>
	/// ファイル関連メソッド
	/// </summary>
	class Files
	{
		/// <summary>
		/// 指定したディレクトリ内のすべてのファイル・フォルダをコピーします。(aとxを指定、a\b\... → x\b\...)
		/// </summary>
		/// <param name="OriginalDirectory">コピー元のディレクトリ</param>
		/// <param name="TargetDirectory">コピー先のディレクトリ</param>
		/// <returns>成功:true</returns>
		public static bool FilecopyOfDirectory(string OriginalDirectory, string TargetDirectory)
		{
			bool b = true;
			int OriginalName_Count = OriginalDirectory.Count();
			if (!Directory.Exists(OriginalDirectory))
			{
				return false;
			}

			// すべてのフォルダとファイルを取得
			string[] FileAndFolder = Directory.GetDirectories(OriginalDirectory, "*", SearchOption.AllDirectories);
			for (int i = 0; i < FileAndFolder.Length; i++)
			{
				Directory.CreateDirectory(TargetDirectory + FileAndFolder[i].Remove(0, OriginalName_Count));
			}
			FileAndFolder = Directory.GetFiles(OriginalDirectory, "*", SearchOption.AllDirectories);
			for (int i = 0; i < FileAndFolder.Length; i++)
			{
				File.Copy(FileAndFolder[i], TargetDirectory + FileAndFolder[i].Remove(0, OriginalName_Count));
			}

			return b;
		}
	}
}

