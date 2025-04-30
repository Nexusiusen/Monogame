using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace test
{
    public class FireBullet : Ability
    {
        private Projectile _template;
        private Timer _windupTimer;

        public FireBullet(Projectile bulletTemplate)
        {
            _template = bulletTemplate;
            WindupTime = 0.1f;  // Time to wait before firing the projectile
            PauseTime = 0.4f;   // Pause after firing
            Cooldown = 3f;      // Cooldown before this ability can be used again
            Type = AbilityType.Tap;
        }

        public override void Activate(Champ champ, List<Sprite> sprites)
        {
            if (!CanActivate) return;  // Check if ability can be activated (not on cooldown)

            // Pause the champ's casting animation
            champ.PauseCasting(WindupTime);

            // Create and start the windup timer
            _windupTimer = new Timer(WindupTime, () =>
            {
                FireProjectile(champ, sprites);  // Fire the projectile after windup time
                StartCooldown();                 // Start cooldown after firing the projectile
                champ.PauseCasting(PauseTime);   // Pause the champ's casting for a short time

                // Clean up references to avoid holding onto unnecessary memory
                _windupTimer = null;
            });
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _windupTimer?.Update(gameTime);  // Update the windup timer if it's active
        }

        private void FireProjectile(Champ champ, List<Sprite> sprites)
        {
            // Clone the projectile template to create a new instance
            var bullet = _template.Clone() as Projectile;

            // Get mouse position to determine firing direction
            var mouseState = Mouse.GetState();
            Vector2 mousePosition = new(mouseState.X, mouseState.Y);
            Vector2 direction = mousePosition - champ.Position;

            // Normalize direction to avoid issues with zero-length vectors
            if (direction != Vector2.Zero)
                direction.Normalize();
            else
                direction = champ.Direction;  // Fallback to the champ's facing direction

            // Set properties of the bullet
            bullet.Direction = direction;
            bullet.Position = champ.Position;
            bullet.LinearVelocity = 12f;    // Set the bullet's speed
            bullet.MaxRange = 400f;         // Set the maximum range of the bullet
            bullet.Parent = champ;          // Set the champ as the parent of the bullet
            bullet.SetStartPosition(champ.Position); // Set the bullet's start position

            // Add the bullet to the list of sprites (or projectiles) in the game
            sprites.Add(bullet);
        }
    }
}
