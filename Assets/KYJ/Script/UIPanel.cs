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
            textBoxAnimator.SetBool("TextOn", true);
            PoseCheck();
        }
        else
        {
            textBoxAnimator.SetBool("TextOn", false);
        }
    }

    void PoseCheck()
    {
        statusBar.value = statusValue;
        if (!stay)
        {
            statusValue -= Time.deltaTime;
            cheerTxt.alpha = 1;
            goodTxt.alpha = 0;
        }
        else
        {
            statusValue += Time.deltaTime;
            goodTxt.alpha = 1;
            cheerTxt.alpha = 0;
        }
        if (statusBar.value == 5)
        {
            clearTxt.alpha = 1;
            goodTxt.alpha = 0;
            textBoxAnimator.SetBool("TextOn", true);
        }
    }
}
