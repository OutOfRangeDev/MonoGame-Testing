using System.Collections.Generic;
namespace Test_Monogame.Scripts.Core.SceneManager;

public class SceneManager
{
    private readonly Stack<IScene> _sceneStack = new();

    public void LoadScene(IScene scene)
    {
        _sceneStack.Push(scene);
        scene.Load();
    }

    public void UnloadScene()
    {
        _sceneStack.Pop().Unload();
    }
    
    public IScene GetCurrentScene()
    {
        return _sceneStack.Peek();
    }
}