using BepInEx;
using GorillaNetworking;
using HarmonyLib;
using PlayFab;
using PlayFab.ClientModels;
using System.Linq;
using System.Reflection;

namespace FOAA;
[HarmonyPatch, BepInPlugin("skellon.industry.foaa", "1OAA", "1.0")]
public sealed class Plugin : BaseUnityPlugin
{
    private Plugin() => Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
    [HarmonyPatch(typeof(GorillaServer), nameof(GorillaServer.UploadGorillanalytics)), HarmonyPrefix]
    static bool AnalyticsPath() => false;
    [HarmonyPatch(typeof(GorillaServer), nameof(GorillaServer.CheckIsMothershipTelemetryEnabled)), HarmonyPostfix]
    static void Telemetry(ref bool __result) => __result = false;
    [HarmonyPatch(typeof(PlayFabClientAPI), nameof(PlayFabClientAPI.UpdateUserTitleDisplayName)), HarmonyPrefix]
    static void Name(ref UpdateUserTitleDisplayNameRequest request) => request.DisplayName = UnityEngine.Random.Range(37645, 82476).ToString();
    [HarmonyPatch(typeof(PlayFabClientAPI), nameof(PlayFabClientAPI.ReportDeviceInfo)), HarmonyPrefix]
    static void DeviceInfo(ref DeviceInfoRequest request) => request.Info.Clear();
}
