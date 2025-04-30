using Microsoft.Xna.Framework;

namespace test
{
    public interface IController
    {
        void Update(GameTime gameTime, Champ sprite);
    }
}