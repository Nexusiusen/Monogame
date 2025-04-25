using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class Kyle : Champ
    {
        private Projectile _bulletTemplate;

        public Kyle(Texture2D texture, Controller controller, Projectile bulletTemplate)
            : base(texture, controller)
        {
            _bulletTemplate = bulletTemplate;

            _abilities.Add(new FireBullet(_bulletTemplate));
        }

        protected override void HandleInput(List<Sprite> sprites)
        {
            if (_controller.SpacingAbility)
            {
                _controller.SpacingAbility = false;
                _abilities[0].Activate(this, sprites);
            }
        }
    }
}