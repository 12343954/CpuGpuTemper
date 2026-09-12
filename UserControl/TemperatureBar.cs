using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace CoolooAI.CpuGpuTemperature
{
    /// <summary>
    /// 可水平/垂直摆放的温度指示条（UserControl 版）
    /// 支持不同温度区间显示不同颜色
    /// </summary>
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Value")]
    public partial class TemperatureBar : System.Windows.Forms.UserControl
    {
        private float _value = 25f;
        private float _minimum = 0f;
        private float _maximum = 100f;
        private Orientation _orientation = Orientation.Horizontal;

        private readonly ToolTip _toolTip = new ToolTip();

        public TemperatureBar()
        {
            InitializeComponent();

            // UserControl 常用双缓冲设置
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);

            // 默认尺寸建议
            Size = new Size(200, 30);

            // 背景色（深色主题友好，可在设计器修改）
            BackColor = Color.FromArgb(0, 0, 0);

            // ToolTip 设置
            _toolTip.AutoPopDelay = 5000;
            _toolTip.InitialDelay = 300;
            _toolTip.ReshowDelay = 100;
            _toolTip.ShowAlways = true;

            // ToolTip 文字颜色（可选，如果想统一风格）
            _toolTip.ForeColor = Color.FromArgb(220, 230, 255);
            _toolTip.BackColor = Color.FromArgb(0, 0, 0);
            _toolTip.OwnerDraw = true;  // 如果想自定义绘制ToolTip

            // 默认字体（用于将来可能显示文字）
            Font = new Font("Segoe UI", 9f);
        }

        #region 公开属性

        [Category("温度条"), Description("当前温度值"), DefaultValue(25f)]
        public float Value
        {
            get => _value;
            set
            {
                float newValue = Math.Clamp(value, _minimum, _maximum);
                if (Math.Abs(_value - newValue) > 0.001f)
                {
                    _value = newValue;
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                    Invalidate();
                    UpdateToolTip();
                }
            }
        }

        [Category("温度条"), Description("最小温度"), DefaultValue(0f)]
        public float Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                if (_maximum <= _minimum) _maximum = _minimum + 1;
                if (_value < _minimum) Value = _minimum;
                Invalidate();
            }
        }

        [Category("温度条"), Description("最大温度"), DefaultValue(100f)]
        public float Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                if (_minimum >= _maximum) _minimum = _maximum - 1;
                if (_value > _maximum) Value = _maximum;
                Invalidate();
            }
        }

        [Category("温度条"), Description("条的方向：水平或垂直"), DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    Invalidate();
                }
            }
        }

        #endregion

        #region 事件

        [Category("温度条"), Description("温度值发生变化时触发")]
        public event EventHandler ValueChanged;

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Width < 10 || Height < 10) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle clientRect = ClientRectangle;

            // 1. 背景轨道
            using (var bgBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(bgBrush, clientRect);
            }

            // 2. 计算填充比例
            float range = _maximum - _minimum;
            float percent = range > 0 ? (_value - _minimum) / range : 0f;
            percent = Math.Clamp(percent, 0f, 1f);

            // 3. 确定填充区域
            Rectangle fillRect;
            if (_orientation == Orientation.Horizontal)
            {
                fillRect = new Rectangle(
                    clientRect.X,
                    clientRect.Y,
                    (int)(clientRect.Width * percent),
                    clientRect.Height);
            }
            else // Vertical
            {
                int fillHeight = (int)(clientRect.Height * percent);
                fillRect = new Rectangle(
                    clientRect.X,
                    clientRect.Bottom - fillHeight,
                    clientRect.Width,
                    fillHeight);
            }

            // 4. 根据温度获取颜色
            Color barColor = GetTemperatureColor(_value);

            // 5. 绘制填充条
            using (var fillBrush = new SolidBrush(barColor))
            {
                e.Graphics.FillRectangle(fillBrush, fillRect);
            }

            // 6. 边框
            using (var borderPen = new Pen(Color.FromArgb(120, 120, 140), 1))
            {
                e.Graphics.DrawRectangle(borderPen,
                    clientRect.X, clientRect.Y,
                    clientRect.Width - 1, clientRect.Height - 1);
            }

            // 7. 简单刻度线（可选）
            DrawScaleLines(e.Graphics, clientRect);
        }

        private Color GetTemperatureColor(float temp)
        {
            // 完全替换为冷蓝渐变风格（匹配图片左侧温度条）
            if (temp >= 85f) return Color.FromArgb(80, 255, 60, 60);      // 极高 → 红色报警
            if (temp >= 75f) return Color.FromArgb(80, 255, 120, 80);     // 高温 → 橙红
            if (temp >= 65f) return Color.FromArgb(80, 255, 120, 0);    // 中高 → 偏紫蓝
            if (temp >= 55f) return Color.FromArgb(80, 255, 215, 0);     // 中 → 亮蓝
            if (temp >= 45f) return Color.FromArgb(80, 50, 205, 50);     // 正常 → 绿色
            if (temp >= 35f) return Color.FromArgb(100, 40, 100, 180);     // 偏低 → 暗蓝
            return Color.FromArgb(100, 70, 130, 180);
        }

        private void DrawScaleLines(Graphics g, Rectangle rect)
        {
            using var pen = new Pen(Color.FromArgb(60, 140, 140, 160), 1);
            const int count = 10;

            if (_orientation == Orientation.Horizontal)
            {
                for (int i = 1; i < count; i++)
                {
                    int x = rect.Left + (int)(rect.Width * i / (float)count);
                    g.DrawLine(pen, x, rect.Top + 5, x, rect.Bottom - 5);
                }
            }
            else
            {
                for (int i = 1; i < count; i++)
                {
                    int y = rect.Bottom - (int)(rect.Height * i / (float)count);
                    g.DrawLine(pen, rect.Left + 5, y, rect.Right - 5, y);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            UpdateToolTip();
        }

        private void UpdateToolTip()
        {
            string tipText = $"温度：{_value:F1} °C";
            if (_toolTip.GetToolTip(this) != tipText)
            {
                _toolTip.SetToolTip(this, tipText);
            }
        }

    }
}
