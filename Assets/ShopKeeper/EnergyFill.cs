using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyFill : MonoBehaviour
{
    public int CurrentAmount { get; private set; }

    [SerializeField]
    private Image _mainBar;
    [SerializeField]
    private Image _lagBar;

    private int _max;

    private readonly float LagDelay = 1f;
    private readonly float LagDuration = 0.3f;

    public void SetFillMax(int amount)
    {
        CurrentAmount = _max = amount;
        _mainBar.fillAmount = 100;
        _lagBar.fillAmount = 100;
    }

    public void Deduct(int amount)
    {
        StartCoroutine(IterateDeduction(amount));
    }

    private IEnumerator IterateDeduction(int amount)
    {
        CurrentAmount -= amount;
        float newFill = ScreenPrinter.Debug("Energy", (float)CurrentAmount / _max);

        _mainBar.fillAmount = newFill;

        // Wait a second, then interpolate the lag bar to the fill amount over half a second
        yield return new WaitForSeconds(LagDelay);

        float startingLagFill = _lagBar.fillAmount;
        for (float elapsed = 0; elapsed < LagDuration; elapsed += Time.deltaTime)
        {
            float newLagFill = startingLagFill - (elapsed / LagDuration * ((float)amount / _max));
            _lagBar.fillAmount = newLagFill;

            yield return null;
        }

        // In case we went a little over on the final iteration, set proper lag fill once more
        _lagBar.fillAmount = _mainBar.fillAmount;
    }
}
