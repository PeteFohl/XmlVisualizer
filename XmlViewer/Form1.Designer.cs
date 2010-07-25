namespace XmlViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
            this.xmlViewerBox = new XmlVisualizer.XmlViewerBox();
            this.SuspendLayout();
            // 
            // xmlViewerBox
            // 
            this.xmlViewerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlViewerBox.AttributeNameColor = System.Drawing.Color.FromArgb( ((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))) );
            this.xmlViewerBox.AttributeValueColor = System.Drawing.Color.FromArgb( ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))) );
            this.xmlViewerBox.AutoScroll = true;
            this.xmlViewerBox.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))) );
            this.xmlViewerBox.Element = null;
            this.xmlViewerBox.Font = new System.Drawing.Font( "Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.xmlViewerBox.ForeColor = System.Drawing.Color.FromArgb( ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))) );
            this.xmlViewerBox.InnerTextColor = System.Drawing.Color.Cyan;
            this.xmlViewerBox.Location = new System.Drawing.Point( -1, 0 );
            this.xmlViewerBox.Margin = new System.Windows.Forms.Padding( 4, 4, 4, 4 );
            this.xmlViewerBox.Name = "xmlViewerBox";
            this.xmlViewerBox.Size = new System.Drawing.Size( 667, 551 );
            this.xmlViewerBox.TabIndex = 0;
            this.xmlViewerBox.TagNameColor = System.Drawing.Color.FromArgb( ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))) );
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 665, 550 );
            this.Controls.Add( this.xmlViewerBox );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "Form1";
            this.Text = "Xml Viewer External";
            this.ResumeLayout( false );

        }

        #endregion

        private XmlVisualizer.XmlViewerBox xmlViewerBox;
    }
}

