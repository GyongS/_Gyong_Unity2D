using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTileAni : MonoBehaviour {

    private CTile _tile;   
    private SpriteRenderer _renderer;

    [SerializeField]
    private Sprite[] _sprites;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Init(CTile tile)
    {
        _tile = tile;
        _tile.HitEvent += ChangeSprite;
    }    

    private void ChangeSprite()
    {
        Debug.Log((int)_tile.CurHp);
        _renderer.sprite = _sprites[(int)_tile.CurHp];        
    }    
}
