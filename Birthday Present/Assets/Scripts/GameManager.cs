using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int coins;
    public SceneRandomiser sceneRandomiser;
    public TextMeshProUGUI coinsText;

    private void Start()
    {

        instance = this;
        sceneRandomiser = GetComponent<SceneRandomiser>();
        //if(PlayerPrefs.GetInt("Highestlevel")< 1)
        //{
        //    PlayerPrefs.SetInt("HighestLevel", 1);
        //}
        
    }

    private void Update()
    {
        if (coinsText != null)
        {
            coinsText.text = coins.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey("HighestLevel");
            Debug.Log("ERASED");
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVBERT");
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;
        ParticleSystem.EmissionModule particles = player.GetComponentInChildren<ParticleSystem>().emission;
        particles.enabled = false;
        

        Invoke("ResetLevel", 1.5f);
    }

    public void GameWon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if(PlayerPrefs.GetInt("HighestLevel") < SceneManager.GetActiveScene().buildIndex + 1)
        {
            PlayerPrefs.SetInt("HighestLevel", SceneManager.GetActiveScene().buildIndex + 1);

        }
        Debug.Log(PlayerPrefs.GetInt("HighestLevel"));
    }

    public void ResetLevel()
    {
        coins = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //sceneRandomiser.LoadNextScene();
    }
}
