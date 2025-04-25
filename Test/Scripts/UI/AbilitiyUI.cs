using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class AbilityUI
{
    public Texture2D Icon;
    public Vector2 Position;
    public Vector2 Size;
    public Ability BoundAbility;

    private SpriteFont _font;

    public AbilityUI(Texture2D icon, Vector2 position, Vector2 size, Ability ability, SpriteFont font)
    {
        Icon = icon;
        Position = position;
        Size = size;
        BoundAbility = ability;
        _font = font;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw icon
        spriteBatch.Draw(Icon, new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), Color.White);

        if (!BoundAbility.CanActivate)
        {
            float cooldownRatio = BoundAbility.RemainingCooldown / BoundAbility.Cooldown;

            // Dark overlay fill
            spriteBatch.Draw(Icon,
                new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)(Size.Y * cooldownRatio)),
                new Rectangle(0, 0, Icon.Width, (int)(Icon.Height * cooldownRatio)),
                Color.Black * 0.6f);

            // Text overlay (remaining time)
            string time = BoundAbility.RemainingCooldown.ToString("0.0");
            Vector2 textSize = _font.MeasureString(time);
            Vector2 textPosition = Position + (Size - textSize) / 2;

            spriteBatch.DrawString(_font, time, textPosition, Color.White);
        }
    }
}

}