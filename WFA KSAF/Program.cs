﻿using System;
using System.Windows.Forms;
using WFA.KSAF.Forms;

namespace WFA.KSAF
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainUi());
        }
    }
}
