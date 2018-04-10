using System;
using System.Drawing;
using ZedGraph;

namespace WFA.KSAF.Helpers
{
    internal static class ZedGraphHlp
    {
        public static Color RandomColor
        {
            get
            {
                Color[] colors =
                {
                    Color.Black,
                    Color.Blue,
                    Color.Brown,
                    Color.Gray,
                    Color.Green,
                    Color.Indigo,
                    Color.Orange,
                    Color.Red,
                    Color.Aqua,
                    Color.Gold,
                    Color.DarkViolet,
                    Color.DeepPink,
                    Color.YellowGreen
                };
                return colors[new Random().Next(colors.Length)];
            }
        }

        public static void DrawGraph(ZedGraphControl zedGraph, string graphName, PointPairList list, Color graphColor, bool isDeptActive)
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            //pane.CurveList.Clear();
            var listNew = new PointPairList(list);
            // Создадим кривую с названием GraphName, 
            // которая будет рисоваться цветом (GraphColor),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve(graphName, listNew, graphColor, SymbolType.None);
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = false;
            if (isDeptActive)
            {
                pane.XAxis.Title.Text = "KPD";
                pane.YAxis.Title.Text = "DEPT";
            }
            else
            {
                pane.XAxis.Title.Text = "F(x)";
                pane.YAxis.Title.Text = "x";
            }

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();
            // Обновляем график
            zedGraph.Invalidate();
        }
    }
}
