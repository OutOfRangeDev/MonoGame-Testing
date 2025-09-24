using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test_Monogame.Scripts.Core.SceneManager;

public interface IScene
{
    public void Load();
    public void Unload();
    public void Update(GameTime gameTime);
    public void Draw(SpriteBatch spriteBatch);
}