using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UI))]
public class WallHack : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Enemy[] _enemies;
    [SerializeField]
    private float _raidus;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _delay;
    [SerializeField]
    private AudioSource _audio;

    private bool _canTurnOn = true;

    private UI _ui;

    private bool _passFrame;

    public void TurnOn()
    {
        if (_canTurnOn)
        {
            _audio.Play();
            _ui.SwitchWallHackIcon();
            foreach (var enemy in _enemies)
            {
                if ((enemy.transform.position - _player.position).sqrMagnitude < _raidus)
                {
                    enemy.ShowOutline();
                }
            }

            _canTurnOn = false;
            StartCoroutine(TimerToTurnOff());
        }
    }

    private void Update()
    {
        if (!_passFrame)
        {
            _passFrame = true;
            _ui.SetWallHackText(Vector3.Distance(_enemies[0].transform.position, _player.position));
        }
        else
        {
            _passFrame = false;
        }
    }

    private IEnumerator TimerToTurnOff()
    {
        yield return new WaitForSeconds(_timer);

        foreach (var enemy in _enemies)
        {
            enemy.HideOutline();
        }

        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_delay);

        _ui.SwitchWallHackIcon();
        _canTurnOn = true;
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>().transform;
        _enemies = FindObjectsOfType<Enemy>();

        _ui = GetComponent<UI>();
    }
}
