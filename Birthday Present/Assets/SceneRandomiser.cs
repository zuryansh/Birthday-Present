using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRandomiser : MonoBehaviour
{
    public List<int> PossibleSceneNums = new List<int>();
    public List<int> CurrentSceneNums = new List<int>();

    public int currentSceneListIndex;

    public int numberOfScenes;

    private void Start()
    {
        GetCurrentScenes();
        currentSceneListIndex = 0;
    }

    int PickRandomScene()
    {

        int randomScene;


        randomScene = PossibleSceneNums[Random.Range(0, PossibleSceneNums.Count)]; // get a random scene
        PossibleSceneNums.Remove(randomScene); // remove that scene so it dosent get picked twice

        //return SceneManager.GetSceneByBuildIndex(randomScene); // return the scene
        return randomScene;
    }

    void GetCurrentScenes()
    {
        if (numberOfScenes > PossibleSceneNums.Count)
        {
            Debug.LogError("Cannot make a list larger than possible scene count");
            return;
        }


        for (int i = 0; i < numberOfScenes; i++)
        {
            CurrentSceneNums.Add(PickRandomScene());
        }
    }




    public void LoadNextScene()
    {
        currentSceneListIndex++;
        Debug.Log(currentSceneListIndex);
        SceneManager.LoadScene(CurrentSceneNums[currentSceneListIndex]);
        
    }
}

