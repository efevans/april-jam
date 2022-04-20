using System;
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
    public GoldDisplay GoldDisplay;
    public AudioSource AudioSource;
    public Settings MySettings;

    public int Gold { get; private set; } = 500;

    [Inject]
    public GameController(
        Patron patron,
        SceneLocations sceneLocations,
        ItemDisplay itemDisplay,
        OptionsMenu optionsMenu,
        GoldDisplay goldDisplay,
        AudioSource audioSource,
        Settings mySettings)
    {
        Patron = patron;
        SceneLocations = sceneLocations;
        ItemDisplay = itemDisplay;
        OptionsMenu = optionsMenu;
        GoldDisplay = goldDisplay;
        AudioSource = audioSource;
        MySettings = mySettings;
    }

    public void Initialize()
    {
        _gameState = DefaultGameState;
        GoldDisplay.SetGold(Gold);
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

    public void PurchaseItem(int price)
    {
        Gold -= price;
        GoldDisplay.SetGold(Gold);
        AudioSource.PlayOneShot(MySettings.OnBuy);
    }

    [Serializable]
    public class Settings
    {
        public AudioClip OnBuy;
    }
}
