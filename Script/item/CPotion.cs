using UnityEngine;
using UnityEngine.UI;


public enum ItemState
{
    Move = 0,
    Stop
}



public class CPotion : MonoBehaviour
{



    private Slider HPSlider;

    // STATE
    private ItemState _State = ItemState.Move;

    private float rotSpeed = 260.0f;
    private Transform _Tr;



    void Start()
    {
        _Tr = GetComponent<Transform>();
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 250.0f);
        HPSlider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    void Update()
    {
        if(_State == ItemState.Stop)
        {
            _Tr.Rotate(Vector3.zero);
        }

        else
            _Tr.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "block")
        {
            _State = ItemState.Stop;
            transform.rotation = Quaternion.identity;            
        }

        if (col.gameObject.tag == "Player")
        {

            HPSlider.value += 200;
            Destroy(this.gameObject);

        }
    }
}
