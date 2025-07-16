using System.IO;
using UnityEngine;


[System.Serializable]
public class DirectionSpriteTable
{
    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;
    public Sprite Spacebar;

    public Sprite GetSprite(Direction dir)
    {
        return dir switch
        {
            Direction.Up => Up,
            Direction.Down => Down,
            Direction.Left => Left,
            Direction.Right => Right,
            Direction.Spacebar => Spacebar,
            _ => null
        };
    }

   
}
