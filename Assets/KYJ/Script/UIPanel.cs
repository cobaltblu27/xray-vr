using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static System.Net.Mime.MediaTypeNames;
public class UIPanel : MonoBehaviour
{
    [SerializeField] private Slider statusBar;
    [SerializeField] private TextMeshProUGUI clearTxt;
    [SerializeField] private TextMeshProUGUI cheerTxt;
    [SerializeField] private TextMeshProUGUI goodTxt;

    private float statusValue;

    public bool stage;
    public bool stay;
    private void Start()
    {
        statusValue = Mathf.Clamp(0, 0, 5);
        statusBar.maxValue = 5;
        statusBar.minValue = 0;
    }
    void Update()
    {
        if (stage)
        {
            statusBar.enabled = true;
            PoseCheck();
        }
        else
        {
            statusBar.enabled = false;
            statusValue = 0;
        }
    }

    void PoseCheck()
    {
        if (!stay)
        {
            statusValue -= 1;
            if (statusValue == 2.0f)
            {
                cheerTxt.alpha = 1.0f;
            }
        }
        else
        {
            statusValue += Time.deltaTime;
            if (statusValue == 2.5f)
            {
                goodTxt.alpha = 1.0f;
            }
        }
        if (statusBar.value == 5)
        {
            clearTxt.alpha += Time.deltaTime;
        }
        statusBar.value = statusValue;
    }
}
