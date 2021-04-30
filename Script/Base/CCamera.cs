using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamera : MonoBehaviour
{

    [SerializeField]
    private float minX, maxX;

    [SerializeField]
    private float minY, maxY;

    [SerializeField]
    private float _lerpTime;

    private CUnit _unit;

    private Vector3 moveDir;

    public void Init(CUnit unit) { _unit = unit; }

    public void MoveTarget()
    {
        moveDir.Set(Mathf.Clamp(_unit.transform.position.x, minX, maxX),
            Mathf.Clamp(_unit.transform.position.y, minY, maxY),
            transform.position.z);

        if (Vector2.Distance(transform.position, moveDir) >= 0.5f)
            transform.position = Vector3.Lerp(transform.position, moveDir, _lerpTime * Time.fixedDeltaTime);        

        else
            transform.position = moveDir;    
    }   

    private void LateUpdate()
    {
        if (_unit == null)
            return;

        MoveTarget();
    }
}
