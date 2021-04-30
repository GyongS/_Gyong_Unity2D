using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodDelay : MonoBehaviour
{
    private Animator _anim;
    public Slider MagneticSlider;
    public Slider HPSlider;

    enum State
    {
        b1,
        b2,
        b3
    };
    State currentState;

    private bool Blood1;
    private bool Blood2;
    private bool Blood3;

    float bloodTime;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine("BloodAnimDelay");
    }

    private void BloodAni()
    {
        switch (currentState)
        {
            case State.b1:
                Blood1 = false;
                Blood2 = true;
                Blood3 = false;
                currentState = State.b2;
                break;
            case State.b2:
                Blood1 = false;
                Blood2 = false;
                Blood3 = true;
                currentState = State.b3;
                break;
            case State.b3:
                Blood1 = true;
                Blood2 = false;
                Blood3 = false;
                currentState = State.b1;
                break;
        }
    }

    IEnumerator BloodAnimDelay()
    {
        while (HPSlider.value >= 0)
        {            
            if (MagneticSlider.value >= 20)
            {
                HPSlider.value -= 2f;
                BloodAni();
            }
            if (MagneticSlider.value >= 40)
            {
                HPSlider.value -= 4f;
            }
            if (MagneticSlider.value >= 60)
            {
                HPSlider.value -= 8f;
            }
            if (MagneticSlider.value >= 80)
            {
                HPSlider.value -= 10f;
            }

            _anim.SetBool("Blood1", Blood1);
            _anim.SetBool("Blood2", Blood2);
            _anim.SetBool("Blood3", Blood3);
            yield return new WaitForSeconds(1f);
        }

    }
}

