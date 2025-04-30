using Microsoft.Xna.Framework;
using System;

public class Timer
{
    private float _duration;
    private float _timeRemaining;
    private bool _isRunning;
    private Action _onComplete;
    public float TimeElapsed => _duration - _timeRemaining;

    public Timer(float duration, Action onComplete)
    {
        _duration = duration;
        _timeRemaining = duration;
        _onComplete = onComplete;
        _isRunning = true;
    }

    public void Update(GameTime gameTime)
    {
        if (!_isRunning) return;

        _timeRemaining -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (_timeRemaining <= 0f)
        {
            _isRunning = false;
            _onComplete?.Invoke();
        }
    }

    public bool IsRunning => _isRunning;
}
