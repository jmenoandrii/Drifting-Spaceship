using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OutlineItem))]
[RequireComponent(typeof(Rigidbody))]
public class TakenItem : MonoBehaviour
{
    public UnityEvent OnItemTakedEvent;

    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private OutlineItem _outlineItem;

    [SerializeField]
    private string _nameItem;

    private UI _ui;

    public void Get(Transform inventory)
    {
        OnItemTakedEvent.Invoke();
        _ui.PlayAlertItem(_nameItem);

        _outlineItem.OnHoverExit();
        transform.SetParent(inventory);

        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;

        gameObject.SetActive(false);
    }

    public void Drop()
    {
        gameObject.SetActive(true);

        transform.SetParent(null);

        _rigidbody.AddForce(transform.forward * 2);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _outlineItem = GetComponent<OutlineItem>();

        _ui = FindObjectOfType<UI>();
    }
}
