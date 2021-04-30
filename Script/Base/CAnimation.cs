using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimation : MonoBehaviour {

    private Animator _animator;
    public Animator Animator { get { return _animator; } }

    [SerializeField]
    private Collider2D _col;

    private SpriteRenderer _renderer;

    private System.Enum _state;
    public System.Enum State { get { return _state; } }
    public void SetState(System.Enum state) { _state = state; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // CHANGE STATE
    public void ChangeState(System.Enum state)
    {
        if (_state == state)
            return;

        _state = state;
        _animator.SetInteger("State", _state.GetHashCode());
    }

    public virtual void Init(CUnit unit) { }

    // FLIP SPRITE
    public void FlipX(bool flip)
    {
        if (_renderer.flipX == flip)
        {           
            return;          
        }        
        _renderer.flipX = flip;
    }
}
