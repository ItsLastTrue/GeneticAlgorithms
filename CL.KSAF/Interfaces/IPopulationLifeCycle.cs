using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.KSAF.Interfaces
{
    internal interface IPopulationLifeCycle
    {
        void OnSelectionStarted();

        void OnSelectionContinue();

        void OnPopulationCreated();

        void OnFindBetterIndividual();

        void OnDeviationLeveled();

        void OnMaxIterationsLeveled();

        void OnSelectionFinished();
    }
}
