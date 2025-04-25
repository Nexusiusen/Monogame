using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace test
{
    public class FireBullet : Ability
{
    private Projectile _template;

    public FireBullet(Projectile bulletTemplate)
    {
        _template = bulletTemplate;
        WindupTime = 0f;
        PauseTime = 0.3f;
        Cooldown = 3f;
        Type = AbilityType.Tap;
    }

    public override void Activate(Champ champ, List<Sprite> sprites)
    {
        if (!CanActivate) return;

        var bullet = _template.Clone() as Projectile;

        var mouseState = Mouse.GetState();
        Vector2 mousePosition = new(mouseState.X, mouseState.Y);
        Vector2 direction = mousePosition - champ.Position;

        if (direction != Vector2.Zero)
            direction.Normalize();
        else
            direction = champ.Direction;

        bullet.Direction = direction;
        bullet.Position = champ.Position;
        bullet.LinearVelocity = 12f;
        bullet.MaxRange = 400f;
        bullet.Parent = champ;
        bullet.SetStartPosition(champ.Position);

        sprites.Add(bullet);

        StartCooldown();
        champ.PauseCasting(PauseTime);
    }
}

}
