using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPenal : MonoBehaviour
{
    [SerializeField] private Slider statusBar;
    [SerializeField] private Text[] texts;

    private float statusValue;

    public IEnumerator StatusCoroutine(float timer)
    {
        float stopTime = 3;
        while (stopTime >= 3) 
        {
            stopTime -= Time.deltaTime;
            statusValue = stopTime;
            statusBar.value = statusValue;

            yield return new WaitForSeconds(stopTime);

        }

        statusValue = 3;
        statusBar.value = statusValue;
    }
}
