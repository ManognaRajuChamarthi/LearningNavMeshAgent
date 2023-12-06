using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Context : MonoBehaviour
{
    [Header("Enemy Variables")]
    [SerializeField] private float _wanderSpeed = 5f;//How fast enemy should move if it is in wander state
    [SerializeField] private float _turnSpeed = 10f;
    [Space]
    [SerializeField] private float _patrolArea = 2f;
    [Space]
    [SerializeField] private float _waitTimeBeforeMovingToNewPostion = 1f;

    [Header("movement Variables")]
    [SerializeField] private NavMeshAgent _agent;
    private Transform _transform; //Transform component of the object
    private Vector3 _startPosition;


    //StateMachine
    public Abstract _current;
    public Wander _wanderState = new Wander();
    public Chase _chaseState = new Chase();


    //getterSetters
    public Transform Transform { get { return _transform; } }
    public NavMeshAgent Agent { get { return _agent; } }

    public Vector3 StartPosition { get { return _startPosition; } }

    public float PatrolArea { get { return _patrolArea; } }
    public float WaitTimeBeforeMovingToNewPostion { get { return _waitTimeBeforeMovingToNewPostion; } }
    public float WanderSpeed { get { return _wanderSpeed; } }
    public float TurnSpeed { get { return _turnSpeed; } }



    private void Awake()
    {
        _transform = transform;
        _agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        _startPosition = _transform.position;
        _current = _wanderState;
        _wanderState.EnterState(this);
    }

    void FixedUpdate()
    {
        _current.FixedUpdateState(this);
    }


    void Update()
    {
        _current.UpdateState(this);
        //RotateCharacter();
    }

    public void SwitchMovementStates(Abstract _State)
    {
        _current = _State;
        _State.EnterState(this);
    }


    void RotateCharacter()
    {
       
    }

}
