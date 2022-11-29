using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    public float timeLeft;
    public bool timerOn = false;
    

    public Text text;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Listo!");
                timeLeft = 0;
                timerOn = false;
                
                if (SceneManager.GetActiveScene().name == "main") GameManager.Instance.EndGameRecollect();
                if (SceneManager.GetActiveScene().name == "fps_game") TargetBounds.Instance.EndGameFPS();
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        text.text = string.Format("{0:00} : {1:00}",minutes,seconds);
    }
}
