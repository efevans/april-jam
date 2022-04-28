using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public AudioSource AudioSource;
    public ItemDisplay ItemDisplay;
    public OptionsMenu OptionsMenu;
    public GoldDisplay GoldDisplay;
    public Patron Patron;
    public ShopKeeper ShopKeeper;
    public SceneLocations SceneLocations;
    public ItemDatabase ItemDatabase;
    public ScreenPrinter ScreenPrinter;
    public DailyTip DailyTip;
    public ResultsList ResultsList;

    public GameObject ResultLineItemPrefab;
    public Transform ResultsContent;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AudioSource>()
            .FromInstance(AudioSource);

        Container.BindInterfacesAndSelfTo<Patron>()
            .FromInstance(Patron);

        Container.BindInterfacesAndSelfTo<ShopKeeper>()
            .FromInstance(ShopKeeper);

        Container.BindInterfacesAndSelfTo<ItemDisplay>()
            .FromInstance(ItemDisplay);

        Container.BindInterfacesAndSelfTo<OptionsMenu>()
            .FromInstance(OptionsMenu);

        Container.BindInterfacesAndSelfTo<GoldDisplay>()
            .FromInstance(GoldDisplay);

        Container.BindInterfacesAndSelfTo<ItemDatabase>()
            .FromInstance(ItemDatabase);

        Container.BindInterfacesAndSelfTo<SceneLocations>()
            .FromInstance(SceneLocations);

        Container.BindInterfacesAndSelfTo<DailyTip>()
            .FromInstance(DailyTip);

        Container.BindInterfacesAndSelfTo<ResultsList>()
            .FromInstance(ResultsList);

        Container.BindFactory<ResultsList.Purchases.ProfitSummary, ResultLine, ResultLine.Factory>()
            .FromComponentInNewPrefab(ResultLineItemPrefab)
            .UnderTransform(ResultsContent);

        Container.BindInterfacesAndSelfTo<Market>()
            .FromNew()
            .AsSingle()
            .Lazy();

        Container.BindInterfacesAndSelfTo<GameController>()
            .FromNew()
            .AsSingle()
            .Lazy();
    }
}