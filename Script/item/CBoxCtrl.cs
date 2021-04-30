using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CBoxCtrl : MonoBehaviour
{
    [SerializeField]
    private ItemControl _item;


    private void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 initPos = transform.position;
        Quaternion initRot = Quaternion.identity;

       
        if (col.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
            ItemControl newitem = Instantiate(_item, initPos, initRot);
        }
    }
}

