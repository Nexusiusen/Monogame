using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class Champ : Sprite
    {
        public Controller _controller;
        public float Speed;

        private Timer _castingPauseTimer;

        protected List<Ability> _abilities = new List<Ability>();
        public List<Ability> GetAbilities() => _abilities;

        public Stats BaseStats { get; set; } = new Stats();

        public Champ(Texture2D texture, Controller controller) : base(texture)
        {
            _controller = controller;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            foreach (var ability in _abilities)
                ability.Update(gameTime);

            _castingPauseTimer?.Update(gameTime);

            if (!IsCasting)
            {
                _controller.Update(gameTime, this);
                HandleInput(sprites);
            }

            Direction = Vector2.Normalize(_controller._targetPosition - Position);
        }

        protected virtual void HandleInput(List<Sprite> sprites)
        {
            // To be overridden by specific champs like Kyle
        }

        public void PauseCasting(float duration)
        {
            _castingPauseTimer = new Timer(duration, () =>
            {
                _castingPauseTimer = null;
            });
        }

        public bool IsCasting => _castingPauseTimer != null && _castingPauseTimer.IsRunning;
    }
}
