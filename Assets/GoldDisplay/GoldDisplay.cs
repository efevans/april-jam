using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _goldText;

    public void SetGold(int value)
    {
        _goldText.text = $"{value}G";
    }
}
