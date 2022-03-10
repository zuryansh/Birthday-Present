using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transition ;
    public GameObject PauseScreen;

    public void LoadScene(string scene)
    {
        Debug.Log("LOAD");
        Time.timeScale = 1;
        StartCoroutine(Transition(scene));

    }

    IEnumerator Transition(string name)
    {
        //play animation
        if (transition != null)
        {
            transition.SetTrigger("Fade");
        }
        //GameManager.instance.ToggleAudio(false);

        //wait
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(name);
    }

    public void PauseGame()
    {
        StartCoroutine(DelayedPause());
    }

    IEnumerator DelayedPause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            PauseScreen.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            PauseScreen.SetActive(false);
            yield return new WaitForSecondsRealtime(2f);
            //Debug.Log("UNPAUSE");
            Time.timeScale = 1;
        }

    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index+1);
        Debug.Log(QualitySettings.GetQualityLevel()+1);
    }
}
