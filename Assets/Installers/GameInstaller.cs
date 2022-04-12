using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public AudioSource AudioSource;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AudioSource>()
            .FromInstance(AudioSource);
    }
}