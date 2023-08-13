using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UI))]
[RequireComponent(typeof(WallHack))]
public class PlayerKeyboard : MonoBehaviour
{
    public Player Player;
    public Flashlight Flashlight;

    private UI _ui;
    private Level _level;
    private WallHack _wallHack;

    private PlayerControls _playerControls;

    private Vector2 _movementInput;
    private Vector2 _mouseInput;


    private void Awake()
    {
        _wallHack = GetComponent<WallHack>();
        _ui = GetComponent<UI>();
        _level = GetComponent<Level>();

        Player = FindObjectOfType<Player>();

        _playerControls = new PlayerControls();
        _playerControls.Enable();

        _playerControls.FPSControl.Movement.performed += ctx => _movementInput = ctx.ReadValue<Vector2>();
        _playerControls.FPSControl.MouseX.performed += ctx => _mouseInput.x = ctx.ReadValue<float>();
        _playerControls.FPSControl.MouseY.performed += ctx => _mouseInput.y = ctx.ReadValue<float>();
        _playerControls.FPSControl.Crouch.performed += ctx => Player.CheckCrouch();

        _playerControls.Actions.SwitchFlashlight.performed += ctx => Flashlight.Switch();
        _playerControls.Actions.Action.performed += ctx => Player.RecieveAction();
        _playerControls.Actions.Drop.performed += ctx => Player.DropItem();
        _playerControls.Actions.TurnOnCheat.performed += ctx => _wallHack.TurnOn();

        _playerControls.Menu.SwitchPad.performed += ctx => _ui.SwitchPadMenu();
        _playerControls.Menu.Exit.performed += ctx => Application.Quit();
        _playerControls.Menu.Restart.performed += ctx => _level.Restart();

    }

    public void SetFlashlight(Flashlight flashlight)
    {
        Flashlight = flashlight;
    }

    private void Update()
    {
        Player.RecieveInputMovement(_movementInput);
        Player.RecieveInputMouse(_mouseInput);

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
