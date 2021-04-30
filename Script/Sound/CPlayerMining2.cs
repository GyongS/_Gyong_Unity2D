using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
[RequireComponent(typeof(AudioSource))]

public class CPlayerMining2 : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] _clip;
    private AudioSource _source;

    private Animator anim;
    private bool MiningRL = false;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }


    public void PlayerDrillSound()
    {
        if (CrossPlatformInputManager.GetButton("MiningRL"))
        {
            if (_source.isPlaying) return;
            else
            {
                MiningRL = true;
                _source.PlayOneShot(_clip[0]); //return;
            }
        }
        else
        {
            MiningRL = false;
            _source.Stop();
        }
        //anim.SetBool("MiningDown", Mining);
    }




    public void FixedUpdate()
    {
        PlayerDrillSound();
    }

}

