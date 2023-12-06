using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    [Header("Enemy Variables")]
    [SerializeField] private float _wanderSpeed = 5f;//How fast enemy should move if it is in wander state
    [SerializeField] private float _enemyTurnSpeed = 10f;
    [Space]
    [SerializeField] private float _patrolArea = 2f;
    [Space]
    [SerializeField] private float _waitTimeBeforeMovingToNewPostion = 1f;
    [SerializeField] private float _correctionFactorAdjustmentTime = 1f;

    [Header("movement Variables")]
    private Transform _enemyTransform; //Transform component of the object
    private Vector3 _startPosition;


    //StateMachine
    public Abstract _current;
    public Wander _wanderState = new Wander();
    public Chase _chaseState = new Chase();


    //getterSetters
    public Transform EnemyTransform { get { return _enemyTransform; } }

    public Vector3 StartPosition { get { return _startPosition; } }

    public float PatrolArea { get { return _patrolArea; } }
    public float WaitTimeBeforeMovingToNewPostion { get { return _waitTimeBeforeMovingToNewPostion; } }
    public float CorrectionFactorAdjustmentTime { get { return _correctionFactorAdjustmentTime; } }
    public float WanderSpeed { get { return _wanderSpeed; } }
    public float EnemyTurnSpeed { get { return _enemyTurnSpeed; } }



    private void Awake()
    {
        _enemyTransform = transform;
    }


    void Start()
    {
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
        RotateCharacter();
    }

    public void SwitchMovementStates(Abstract _State)
    {
        _current = _State;
        _State.EnterState(this);
    }


    void RotateCharacter()
    {
        //Vector3 dir = new Vector3();


        /*if ()
        {
            Vector3 relative = (transform.position + dir) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _enemyTurnSpeed * Time.deltaTime);

        }*/
    }

}
