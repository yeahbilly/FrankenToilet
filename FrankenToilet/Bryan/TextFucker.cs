namespace FrankenToilet.Bryan;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> fucks your text </summary>
public class TextFucker : MonoBehaviour
{
    /// <summary> Text component on this gameObject. </summary>
    public TextMeshProUGUI Text;

    /// <summary> Legacy text component on this gameObject. </summary>
    public Text Legacy;

    /// <summary> Grab text. </summary>
    public void Awake()
    {
        enabled = Femboy.fuckText;
        if (!Femboy.fuckText)
            return;

        Text = GetComponent<TextMeshProUGUI>();
        Legacy = GetComponent<Text>();
    }

    /// <summary> fuck le text >:3 </summary>
    public void LateUpdate()
    {
        Color col = Color.HSVToRGB(Mathf.LerpUnclamped(0f, 0.2f, Time.realtimeSinceStartup % 5), 1f, 1f);

        Text?.color = col;
        Legacy?.color = col;
    }
}
