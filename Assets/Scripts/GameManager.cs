using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public Text messageUI;
    public Text items;
    int itemType;
    int itemCount;
    GameObject player;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        messageUI.gameObject.SetActive(false);
        player = GameObject.Find("Recolectora");
        itemCount = 0;

        itemType = Random.Range(0,2);
        switch (itemType)
        {
            case 0:
                MessageUI("Debes juntar 5 latas en menos de 2 minutos!");

                GameType(itemType);
                break;
            case 1:
                MessageUI("Debes juntar 5 botellas en menos de 2 minutos!");
                GameType(itemType);
                break;
            case 2:
                MessageUI("Debes juntar 5 vasos en menos de 2 minutos!");
                GameType(itemType);
                break;
        }

        DontDestroyOnLoad(gameObject);
    }

    public async void MessageUI(string message)
    {
        messageUI.text = message;
        messageUI.gameObject.SetActive(true);
        await Task.Delay(5000);
        messageUI.gameObject.SetActive(false);
    }

    public void GameType(int gameType)
    {
        switch (gameType)
        {
            case 0:
            default:
                break;
        }
    }

    public async void EndGame()
    {
        //TODO

        player.GetComponent<NavMeshAgent>().enabled = false;
        player.GetComponent<Animator>().SetTrigger("EndGame");
        
        MessageUI("Fin del Juego :(");
        await Task.Delay(6000);
        SceneManager.LoadScene("main");
    }

    public async void CountItem()
    {
        itemCount++;
        items.text = itemCount.ToString() + "/5";
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().SetTrigger("Pickup");
        await Task.Delay(1500);
        player.GetComponent<PlayerMovement>().enabled = true;
    }


}
