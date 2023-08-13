using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    private float _speedWalking;
    [SerializeField]
    private float _speedCrouching;

    [SerializeField]
    private float _standingHeight = 2f;
    [SerializeField]
    private float _crouchingHeight = 0.5f;

    [SerializeField]
    private float _gravity = -30f;

    [SerializeField]
    private CharacterController _controller;

    [Header("Camera Settings")]
    [SerializeField]
    private Vector2 _sensetivity = new Vector2(8f, 0.5f);
    [SerializeField]
    private float _xClamp;

    [SerializeField]
    private Transform _camera;

    [Header("Raycast Settings")]
    [SerializeField]
    private float _distanceRaycast;
    [SerializeField]
    private LayerMask _layerMaskRaycast;

    [Header("Other Settings")]
    [SerializeField]
    private Transform _inventory;
    [SerializeField]
    private List<AudioClip> _footstepsClips;
    [SerializeField]
    private float _delayWalk;
    [SerializeField]
    private AudioSource _getItemSound;
    [SerializeField]
    private AudioSource _dropItemSound;
    [SerializeField]
    private AudioSource _heartbeatSound;
    private bool canPlayAudio = true;

    private float _xRotation = 0f;
    private Vector2 _mouseInput;

    private Vector2 _movementInput;
    private Vector2 _verticalVelocity = Vector2.zero;

    private bool _isCrouching;
    private bool _isGettedUp;
    private readonly float _heightError = 0.05f;

    private OutlineItem _lastHoveredItem;

    private TakenItem _itemInInventory;
    private bool _getItem = false;

    private AudioSource _audio;

    private bool _die;
    private Transform _enemy;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _audio = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController>();
    }

    public void RecieveInputMovement(Vector2 input)
    {
        _movementInput = input;
    }

    public void RecieveInputMouse(Vector2 input)
    {
        _mouseInput.x = input.x * _sensetivity.x;
        _mouseInput.y = input.y * _sensetivity.y;
    }

    public void RecieveAction()
    {
        _getItem = true;
    }

    public void End(Transform enemy)
    {
        _enemy = enemy;
        _controller.enabled = false;
        _sensetivity = Vector2.zero;
        _die = true;
    }

    public void CheckCrouch()
    {
        _isCrouching = !_isCrouching;
    }

    public void Heartbeat(float distance)
    {
        if (distance <= 5)
        {
            _heartbeatSound.pitch = 1.2f;
        }
        else if (distance <= 15)
        {
            _heartbeatSound.pitch = 0.9f;
        }
        else if (distance <= 25)
        {
            _heartbeatSound.pitch = 0.5f;
        }
        else
        {
            _heartbeatSound.pitch = 0f;
        }
    }

    public void DropItem()
    {
        if (_itemInInventory != null)
        {
            _dropItemSound.Play();
            _itemInInventory.Drop();

            _itemInInventory = null;
        }
    }

    private void CheckAudio(float speed)
    {
        if (_controller.isGrounded && speed > 2f && !_audio.isPlaying && canPlayAudio)
        {
            StartCoroutine(Footstep());
            canPlayAudio = false;
        }
    }

    private void MouseLook()
    {
        if (!_die)
        {
            transform.Rotate(Vector3.up, _mouseInput.y * Time.deltaTime);

            _xRotation -= _mouseInput.x;
            _xRotation = Mathf.Clamp(_xRotation, -_xClamp, _xClamp);
            Vector3 targetRotation = transform.eulerAngles;

            targetRotation.x = _xRotation;
            _camera.eulerAngles = targetRotation;
        }
        else
        {
            Vector3 targetPosition = new Vector3(_enemy.position.x, transform.position.y, _enemy.position.z);
            transform.LookAt(targetPosition);
        }
    }

    private void Movement()
    {
        if (_controller.isGrounded)
            _verticalVelocity.y = 0;

        Vector3 horizontalVelocity = (transform.right * _movementInput.x + transform.forward * _movementInput.y) * (!_isCrouching && _isGettedUp ? _speedWalking : _speedCrouching);
        _controller.Move(horizontalVelocity * Time.deltaTime);

        _verticalVelocity.y += _gravity * Time.deltaTime;
        _controller.Move(_verticalVelocity * Time.deltaTime);

        CheckAudio(horizontalVelocity.magnitude);
    }

    private void GetUp()
    {
        if (_controller.height < _standingHeight)
        {
            _isGettedUp = false;

            float lastHeight = _controller.height;

            if (Physics.Raycast(transform.position, transform.up, out RaycastHit hit, _standingHeight))
            {
                if (hit.distance < _standingHeight - _crouchingHeight)
                {
                    UpdateCharacterHeight(_crouchingHeight + hit.distance);
                    return;
                }
            }

            UpdateCharacterHeight(_standingHeight);

            if (_controller.height + _heightError >= _standingHeight)
            {
                _controller.height = _standingHeight;
            }

            transform.position += Vector3.up * ((_controller.height - lastHeight) / 2);
        }
        else
        {
            _isGettedUp = true;
        }
    }

    private void Crouch()
    {
        _isGettedUp = false;
        if (_controller.height > _crouchingHeight)
        {
            UpdateCharacterHeight(_crouchingHeight);

            if (_controller.height - _heightError <= _crouchingHeight)
            {
                _controller.height = _crouchingHeight;
            }
        }
    }

    private void GetItem(TakenItem item)
    {
        if (_itemInInventory != null)
            DropItem();

        _getItemSound.Play();
        _itemInInventory = item;
        _itemInInventory.Get(_inventory);
    }

    private void CheckRaycast()
    {
        if (_lastHoveredItem != null)
        {
            _lastHoveredItem.OnHoverExit();
            _lastHoveredItem = null;
        }

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distanceRaycast, _layerMaskRaycast, QueryTriggerInteraction.Ignore))
        {
            if (hitInfo.collider.TryGetComponent(out OutlineItem outlineItem))
            {
                if (_lastHoveredItem != null)
                    _lastHoveredItem.OnHoverExit();

                _lastHoveredItem = outlineItem;
                outlineItem.OnHoverEnter();

                if (_getItem)
                {
                    if (outlineItem.TryGetComponent(out TakenItem takenItem))
                    {
                        if (takenItem != this && takenItem != _itemInInventory)
                        {
                            GetItem(takenItem);
                            _lastHoveredItem = null;
                        }
                    }
                    else if (outlineItem.TryGetComponent(out Pad pad))
                    {
                        if (pad != this)
                        {
                            pad.StartRead();
                        }
                    }
                    else if (outlineItem.TryGetComponent(out Door door))
                    {
                        if (door.TryOpenDoor(_itemInInventory))
                        {
                            Destroy(_itemInInventory.gameObject);
                            _itemInInventory = null;
                        }
                    }
                    else if (outlineItem.TryGetComponent(out Lifeboat lifeboat))
                    {
                        if (lifeboat.TryAddItems(_itemInInventory))
                        {
                            Destroy(_itemInInventory.gameObject);
                            _itemInInventory = null;
                        }
                    }
                }
            }
        }

        _getItem = false;
    }
    private IEnumerator Footstep()
    {
        int numberRandomClip = UnityEngine.Random.Range(0, _footstepsClips.Count);

        _audio.clip = _footstepsClips[numberRandomClip];

        _audio.volume = UnityEngine.Random.Range(0.65f, 0.75f);
        _audio.pitch = UnityEngine.Random.Range(0.8f, 1.1f);
        _audio.Play();

        yield return new WaitForSeconds(_delayWalk);

        canPlayAudio = true;
    }

    private void UpdateCharacterHeight(float newHeight)
    {
        _controller.height = Mathf.Lerp(_controller.height, newHeight, _speedCrouching * Time.deltaTime);
    }

    private void Update()
    {
        MouseLook();
        Movement();

        if (_isCrouching)
            Crouch();
        else
            GetUp();

        CheckRaycast();
    }
}