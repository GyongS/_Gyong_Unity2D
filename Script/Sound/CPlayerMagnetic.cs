using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerMagnetic : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] _clip;

    [SerializeField]
    private Slider _Magnetic;

    private SpriteRenderer _sprite;

    private AudioSource _source;
    private Animator _anim;

    private bool Lightning = false;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    public void MagneticSound()
    {

        if (_source.isPlaying) return;
        if (_Magnetic.value < 20)
        {
            Lightning = false;
            _source.volume = 0;
        }
        if (_Magnetic.value > 20)
        {
            Lightning = true;
            _source.volume = (float)0.02;
            _source.PlayOneShot(_clip[0]);
        }

        if (_Magnetic.value > 40)
        {
            _source.volume = (float)0.04;
            _source.PlayOneShot(_clip[0]);
        }

        if (_Magnetic.value > 60)
        {
            _source.volume = (float)0.06;
            _source.PlayOneShot(_clip[0]);
        }
        if (_Magnetic.value > 80)
        {
            _source.volume = (float)0.08;
            _source.PlayOneShot(_clip[0]);
        }

        _anim.SetBool("Lightning", Lightning);

    }

    public void Update()
    {
        MagneticSound();

    }


}
