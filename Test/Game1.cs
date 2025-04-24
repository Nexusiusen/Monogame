using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace test;

public class Game1 : Game
{
    private Sprite _sprite1;
    private Sprite _sprite2;

    private Sprite ballSprite;

    Texture2D ballTexture;
    Vector2 ballPosition;
    Vector2 targetPosition;

    bool isMoving;
    float ballSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

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
        ballSpeed = 10f; 
        
        ControlFlowBuilder 

        ballSprite.Position = ballPosition;
        ballSprite.Speed = ballSpeed;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _sprite1 = new Sprite(Content.Load<Texture2D>("ball"));
        _sprite1.Position = new Vector2(100, 100);
        _sprite2 = new Sprite(Content.Load<Texture2D>("ball")){
            Position = new Vector2(200, 200),
            Speed = 5f

        };

        // TODO: use this.Content to load your game content here
        ballTexture = Content.Load<Texture2D>("ball");
        ballSprite = new Sprite(Content.Load<Texture2D>("ball"));
        
        // Load the ball texture
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        ballSprite.Update(gameTime);
        
        

        //the time since update was called last
        float updateBallSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        var kstate = Keyboard.GetState();

        var mstate = Mouse.GetState();
        if (mstate.RightButton == ButtonState.Pressed)
        {
            targetPosition = new Vector2(mstate.X, mstate.Y);
            isMoving = true;
        }

        if (isMoving)
{
    Vector2 direction = targetPosition - ballPosition;
    float distance = direction.Length();

    if (distance < 1f)
    {
        // Close enough to stop
        isMoving = false;
        ballPosition = targetPosition;
    }
    else
    {
        direction.Normalize();
        ballPosition += direction * ballSpeed * updateBallSpeed;

        // Clamp if overshooting
        if ((targetPosition - ballPosition).LengthSquared() > distance * distance)
        {
            ballPosition = targetPosition;
            isMoving = false;
        }
    }
}

        if (kstate.IsKeyDown(Keys.S))
        {
           
           if(isMoving)
           {
               targetPosition = ballPosition;
           }
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        ballSprite.Draw(_spriteBatch);
       // _spriteBatch.Draw(ballTexture, ballPosition, null, Color.White,0f,new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
