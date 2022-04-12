using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public OptionsMenu.Settings OptionsMenuSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(OptionsMenuSettings);
    }
}
