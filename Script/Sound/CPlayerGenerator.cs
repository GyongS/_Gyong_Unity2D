using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerGenerator : MonoBehaviour {
    [SerializeField]
    private AudioClip[] _clip;

    private AudioSource _source;
    

    private bool _ItemAni;
    private int a;
    
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void GeneratorOnSound()
    {
        if (_source.isPlaying) return;

        else if (a == 1)
        {
            _source.Stop();
        }
        else
        {
            a += 1;
            _source.PlayOneShot(_clip[0]);
        }


    }

    
}
