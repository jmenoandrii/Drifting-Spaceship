using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UI))]
public class Stats : MonoBehaviour
{
    [SerializeField]
    private float _battery;

    private float _maxBattery;

    private UI _ui;

    public float Battery { 
        get => _battery; 
        set { 
            _battery = value;
            _battery = Mathf.Clamp(_battery, 0, _maxBattery);
            _ui.SetBatteryCharge(_battery);
        }
    }

    public void AddBattery(float value)
    {
        Battery += value;
    }

    private void Start()
    {
        _ui = GetComponent<UI>();

        _maxBattery = _battery;
    }
}
