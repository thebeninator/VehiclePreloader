using GHPC.Mission;
using MelonLoader;
using UnityEngine;
using VehiclePreloader;

[assembly: MelonInfo(typeof(Mod), "Vehicle Preloader", "1.0.0", "ATLAS")]
[assembly: MelonPriority(-1)]
[assembly: MelonGame("Radian Simulations LLC", "GHPC")]

namespace VehiclePreloader
{
    public class Mod : MelonMod
    {
        internal static bool done = false;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (done || (sceneName != "MainMenu2_Scene" && sceneName != "MainMenu2-1_Scene" && sceneName != "t64_menu")) return;

            UnitPrefabLookupScriptable lookup = Resources.FindObjectsOfTypeAll<UnitPrefabLookupScriptable>()[0];
            UnitPrefabLookupScriptable.UnitPrefabMetadata[] all_units = lookup.AllUnits;

            foreach (var unit in all_units)
            {
                unit.PrefabReference.LoadAssetAsync<GameObject>().WaitForCompletion();
            }

            done = true;
        }
    }
}
