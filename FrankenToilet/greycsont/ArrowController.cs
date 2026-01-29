using UnityEngine;
using UnityEngine.UI;

using FrankenToilet.Core;

namespace FrankenToilet.greycsont;

[EntryPoint]
public static class ArrowController
{
    const string noteSkinPath = "FrankenToilet.greycsont.noteskinstealfrometterna.bundle";
    
    public static AssetBundle assetBundle;

    public static Sprite[] arrowSprites;
    
    [EntryPoint]
    public static void Initialize()
    {
        assetBundle = AssetBundleHelper.LoadAssetBundle(noteSkinPath);
        arrowSprites = assetBundle.LoadAssetWithSubAssets<Sprite>("arrow");
    }

    public static void GenerateImage(float timeInSeconds)
    {
        LogHelper.LogDebug($"[greycsont] truestop time: {timeInSeconds}");
        
        var hammer = HammerTracker.lastActiveHammer;
        if (hammer == null) return;
        if (hammer.target == null) return;
        if (hammer.hitEnemy == null) return;

        var canvas = UnityPathHelper.FindCanvas();
        
        if (canvas == null) return;
        
        var imgObj = new GameObject("HammerArrowIndicator");
        
        imgObj.transform.SetParent(canvas.transform, false);
        
        imgObj.transform.SetAsLastSibling();
        
        var img = imgObj.AddComponent<Image>();
        img.sprite = arrowSprites[Random.Range(0, arrowSprites.Length)];
        img.SetNativeSize();
        imgObj.AddComponent<DestoryTimer>().lifetime = timeInSeconds;
        
        var color = img.color;
        color.a = 0.2f;
        img.color = color;
        
        var rect = imgObj.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        
        rect.localEulerAngles = new Vector3(0, 0, -90f * DirectionRandomizer.randomDirection);
        
        rect.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        
        LogHelper.LogDebug($"[greycsont] created {img.name}");

    }
}


public static class UnityPathHelper
{
    public static Canvas FindCanvas()
    {
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        foreach (var root in scene.GetRootGameObjects())
        {
            var canvas = root.GetComponent<Canvas>();
            if (canvas != null)
                return canvas;
        }
        return null;
    }
}

public class DestoryTimer : MonoBehaviour
{
    public float lifetime;
    private float timer = 0f;

    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}