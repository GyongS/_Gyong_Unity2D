using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.Dynamic;

public class CPlayerSwitch : MonoBehaviour
{


    [SerializeField]
    private float _damage;

    [SerializeField]
    private Collider2D[] _Switch;

    [SerializeField]
    private Button _button;

    private float _curTime = 0.0f;

    private Collider2D _col;
    private Transform _tr;

    public bool _hitCheck = false;



    private void Awake()
    {

        _button.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_hitCheck)
        {
            _tr.GetComponent<ISendDamage>().HitDamage(_damage);
            _hitCheck = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item" && col.gameObject.tag != "block")
        {
            if (col.gameObject.transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ItemOFF"))
            {
                _tr = col.gameObject.transform;
                _hitCheck = true;
            }
            Debug.Log("Switch on");
        }
    }

}
