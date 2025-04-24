using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace test
{
    public class Sprite
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; } = 100f;
        private Texture2D _texture;
        private IController _controller;

        public Sprite(Texture2D texture, IController controller = null)
        {
            _texture = texture;
            _controller = controller;
        }

        public void Update(GameTime gameTime)
        {
            _controller?.Update(gameTime, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0f,
                new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}