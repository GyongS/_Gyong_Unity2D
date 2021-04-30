using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CTile : CUnit
{
    [SerializeField]
    private ItemControl _item;    

    private CTileAni _animation;    

    protected override void Awake()
    {
        base.Awake();

        DeadEvent += BrokenItem;

        _animation = GetComponentInChildren<CTileAni>();
        _animation.Init(this);
    }
    public void SetIsItem()
    {
        isItem = true;
    }  

    bool isItem = false;   

    private void BrokenItem()
    {
        if (isItem)
        {
            ItemControl newitem = Instantiate(_item, transform.position, Quaternion.identity, null);
        }      
        gameObject.SetActive(false);
    }
}
