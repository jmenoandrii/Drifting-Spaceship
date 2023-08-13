using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Door : MonoBehaviour
{
    [SerializeField]
    private TakenItem _neededItem;
    [SerializeField]
    private string _alertText;

    private UI _ui;
    private OutlineItem _outline;
    private Collider _collider;
    private AudioSource _audioSource;
    private Animation _animation;
    private bool _opened = false;

    public bool TryOpenDoor(TakenItem item)
    {
        if (!_opened)
        {
            if (_neededItem != null)
            {
                if (_neededItem == item)
                {
                    Open();
                    return true;
                }
            }
            else
            {
                Open();
                return true;
            }

            _ui.PlayAlertDoor(_alertText);
        }


        return false;
    }

    private void Open()
    {
        _animation.Play();
        _audioSource.Play();
        _opened = true;
        _outline.OnHoverExit();
        Destroy(_outline);
        Destroy(_collider);
    }

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _outline = GetComponent<OutlineItem>();
        _collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();

        _ui = FindObjectOfType<UI>();
    }
}
