using BepInEx;

namespace FOAA
{
    [BepInPlugin("industry.foaa", "Fuck Off Another Axiom", "1.0.0")]
    internal class Plugin : BaseUnityPlugin
    {
        public void Start()
        {
            GorillaTagger.OnPlayerSpawned(OnGameInit);
        }

        public void OnGameInit()
        {

        }

        public void Update()
        {

        }
    }
}
