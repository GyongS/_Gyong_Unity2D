using UnityEngine;
using UnityEngine.UI;


public class CPotionSound : MonoBehaviour
{

    public AudioSource _source;
    
    
    void Start()
    {
        _source = GetComponent<AudioSource>();
      
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "Player")
        {
            _source.Play();
        }
    }
}
