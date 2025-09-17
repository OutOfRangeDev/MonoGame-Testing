using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test_Monogame;

public class Game1 : Game
{
    Random random = new Random();
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Texture2D target;
    private Texture2D crosshair;
    private SpriteFont font;
    
    int score = 0;
    MouseState mouse;
    bool mouseReleased = true;
    
    Vector2 mousePosition;
    Vector2 targetPosition = new Vector2(200, 200);
    int targetRadius = 45;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        target = Content.Load<Texture2D>("target");
        crosshair = Content.Load<Texture2D>("crosshair");
        font = Content.Load<SpriteFont>("testFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        mouse = Mouse.GetState();
        mousePosition = new Vector2(mouse.X, mouse.Y);
        
        if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
        {
            if(Vector2.Distance(mousePosition, targetPosition + new Vector2(targetRadius, targetRadius)) < targetRadius)
            {
                Hit();
            }
            mouseReleased = false;
        }
        
        if (mouse.LeftButton == ButtonState.Released)
        {
            mouseReleased = true;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(target, targetPosition, Color.White);
        _spriteBatch.Draw(crosshair, new Vector2(mouse.X - crosshair.Width / 2, mouse.Y - crosshair.Height / 2), Color.White);
        _spriteBatch.DrawString(font, "Score: " + score , new Vector2(0, 0), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
    
    void Hit()
    {
        score++;
        targetPosition = new Vector2(random.Next(0,500), random.Next(0,300));
    }
}