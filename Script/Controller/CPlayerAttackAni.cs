using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CPlayerAttackAni : MonoBehaviour {

    [SerializeField]
    private float _damage;

    [SerializeField]
    private Collider2D[] attackTrigger;

    private float _curTime = 0.0f;
    private const float _maxTime = 0.1f;

    private bool MiningDown = false;
    private bool MiningRL = false;
    private bool Flying = false;

    private float attackTimer = 0;
    private float attacked = 1.0f;


    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger[0].enabled = false;
        attackTrigger[1].enabled = false;        

    }


    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Mining"))
        {
            MiningDown = true;
            attackTimer = attacked;
            
            if (_curTime >= _maxTime)
            {
                _curTime = 0.0f;
                attackTrigger[0].enabled = !attackTrigger[0].enabled;
            }
            else
                _curTime += Time.fixedDeltaTime;

        }
        else if (CrossPlatformInputManager.GetButton("MiningRL"))
        {
            MiningRL = true;
            attackTimer = attacked;

            if (_curTime >= _maxTime)
            {
                _curTime = 0.0f;
                attackTrigger[1].enabled = !attackTrigger[1].enabled;
            }
            else
                _curTime += Time.fixedDeltaTime;
        }  

        else
        {
            MiningDown = CrossPlatformInputManager.GetButton("Mining");
            MiningRL = CrossPlatformInputManager.GetButton("MiningRL");
            Flying = CrossPlatformInputManager.GetButton("Flying");
            attackTrigger[0].enabled = false;
            attackTrigger[1].enabled = false;
        }

        anim.SetBool("MiningDown", MiningDown);
        anim.SetBool("MiningRL", MiningRL);
        anim.SetBool("Flying", Flying);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "block")
        {
            Debug.Log("ATTACK");
            col.GetComponent<ISendDamage>().HitDamage(_damage);
        }
    }   
}
