using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoblinState
{
    IDLE = 0,
    PATROL,
    CHASE,
    ATTACK,
    DEAD,
}

[RequireComponent(typeof(GoblinStat))]
[ExecuteInEditMode]
public class GoblinFSMManager : MonoBehaviour, IFSMManager
{
    private bool _isinit = false;
    public GoblinState startState = GoblinState.IDLE;
    private Dictionary<GoblinState, GoblinFSMState> _states = new Dictionary<GoblinState, GoblinFSMState>();

    [SerializeField]
    private GoblinState _currentState;
    public GoblinState CurrentState
    {
        get
        {
            return _currentState;
        }
    }

    public GoblinFSMState CurrentStateComponent
    {
        get { return _states[_currentState]; }
    }

    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private CharacterController _playercc;
    public CharacterController PlayerCC { get { return _playercc; } }

    private Transform _playerTransform;
    public Transform PlayerTransform { get { return _playerTransform; } }

    private GoblinStat _stat;
    public GoblinStat Stat { get { return _stat; } }

    private Animator _anim;
    public Animator Anim { get { return _anim; } }

    private Camera _sight;
    public Camera Sight { get { return _sight; } }

    public int sightAspect = 3;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _stat = GetComponent<GoblinStat>();
        _anim = GetComponentInChildren<Animator>();
        _sight = GetComponentInChildren<Camera>();

        _playercc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        _playerTransform = _playercc.transform;

        GoblinState[] stateValues = (GoblinState[])System.Enum.GetValues(typeof(GoblinState));
        foreach (GoblinState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Goblin" + s.ToString());
            GoblinFSMState state = (GoblinFSMState)GetComponent(FSMType);
            if (null == state)
            {
                state = (GoblinFSMState)gameObject.AddComponent(FSMType);
            }

            _states.Add(s, state);
            state.enabled = false;
        }

    }

    public void SetState(GoblinState newState)
    {
        if (_isinit)
        {
            _states[_currentState].enabled = false;
            _states[_currentState].EndState();
        }
        _currentState = newState;
        _states[_currentState].BeginState();
        _states[_currentState].enabled = true;
        _anim.SetInteger("CurrentState", (int)_currentState);
    }

    private void Start()
    {
        SetState(startState);
        _isinit = true;
    }

    private void OnDrawGizmos()
    {
        if (_sight != null)
        {
            Gizmos.color = Color.red;
            Matrix4x4 temp = Gizmos.matrix;

            Gizmos.matrix = Matrix4x4.TRS(
                _sight.transform.position,
                _sight.transform.rotation,
                Vector3.one
                );

            Gizmos.DrawFrustum(
                _sight.transform.position,
                _sight.fieldOfView,
                _sight.farClipPlane,
                _sight.nearClipPlane,
                _sight.aspect
                );

            Gizmos.matrix = temp;
        }
    }

    public void NotifyTargetKilled()
    {
        SetState(GoblinState.IDLE);
        _playerTransform = null;
        _playercc = null;
    }

    public void SetDeadState()
    {
        SetState(GoblinState.DEAD);
    }
}
