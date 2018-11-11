using System.Drawing;

namespace SpaceForms
{
    /// <summary>
    /// проверка на пересечение
    /// </summary>
    public interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}