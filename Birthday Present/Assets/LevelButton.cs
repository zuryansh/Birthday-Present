using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public int levelNum;

    private void Start()
    {
        if (levelNum > PlayerPrefs.GetInt("HighestLevel"))
        {
            gameObject.SetActive(false);
        }
    }
}
