using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private static TextManager _instance;
    private TMP_Text _display;
    private static readonly string[] DisplayMessages = {string.Empty, "I am a BANANA!", "I am not myself today", "I’m in Volume 3, its nice here!"};

    private void Awake()
    {
        ResolveDependencies();
        SetDisplayText();
    }

    private void ResolveDependencies()
    {
        _instance = this;
        _display = GetComponent<TMP_Text>();
    }

    public static void SetDisplayText(int index = 0)
    {
        _instance._display.text = DisplayMessages[index];
    }
}
