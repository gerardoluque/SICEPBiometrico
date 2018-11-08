using System;
using System.Resources;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BioBaseDotNetDemo
{
    /// <summary>
    /// Summary description for ImageCtrl.
    /// </summary>
    [ComVisible(false)]
    public class ImageCtrl : System.Windows.Forms.UserControl
    {
		private ContextMenu contextMenu = new ContextMenu();
		private MenuItem menuItemCenterAndFit;
		private MenuItem menuItemZoomIn;
		private MenuItem menuItemZoomOut;

		/// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
		private bool	_selected;
        private Bitmap	_bitmap;
        private float	_panX;
        private float	_panY;
        private float	_imageScale	= 1.0f;
        private float	_imageDpi	= 500.0f;
        private float	_scale		= 1.0f;
        private string	_captionUL;
        private string	_captionLL;
        private string  _captionMiddle;
        private bool	_drawRedX;

        private bool	_drag;
        private int		_dragX0;
        private int		_dragY0;
        private bool	_dragZoom;
        private bool	_skip1Down;
        private float	_zoomFactor	= 1.10f;
        private float	_panFactor	= 0.10f;

        private Rectangle[] _rectangles;
        private object		_userData;
        private int			_fgnId;
		private System.Windows.Forms.HelpProvider helpProvider1;
        private int			_maskId;
		

        public ImageCtrl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // Set for double buffering to avoid drawing flicker
            SetStyle( ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint | 
                ControlStyles.DoubleBuffer, true );

            this.MouseDown+=new MouseEventHandler(ImageCtrl_MouseDown);
            this.MouseUp+=new MouseEventHandler(ImageCtrl_MouseUp);
            this.MouseMove+=new MouseEventHandler(ImageCtrl_MouseMove);
            this.MouseWheel+= new System.Windows.Forms.MouseEventHandler(ImageCtrl_MouseWheel);
            this.GotFocus+=new EventHandler(ImageCtrl_GotFocus);

			// Build context menu
			menuItemCenterAndFit = new MenuItem(Properties.Resources.txtCenterAndFit);
			contextMenu.MenuItems.Add(menuItemCenterAndFit);
			menuItemCenterAndFit.Click+=new EventHandler(menuItemCenterAndFit_Click);

			menuItemZoomIn = new MenuItem( Properties.Resources.txtZoomIn);
			contextMenu.MenuItems.Add(menuItemZoomIn);
			menuItemZoomIn.Click+=new EventHandler(menuItemZoomIn_Click);

			menuItemZoomOut		 = new MenuItem( Properties.Resources.txtZoomOut);
			contextMenu.MenuItems.Add(menuItemZoomOut);
			menuItemZoomOut.Click+=new EventHandler(menuItemZoomOut_Click);

			this.ContextMenu = contextMenu;

            this.Cursor = Cursors.SizeAll;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if( _bitmap != null )
                {
                    _bitmap.Dispose();
                    _bitmap = null;
                }

                if(components != null)
                {
                    components.Dispose();
                }
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
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			// 
			// ImageCtrl
			// 
			this.BackColor = System.Drawing.Color.White;
			this.helpProvider1.SetHelpString(this, @"This window is used display an image of biometric or scanned document information.  After clicking on this window, you may use the arrow keys to pan the image.  Use Ctrl+up/down arrow keys to zoom the image.  A mouse wheel may be used to zoom the image.  Hold down the left mouse button to drag the image position.  Panning and zooming the image only affect the viewing of the image.  It does not change the image itself.");
			this.Name = "ImageCtrl";
			this.helpProvider1.SetShowHelp(this, true);
			this.Resize += new System.EventHandler(this.ImageCtrl_Resize);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageCtrl_Paint);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageCtrl_KeyUp);
		}
        #endregion

        public new bool Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; SetBackColor(); }
        }

        public int FgnId
        {
            get { return _fgnId; }
            set { _fgnId = value; Invalidate(); }
        }

        public int MaskId
        {
            get { return _maskId; }
            set { _maskId = value; Invalidate(); }
        }

        public string CaptionUL
        {
            get { return _captionUL; }
            set { _captionUL = value; Invalidate(); }
        }

        public string CaptionLL
        {
            get { return _captionLL; }
            set { _captionLL = value; Invalidate(); }
        }

        public string CaptionMiddle
        {
            get { return _captionMiddle; }
            set { _captionMiddle = value; Invalidate(); }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; Invalidate(); }
        }

        public Bitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; Invalidate(); }
        }

        public object UserData
        {
            get { return _userData; }
            set { _userData = value; }
        }

        public float PanX
        {
            get { return _panX; }
            set { _panX = value; Invalidate(); }
        }

        public float PanY
        {
            get { return _panY; }
            set { _panY = value; Invalidate(); }
        }

        public float ImageScale
        {
            get { return _imageScale; }
            set { _imageScale = value; Invalidate(); }
        }

        public float ImageDpi
        {
            get { return _imageDpi; }
            set { _imageDpi = value; Invalidate(); }
        }

        public Rectangle[] Rectangles
        {
            get { return _rectangles; }
            set { _rectangles = value; Invalidate(); }
        }

        private void SetBackColor()
        {
            Color backColor = Color.White;

            if (this.Enabled == false)
            {
                if (this.Parent != null)
                    backColor = Parent.BackColor;
                else
                    backColor = Color.LightGray;
            }

            if( backColor != this.BackColor)
                this.BackColor = backColor;
        }

        public bool DrawRedX
        {
            get { return _drawRedX; }
            set { _drawRedX = value; Invalidate(); }
        }

        private void ImageCtrl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                /*
                SolidBrush backBrush;
                if (this.Enabled == false)
                {
                    if (this.Parent != null)
                        backBrush = new SolidBrush(Parent.BackColor);
                    else
                        backBrush = new SolidBrush(Color.LightGray);
                }
                else
                    backBrush = new SolidBrush(this.BackColor);

                e.Graphics.FillRectangle(backBrush, this.ClientRectangle);
                 **/

                Pen pen;

                if( _bitmap != null )
                {	// Got an image, show it
                    _scale = _imageScale;
                    float dstWidth  = ((float) _bitmap.Width)  * _scale;
                    float dstHeight = ((float) _bitmap.Height) * _scale;

                    RectangleF dstRect = new RectangleF( _panX, _panY, dstWidth, dstHeight );
                    RectangleF srcRect = new RectangleF( 0.0f, 0.0f, (float)_bitmap.Width, (float)_bitmap.Height );

                    e.Graphics.DrawImage( _bitmap, dstRect, srcRect, GraphicsUnit.Pixel );
                }

                // Reference Rectangles
                if( _rectangles != null )
                {
                    foreach ( Rectangle rect in _rectangles )
                    {
                        pen = new Pen( Color.Green, 1.0f );
                        float x0	 = (rect.Left  * _imageScale) + _panX; 
                        float y0	 = (rect.Top   * _imageScale) + _panY; 
                        float width  = rect.Width  * _imageScale; 
                        float height = rect.Height * _imageScale; 
                        e.Graphics.DrawRectangle( pen, x0, y0, width, height );
                    }
                }

                // Text for Captions (if any)
                Font font = new Font( "Arial", 8.0f );
                if( _captionUL != null )
                {
                    DrawCaption( e.Graphics, _captionUL, font, 2.0f, 2.0f );
                }

                if( _captionLL != null )
                {
                    SizeF size = e.Graphics.MeasureString( _captionLL, font );
                    float y0 = Height - size.Height - 2.0f;
                    DrawCaption( e.Graphics, _captionLL, font, 2.0f, y0 );
                }

                if( _captionMiddle != null )
                {
                    Font bigFont = new Font( "Arial", 24.0f );
                    SizeF size = e.Graphics.MeasureString( _captionMiddle, bigFont );
                    float y0 = (Height/2) - (size.Height/2) - 2.0f;
                    float x0 = (Width/2) - (size.Width/2) - 2.0f; 
                    DrawCaption( e.Graphics, _captionMiddle, bigFont, x0, y0 );
                }

                // Draw the bounding rectangle (regular or selected)
                if( _selected )
                    pen = new Pen( Color.Black, 4.0f );
                else
                    pen = new Pen( Color.Gray, 1.0f );

                e.Graphics.DrawRectangle( pen, 0,0, Width-1, Height-1 );

                // Red X marker?
                if( _drawRedX == true )
                {
                    pen = new Pen( Color.Red, 2.0f );
                    int xc = Width / 2;
                    int yc = Height / 2;
                    int dx = Width / 4;
                    int dy = Height / 4;
                    
                    e.Graphics.DrawLine( pen, xc-dx,yc-dy, xc+dx, yc+dy );
                    e.Graphics.DrawLine( pen, xc-dx,yc+dy, xc+dx, yc-dy );
                }
            }
            catch
            {
            }
        }

        private void DrawCaption( Graphics graphics, string caption, Font font, float x0, float y0 )
        {	// Displays caption text on a BackColor background

            SizeF size = graphics.MeasureString( caption, font );

            Brush brush = new SolidBrush( this.BackColor );
            graphics.FillRectangle( brush, x0, y0, size.Width, size.Height ); 

            brush = new SolidBrush( Color.Green );
            graphics.DrawString( caption, font, brush, x0, y0 );
        }

        private void ImageCtrl_Resize(object sender, System.EventArgs e)
        {
            Invalidate();
        }

        public void ClearImage()
        {
            if( _bitmap != null )
            {
                _bitmap.Dispose();
                _bitmap = null;
            }
        }

        public void LoadImage( int iHll, int iVll, int iDpi, Bitmap bmp )
        {
            try
            {
                ClearImage();
                this.Bitmap = bmp;
                this.ImageDpi = iDpi;

                CenterAndFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "ImageCtrl.LoadImage" );
            }
        }

        public void LoadImage( int iHll, int iVll, int iDpi, ref byte[] data )
        {
            try
            {
                Bitmap bitmap = new Bitmap( iHll, iVll, PixelFormat.Format8bppIndexed );
                Rectangle rect = new Rectangle( 0, 0, iHll, iVll );
                BitmapData bmData = bitmap.LockBits( rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed );
                //if (bmData.Stride == iHll)
                //    Marshal.Copy( data, 0, bmData.Scan0, data.Length );
                //else
                {   // Stride and image width not same, do hard way!
                    int x, y;
                    byte[] row = new byte[bmData.Stride];
                    for (x = 0; x < row.Length; x++)
                        row[x] = 0;

                    for (y = 0; y < iVll; y++)
                    {
                        int from = ( y ) * iHll;
                        for (x = 0; x < iHll; x++)
                            row[x] = data[from++];

                        IntPtr toPtr = new IntPtr((int)bmData.Scan0 + y * bmData.Stride);
                        Marshal.Copy(row, 0, toPtr, bmData.Stride);
                    }
                }

                bitmap.UnlockBits( bmData );

                bitmap.SetResolution( iDpi, iDpi );
                bitmap.Palette = GrayscalePalette( );

                ClearImage();
                this.Bitmap = bitmap;
                this.ImageDpi = iDpi;

                CenterAndFit();
			}
            catch ( Exception ex )
            {
                MessageBox.Show( ex.Message,  "ImageCtrl.LoadImage" );
            }
        }

        private static ColorPalette GrayscalePalette()
        {	// A palette cannot be directly created. Make a bitmap and "steal" its palette.
            try
            {
                Bitmap bitmap = new Bitmap( 1, 1, PixelFormat.Format8bppIndexed );
                ColorPalette palette = bitmap.Palette;
                bitmap.Dispose();
                for( int i = 0; i < 256; i++ )
                    palette.Entries[i] = Color.FromArgb( 255, i, i, i );
                return palette;
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message, "PluginBase.ColorPalette" );
                return null;
            }
        }


        private bool InZoomDragRegion( int x )
        {
            return (Width - x) < 20;
        }

        private void ImageCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            if( _skip1Down == false )
            {
                _drag = true;
                _dragX0 = e.X;
                _dragY0 = e.Y;

                _dragZoom = InZoomDragRegion(e.X);
            }

            _skip1Down = false;
        }

        private void ImageCtrl_MouseUp(object sender, MouseEventArgs e)
        {
            _drag = false;
            _dragZoom = false;
        }

        private void ImageCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            if( _bitmap == null )
                return;

            if( (InZoomDragRegion(e.X)== true) || (_dragZoom == true) )
                this.Cursor = Cursors.SizeNS;
            else if( _drag == true )
                this.Cursor = Cursors.SizeAll;
            else
                this.Cursor = Cursors.Arrow;

            if( _drag == false )
                return;

            float dx = e.X - _dragX0;
            float dy = e.Y - _dragY0;

            if( _dragZoom )
            {
                // Apply new zoom scaling
                float zoomBy = _zoomFactor;
                if( dy < 0 )
                    zoomBy = 1.0f / _zoomFactor;

                DoZoom( Width/2, Height/2, zoomBy );
            }
            else
            {
                _panX += dx;
                _panY += dy;
                Invalidate();
            }

            _dragX0 = e.X;
            _dragY0 = e.Y;
        }

        public void CenterAndFit()
        {	// Note, the image DPI must be correct for this to work

            if( _bitmap == null )
                return;

            Graphics gr = Graphics.FromHwnd( this.Handle );
            float dpi = gr.DpiX;
            _scale = ( dpi / _imageDpi ) * _imageScale;

            float scaleH = (float) Width / _bitmap.Width;
            float scaleV = (float) Height / _bitmap.Height;
            _imageScale = Math.Min( scaleH, scaleV );

            _panX = 0.0f;
            _panY = 0.0f;

            if( _imageScale == scaleH )
            {
                float heightPx = _bitmap.Height * _imageScale;
                _panY = ( ((float) Height) - heightPx ) / 2.0f;
            }
            else
            {
                float widthPx = _bitmap.Width * _imageScale;
                _panX = ( ((float) Width) - widthPx ) / 2.0f;
            }
 
            Invalidate();

        }

        private void ImageCtrl_GotFocus(object sender, EventArgs e)
        {
            _skip1Down = true;
        }

        protected override bool ProcessDialogKey(Keys k)
        {	// This override prevents the change of focus to the next control (standard dialog processing).
            // This control uses the arrow keys to do pan and zoom of the image instead of tabbing to the
            // next control.
            return true;
        }

        private void ImageCtrl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            e.Handled = DoProcessKey( e.KeyCode );
        }

        protected bool DoProcessKey(Keys k)
        {	// Process special pan/zoom keys
            bool bProcessed = true;
            bool control = Control.ModifierKeys == Keys.Control;

            switch ( k )
            {
                case Keys.Left:
                case Keys.Left | Keys.Control:
                case Keys.Left | Keys.Shift:
                    PanLeft();
                    break;

                case Keys.Right:
                case Keys.Right | Keys.Control:
                case Keys.Right | Keys.Shift:
                    PanRight();
                    break;

                case Keys.Up:
                case Keys.Up | Keys.Shift:
                case Keys.Up | Keys.Control:
                    if( control == true )
                        ZoomOut();
                    else
                        PanUp();
                    break;

                case Keys.Down:
                case Keys.Down | Keys.Shift:
                case Keys.Down | Keys.Control:
                    if( control == true )
                        ZoomIn();
                    else
                        PanDown();
                    break;

                default:
                    bProcessed = base.ProcessDialogKey(k);
                    break;
            }

            return bProcessed;
        }

        private void ImageCtrl_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {	// Zooming with the mouse wheel

            if( e.Delta == 0 )
                return;

            // Apply new zoom scaling
            float zoomBy = _zoomFactor;
            if( e.Delta < 0 )
                zoomBy = (1.0f / _zoomFactor);

            DoZoom( e.X, e.Y, zoomBy );
        }

        private void PanUp()
        {
            _panY -= Math.Max( Width * _panFactor, 1.0f );
            Invalidate();
        }

        private void PanDown()
        {
            _panY += Math.Max( Width * _panFactor, 1.0f );
            Invalidate();
        }

        private void PanRight()
        {
            _panX += Math.Max( Height * _panFactor, 1.0f );
            Invalidate();
        }

        private void PanLeft()
        {
            _panX -= Math.Max( Height * _panFactor, 1.0f );
            Invalidate();
        }

        private void ZoomIn()
        {
            float zoomBy = _zoomFactor;
            DoZoom( Width/2, Height/2, zoomBy );
        }

        private void ZoomOut()
        {
            float zoomBy = (1.0f / _zoomFactor);
            DoZoom( Width/2, Height/2, zoomBy );
        }

        private void DoZoom( int aboutX, int aboutY, float zoomBy )
        {	// Zooming with the mouse wheel

            // Calculate current "about point" in bitmap units
            float xcDim = (aboutX - _panX) / _scale;
            float ycDim = (aboutY - _panY) / _scale;

            // Set new zooming scale
            _imageScale *= zoomBy;

            // Set pan to retain same bitmap point in the view
            float scale = _scale * zoomBy;
            _panX = aboutX - (xcDim * scale);
            _panY = aboutY - (ycDim * scale);

            Invalidate();
		}

		private void menuItemCenterAndFit_Click(object sender, EventArgs e)
		{
			CenterAndFit();
		}

		private void menuItemZoomIn_Click(object sender, EventArgs e)
		{
			ZoomIn();
		}

		private void menuItemZoomOut_Click(object sender, EventArgs e)
		{
			ZoomOut();
		}

		/// <summary>
		/// Helper member to assist in encoding fingerprint images scores and annotations.
		/// </summary>
		/// <param name="scores">Array of score values.</param>
		/// <param name="annotations">Array of annotation values that correspond to the scores. Set
		/// each array item that has no annotation to null.</param>
		/// <returns>The text encoding of the score and annotation values.</returns>
		public static string EncodeScores( int[] scores, string[] annotations )
		{
			try
			{
				string strScores = "";

				if( (scores != null) && (scores.Length > 0) )
				{
					strScores = "Scores: " + EncodeScore(scores[0], annotations[0]);
					for ( int index=1; index < scores.Length; index++ )
						strScores += string.Format( ", {0}", EncodeScore(scores[index], annotations[index] ) );
				}

				return strScores;
			}
			catch ( Exception ex )
			{
				MessageBox.Show( ex.Message, "PluginPiv.EncodeScores" );
				return "";
			}
		}

		private static string EncodeScore( int score, string annotation )
		{
			string text;
			
			if( (annotation == null) || (annotation.Length == 0) )
				text = score.ToString();
			else
			{
				if( score == 0 )
					text = annotation;
				else
					text = string.Format( "{0}:{1}", score, annotation );
			}

			return text;
		}
	}
}
