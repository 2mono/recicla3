using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TargetBounds : MonoBehaviour
{
    [SerializeField] BoxCollider col;

    [SerializeField] Text targetCountText;
    [SerializeField] GameObject messageGO;
    [SerializeField] Text messageUI;
    public int targetCount;

    
    public static TargetBounds Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        messageGO.SetActive(false);

        Invoke("StartGame", 2f);
    }

    void StartGame()
    {
        MessageUI("Derriba todos los objetivos que puedas en 2 Minutos!");
        Timer.Instance.timerOn = true;
    }

    public async void EndGameFPS()
    {
        AudioManager.instance.PlayGameOver();
        MessageUI("Derribaste " + targetCount + " objetivos! Buen trabajo!");
        await Task.Delay(5000);
        SceneManager.LoadScene("main");
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 center = col.center + transform.position;

        float minX = center.x - col.size.x / 2f;
        float maxX = center.x + col.size.x / 2f;

        float minY = center.y - col.size.y / 2f;
        float maxY = center.y + col.size.y / 2f;

        float minZ = center.z - col.size.z / 2f;
        float maxZ = center.z - col.size.z / 2f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        return randomPosition;
    }

    public async void MessageUI(string message)
    {
        messageGO.SetActive(true);
        messageUI.text = message;
        messageGO.SetActive(true);
        await Task.Delay(5000);
        messageGO.SetActive(false);
//      messageUI.enabled = false;
    }

    public void TargetCount()
    {
        targetCount++;
        targetCountText.text = targetCount.ToString();
    }


}
