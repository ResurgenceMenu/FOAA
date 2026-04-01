using System.Collections.Generic;
using BepInEx;
using GorillaNetworking;
using HarmonyLib;

namespace FOAA
{
    [BepInPlugin("industry.foaa", "Fuck Off Another Axiom", "1.0.0")]
    internal class Plugin : BaseUnityPlugin
    {
        private static Harmony instance;

        public void Start()
        {
            instance = new Harmony("industry.foaa");
            
            instance.PatchAll();
        }
    }

    public class Patches
    {
        [HarmonyPatch(typeof(Gorillanalytics))]
        public static class PatchGorillanalytics
        {
            [HarmonyPatch(nameof(Gorillanalytics.UploadGorillanalytics)), HarmonyPrefix]
            public static bool BlockGorillaAnalyticsTelemetry() => false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry))]
        public static class PatchGorillaTelemetry
        {
            [HarmonyPatch(nameof(GorillaTelemetry.PostShopEvent), typeof(VRRig), typeof(GTShopEventType),
                 typeof(CosmeticsController.CosmeticItem)), HarmonyPrefix]
            public static bool BlockShopEventTelemetry_V1() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostShopEvent), typeof(VRRig), typeof(GTShopEventType),
                 typeof(IList<CosmeticsController.CosmeticItem>)), HarmonyPrefix]
            public static bool BlockShopEventTelemetry_V2() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostBuilderKioskEvent), typeof(VRRig), typeof(GTShopEventType),
                 typeof(BuilderSetManager.BuilderSetStoreItem)), HarmonyPrefix]
            public static bool BlockBuilderKioskEventTelemetry_V1() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostBuilderKioskEvent), typeof(VRRig), typeof(GTShopEventType),
                 typeof(IList<BuilderSetManager.BuilderSetStoreItem>)), HarmonyPrefix]
            public static bool BlockBuilderKioskEventTelemetry_V2() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostKidEvent)), HarmonyPrefix]
            public static bool BlockKidEventTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.WamGameStart)), HarmonyPrefix]
            public static bool BlockWamGameStartTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.WamLevelEnd)), HarmonyPrefix]
            public static bool BlockWamLevelEndTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostCustomMapPerformance)), HarmonyPrefix]
            public static bool BlockCustomMapPerformanceTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostCustomMapTracking)), HarmonyPrefix]
            public static bool BlockCustomMapTrackingTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostCustomMapDownloadEvent)), HarmonyPrefix]
            public static bool BlockCustomMapDownloadEventTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorShiftStart), typeof(string), typeof(int), typeof(float),
                 typeof(bool), typeof(int), typeof(int), typeof(string)), HarmonyPrefix]
            public static bool BlockGhostReactorShiftStartTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorGameEnd), typeof(string), typeof(int), typeof(int),
                 typeof(int), typeof(int), typeof(int), typeof(int), typeof(int), typeof(List<string>), typeof(int),
                 typeof(bool), typeof(float), typeof(float), typeof(bool), typeof(ZoneClearReason), typeof(int),
                 typeof(int), typeof(Dictionary<string, int>), typeof(int), typeof(int)), HarmonyPrefix]
            public static bool BlockGhostReactorShiftEndTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostNotificationEvent)), HarmonyPrefix]
            public static bool BlockPostNotificationEventTelemetry() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.EnqueueTelemetryEvent))]
            public static bool BlockGorillaTelemetry_EnqueueTelemetryEvent() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.EnqueueTelemetryEventPlayFab))]
            public static bool BlockGorillaTelemetry_EnqueueTelemetryEventPlayFab() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorToolUpgrade)), HarmonyPrefix]
            public static bool Block_GhostReactorToolUpgrade() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorChaosSeedStart)), HarmonyPrefix]
            public static bool Block_GhostReactorChaosSeedStart() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorChaosJuiceCollected)), HarmonyPrefix]
            public static bool Block_GhostReactorChaosJuiceCollected() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorOverdrivePurchased)), HarmonyPrefix]
            public static bool Block_GhostReactorOverdrivePurchased() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorCreditsRefillPurchased)), HarmonyPrefix]
            public static bool Block_GhostReactorCreditsRefillPurchased() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorFloorStart)), HarmonyPrefix]
            public static bool Block_GhostReactorFloorStart() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorFloorComplete)), HarmonyPrefix]
            public static bool Block_GhostReactorFloorComplete() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorToolPurchased)), HarmonyPrefix]
            public static bool Block_GhostReactorToolPurchased() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorRankUp)), HarmonyPrefix]
            public static bool Block_GhostReactorRankUp() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorToolUnlock)), HarmonyPrefix]
            public static bool Block_GhostReactorToolUnlock() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.GhostReactorPodUpgradePurchased)), HarmonyPrefix]
            public static bool Block_GhostReactorPodUpgradePurchased() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.SuperInfectionEvent),
                 typeof(bool), typeof(float), typeof(float), typeof(float), typeof(float),
                 typeof(float), typeof(float),
                 typeof(Dictionary<SITechTreePageId, float>),
                 typeof(Dictionary<SITechTreePageId, float>),
                 typeof(float), typeof(float), typeof(float), typeof(float),
                 typeof(Dictionary<SITechTreePageId, int>),
                 typeof(Dictionary<SITechTreePageId, int>),
                 typeof(int), typeof(int), typeof(int), typeof(int),
                 typeof(Dictionary<SIResource.ResourceType, int>),
                 typeof(Dictionary<SIResource.ResourceType, int>),
                 typeof(int), typeof(int),
                 typeof(bool[][]),
                 typeof(int)
             ), HarmonyPrefix]
            public static bool Block_SuperInfectionEvent_Full() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.SuperInfectionEvent),
                 typeof(string), typeof(int), typeof(int),
                 typeof(float), typeof(float), typeof(float)
             ), HarmonyPrefix]
            public static bool Block_SuperInfectionEvent_Purchase() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.EnqueueZoneEvent)), HarmonyPrefix]
            public static bool Block_ZoneEvent() => false;

            [HarmonyPatch(nameof(GorillaTelemetry.PostGameModeEvent)), HarmonyPrefix]
            public static bool Block_GameModeEvent() => false;

            [HarmonyPatch("FetchItemArgs"), HarmonyPrefix]
            public static bool Block_FetchItemArgs() => false;

            [HarmonyPatch("BuilderItemsToStrings"), HarmonyPrefix]
            public static bool Block_BuilderItemsToStrings() => false;
        }
    }
}