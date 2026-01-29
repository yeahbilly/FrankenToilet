using System.Diagnostics;
using HarmonyLib;

using FrankenToilet.Core;

namespace FrankenToilet.greycsont;

[PatchOnEntry]
[HarmonyPatch(typeof(TimeController))]
public class TimeControllerPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(TimeController.TrueStop))]
    public static void CheckCallerName(ref float length, TimeController __instance)
    {
        StackTrace stackTrace = new StackTrace(false);
        if (stackTrace.FrameCount < 3) return;

        var method = stackTrace.GetFrame(2).GetMethod();
        var type = method.DeclaringType;
        
        if (type != null && type.Name.Contains("<ImpactRoutine>d__") && type.DeclaringType == typeof(ShotgunHammer)) 
            ArrowController.GenerateImage(length);
    }
}