using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{

    public static IEnumerator ResetTime(float slowedTime)
    {
        yield return new WaitForSecondsRealtime(slowedTime);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
       
    }

    public void SlowDownTime(float slowDownFactor , float time )
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        StartCoroutine(ResetTime(time));
    }
}
