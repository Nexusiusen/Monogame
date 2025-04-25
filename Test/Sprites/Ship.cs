using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class Ship : Sprite
    {
        public Projectile _bullet;

        public Ship(Texture2D texture): base(texture)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey; 
            _currentKey = Keyboard.GetState();

            if(_currentKey.IsKeyDown(Keys.A))
            {
                _rotation -= MathHelper.ToRadians(RotaionVelocity);
            }    
            else if(_currentKey.IsKeyDown(Keys.D))
            {
                _rotation += MathHelper.ToRadians(RotaionVelocity);
            }

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            if(_currentKey.IsKeyDown(Keys.W))
            {
                Position += Direction * LinearVelocity;
            }
            else if(_currentKey.IsKeyDown(Keys.S))
            {
                Position -= Direction * LinearVelocity;
            }

            if(_currentKey.IsKeyDown(Keys.Space) && _previousKey.IsKeyUp(Keys.Space))
            {
                AddBullet(sprites);

            }
        }

        private void AddBullet(List<Sprite> sprites)
        {
            var bullet = _bullet.Clone() as Projectile;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            bullet.LinearVelocity = this.LinearVelocity * 2f;
            bullet.Parent = this;

            sprites.Add(bullet);
        }
    }
    }