using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CController : MonoBehaviour {

    [SerializeField]
    private CCamera _cam;

    [SerializeField]
    private Magneticani _Magnetic;

    [SerializeField]
    private CUnit _target;

    [SerializeField]
    private CUnit _target2;

    private void Awake()
    {
        _cam.Init(_target);
        _Magnetic.Init(_target2);
    }

    private void FixedUpdate()
    {
        _target.Active();
        _target2.Active();
    }
}
