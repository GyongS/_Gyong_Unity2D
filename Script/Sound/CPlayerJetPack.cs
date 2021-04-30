using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
[RequireComponent(typeof(AudioSource))]
public class CPlayerJetPack : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] _clip;
    private AudioSource _source;

    private Animator anim;

    private bool Jetpack = false;


    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void JetPackOnSound()
    {
        if (CrossPlatformInputManager.GetButton("Flying"))
        {
            if (_source.isPlaying) return;
            else
            {
                Jetpack = true;
                _source.PlayOneShot(_clip[0]);
            }
        }
        else
        {
            Jetpack = false;
            _source.Stop();
        }
        //anim.SetBool("Flying", Jetpack);
    }
    //제트팩 사운드, Flying 파라메타가 false 경우 소리 안남.

    private void Update()
    {
        JetPackOnSound();
    }


}

   

