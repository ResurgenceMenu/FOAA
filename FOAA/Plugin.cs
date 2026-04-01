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
        }
    }
}