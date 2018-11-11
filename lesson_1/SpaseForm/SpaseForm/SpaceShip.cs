using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace SpaceForms
{
    public class SpaceShip : SpaceObjects
    {
        public static bool CanDrawImageShip { get; set; }
        private static Image _imgShip;
        public static int SpeedShip;
        private static SoundPlayer shotSound = new SoundPlayer(Resource1.shot);

        public SpaceShip(Point pos, Point dir, Size size, int speedShip) : base(pos, dir, size)
        {
            SpeedShip = speedShip;
            try
            {
                _imgShip = Resource1.ship;
                CanDrawImageShip = true;
            }
            catch
            {
                CanDrawImageShip = false;
            }
        }

        public override void Draw()
        {
            if (CanDrawImageShip)
            {
                Game.Buffer.Graphics.DrawImage(_imgShip, Position);
            }
            else
            {
                Game.Buffer.Graphics.DrawRectangle(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
            }
        }

        /// <summary>
        /// Обновляем координаты корабля
        /// </summary>
        public override void Update()
        {
            Position.X = Position.X;
            if (Position.X >= 0 && Position.Y>=50 || Position.X < Game.Width - 40 && Position.Y <= Game.Height - 20 ) return;
            if (Position.X <= 0 || Position.X >= Game.Width - 40) Position.X = Position.X;
            if (Position.Y <= 50 || Position.Y <= Game.Height - 20) Position.Y = Position.Y;  
        }

        /// <summary>
        /// Описываем поведение корабля при нажатии клавиш
        /// </summary>
        /// <param name="keys">Нажатые клавиши</param>
        /// <returns>Возвращает новые координаты коробля  и пули при выстреле</returns>
        public Point Move (KeyEventArgs keys)
        {
            var key = keys.KeyCode;
            
            if (key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right || key == Keys.Space)
            {
                switch (key)
                {
                    case Keys.Right:
                        if (Position.X <= Game.Width - 78) Position.X = Position.X + SpeedShip;
                        break;
                    case Keys.Left:
                        if (Position.X >= 5) Position.X = Position.X - 3;
                        break;
                    case Keys.Up:
                        if (Position.Y >= 45) Position.Y = Position.Y - 3;
                        break;
                    case Keys.Down:
                        if (Position.Y <= Game.Height - 10) Position.Y = Position.Y + 3;
                        break;
                    case Keys.Space:
                    {
                        if (!Bullets.Bullet)
                        {
                            shotSound.Play();
                            shotSound.Dispose();
                            Game.BulletsShort = new Bullets(new Point(Position.X+65, Position.Y+7), new Point(Direction.X, 0), new Size(11, 3), SpeedShip);
                            Bullets.Bullet = true;
                        }
                    }
                    break;
                }
            }
            else
            {
                Position.X = Position.X;
                Position.Y = Position.Y;
            }

            return Position;
        }

    }
}