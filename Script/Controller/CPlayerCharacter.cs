using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public sealed class CPlayerCharacter : CUnit
{
    //CLASS
    private CPlayerAnimation _animation;

    //PARAMETER
    private float _horizontal;
    public float Horziontal { get { return _horizontal; } }

    private float _vertical;
    public float Vertical { get { return _vertical; } }

    private Vector2 _moveMent;

    [SerializeField]
    private float _posminX, _posmaxX;

    [SerializeField]
    private float minY, maxY;

    [SerializeField]
    float jumpForce;
   

    protected override void Awake()
    {
        base.Awake();

        _animation = transform.Find("Anim").GetComponent<CPlayerAnimation>();
        _animation.Init(this);

    }

    private void Update()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, _posminX, _posmaxX),
                                              Mathf.Clamp(transform.localPosition.y, minY, maxY),
                                              transform.localPosition.z);
        MoveMent();
    }
   

    public override void Active()
    {
        base.Active();        
    }
    

    private void MoveMent()
    {
        _horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        _vertical = CrossPlatformInputManager.GetAxis("Vertical");

        _moveMent = (_horizontal * Vector2.right) * Speed;
        
        _moveMent.y = CharRigid.velocity.y;
        CharRigid.velocity = _moveMent;        
    }
}
