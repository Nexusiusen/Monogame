using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class Sprite : ICloneable
    {
        protected Texture2D _texture;
        
        protected float _scale=1f;
        protected float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public Vector2 Position;
        public Vector2 Origin;

        public Vector2 Direction;
        public float RotaionVelocity=3f;
        public float LinearVelocity=4f;

        public Sprite Parent;
        
        public bool IsRemoved = false;

        public Sprite(Texture2D texture, float scale){
            _texture = texture;
            _scale = scale;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites){

        }

        public virtual void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation,Origin, _scale, SpriteEffects.None, 0f);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}