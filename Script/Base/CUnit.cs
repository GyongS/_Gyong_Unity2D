using UnityEngine;

[System.Serializable]
public struct Stat
{
    public float MaxHp;
    public float CurHp;
    public float Speed;
    public float Damage;

    public Stat(float hp, float speed,float damage)
    {
        MaxHp = hp;
        CurHp = MaxHp;
        Speed = speed;
        Damage = damage;
    }
}

public delegate void UnitStatEvent();

public class CUnit : MonoBehaviour ,ISendDamage {

    [SerializeField]
    private Stat _unitStat;

    // INSPECTOR
    [SerializeField]
    private bool _deadEvent;

    // EVENT
    public UnitStatEvent DeadEvent;
    public UnitStatEvent HitEvent;

    public float MaxHp { get { return _unitStat.MaxHp; } }
    public float CurHp { get { return _unitStat.CurHp; } }
    public float Speed { get { return _unitStat.Speed; } }
    public bool IsDead { get { return _unitStat.CurHp == 0 ? true : false; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void HitDamage(float damage)
    {
        if (IsDead)
            return;

        float cal = _unitStat.CurHp - damage;
        _unitStat.CurHp = cal > 0 ? cal : 0;

        if (IsDead && _deadEvent)
            DeadEvent();

        if (HitEvent != null)
            HitEvent();
    }

    public float GetPercent()
    {
        return (CurHp / MaxHp) * 100.0f;
    }
    private Rigidbody2D _rigidbody;
    public Rigidbody2D CharRigid { get { return _rigidbody; } }

    public virtual void Active() { }

}
