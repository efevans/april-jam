using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ScreenPrinter : MonoBehaviour
{
    private static ScreenPrinter instance;

    public static T Debug<T>(string key, T value)
    {
        instance.Upsert(key, value);
        return value;
    }

    [SerializeField]
    private bool isEnabled;

    [SerializeField]
    private TextMeshProUGUI debugTextEle;

    [SerializeField]
    private Canvas canvas;

    private readonly Dictionary<string, object> messages = new Dictionary<string, object>();

    private bool needsRefresh;

    private void Awake()
    {
        instance = this;
        canvas.enabled = isEnabled;
    }

    private void OnValidate()
    {
        canvas.enabled = isEnabled;
    }

    private void Update()
    {
        if (!isEnabled)
        {
            return;
        }

        if (needsRefresh)
        {
            RefreshText();
            needsRefresh = false;
        }
    }

    private void RefreshText()
    {
        var builder = new StringBuilder();

        foreach (KeyValuePair<string, object> kvp in messages)
        {
            builder.Append(kvp.Key);
            builder.Append(" = ");
            builder.AppendLine(kvp.Value.ToString());
        }

        debugTextEle.text = builder.ToString();
    }

    private void Upsert(string key, object value)
    {
        messages[key] = value;
        needsRefresh = true;
    }
}
