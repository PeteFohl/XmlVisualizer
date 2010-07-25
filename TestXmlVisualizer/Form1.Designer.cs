namespace TestXmlVisualizer
{
    partial class Form1
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
            this.xmlViewerBox1 = new XmlVisualizer.XmlViewerBox();
            this.btnSpawn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xmlViewerBox1
            // 
            this.xmlViewerBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlViewerBox1.AttributeNameColor = System.Drawing.Color.FromArgb( ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))) );
            this.xmlViewerBox1.AttributeValueColor = System.Drawing.Color.FromArgb( ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))) );
            this.xmlViewerBox1.AutoScroll = true;
            this.xmlViewerBox1.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))) );
            this.xmlViewerBox1.Element = null;
            this.xmlViewerBox1.Font = new System.Drawing.Font( "ProggyCleanTTSZ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.xmlViewerBox1.ForeColor = System.Drawing.Color.FromArgb( ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))) );
            this.xmlViewerBox1.InnerTextColor = System.Drawing.Color.FromArgb( ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))) );
            this.xmlViewerBox1.Location = new System.Drawing.Point( 0, -1 );
            this.xmlViewerBox1.Name = "xmlViewerBox1";
            this.xmlViewerBox1.Size = new System.Drawing.Size( 292, 225 );
            this.xmlViewerBox1.TabIndex = 0;
            this.xmlViewerBox1.TagNameColor = System.Drawing.Color.FromArgb( ((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))) );
            // 
            // btnSpawn
            // 
            this.btnSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpawn.Location = new System.Drawing.Point( 12, 233 );
            this.btnSpawn.Name = "btnSpawn";
            this.btnSpawn.Size = new System.Drawing.Size( 75, 23 );
            this.btnSpawn.TabIndex = 1;
            this.btnSpawn.Text = "Spawn";
            this.btnSpawn.UseVisualStyleBackColor = true;
            this.btnSpawn.Click += new System.EventHandler( this.btnSpawn_Click );
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292, 268 );
            this.Controls.Add( this.btnSpawn );
            this.Controls.Add( this.xmlViewerBox1 );
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout( false );

        }

        #endregion

        private XmlVisualizer.XmlViewerBox xmlViewerBox1;
        private System.Windows.Forms.Button btnSpawn;
    }
}

