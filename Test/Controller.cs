using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class BallMouseMovementController : IController
    {
        private Vector2 _targetPosition;
        private bool _isMoving;

        public void Update(GameTime gameTime, Sprite sprite)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

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
        }
    }
}