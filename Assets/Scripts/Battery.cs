using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField]
    private float _charge;

    private Stats _stats;

    public void Get()
    {
        _stats.Battery += _charge;
        Destroy(gameObject);
    }

    private void Awake()
    {
        _stats = FindObjectOfType<Stats>();
    }
}
