using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Animation _padMenu, _offPadMenu;
    [SerializeField]
    private TextMeshProUGUI _padText;
    [SerializeField]
    private AudioSource _padAudio;
    [SerializeField]
    private AnimationClip _showPadAnim, _hidePadAnim, _loadingPadAnim, _turnOffPadAnim; 

    private bool _padMenuShown = false;
    private bool _padMenuTurnedOff = false;
    private bool _padTextLoaded = true;

    [SerializeField]
    private TextMeshProUGUI _batteryText;

    [SerializeField]
    private Image _wallHackIcon;
    [SerializeField]
    private TextMeshProUGUI _wallHackText;
    [SerializeField]
    private Sprite _oppositeWallHackIcon;

    [SerializeField]
    private GameObject _alertDoor;
    private TextMeshProUGUI _alertDoorText;
    private Animation _alertDoorAnimation;

    [SerializeField]
    private GameObject _alertItem;
    private TextMeshProUGUI _alertItemText;
    private Animation _alertItemAnimation;

    [SerializeField]
    private Animation _transition;

    [SerializeField]
    private GameObject _winPanel;
    [SerializeField]
    private GameObject _losePanel;

    public void SwitchWallHackIcon()
    {
        Sprite cashed = _wallHackIcon.sprite;
        _wallHackIcon.sprite = _oppositeWallHackIcon;
        _oppositeWallHackIcon = cashed;
    }

    public void SetWallHackText(float value)
    {
        _wallHackText.text = ((int)value).ToString() + "m";
    }

    public void SetBatteryCharge(float charge)
    {
        _batteryText.text = ((int)charge).ToString() + "%";

        if (!_padMenuTurnedOff && charge <= 0f)
        {
            TurnOffPadMenu();
            TurnOnPadMenu();
        }
    }

    public void PlayAlertDoor(string text)
    {
        _alertDoor.SetActive(true);
        _alertDoorText.text = text;
        _alertDoorAnimation.Play();
    }

    public void PlayAlertItem(string text)
    {
        _alertItem.SetActive(true);
        _alertItemText.text = "You took " + text;
        _alertItemAnimation.Play();
    }

    public void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        _losePanel.SetActive(true);
    }

    public void SwitchPadMenu()
    {
        _padMenuShown = !_padMenuShown;
        _padMenu.Play(_padMenuShown ? _showPadAnim.name : _hidePadAnim.name);
        _padAudio.Play();
    }

    public void ShowPadMenu(Pad pad)
    {
        if (_padTextLoaded && !_padMenuTurnedOff)
        {
            StartCoroutine(LoadingPadText(pad.Text));
            _padTextLoaded = false;

            if (!_padMenuShown)
            {
                _padMenuShown = true;
                _padMenu.Play(_showPadAnim.name);
                _padAudio.Play();
            }
        }
    }

    public void TurnOffPadMenu()
    {
        if (!_padMenuTurnedOff)
        {
            _padMenuTurnedOff = true;
            _offPadMenu.gameObject.SetActive(true);
            _offPadMenu.Play(_turnOffPadAnim.name);
        }
    }

    public void TurnOnPadMenu()
    {
        if (_padMenuTurnedOff)
        {
            _offPadMenu.Play(_loadingPadAnim.name);
            StartCoroutine(TurningOnPad());
        }
    }

    public void StartTransition()
    {
        _transition.Play("StartTransition");
    }

    private IEnumerator LoadingPadText(string newText)
    {
        _padText.text = "Flash Drive Detected...";

        yield return new WaitForSeconds(1f);

        _padText.text = "Loading...";

        yield return new WaitForSeconds(2f);

        _padText.text = newText;
        _padTextLoaded = true;
    }

    private IEnumerator TurningOnPad()
    {
        yield return new WaitForSeconds(7f);

        _padMenuTurnedOff = false;
        _offPadMenu.gameObject.SetActive(false);
    }

    private void Awake()
    {
        if (_alertDoor)
        {
            _alertDoorText = _alertDoor.GetComponent<TextMeshProUGUI>();
            _alertDoorAnimation = _alertDoor.GetComponent<Animation>();
        }

        if (_alertItem)
        {
            _alertItemText = _alertItem.GetComponent<TextMeshProUGUI>();
            _alertItemAnimation = _alertItem.GetComponent<Animation>();
        }
    }
}
