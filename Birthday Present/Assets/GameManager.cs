using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int coins;
    public SceneRandomiser sceneRandomiser;

    private void Start()
    {

        instance = this;
        sceneRandomiser = GetComponent<SceneRandomiser>();
    }



    public void GameOver()
    {
        Debug.Log("GAME OVBERT");
        FindObjectOfType<PlayerMovement>().enabled = false;
        Invoke("ResetLevel", 1f);
    }

    public void GameWon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //sceneRandomiser.LoadNextScene();
    }
}
