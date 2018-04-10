using System;
using CL.KSAF.Entities;

namespace CL.KSAF.Creators
{
    public sealed class SelectionStatusBuilder : SelectionStatusClass
    {
        private readonly SelectionStatus _selectionStatus;

        public SelectionStatusBuilder(SelectionConfig selectionConfig)
        {
            _selectionStatus = new SelectionStatus(selectionConfig);
        }

        public override void Core()
        {

        }

        public override void AddProgressBar()
        {
            _selectionStatus.IsProgressOnline = true;
        }

        public override void AddGraphPointsCollector(Action collectGraphPoints) =>
            _selectionStatus.GraphPointsCollector = collectGraphPoints;

        public override void AddPhenotypeLog(Action collectLog) =>
            _selectionStatus.LogPhenotypesFunc = collectLog;

        /// <summary>
        /// Добавляет в 'Статус селекции' метод логирования исходного кода класса каждой новой популяции, с заданной 'глубиной' хранения.
        /// </summary>
        public override void AddClassCodeCollector(Action collectClassCodeAction) =>
            _selectionStatus.CollectClassCode = collectClassCodeAction;
        
        public override SelectionStatus GetResult() =>
            _selectionStatus;
    }
}