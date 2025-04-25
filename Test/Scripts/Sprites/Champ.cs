using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test
{
    public class Champ : Sprite
{
    public Controller _controller;

    public float Speed;

    private bool _isCasting = false;
    private float _pauseTimer = 0f;
    private float _pauseDuration = 0f;

     protected List<Ability> _abilities = new List<Ability>();

    public List<Ability> GetAbilities() => _abilities;

    public Stats BaseStats { get; set; } = new Stats();


    public Champ(Texture2D texture, Controller controller) : base(texture)
    {
        _controller = controller;
    }

    public override void Update(GameTime gameTime, List<Sprite> sprites)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        foreach (var ability in _abilities)
            ability.Update(gameTime);

        if (_isCasting)
        {
            _pauseTimer += deltaTime;
            if (_pauseTimer >= _pauseDuration)
            {
                _isCasting = false;
                _pauseTimer = 0f;
            }
        }

        if (!_isCasting)
        {
            _controller.Update(gameTime, this);
            HandleInput(sprites);
        }

        Direction = Vector2.Normalize(_controller._targetPosition - Position);
    }

    protected virtual void HandleInput(List<Sprite> sprites)
    {
        // To be overridden by derived champs like Kyle
    }

    public void PauseCasting(float duration)
    {
        _isCasting = true;
        _pauseDuration = duration;
        _pauseTimer = 0f;
    }
}

}