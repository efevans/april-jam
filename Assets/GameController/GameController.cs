using UnityEngine;
using Zenject;

public class GameController : IInitializable, ITickable
{
    private GameState _gameState;
    private GameState DefaultGameState => new StartState(this);

    public Patron Patron;
    public SceneLocations SceneLocations;
    public ItemDisplay ItemDisplay;
    public OptionsMenu OptionsMenu;

    [Inject]
    public GameController(
        Patron patron,
        SceneLocations sceneLocations,
        ItemDisplay itemDisplay,
        OptionsMenu optionsMenu)
    {
        Patron = patron;
        SceneLocations = sceneLocations;
        ItemDisplay = itemDisplay;
        OptionsMenu = optionsMenu;
    }

    public void Initialize()
    {
        _gameState = DefaultGameState;
    }

    public void Tick()
    {
        _gameState.Update();
    }

    public void SetState(GameState gameState)
    {
        _gameState = gameState;
        _gameState.Start();
    }
}
