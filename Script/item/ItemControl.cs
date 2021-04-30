using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class 
    ItemControl : MonoBehaviour {

    
    [SerializeField]
    private Sprite _sprite;   

    public void Random(int value)
    {
        switch (value)
        {
            case 0:
                transform.GetComponent<SpriteRenderer>().sprite = _sprite;
                Debug.Log("아이템");
                break;
        }
    }

}
