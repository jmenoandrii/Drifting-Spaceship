using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeboat : MonoBehaviour
{
    [SerializeField]
    private List<TakenItem> _neededItems;
    [SerializeField]
    private bool canFly;
    [SerializeField]
    private AudioSource _capsula;
    [SerializeField]
    private AudioSource _capsulaError;

    private Level _level;

    public bool TryAddItems(TakenItem item)
    {
        foreach (var neededItem in _neededItems)
        {
            if (neededItem == item)
            {
                _capsula.Play();
                _neededItems.Remove(item);
                CheckIfCanEnd();
                return true;
            }
        }
        _capsulaError.Play();
        return false;
    }

    private void CheckIfCanEnd()
    {
        if (_neededItems.Count <= 0)
        {
            canFly = true;
            _level.Win(transform);
        }
        else if (_neededItems.Count == 1)
        {
            _neededItems[0].OnItemTakedEvent.AddListener(_level.LastItem);
        }
    }

    private void Awake()
    {
        _level = FindObjectOfType<Level>();
        _capsula = GetComponent<AudioSource>();
    }
}
