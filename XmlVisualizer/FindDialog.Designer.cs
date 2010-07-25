namespace XmlViewer
{
    partial class FindDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbFindWhat = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 9 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 27, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Find";
            // 
            // tbFindWhat
            // 
            this.tbFindWhat.Location = new System.Drawing.Point( 46, 9 );
            this.tbFindWhat.Name = "tbFindWhat";
            this.tbFindWhat.Size = new System.Drawing.Size( 234, 20 );
            this.tbFindWhat.TabIndex = 1;
            this.tbFindWhat.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.tbFindWhat_KeyPress );
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point( 204, 36 );
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size( 75, 23 );
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler( this.btnFind_Click );
            // 
            // FindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292, 70 );
            this.Controls.Add( this.btnFind );
            this.Controls.Add( this.tbFindWhat );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Find";
            this.TopMost = true;
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFindWhat;
        private System.Windows.Forms.Button btnFind;
    }
}