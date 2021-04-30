using UnityEngine;

[System.Serializable]
public struct InvisibleObjectStat
{
    public float Speed;

    public InvisibleObjectStat(float speed)
    {
        Speed = speed;
    }
}

public class CInivisibleObject : MonoBehaviour {

    // MEMBER
    [SerializeField]
    private InvisibleObjectStat _stat;
    private Rigidbody2D _rigid;

    // GET
    public InvisibleObjectStat Stat { get { return _stat; } }
    public Rigidbody2D Rigid { get { return _rigid; } }

    public virtual void Repair() { }

    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
}
