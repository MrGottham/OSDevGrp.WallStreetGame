using System;
using System.Collections.Generic;
using System.Text;

namespace OSDevGrp.WallStreetGame
{
    public abstract class Graph : System.Object, IDisposable
    {
        private float _XPos = 0F;
        private float _YPos = 0F;
        private float _Width = 0F;
        private float _Height = 0F;
        private double _YMin = 0D;
        private double _YMax = 1000D;
        private bool _ShowMinMax = true;
        private bool _IsCurrency = false;
        private System.Drawing.Color _BackColor = System.Drawing.Color.Empty;
        private System.Drawing.Color _GridColor = System.Drawing.Color.White;
        private System.Drawing.Brush _Brush = System.Drawing.Brushes.Black;
        private System.Drawing.Brush _TextBrush = System.Drawing.Brushes.Black;
        private System.Drawing.Pen _Pen = null;
        private System.Drawing.SolidBrush _SolidBrush = null;
        private System.Drawing.Font _TextFont = null;

        #region IDisposable variables
        private bool _Disposed = false;
        #endregion

        public Graph(float x, float y, float width, float height, System.Drawing.Color backcolor) : base()
        {
            try
            {
                XPos = x;
                YPos = y;
                Width = width;
                Height = height;
                YMin = 0;
                YMax = 1000D;
                ShowMinMax = true;
                IsCurrency = false;
                BackColor = backcolor;
                GridColor = System.Drawing.Color.White;
                Brush = System.Drawing.Brushes.Black;
                TextBrush = System.Drawing.Brushes.Black;
                Pen = new System.Drawing.Pen(System.Drawing.Brushes.Black);
                SolidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                Disposed = false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ~Graph()
        {
            try
            {
                Dispose(false);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public float XPos
        {
            get
            {
                return _XPos;
            }
            private set
            {
                _XPos = value;
            }
        }

        public float YPos
        {
            get
            {
                return _YPos;
            }
            private set
            {
                _YPos = value;
            }
        }

        public float Width
        {
            get
            {
                return _Width;
            }
            private set
            {
                _Width = value;
            }
        }

        public float Height
        {
            get
            {
                return _Height;
            }
            private set
            {
                _Height = value;
            }
        }

        public double YMin
        {
            get
            {
                return _YMin;
            }
            set
            {
                _YMin = value;
            }
        }

        public double YMax
        {
            get
            {
                return _YMax;
            }
            set
            {
                _YMax = value;
            }
        }

        protected float YStep
        {
            get
            {
                return Height / ((float) (YMax - YMin));
            }
        }

        public bool ShowMinMax
        {
            get
            {
                return _ShowMinMax;
            }
            set
            {
                _ShowMinMax = value;
            }
        }

        public bool IsCurrency
        {
            get
            {
                return _IsCurrency;
            }
            set
            {
                _IsCurrency = value;
            }
        }

        public System.Drawing.Color BackColor
        {
            get
            {
                return _BackColor;
            }
            private set
            {
                _BackColor = value;
            }
        }

        public System.Drawing.Color GridColor
        {
            get
            {
                return _GridColor;
            }
            set
            {
                _GridColor = value;
            }
        }

        public System.Drawing.Brush Brush
        {
            get
            {
                return _Brush;
            }
            set
            {
                _Brush = value;
            }
        }

        public System.Drawing.Brush TextBrush
        {
            get
            {
                return _TextBrush;
            }
            set
            {
                _TextBrush = value;
            }
        }

        protected System.Drawing.Pen Pen
        {
            get
            {
                return _Pen;
            }
            private set
            {
                _Pen = value;
            }
        }

        protected System.Drawing.SolidBrush SolidBrush
        {
            get
            {
                return _SolidBrush;
            }
            private set
            {
                _SolidBrush = value;
            }
        }

        public System.Drawing.Font TextFont
        {
            get
            {
                return _TextFont;
            }
            set
            {
                _TextFont = value;
            }
        }

        #region IDisposable properties
        private bool Disposed
        {
            get
            {
                return _Disposed;
            }
            set
            {
                _Disposed = value;
            }
        }
        #endregion

        #region IDisposable methods
        public void Dispose()
        {
            try
            {
                Dispose(true);
                System.GC.SuppressFinalize(this);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void Dispose(bool disposing)
        {
            try
            {
                if (!Disposed)
                {
                    if (disposing)
                    {
                        if (Pen != null)
                        {
                            Pen.Dispose();
                            Pen = null;
                        }
                        if (SolidBrush != null)
                        {
                            SolidBrush.Dispose();
                            SolidBrush = null;
                        }
                    }
                    Disposed = true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        protected float CalcYPos(double value)
        {
            try
            {
                double delta = YMax - value;
                if (delta >= 0)
                {
                    return (float) (YPos + (YStep * delta));
                }
                throw new System.OverflowException();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Clear(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(BackColor);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Grid(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                SolidBrush.Color = GridColor;
                e.Graphics.FillRectangle(SolidBrush, XPos, YPos, Width, Height);
                if (ShowMinMax)
                {
                    bool fontcreated = false;
                    System.Globalization.NumberFormatInfo nfi = System.Globalization.NumberFormatInfo.CurrentInfo;
                    System.Globalization.RegionInfo ri = System.Globalization.RegionInfo.CurrentRegion;
                    if (TextFont == null)
                    {
                        TextFont = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif.Name, 7, System.Drawing.FontStyle.Bold);
                        fontcreated = true;
                    }
                    if (IsCurrency)
                    {
                        e.Graphics.DrawString(YMax.ToString("n", nfi) + " " + ri.ISOCurrencySymbol, TextFont, TextBrush, XPos, YPos);
                        e.Graphics.DrawString(YMin.ToString("n", nfi) + " " + ri.ISOCurrencySymbol, TextFont, TextBrush, XPos, YPos + Height - TextFont.Height);
                    }
                    else
                    {
                        e.Graphics.DrawString(YMax.ToString("n", nfi), TextFont, TextBrush, XPos, YPos);
                        e.Graphics.DrawString(YMin.ToString("n", nfi), TextFont, TextBrush, XPos, YPos + Height - TextFont.Height);
                    }
                    if (fontcreated)
                    {
                        TextFont.Dispose();
                        TextFont = null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public enum GraphType
    {
        Line = 1,
        Bar = 2
    }

    public class LineGraph : Graph
    {
        private double _XMin = 0D;
        private double _XMax = 1000D;
        private float _XMargin = 10F;
        private bool _ShowGridLines = true;
        private double _GrdiLineStepX = 0;
        private double _GridLineStepY = 0;
        private float _GraphWidth = 0.50F;
        private float _GridLineWidth = 0.25F;
        private bool _AdjustToRight = false;
        private System.Drawing.Color _GraphColor = System.Drawing.Color.Blue;
        private System.Drawing.Color _GridLineColor = System.Drawing.Color.LightGray;

        public LineGraph(float x, float y, float width, float height, System.Drawing.Color backcolor) : base(x, y, width, height, backcolor)
        {
            try
            {
                XMin = 0D;
                XMax = 1000D;
                XMargin = 10F;
                ShowGridLines = true;
                GridLineStepX = (XMax - XMin) / 10;
                GridLineStepY = (YMax - YMin) / 10;
                GraphWidth = 0.50F;
                GridLineWidth = 0.25F;
                GraphColor = System.Drawing.Color.Blue;
                GridLineColor = System.Drawing.Color.LightGray;
                AdjustToRight = false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public double XMin
        {
            get
            {
                return _XMin;
            }
            set
            {
                _XMin = value;
            }
        }

        public double XMax
        {
            get
            {
                return _XMax;
            }
            set
            {
                _XMax = value;
            }
        }

        public float XMargin
        {
            get
            {
                return _XMargin;
            }
            set
            {
                _XMargin = value;
            }
        }

        protected float XStep
        {
            get
            {
                if (XMin + 1 == XMax)
                    return (Width - (XMargin * 2)) / ((float) (XMax - XMin));
                else
                    return (Width - (XMargin * 2)) / ((float) (XMax - XMin - 1));
            }
        }

        public bool ShowGridLines
        {
            get
            {
                return _ShowGridLines;
            }
            set
            {
                _ShowGridLines = value;
            }
        }

        public double GridLineStepX
        {
            get
            {
                return _GrdiLineStepX;
            }
            set
            {
                _GrdiLineStepX = value;
            }
        }

        public double GridLineStepY
        {
            get
            {
                return _GridLineStepY;
            }
            set
            {
                _GridLineStepY = value;
            }
        }

        public float GraphWidth
        {
            get
            {
                return _GraphWidth;
            }
            set
            {
                _GraphWidth = value;
            }
        }

        public float GridLineWidth
        {
            get
            {
                return _GridLineWidth;
            }
            set
            {
                _GridLineWidth = value;
            }

        }

        public bool AdjustToRight
        {
            get
            {
                return _AdjustToRight;
            }
            set
            {
                _AdjustToRight = value;
            }
        }

        public System.Drawing.Color GraphColor
        {
            get
            {
                return _GraphColor;
            }
            set
            {
                _GraphColor = value;
            }
        }

        public System.Drawing.Color GridLineColor
        {
            get
            {
                return _GridLineColor;
            }
            set
            {
                _GridLineColor = value;
            }
        }

        protected float CalcXPos(double value)
        {
            try
            {
                double delta = XMin + value;
                if (delta >= 0)
                {
                    return (float) (XPos + XMargin + (XStep * delta));
                }
                throw new System.OverflowException();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public override void Grid(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                base.Grid(e);
                if (ShowGridLines && GridLineStepX > 0)
                {
                    double d = XMin + GridLineStepX;
                    float x = CalcXPos(d);
                    Pen.Color = GridLineColor;
                    Pen.Width = GridLineWidth;
                    while (x < XPos + Width - XMargin)
                    {
                        e.Graphics.DrawLine(Pen, x, YPos, x, YPos + Height);
                        d += GridLineStepX;
                        x = CalcXPos(d);
                    }
                }
                if (ShowGridLines && GridLineStepY > 0)
                {
                    double d = YMax - GridLineStepY;
                    float y = CalcYPos(d);
                    Pen.Color = GridLineColor;
                    Pen.Width = GridLineWidth;
                    while (y < YPos + Height)
                    {
                        e.Graphics.DrawLine(Pen, XPos, y, XPos + Width, y);
                        d -= GridLineStepY;
                        y = CalcYPos(d);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Graph(System.Windows.Forms.PaintEventArgs e, System.Collections.Generic.List<double> values)
        {
            try
            {
                float x = CalcXPos(XMin);
                if (AdjustToRight)
                    x = CalcXPos(XMax - values.Count);
                Pen.Color = GraphColor;
                Pen.Width = GraphWidth;
                if (values.Count > 1)
                {
                    for (int i = 1; i < values.Count; i++)
                    {
                        e.Graphics.DrawLine(Pen, x, CalcYPos(values[i - 1]), x + XStep, CalcYPos(values[i]));
                        x += XStep;
                    }
                }
                else if (values.Count > 0)
                {
                    e.Graphics.DrawLine(Pen, x, CalcYPos(values[0]), x + XStep, CalcYPos(values[0]));
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public class BarGraph : Graph
    {
        private int _NoOfBars = 4;
        private float _XMargin = 10F;
        private bool _ShowGridLines = true;
        private double _GridLineStepY = 0;
        private float _GridLineWidth = 0.25F;
        private float _BarSpace = 10F;
        private System.Drawing.Color _GridLineColor = System.Drawing.Color.LightGray;

        public BarGraph(float x, float y, float width, float height, System.Drawing.Color backcolor) : base(x, y, width, height, backcolor)
        {
            try
            {
                NoOfBars = 4;
                XMargin = 10F;
                ShowGridLines = true;
                GridLineStepY = (YMax - YMin) / 10;
                GridLineWidth = 0.25F;
                BarSpace = 10F;
                BarBrush = System.Drawing.Brushes.Blue;
                GridLineColor = System.Drawing.Color.LightGray;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int NoOfBars
        {
            get
            {
                return _NoOfBars;
            }
            set
            {
                _NoOfBars = value;
            }
        }

        public float XMargin
        {
            get
            {
                return _XMargin;
            }
            set
            {
                _XMargin = value;
            }
        }

        public bool ShowGridLines
        {
            get
            {
                return _ShowGridLines;
            }
            set
            {
                _ShowGridLines = value;
            }
        }

        public double GridLineStepY
        {
            get
            {
                return _GridLineStepY;
            }
            set
            {
                _GridLineStepY = value;
            }
        }

        public float GridLineWidth
        {
            get
            {
                return _GridLineWidth;
            }
            set
            {
                _GridLineWidth = value;
            }
        }

        public float BarSpace
        {
            get
            {
                return _BarSpace;
            }
            set
            {
                _BarSpace = value;
            }
        }

        public System.Drawing.Brush BarBrush
        {
            get
            {
                return base.Brush;
            }
            set
            {
                base.Brush = value;
            }
        }

        public System.Drawing.Color GridLineColor
        {
            get
            {
                return _GridLineColor;
            }
            set
            {
                _GridLineColor = value;
            }
        }

        public override void Grid(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                base.Grid(e);
                if (ShowGridLines && GridLineStepY > 0)
                {
                    double d = YMax - GridLineStepY;
                    float y = CalcYPos(d);
                    Pen.Color = GridLineColor;
                    Pen.Width = GridLineWidth;
                    while (y < YPos + Height)
                    {
                        e.Graphics.DrawLine(Pen, XPos, y, XPos + Width, y);
                        d -= GridLineStepY;
                        y = CalcYPos(d);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Bar(System.Windows.Forms.PaintEventArgs e, int barno, double value)
        {
            try
            {
                float width = (Width - (XMargin * 2) - (BarSpace * (NoOfBars - 1))) / NoOfBars;
                float x = XPos + XMargin + ((width + BarSpace) * barno);
                e.Graphics.FillRectangle(BarBrush, x, CalcYPos(value), width, YPos + Height - CalcYPos(value));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
