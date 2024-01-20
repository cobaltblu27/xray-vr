using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIPanel : MonoBehaviour
{
    [SerializeField] private Slider statusBar;
    [SerializeField] private TextMeshProUGUI texts;

    private float statusValue;

    public bool success;
    void Update()
    {
        if (success) StartCoroutine(StatusCoroutine(3));
    }

    //X-ray Scene, Tutorial
    public IEnumerator StatusCoroutine(float timer)
    {
        float stopTime = 0;
        while (stopTime <= 3) 
        {
            stopTime += Time.deltaTime;
            statusValue = stopTime;
            statusBar.value = statusValue;
            texts.text = "" + statusValue;
            Debug.Log(stopTime);
            yield return new WaitForSeconds(timer);
        }
        statusValue = 0;
        statusBar.value = statusValue;
    }
}
