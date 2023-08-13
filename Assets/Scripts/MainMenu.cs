using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private PlayerControls _playerControls;
    private UI _ui;

    [SerializeField]
    private Animation _mainText;

    private bool _padShown;

    public void ShowMainPad()
    {
        if (!_padShown)
        {
            _mainText.Play("HideStartText");
            _ui.ShowPadMenu(new Pad());
            _padShown = true;
        }
    }

    public void StartGame()
    {
        _ui.StartTransition();
        StartCoroutine(TimerToStart());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator TimerToStart()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        _ui = GetComponent<UI>();

        _playerControls = new PlayerControls();
        _playerControls.Enable();

        _playerControls.Menu.SwitchPad.performed += ctx => ShowMainPad();
        _playerControls.Menu.Exit.performed += ctx => Quit();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
