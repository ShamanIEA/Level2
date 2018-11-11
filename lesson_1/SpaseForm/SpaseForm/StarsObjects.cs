using System;
using System.Drawing;

namespace SpaceForms
{
    public class StarsObjects : SpaceObjects
    {
        public static bool CanDrawImage { get; set; }
        private static Image _img;

        public StarsObjects(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            try
            {
                _img = Resource1.star;
                //_img = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Img\star.png"));
                CanDrawImage = true;
            }
            catch
            {
                CanDrawImage = false;
            }
        }

        public override void Draw()
        {
            if (CanDrawImage)
            {
                Game.Buffer.Graphics.DrawImage(_img, Position);
            }
            else
            {
                Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
            }
        }

        public void DrawSmallStars()
        {
                Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            var rnd = new Random();
            Position.X = Position.X - Direction.X;
            if (Position.X >= 0) return;
            Position.X = Game.Width + Size.Width;
            Position.Y = rnd.Next(40, Game.Height - 10);
        }
    }
}