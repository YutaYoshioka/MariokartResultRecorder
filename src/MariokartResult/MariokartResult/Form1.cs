using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MariokartResult
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void NEW_GAME_button_Click(object sender, EventArgs e)
		{
			var GameWindow = new GameWindow();
			GameWindow.Show();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
