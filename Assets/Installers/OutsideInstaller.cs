using UnityEngine;
using Zenject;

public class OutsideInstaller : MonoInstaller
{
    public Message Message;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Message>()
            .FromInstance(Message);

        Container.BindInterfacesAndSelfTo<OutsideController>()
            .FromNew()
            .AsSingle()
            .Lazy();
    }
}