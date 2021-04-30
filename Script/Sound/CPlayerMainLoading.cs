using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class CPlayerMainLoading : MonoBehaviour
{
    private AudioSource _source;
    private void Awake()
    {
        _source =  GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(this.gameObject);
        }
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
