using System;
using System.Drawing;

namespace SpaceForms
{
    public class SpaceObjects
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;


        public SpaceObjects (Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        public virtual void Draw()
        {
            BackGround.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
        {
            var random = new Random();
            Position.X += Direction.X + random.Next(-2, 2);
            Position.Y += Direction.Y + random.Next(-2, 2);
            if (Position.X < 0 || Position.X > BackGround.Width - Size.Width)
            {
                Direction.X = -Direction.X;
            }
            if (Position.Y < 0 || Position.Y > BackGround.Height - Size.Height)
            {
                Direction.Y = -Direction.Y;
            }
        }
    }
}