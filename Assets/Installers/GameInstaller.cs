using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public AudioSource AudioSource;

    public ItemDisplay ItemDisplay;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AudioSource>()
            .FromInstance(AudioSource);

        Container.BindInterfacesAndSelfTo<ItemDisplay>()
            .FromInstance(ItemDisplay);
    }
}