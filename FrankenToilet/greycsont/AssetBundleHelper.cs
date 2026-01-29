using UnityEngine;
using System.Reflection;

using FrankenToilet.Core;


namespace FrankenToilet.greycsont;


public static class AssetBundleHelper
{
    public static AssetBundle LoadAssetBundle(string assetBundlePath)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(assetBundlePath);
        if (stream == null)
        {
            LogHelper.LogError($"[greycsont] FUCK YOU UNITY");
        }
        
        LogHelper.LogInfo($"[greycsont] Loaded AssetBundle: {assetBundlePath}");
        
        return AssetBundle.LoadFromStream(stream);;
    }

}