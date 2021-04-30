using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIngameSound : MonoBehaviour {

    private AudioSource _source;
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void SoundOFF()
    {
        _source.mute = true;
    }

    public void SoundON()
    {
        _source.mute = false;
    }
}
