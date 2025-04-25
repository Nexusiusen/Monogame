using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test;

public class Game1 : Game
{
    private Champ _player;
    private Texture2D ballTexture;
    private Vector2 ballPosition;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<Sprite> _sprites;

    private List<AbilityUI> _abilityUIs;
    private SpriteFont _uiFont; // Load this in LoadContent


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        var shipTexture = Content.Load<Texture2D>("ball");
        _player = new Kyle(shipTexture, new Controller())
        {
            Position = new Vector2(100, 100),
            Speed=150f,
        };

        _sprites = new List<Sprite> { _player };
        

        _uiFont = Content.Load<SpriteFont>("UIFont");
        Texture2D qIcon = Content.Load<Texture2D>("q");
        Texture2D wIcon = Content.Load<Texture2D>("w");
        // etc...
        
            // Assume _player is your Champ (like Kyle) instance
            InitAbilityUI(_player, qIcon, wIcon, _uiFont);

        // TODO: use this.Content to load your game content here
        ballTexture = Content.Load<Texture2D>("ball");
        
        // Load the ball texture
    }

    private void InitAbilityUI(Champ champ, Texture2D qIcon, Texture2D wIcon, SpriteFont font)
    {
        _abilityUIs = new List<AbilityUI>();

        var spacing = new Vector2(80, 0); // space between icons
        var startPos = new Vector2(30, GraphicsDevice.Viewport.Height - 100);
        var size = new Vector2(64, 64);

        var abilities = champ.GetAbilities(); // We’ll expose this below

        if (abilities.Count > 0)
            _abilityUIs.Add(new AbilityUI(qIcon, startPos + spacing * 0, size, abilities[0], font));
        if (abilities.Count > 1)
            _abilityUIs.Add(new AbilityUI(wIcon, startPos + spacing * 1, size, abilities[1], font));
        // etc for E, R
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        foreach (var sprite in _sprites.ToArray())
        {
            sprite.Update(gameTime, _sprites);
        }

        PostUpdate();

        base.Update(gameTime);
    }

    private void PostUpdate()
    {
        for (int i = 0; i < _sprites.Count; i++)
        {
            if (_sprites[i].IsRemoved)
            {
                _sprites.RemoveAt(i);
                i--;
            }
        }
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        }
        
        foreach (var ui in _abilityUIs)
        {
            ui.Draw(_spriteBatch);
        }
        


       // _spriteBatch.Draw(ballTexture, ballPosition, null, Color.White,0f,new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
