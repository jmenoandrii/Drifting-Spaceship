using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFlashlight : Flashlight
{
    [SerializeField]
    private float _timerToTurnOff;
    [SerializeField]
    private float _delay;

    private bool _canTurnOn = true;

    public override void Switch()
    {
        if (!_light.activeSelf && _canTurnOn)
        {
            _switchFlashlight.Play();
            _light.SetActive(true);
            _canTurnOn = false;
            StartCoroutine(TimerToTurnOff());
        }
    }

    private void TurnOff()
    {
        _switchFlashlight.Play();
        _light.SetActive(false);
        StartCoroutine(Delay());
    }

    private IEnumerator TimerToTurnOff()
    {
        yield return new WaitForSeconds(_timerToTurnOff);
        TurnOff();
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);
        _canTurnOn = true;
    }
}
