using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class Kyle : Champ
    {
        private Projectile _bulletTemplate;

        private Texture2D _bulletTexture;

        public Kyle(Texture2D texture, Controller controller)
            : base(texture, controller)
        {
            _bulletTexture = texture; // Assuming the bullet uses the same texture as the champ for simplicity
            _bulletTemplate = new Projectile(_bulletTexture);

            _abilities.Add(new FireBullet(_bulletTemplate));

            BaseStats = new Stats
        {
            AttackDamage = 80f,
            AttackSpeed = 1.2f,
            MaxHP = 150f,
            CurrentHP = 150f,
            MovementSpeed = 120f,
            Armor = 10f
        };

            
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