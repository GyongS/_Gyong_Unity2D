using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CItemAni : MonoBehaviour
{
    private CItemTile _tile;

    private SpriteRenderer _renderer;

    private Animator anim;
  
    private Slider MagneticSlider;

    private bool ItemAni;

    [SerializeField]
    private Sprite[] _sprite;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        MagneticSlider = GameObject.Find("MagneticSlider").GetComponent<Slider>();
    }

    public void Init(CItemTile tile)
    {
        _tile = tile;
        _tile.HitEvent += ChangeSprite;
    }


    public void ChangeSprite()
    {
        Debug.Log((int)_tile.CurHp);
        _renderer.sprite = _sprite[(int)_tile.CurHp];   
     
        if (_tile.CurHp == 0)
        {
            ItemAni = true;
            MagneticSlider.value -= 30;
        }
        anim.SetBool("ItemAni", ItemAni);
    }   
}
