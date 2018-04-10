using System;
using System.Drawing;
using System.Windows.Forms;
using WFA.KSAF.Helpers;
using ZedGraph;

namespace WFA.KSAF.DrawningGraphs
{
    internal sealed class ZedGraphPainting
    {
        private readonly ZedGraphControl _zedGraphResult;
        private readonly RichTextBox _richTextBoxIncoming;
        private readonly PointPairList _pointPairList = new PointPairList();

        private bool _isPaintingBegun;
        private double _lastX, _lastY;

        public ZedGraphPainting(ZedGraphControl zedGraphResult, RichTextBox richTextBoxIncoming)
        {
            _zedGraphResult = zedGraphResult;
            _richTextBoxIncoming = richTextBoxIncoming;
        }

        public bool IsDeptActive { get; set; }

        public bool DrawtingMode { get; set; }

        public bool MouseDownEvent(MouseEventArgs e)
        {
            if (!DrawtingMode) return default(bool);

            _isPaintingBegun = true;
            _zedGraphResult.IsEnableHZoom = false;
            _zedGraphResult.IsEnableVZoom = false;
            _pointPairList.Clear();
            _richTextBoxIncoming.Clear();
            _zedGraphResult.GraphPane.ReverseTransform(e.Location, out _lastX, out _lastY);
            _lastX = Math.Round(_lastX, 1);
            _lastY = Math.Round(_lastY, 1);
            _pointPairList.Add(_lastX, _lastY);
            try
            {
                _zedGraphResult.GraphPane.CurveList["Произвольная"].Color = Color.HotPink;
            }
            catch
            {
                ZedGraphHlp.DrawGraph(_zedGraphResult, "Произвольная", _pointPairList, Color.HotPink, IsDeptActive);
            }
            _zedGraphResult.GraphPane.CurveList["Произвольная"].Clear();
            return default(bool);
        }

        public void MouseMove(MouseEventArgs e)
        {
            _zedGraphResult.GraphPane.ReverseTransform(e.Location, out double currentX, out double currentY);
            currentY = Math.Round(currentY, 1);
            currentX = Math.Round(currentX, 1);

            if (!_isPaintingBegun) return;

            // Выводим результат
            if ((int)(currentY * 10) - (int)(_lastY * 10) > -1) return;

            _lastX = Math.Round(currentX, 1);
            _lastY = Math.Round(currentY, 1);
            _richTextBoxIncoming.Text += _lastY + " " + _lastX + "\r\n";
            _pointPairList.Add(_lastX, _lastY);
            _zedGraphResult.GraphPane.CurveList["Произвольная"].AddPoint(_lastX, _lastY);
            _zedGraphResult.Invalidate();
        }

        public bool MouseUpEvent()
        {
            _isPaintingBegun = false;
            _zedGraphResult.IsEnableHZoom = true;
            _zedGraphResult.IsEnableVZoom = true;
            return default(bool);
        }
    }
}