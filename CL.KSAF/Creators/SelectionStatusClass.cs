using System;
using CL.KSAF.Entities;

namespace CL.KSAF.Creators
{
    public abstract class SelectionStatusClass
    {
        public abstract void Core();

        public abstract void AddProgressBar();

        public abstract SelectionStatus GetResult();

        public abstract void AddPhenotypeLog(Action collectLog);

        public abstract void AddGraphPointsCollector(Action collectGraphPoints);
        
        public abstract void AddClassCodeCollector(Action collectClassCodeAction);
    }
}