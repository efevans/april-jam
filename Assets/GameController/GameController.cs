using System;
using UnityEngine;
using Zenject;

public class GameController : IInitializable, ITickable
{
    private GameState _gameState;
    private GameState DefaultGameState => new DayStartState(this);

    public Market Market { get; private set; }
    public ShopKeeper ShopKeeper { get; private set; }
    public Patron Patron;
    public SceneLocations SceneLocations;
    public ItemDisplay ItemDisplay;
    public OptionsMenu OptionsMenu;
    public GoldDisplay GoldDisplay;
    public AudioSource AudioSource;
    public ItemDatabase ItemDatabase;
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
        Settings mySettings,
        ItemDatabase itemDatabase,
        ShopKeeper shopKeeper,
        Market market)
    {
        Patron = patron;
        SceneLocations = sceneLocations;
        ItemDisplay = itemDisplay;
        OptionsMenu = optionsMenu;
        GoldDisplay = goldDisplay;
        AudioSource = audioSource;
        MySettings = mySettings;
        ItemDatabase = itemDatabase;
        ShopKeeper = shopKeeper;
        Market = market;
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
