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
        public Timer CooldownTimer { get; private set; }
        public float WindupTime { get; protected set; }
        public float PauseTime { get; protected set; }
        public float Cooldown { get; protected set; }
        public AbilityType Type { get; protected set; }

        public bool CanActivate => CooldownTimer == null || !CooldownTimer.IsRunning;

        public float RemainingCooldown => CooldownTimer != null && CooldownTimer.IsRunning
            ? Cooldown - CooldownTimer.TimeElapsed
            : 0f;

        public abstract void Activate(Champ champ, List<Sprite> sprites);

        public virtual void Update(GameTime gameTime)
        {
            CooldownTimer?.Update(gameTime);
        }

        protected void StartCooldown()
        {
            CooldownTimer = new Timer(Cooldown, () =>
            {
                // Cooldown complete — nothing to do unless you want to signal something
                // e.g. Console.WriteLine("Cooldown finished!");
            });
        }
    }
}
