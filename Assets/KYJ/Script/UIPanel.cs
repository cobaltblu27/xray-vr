using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static System.Net.Mime.MediaTypeNames;
using Unity.VisualScripting;
public class UIPanel : MonoBehaviour
{
    [SerializeField] private Slider statusBar;
    [SerializeField] private Animator textBoxAnimator;
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
            textBoxAnimator.gameObject.SetActive(true);
            statusBar.enabled = true;
            textBoxAnimator.SetBool("TextOn", true);
            PoseCheck();
        }
        else
        {
            statusBar.enabled = false;
            textBoxAnimator.SetBool("TextOn", false);
        }
    }

    void PoseCheck()
    {
        statusBar.value = statusValue;
        if (!stay)
        {
            statusValue -= Time.deltaTime;
            if (statusValue >= 1.0f && statusValue <= 2.9f)
            {
                cheerTxt.alpha = 1;
                goodTxt.alpha = 0;
            }
        }
        else
        {
            statusValue += Time.deltaTime;
            if (statusValue >= 3f && statusValue >= 4.9f)
            {
                goodTxt.alpha = 1;
                cheerTxt.alpha = 0;
            }
        }
        if (statusBar.value == 5)
        {
            clearTxt.alpha = 1;
            textBoxAnimator.SetBool("TextOn", true);
        }
    }
}
