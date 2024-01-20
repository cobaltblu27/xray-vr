using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;
public class UIPanel : MonoBehaviour
{
    [SerializeField] private Slider statusBar;
    [SerializeField] private GameObject[] texts;

    private float statusValue;

    private bool success;
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            StatusCheck();
        }
    }
    public void StatusCheck()
    {
         StartCoroutine(StatusCoroutine(2));
    }

    public IEnumerator StatusCoroutine(float timer)
    {
        float stopTime = 2;
        while (success) 
        {
            stopTime -= Time.deltaTime;
            statusValue = stopTime;
            statusBar.value = statusValue;
            Debug.Log(stopTime);
            yield return new WaitForSeconds(timer);
            success = false;
        }
        texts[0].SetActive(true);
        statusValue = 2;
        statusBar.value = statusValue;
    }
}
