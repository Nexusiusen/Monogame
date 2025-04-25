using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test;

public class Game1 : Game
{
    private Unit _sprite1;
    private Unit _sprite2;
    private Unit ballSprite;
    private Texture2D ballTexture;
    private Vector2 ballPosition;
    private float ballSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<Sprite> _sprites;



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
        ballSpeed = 150f; 


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        

        // TODO: use this.Content to load your game content here
        ballTexture = Content.Load<Texture2D>("ball");

        ballSprite = new Unit(ballTexture,  new Controller())
        {
            Position = ballPosition,
            Speed = ballSpeed
        };

        _sprite1 = new Unit(Content.Load<Texture2D>("ball"),  new Controller())
        {
            Position = new Vector2(100, 100),
            Speed = 100f
        };

        _sprite2 = new Unit(Content.Load<Texture2D>("ball"),  new Controller())
        {
            Position = new Vector2(200, 200),
            Speed = 200f
        };
        
        // Load the ball texture

        var shipTexture = Content.Load<Texture2D>("ball");
        _sprites = new List<Sprite>()
        {
            new Champ(shipTexture, new Controller()){
                Position = new Vector2(100, 100),
            }
        };
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

        // Update each sprite
        /* _sprite1.Update(gameTime);
        _sprite2.Update(gameTime);
        ballSprite.Update(gameTime); */

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
        /* foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        } */


       // _spriteBatch.Draw(ballTexture, ballPosition, null, Color.White,0f,new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
