using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{


    public Text counterText;
    

    public float milliseconds, seconds, minutes;

    void Start()
    {

        counterText = GetComponent<Text>() as Text;
    }

    private void FixedUpdate()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f) % 60;
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;        
    }

    void Update()
    {
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
    }
}
