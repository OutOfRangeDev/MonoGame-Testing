using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Test_Monogame.Scripts.Core.SceneManager;

namespace Test_Monogame.Scenes;

public class FirstScene(ContentManager content, SceneManager sceneManager) : IScene
{
    private readonly Random _random = new Random();
    
    private Texture2D _target;
    private Texture2D _crosshair;
    private SpriteFont _font;

    private int _score = 0;
    private MouseState _mouse;
    private bool _mouseReleased = true;

    private Vector2 _mousePosition;
    private Vector2 _targetPosition = new Vector2(200, 200);
    private int _targetRadius = 45;
    
    public void Load()
    {
        _target = content.Load<Texture2D>("target");
        _crosshair = content.Load<Texture2D>("crosshair");
        _font = content.Load<SpriteFont>("testFont");
    }
    
    public void Unload()
    {
        _target.Dispose();
        _crosshair.Dispose();
    }
    
    public void Update(GameTime gameTime)
    {
        _mouse = Mouse.GetState();
        _mousePosition = new Vector2(_mouse.X, _mouse.Y);
        
        if (_mouse.LeftButton == ButtonState.Pressed && _mouseReleased == true)
        {
            if(Vector2.Distance(_mousePosition, _targetPosition + new Vector2(_targetRadius, _targetRadius)) < _targetRadius)
            {
                Hit();
            }
            _mouseReleased = false;
        }
        
        if (_mouse.LeftButton == ButtonState.Released)
        {
            _mouseReleased = true;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_target, _targetPosition, Color.White);
        spriteBatch.Draw(_crosshair, new Vector2(_mouse.X - _crosshair.Width / 2, _mouse.Y - _crosshair.Height / 2), Color.White);
        spriteBatch.DrawString(_font, "Score: " + _score , new Vector2(0, 0), Color.White);
    }
    
    void Hit()
    {
        _score++;
        _targetPosition = new Vector2(_random.Next(0,500), _random.Next(0,300));
    }
}