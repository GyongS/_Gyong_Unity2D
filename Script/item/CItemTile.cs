using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemTile : CUnit
{
    private CItemAni _animation;

    protected override void Awake()
    {
        base.Awake();
        _animation = GetComponentInChildren<CItemAni>();
        _animation.Init(this);
    }   
}