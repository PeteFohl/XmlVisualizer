namespace XmlVisualizer
{
    partial class XmlViewerBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // XmlViewerBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.DoubleBuffered = true;
            this.Name = "XmlViewerBox";
            this.Size = new System.Drawing.Size( 386, 275 );
            this.Paint += new System.Windows.Forms.PaintEventHandler( this.XmlViewerBox_Paint );
            this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.XmlViewerBox_MouseMove );
            this.Scroll += new System.Windows.Forms.ScrollEventHandler( this.XmlViewerBox_Scroll );
            this.MouseClick += new System.Windows.Forms.MouseEventHandler( this.XmlViewerBox_MouseClick );
            this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.XmlViewerBox_MouseDown );
            this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.XmlViewerBox_MouseUp );
            this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.XmlViewerBox_KeyDown );
            this.ResumeLayout( false );

        }

        #endregion
    }
}
