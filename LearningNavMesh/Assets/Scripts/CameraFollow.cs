using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _subject;
    private Transform _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = gameObject.transform;
        _subject = GameObject.FindWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        _camera.transform.position = _subject.transform.position;
    }
}