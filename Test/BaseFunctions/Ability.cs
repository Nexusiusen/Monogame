using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace test
{
    public enum AbilityType
    {
        Tap,
        Hold
    }

    public abstract class Ability
    {
        public float WindupTime { get; protected set; }
        public float PauseTime { get; protected set; }
        public float Cooldown { get; protected set; }
        public AbilityType Type { get; protected set; }

        protected float _cooldownTimer = 0f;
        protected bool _isOnCooldown = false;

        public bool CanActivate => !_isOnCooldown;

        public float RemainingCooldown => _isOnCooldown ? (Cooldown - _cooldownTimer) : 0f;


        public abstract void Activate(Champ champ, List<Sprite> sprites);

        public virtual void Update(GameTime gameTime)
        {
            if (_isOnCooldown)
            {
                _cooldownTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_cooldownTimer >= Cooldown)
                {
                    _isOnCooldown = false;
                    _cooldownTimer = 0f;
                }
            }
        }

        protected void StartCooldown()
        {
            _isOnCooldown = true;
            _cooldownTimer = 0f;
        }
    }
}
