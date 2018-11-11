using System;
//using System.Data.SqlClient;
using System.Drawing;
using System.Media;

namespace SpaceForms
{
    public class Meteors : SpaceObjects//, ICollision
    {
        public static bool CanDrawImageMeteors { get; set; }

        //public Rectangle Rect => new Rectangle(Position, Size);

        //private static bool _babahStatus;
        private static Bitmap _babah = new Bitmap(Resource1.babah1); //как вставить гифку на месте взрыва астероида?
        private static Image _img;
        private static SoundPlayer babah = new SoundPlayer(Resource1.babah);

        public Meteors(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            try
            {
                _img = Resource1.meteors;
                //_babah = Resource1.babah1;
                //_img = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Img\meteors.png"));
                CanDrawImageMeteors = true;
            }
            catch
            {
                CanDrawImageMeteors = false;
            }
        }


        public override void Draw()
        {
            if (CanDrawImageMeteors)
            {
                Game.Buffer.Graphics.DrawImage(_img, Position);
            }
            else
            {
                Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
            }
        }

        //public bool Collision(ICollision o)
        //{
        //    return o.Rect.IntersectsWith(Rect);
        //}

        /// <summary>
        /// Обновляем координаты Мметеоров
        /// </summary>
        public override void Update()
        {
            var rnd = new Random();
            Position.X = Position.X - Direction.X;
            if (Bullets.PositionBullet.X <= Position.X + 25 && Bullets.PositionBullet.X >= Position.X - 3 &&
                Bullets.PositionBullet.Y <= Position.Y + 25 && Bullets.PositionBullet.Y >= Position.Y - 4)
            //if (Collision(Game.BulletsShort))
            {
                babah.Play();
                Bullets.Bullet = false;
                Position.X = Game.Width + Size.Width;
                Position.Y = rnd.Next(40, Game.Height - 10);
            }
            if (Position.X >= 0) return;
            Position.X = Game.Width + Size.Width;
            Position.Y = rnd.Next(40, Game.Height - 10);
        }
    }
}