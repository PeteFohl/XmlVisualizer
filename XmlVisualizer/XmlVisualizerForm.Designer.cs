namespace XmlVisualizer
{
    partial class XmlVisualizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( XmlVisualizerForm ) );
            this.btnSpawn = new System.Windows.Forms.Button();
            this.xmlViewer = new XmlVisualizer.XmlViewerBox();
            this.SuspendLayout();
            // 
            // btnSpawn
            // 
            this.btnSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpawn.Location = new System.Drawing.Point( 12, 523 );
            this.btnSpawn.Name = "btnSpawn";
            this.btnSpawn.Size = new System.Drawing.Size( 127, 23 );
            this.btnSpawn.TabIndex = 3;
            this.btnSpawn.Text = "Spawn External Viewer";
            this.btnSpawn.UseVisualStyleBackColor = true;
            this.btnSpawn.Click += new System.EventHandler( this.btnSpawn_Click );
            // 
            // xmlViewer
            // 
            this.xmlViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlViewer.AttributeNameColor = System.Drawing.Color.FromArgb( ((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))) );
            this.xmlViewer.AttributeValueColor = System.Drawing.Color.FromArgb( ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))) );
            this.xmlViewer.AutoScroll = true;
            this.xmlViewer.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))) );
            this.xmlViewer.Element = null;
            this.xmlViewer.Font = new System.Drawing.Font( "Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.xmlViewer.ForeColor = System.Drawing.Color.FromArgb( ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))) );
            this.xmlViewer.InnerTextColor = System.Drawing.Color.Cyan;
            this.xmlViewer.Location = new System.Drawing.Point( 0, -1 );
            this.xmlViewer.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            this.xmlViewer.Name = "xmlViewer";
            this.xmlViewer.Size = new System.Drawing.Size( 725, 518 );
            this.xmlViewer.TabIndex = 2;
            this.xmlViewer.TagNameColor = System.Drawing.Color.FromArgb( ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))) );
            // 
            // XmlVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))) );
            this.ClientSize = new System.Drawing.Size( 725, 552 );
            this.Controls.Add( this.btnSpawn );
            this.Controls.Add( this.xmlViewer );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XmlVisualizerForm";
            this.ShowInTaskbar = false;
            this.Text = "Xml Visualizer";
            this.ResumeLayout( false );

        }

        #endregion

        private XmlViewerBox xmlViewer;
        private System.Windows.Forms.Button btnSpawn;

    }
}