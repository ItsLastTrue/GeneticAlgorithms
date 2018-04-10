namespace CL.KSAF.Entities
{
    public sealed class SelectionConfig
    {
        public readonly string[] Operators = { "+", "-", "*", "/", "(", ",", "Pow", "Log", "Sin", "Cos", "Tan", "Exp" };

        /// <summary>
        /// Максимальное количество попыток подобраться к лучшему симплексу для алгоритма Нелдора-Мида.
        /// </summary>
        public int MaxNelrodMidIterations { get; set; } = 300;

        /// <summary>
        /// Максимальное число популяций на данном круге (Exp.: при 10, каждые 10 итераций будет остановка).
        /// </summary>
        public int MaxAlgorithmIterations { get; set; }

        /// <summary>
        /// Максимально допустимое суммарное отклонение.
        /// </summary>
        /// <remarks>
        /// По сути измеряется в 'едницах', следовательно незваисим от метода расчета отклонения (среднеквадратичное, по модулю, просто в штуках и тд).
        /// </remarks>
        public double TargetDeviation { get; set; } = 1.0;

        /// <summary>
        /// Скорость роста. Максимальное количество генов для обмена при скрещивании.
        /// </summary>
        public int GrowSpeed { get; set; } = 7;

        /// <summary>
        /// Шанс мутации конечного гена при скрещивании.
        /// </summary>
        public int MutationChance { get; set; } = 10;

        /// <summary>
        /// Максимальное количество переменных в генотипах.
        /// </summary>
        public int MaxConstantsCount { get; set; } = 7;
    }
}