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
    [SerializeField] private float _playerDetectionDistance = 5f;
    [Range(0,1)]
    [SerializeField] private float _feildOfVisionResolution = 1f;
    [Space]
    [SerializeField] private float _waitTimeBeforeMovingToNewPostion = 1f;

    [Header("movement Variables")]
    [SerializeField] private NavMeshAgent _agent;
    private Transform _transform; //Transform component of the object
    private Transform _iPTransform;
    private Vector3 _startPosition;


    //StateMachine
    public Abstract _current;
    public Wander _wanderState = new Wander();
    public Chase _chaseState = new Chase();


    //getterSetters
    public Transform Transform { get { return _transform; } }
    public Transform IPTransform { get { return _iPTransform; } }
    public NavMeshAgent Agent { get { return _agent; } }

    public Vector3 StartPosition { get { return _startPosition; } }

    public float PatrolArea { get { return _patrolArea; } }
    public float WaitTimeBeforeMovingToNewPostion { get { return _waitTimeBeforeMovingToNewPostion; } }
    public float WanderSpeed { get { return _wanderSpeed; } }
    public float TurnSpeed { get { return _turnSpeed; } }
    public float DetectionDistance { get { return _playerDetectionDistance; } }



    private void Awake()
    {
        _transform = transform;
        _iPTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
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
        DetectionArea();
    }

    public void SwitchMovementStates(Abstract _State)
    {
        _current = _State;
        _State.EnterState(this);
    }


    void RotateCharacter()
    {
       
    }

    void DetectionArea()
    {
        Vector3 outer1 = Quaternion.Euler(0f, 180 * _feildOfVisionResolution, 0f) * transform.forward;
        Vector3 outer2 = Quaternion.Euler(0f, -180 * _feildOfVisionResolution, 0f) * transform.forward;

        Debug.DrawLine(transform.position, transform.position + transform.forward*_playerDetectionDistance , Color.green);
        Debug.DrawLine(transform.position, transform.position + outer1 * _playerDetectionDistance, Color.green);
        Debug.DrawLine(transform.position, transform.position + outer2 * _playerDetectionDistance, Color.green);
    }
    

}
