using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Outline))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    private Player _player;
    private NavMeshAgent _agent;
    [SerializeField]
    private Animator _animator;
    private Level _level;
    private Flashlight _flashlight;
    [SerializeField]
    private AudioClip _footstepsClip;
    [SerializeField]
    private float _delayWalk;
    private bool canPlayAudio = true;

    [SerializeField]
    private float _normalSpeed;
    [SerializeField]
    private float _walkingToPlayerSpeed;

    [SerializeField]
    private List<Transform> _homePositions;

    [SerializeField]
    private float _waitTime;

    [SerializeField]
    private int _numberHomePos = 0;

    [SerializeField]
    private float _radiusViewLightOn;
    [SerializeField]
    private float _radiusViewLightOff;

    private Vector3 _lastPointPlayer;

    private Outline _outline;
    [SerializeField]
    private State _state = State.Walking;

    private float _distanceToPlayer;

    private AudioSource _audioWalking;
    [SerializeField]
    private AudioSource _audioScream;

    public void ShowOutline()
    {
        _outline.enabled = true;
    }

    public void HideOutline()
    {
        _outline.enabled = false;
    }

    public void SetPosition(int id)
    {
        _numberHomePos = id;
        _state = State.Wait;
        StopCoroutine(Wait());
        _agent.SetDestination(_homePositions[_numberHomePos].position);
    }

    private int RandomHomePos()
    {
        int a = Random.Range(0, _homePositions.Count);

        return (_numberHomePos == a ? RandomHomePos() : a);
    }

    private void CheckState()
    {
        if (_distanceToPlayer <= (_flashlight.IsFlashlightTurnedOn() ? _radiusViewLightOn : _radiusViewLightOff))
        {
            _state = State.WalkingToPlayer;
            _animator.SetInteger("State", 1);
            StopCoroutine(Seek(_waitTime));
        }
        else if (State.WalkingToPlayer == _state && _state != State.Attack)
        {
            _state = State.SeekPlayer;
            _animator.SetInteger("State", 1);
            StartCoroutine(Seek(_waitTime));
        }
        else
        {
            if (Vector3.Distance(transform.position, _homePositions[_numberHomePos].position) <= 1 && _state != State.InHome)
            {
                _animator.SetInteger("State", 0);
                _state = State.InHome;
                StartCoroutine(Wait());
            }
            else if (Vector3.Distance(transform.position, _lastPointPlayer) <= 1 && _state == State.SeekPlayer)
            {
                _animator.SetInteger("State", 0);
            }
        }
    }

    private void CheckAudio()
    {
        if (_agent.velocity.magnitude > 2f && !_audioWalking.isPlaying && canPlayAudio)
        {
            StartCoroutine(Footstep());
            canPlayAudio = false;
        }
    }

    private IEnumerator Footstep()
    {
        _audioWalking.clip = _footstepsClip;

        _audioWalking.Play();

        yield return new WaitForSeconds(_delayWalk);

        canPlayAudio = true;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_waitTime);
        _animator.SetInteger("State", 1);
        _numberHomePos = RandomHomePos();
        _state = State.Walking;
    }

    private IEnumerator Seek(float time)
    {
        _state = State.SeekPlayer;
        _lastPointPlayer = _playerTransform.position;
        yield return new WaitForSeconds(time);
        _animator.SetInteger("State", 1);
        _state = State.Walking;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && _state == State.WalkingToPlayer)
        {
            _state = State.Attack;
            _level.Die(transform);
            _agent.speed = 0f;
            _animator.SetInteger("State", 2);
            _audioScream.Play();
        }
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _audioWalking = GetComponent<AudioSource>();
        _outline = GetComponent<Outline>();
        _player = FindObjectOfType<Player>();
        _playerTransform = _player.transform;
        _level = FindObjectOfType<Level>();
        _flashlight = FindObjectOfType<Flashlight>();

        _outline.enabled = false;
        _animator.SetInteger("State", 1);
    }

    private void Update()
    {
        if (_state != State.Attack)
        {
            CheckAudio();

            _distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
            _player.Heartbeat(_distanceToPlayer);
            CheckState();

            Vector3 position = _homePositions[_numberHomePos].position;

            switch (_state)
            {
                case State.SeekPlayer:
                    _agent.speed = _walkingToPlayerSpeed;
                    position = _lastPointPlayer;
                    break;
                case State.WalkingToPlayer:
                    _agent.speed = _walkingToPlayerSpeed;
                    position = _playerTransform.position;
                    break;
                case State.Walking:
                    _agent.speed = _normalSpeed;
                    position = _homePositions[_numberHomePos].position;
                    break;
            }

            _agent.SetDestination(position);
        }
    }

    private enum State
    {
        InHome,
        Walking,
        Attack,
        WalkingToPlayer,
        SeekPlayer,
        Wait,
    }

}
