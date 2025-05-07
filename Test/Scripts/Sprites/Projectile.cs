using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace test{
    public class Projectile : Sprite
    {
        protected Vector2 _startPosition;
        public float MaxRange = 400f; // Set this to how far bullets should travel

        public Projectile(Texture2D texture, float scale) : base(texture, scale)
        {
        }

       public override void Update(GameTime gameTime, List<Sprite> sprites)
    {
        Position += Direction * LinearVelocity;

        float distanceTraveled = Vector2.Distance(Position, _startPosition);
        if (distanceTraveled >= MaxRange)
        {
            IsRemoved = true;
        }
    }
    public void SetStartPosition(Vector2 position)
    {
        _startPosition = position;
    }
        
    }
}