using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceForms
{
    public partial class SpaceForm : Form
    {
        private bool StatusGame { get; set; } //Задаём статус книпки Пауза

        private bool StatusStop { get; set; } // Задаём Статус кнопки Выход

        public SpaceForm()
        {
            InitializeComponent();
            PauseToolStripMenuItem.Visible = false;
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StatusStop)
            {
                //Останавливаем timer заставки
                BackGround.Timer.Dispose();
                // Очищаем буфер графики
                BackGround.Buffer.Dispose();

                //Запускаем игру
                GoGame();
            }
            else
            {
                //Останавливаем таймер игры
                Game.Timer.Dispose();
                //Очищаем буфер игры
                Game.Buffer.Dispose();

                //Запускаем игру заново
                GoGame();
            }
        }

        private void GoGame()
        {
            Game.InitGame(this);
            Game.DrawGame();
            ExitToolStripMenuItem.Text = "Стоп";
            StatusStop = true;
            PauseToolStripMenuItem.Visible = true;
            StatusGame = true;
            StartToolStripMenuItem.Text = "Заново";
        }

        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (StatusStop)
            {
                Game.Timer.Dispose();
                Game.Buffer.Dispose();
                BackGround.InitBackground(this);
                BackGround.DrawBackground();
                StatusStop = false;
                StatusGame = false;
                ExitToolStripMenuItem.Text = "Выход";
                PauseToolStripMenuItem.Visible = false;
                StartToolStripMenuItem.Text = "Начать";
            }
            else
            {
                BackGround.Timer.Dispose();
                BackGround.Buffer.Dispose();
                BackColor = Color.Aqua;
                StatusGame = false;
            }

        }

        private void PauseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
            if (StatusGame)
            {
                Game.Timer.Stop();
            }
            else
            {
                Game.Timer.Start();
            }

            StatusGame = !StatusGame;

            //StatusGame ? Game.timer.Stop() : Game.timer.Start();
        }

        private void SpaceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (StatusGame) Game.Ship.Move(e);
        }
    }
}
