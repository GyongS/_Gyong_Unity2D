using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Magnetic : MonoBehaviour
{
    private float _speed;

    private CPlayerCharacter _character;

    public Slider healthBarSlider;

    public Text IngameTimer;
    public Text ResultTimer;

    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    public Slider MagneticSlider;


    private bool isGameOver = false;

    private void Start()
    {

        ResultTimer.enabled = false;
    }

    private void Awake()
    {
        _speed = 0.05f;

        _character = GameObject.Find("Player").GetComponent<CPlayerCharacter>();
    }

    private void FixedUpdate()
    {
        if (!isGameOver)
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10f, 0, 0);
        MinusSlider();
    }

    private void MinusSlider()
    {

        MagneticSlider.value += (_speed);

        if (healthBarSlider.value == 0)
        {
            isGameOver = true;
            ResultTimer.enabled = true;
            IngameTimer.enabled = false;
            Pause();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
