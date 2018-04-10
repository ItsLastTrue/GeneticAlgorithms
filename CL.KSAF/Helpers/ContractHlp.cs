using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace CL.KSAF.Helpers
{
    [DebuggerNonUserCode]
    public static class ContractHlp
    {
        /// <summary>
        /// Проверка условия, в случае невыполнения формирует Exception с указанным текстом.
        /// </summary>
        [AssertionMethod]
        public static void Assert([AssertionCondition(AssertionConditionType.IS_TRUE)]bool predicate, string message)
        {
            if (predicate) return;

            throw new Exception(message);
        }
    }
}
