namespace CL.KSAF.Interfaces
{
    public interface ISelectionLifeCycle
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