using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class Controller : IController
    {
        public Vector2 _targetPosition;
        private bool _isMoving;
        private KeyboardState _currentKey;
        private KeyboardState _previousKey;
        public bool SpacingAbility = false;
        public bool EffectAbility = false;
        public bool MobilityAbility = false;
        public bool UltimateAbility = false;


        public void Update(GameTime gameTime, Champ sprite)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            var mouse = Mouse.GetState();
            var keyboard = Keyboard.GetState();

            if (mouse.RightButton == ButtonState.Pressed)
            {
                _targetPosition = new Vector2(mouse.X, mouse.Y);
                _isMoving = true;
                
            }

            if (keyboard.IsKeyDown(Keys.S) && _isMoving)
            {
                _targetPosition = sprite.Position;
                _isMoving = false;
                
            }

            if (_isMoving)
            {
                Vector2 direction = _targetPosition - sprite.Position;
                float distance = direction.Length();

                if (distance < 1f)
                {
                    sprite.Position = _targetPosition;
                    _isMoving = false;
                    
                }
                else
                {
                    direction.Normalize();
                    sprite.Position += direction * sprite.Speed * deltaTime;

                    if (( _targetPosition - sprite.Position).LengthSquared() > distance * distance)
                    {
                        sprite.Position = _targetPosition;
                        _isMoving = false;
                    }
                }
            }
            // Trigger on q press only (not hold)
            if (_currentKey.IsKeyDown(Keys.Q) && _previousKey.IsKeyUp(Keys.Q))
            {
                SpacingAbility = true;
            }

            if (_currentKey.IsKeyDown(Keys.W) && _previousKey.IsKeyUp(Keys.W))
            {
                EffectAbility = true;
            }

            if (_currentKey.IsKeyDown(Keys.E) && _previousKey.IsKeyUp(Keys.E))
            {
                MobilityAbility = true;
            }

            if (_currentKey.IsKeyDown(Keys.R) && _previousKey.IsKeyUp(Keys.R))
            {
                UltimateAbility = true;
            }
        }
    }
}