namespace MariokartResult
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.NEW_GAME_button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// NEW_GAME_button
			// 
			this.NEW_GAME_button.Location = new System.Drawing.Point(12, 12);
			this.NEW_GAME_button.Name = "NEW_GAME_button";
			this.NEW_GAME_button.Size = new System.Drawing.Size(75, 23);
			this.NEW_GAME_button.TabIndex = 0;
			this.NEW_GAME_button.Text = "NEW GAME";
			this.NEW_GAME_button.UseVisualStyleBackColor = true;
			this.NEW_GAME_button.Click += new System.EventHandler(this.NEW_GAME_button_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1208, 631);
			this.Controls.Add(this.NEW_GAME_button);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::MariokartResult.Properties.Settings.Default, "MainformLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Location = global::MariokartResult.Properties.Settings.Default.MainformLocation;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button NEW_GAME_button;
	}
}

