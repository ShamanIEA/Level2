using System;
using System.Windows.Forms;

namespace SpaceForms
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var spaceForm = new SpaceForm();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            BackGround.InitBackground(spaceForm);
            spaceForm.Show();
            BackGround.DrawBackground();
            Application.Run(spaceForm);
        }
    }
}
