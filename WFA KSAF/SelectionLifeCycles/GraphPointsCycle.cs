using CL.Extensions;
using CL.KSAF.Creators;
using CL.KSAF.Entities;
using CL.KSAF.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WFA.KSAF.Forms;
using WFA.KSAF.Helpers;
using ZedGraph;

namespace WFA.KSAF.SelectionLifeCycles
{
    internal sealed class GraphPointsCycle : ISelectionLifeCycle
    {
        private readonly FormMainUi _formMainUi;

        public GraphPointsCycle(FormMainUi formMainUi)
        {
            _formMainUi = formMainUi;
        }

        private SelectionManager SelectionManager => _formMainUi.SelectionManager;

        public SelectionStatus Status => SelectionManager.Status;

        /// <summary>
        /// Замороженная кривая (на случай если новая слишком девиантна).
        /// </summary>
        public PointPairList FrozenPointsPairList { get; private set; }

        public void OnSelectionStarted()
        {
        }

        public void OnSelectionContinue()
        {

        }

        public void OnPopulationCreated()
        {
            if (Status.LastGraphPoints is null) return;

            var newPointsPairList = new PointPairList();

            //При безумном отклонении график с итерациями становится нечитаемым (слишком мелкий зум размывает кривые),
            //поэтому мы просто не выводим 'неудачные функции'.
            var notEvenClose = false;
            var i = 0;
            foreach (List<double> points in SelectionManager.Arguments)
            {
                double newFy = Status.LastGraphPoints.ElementAt(i);
                double startFy = points.Last();

                if (Math.Abs(newFy) > Math.Abs(startFy) * 50.0 && Math.Abs(startFy).IsLessThanEpsilon() == false)
                {
                    notEvenClose = true;
                    break;
                }

                newPointsPairList.Add(newFy, points.First());
                i++;
            }

            if (notEvenClose) return;

            ZedGraphHlp.DrawGraph(_formMainUi.zedGraphIterations, Status.CurrentIteration.ToString(),
                newPointsPairList, ZedGraphHlp.RandomColor, _formMainUi.checkBoxHaveDept.Checked);

            FrozenPointsPairList = newPointsPairList.Clone();
            
            if (_formMainUi.zedGraphIterations.GraphPane.CurveList.Count > 30)
                _formMainUi.zedGraphIterations.GraphPane.Legend.IsVisible = false;

            DoSafeAction(() =>
            {
                _formMainUi.FormDialog.LabelElaps.Text = Status.Timer.Elapsed.ToString();
                _formMainUi.progressBar1.Value = Status.GetProgressPercent(_formMainUi.SelectionManager.SelectionConfig.MaxAlgorithmIterations);
                _formMainUi.FormDialog.Text = @"Итерация № " + Status.CurrentIteration;
                _formMainUi.FormDialog.Refresh();
            });

            var errs = Status.Log.CompileErrors.Count;
            if (errs > 0)
                DoSafeAction(() => _formMainUi.ошибкиToolStripMenuItem.Text = @"Ошибки " + errs);

            DoSafeAction(_formMainUi.Refresh);
        }

        public void OnFindBetterIndividual()
        {
            var pointsText = string.Empty;
            var i = 0;
            foreach (List<double> points in SelectionManager.Arguments)
            {
                for (var args = 0; args < SelectionManager.Arguments.Rows; args++)
                    pointsText += points.ElementAt(args) + "\t";
                pointsText += Status.BestEverIndividual.GraphPoints.ElementAt(i) + "\r\n";
                i++;
            }

            DoSafeAction(() =>
            {
                _formMainUi.richTextBoxResolve.Text = pointsText;
                _formMainUi.FormDialog.TextboxBestPhenotype.Text = Status.BestEverIndividual.Phenotype;
                _formMainUi.Refresh();
                _formMainUi.FormDialog.Refresh();
            });
        }

        public void OnDeviationLeveled() =>
            Activaition(@"Достигнуто преследуемое отклонение");

        public void OnMaxIterationsLeveled() =>
            Activaition(@"Достигнуто заданное колличество итераций");

        public void OnSelectionFinished() =>
            ZedGraphHlp.DrawGraph(_formMainUi.ZedGraphResult, "Результат подбора", FrozenPointsPairList, Color.Blue, _formMainUi.checkBoxHaveDept.Checked);
        
        private void Activaition(string statusText)
        {
            DoSafeAction(() =>
            {
                _formMainUi.FormDialog.LabelStatusText.Text = statusText;
                _formMainUi.FormDialog.TextboxBestPhenotype.Text = Status.BestEverIndividual.Phenotype;
                _formMainUi.FormDialog.LabelCurrentDeviation.Text = @"Текущее отклонение: " + Status.BestEverIndividual.Deviation;
                _formMainUi.FormDialog.Show();
                _formMainUi.ButtonPauseScreen.Visible = true;
                _formMainUi.Refresh();
                _formMainUi.FormDialog.Refresh();
            });
        }

        private void DoSafeAction(Action a) =>
            _formMainUi.DoActionThreadSafe(a);
    }
}