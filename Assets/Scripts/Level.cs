using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UI))]
public class Level : MonoBehaviour
{
    [SerializeField]
    private float _delayToDie;
    [SerializeField]
    private float _delayToWin;

    private Player _player;
    private UI _ui;

    private bool _lose = false;

    [SerializeField]
    private UnityEvent OnLastItemTakenAction;

    public void Die(Transform enemy)
    {
        _player.End(enemy);
        _ui.StartTransition();
        StartCoroutine(TimerToDie());
        _lose = true;
    }

    public void Win(Transform capsula)
    {
        _player.End(capsula);
        _ui.StartTransition();
        StartCoroutine(TimerToWin());
    }

    public void LastItem()
    {
        OnLastItemTakenAction.Invoke();
    }

    public void Restart()
    {
        if (_lose)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 

    private IEnumerator TimerToDie()
    {
        yield return new WaitForSeconds(_delayToDie);
        _ui.ShowLosePanel();
    }

    private IEnumerator TimerToWin()
    {
        yield return new WaitForSeconds(_delayToWin);
        _ui.ShowWinPanel();
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _ui = GetComponent<UI>();
    }
}
