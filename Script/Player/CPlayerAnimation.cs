using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CPlayerAnimation : CAnimation {

    private CPlayerCharacter _character;

    public override void Init(CUnit character)
    {
        base.Init(character);

        _character = character as CPlayerCharacter;
    }


    private void Update()
    {
        Animator.SetFloat("X", Mathf.Abs(_character.Horziontal));
       
        if(_character.Horziontal > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(_character.Horziontal < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }            
    }
}
