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
    public DailyTip DailyTip;
    public ResultsList ResultsList;


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
        Market market,
        DailyTip dailyTip,
        ResultsList resultsList)
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
        DailyTip = dailyTip;
        ResultsList = resultsList;
    }

    public void Initialize()
    {
        ShopKeeper.Initialize();
        SetState(DefaultGameState);
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

    public void PurchaseItem(Item item, int price)
    {
        ShopKeeper.SpendGold(price);
        ResultsList.LogPurchase(item, price, Market.GetDailyPriceForItem(item));
        AudioSource.PlayOneShot(MySettings.OnBuy);
    }

    [Serializable]
    public class Settings
    {
        public AudioClip OnBuy;
    }
}
