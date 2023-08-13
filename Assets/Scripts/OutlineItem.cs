using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlineItem : MonoBehaviour
{
    [SerializeField]
    private Outline _outline;

    public void OnHoverEnter()
    {
        _outline.enabled = true;
    }

    public void OnHoverExit()
    {
        _outline.enabled = false;
    }

    private void Awake()
    {
        _outline = GetComponent<Outline>();

        _outline.enabled = false;
    }
}
