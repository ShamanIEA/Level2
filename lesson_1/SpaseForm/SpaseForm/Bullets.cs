using System;
using System.Drawing;

namespace SpaceForms
{
    public class Bullets : SpaceShip//, ICollision
    {
        public static bool Bullet;
        public static Point PositionBullet;
        public static Size SizeBullet;

        public Bullets(Point pos, Point dir, Size size, int speedShip) : base(pos, dir, size, speedShip)
        {
            SizeBullet = Size;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Yellow, Position.X, Position.Y, Size.Width, Size.Height);
        }

        //public Rectangle Rect => new Rectangle(Position, Size);
        //public bool Collision(ICollision o)
        //{
        //    return o.Rect.IntersectsWith(Rect);
        //}
        
        public override void Update()
        {
            Position.X = Position.X + SpeedShip * 2 + Game.Speed;
            PositionBullet = Position;
            if (Position.X >= Game.Width + 5)
            {
                Bullet = false;
            }
        }
    }
}