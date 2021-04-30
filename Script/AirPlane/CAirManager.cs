using UnityEngine;

public sealed class CAirManager : MonoBehaviour
{
    [SerializeField]
    private CAirDrop _air;

    [SerializeField]
    private float _dropTime;
    private float _curTime = 0.0f;

    [SerializeField]
    private Transform _startPivot;

    private void Awake()
    {
        _air = Instantiate(_air, Vector3.zero, Quaternion.identity, null);
        _air.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_curTime >= _dropTime)
        {
            GetAirDrop(_startPivot.position);
            _curTime = 0.0f;
        }

        else
            _curTime += Time.fixedDeltaTime;
    }

    public void GetAirDrop(Vector2 pos)
    {
        _air.transform.position = pos;
        _air.Repair();
        _air.gameObject.SetActive(true);
    }
}
