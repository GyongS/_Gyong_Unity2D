using UnityEngine;

public enum AirState
{
    Move = 0,
    DropComplete,
}

public sealed class CAirDrop : CInivisibleObject
{
    private AudioSource _source;

    [SerializeField]
    private AudioClip[] _clip;
    // MEMBER
    private Vector2 _moveDir = Vector2.right;
    private AirState _state = AirState.Move;

    // SUPPLY
    [SerializeField]
    private CBoxCtrl _supply;

    private float _dropPos;
    private const float ENDDESTINATION = 48.0f;

    protected override void Awake()
    {
        base.Awake();
        _source = GetComponent<AudioSource>();

    }


    // UNITY
    private void Update()
    {
        if (Mathf.Abs(ENDDESTINATION) - Mathf.Abs(transform.position.x) <= 0.1f)
            gameObject.SetActive(false);

        else
        {
            Rigid.velocity = (_moveDir * Stat.Speed);

            if (Mathf.Abs(_dropPos) - Mathf.Abs(transform.position.x) <= 0.1f && _state == AirState.Move)
            {
                GetSupply(transform.position);
                _state = AirState.DropComplete;
            }
        }
    }

    public override void Repair()
    {
        base.Repair();

        _state = AirState.Move;
        _dropPos = Random.Range(transform.position.x, 42.0f);
        Rigid.velocity = Vector2.zero;
    }

    private void GetSupply(Vector2 pos)
    {
        Instantiate(_supply, pos, Quaternion.identity, null);
        if (_source.isPlaying)
            return;
        else
        _source.PlayOneShot(_clip[0]);

    }
}
