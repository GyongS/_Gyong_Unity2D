using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerFootStep : MonoBehaviour {

    [SerializeField]
    private AudioClip[] _clip;

    private AudioSource _source;
    private Animator anim;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void PlayerFootStepSound()
    {
        if (transform.position.y < 1)
            _source.PlayOneShot(_clip[Random.Range(0, 2)]);
    }
}