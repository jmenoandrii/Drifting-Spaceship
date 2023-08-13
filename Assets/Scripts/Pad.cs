using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OutlineItem))]
public class Pad : MonoBehaviour
{
    [SerializeField]
    private UI _ui;
    [SerializeField]
    private string _text;
    [SerializeField]
    private UnityEvent OnPadStartReadEvent;

    public string Text { get => _text; set => _text = value; }

    public void StartRead()
    {
        _ui.ShowPadMenu(this);
        OnPadStartReadEvent.Invoke();
    }

    private void Awake()
    {
        if (_ui == null)
            _ui = FindObjectOfType<UI>();
    }
}
