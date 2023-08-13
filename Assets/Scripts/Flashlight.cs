using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Flashlight : MonoBehaviour
{
    [SerializeField]
    protected GameObject _light;

    protected AudioSource _switchFlashlight;

    protected Stats _stats;

    public virtual void Switch()
    {
        _switchFlashlight.Play();
        if (_stats.Battery > 5)
            _light.SetActive(!_light.activeSelf);
        else
            _light.SetActive(false);
    }

    public bool IsFlashlightTurnedOn()
    {
        return _light.activeSelf;
    }

    private void Update()
    {
        if (IsFlashlightTurnedOn())
            _stats.Battery -= 0.8f * Time.deltaTime;
        else
            _stats.Battery += 0.5f * Time.deltaTime;

        if (_stats.Battery <= 0)
            Switch();
    }

    private void Start()
    {
        _switchFlashlight = GetComponent<AudioSource>();

        _stats = FindObjectOfType<Stats>();
    }
}
