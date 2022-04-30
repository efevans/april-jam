using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class ShopSettingsInstaller : ScriptableObjectInstaller<ShopSettingsInstaller>
{
    public OptionsMenu.Settings OptionsMenuSettings;
    public ItemDisplay.Settings ItemDisplaySettings;
    public ResultsList.Settings ResultsListSettings;
    public ShopController.Settings GameControllerSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(OptionsMenuSettings);
        Container.BindInstance(ItemDisplaySettings);
        Container.BindInstance(ResultsListSettings);
        Container.BindInstance(GameControllerSettings);
    }
}
