using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
[RequireComponent(typeof(AudioSource))]
public class CPlayerMining : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] _clip;
    private AudioSource _source;

    private Animator anim;

    private bool Mining = false;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }


    public void PlayerDrillSound()
    {
        if (CrossPlatformInputManager.GetButton("Mining"))
        {
            if (_source.isPlaying) return;
            else
            {
                Mining = true;
                _source.PlayOneShot(_clip[0]); //return;
            }
        }
        else
        {
            Mining = false;
            _source.Stop();
        }
        //anim.SetBool("MiningDown", Mining);
    }




    public void FixedUpdate()
    {
        PlayerDrillSound();
    }

    }

