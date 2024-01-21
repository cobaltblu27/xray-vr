using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    private float initSize;
    private TextMeshProUGUI text;
    private Vector3 initPos;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        initSize = GetComponent<TextMeshProUGUI>().fontSize;
    }
    private void Update()
    {
        if (text.alpha >= 1)
        {
            StartCoroutine(DestroyThis());
        }
    }
    IEnumerator DestroyThis()
    {
        float timer = 1.5f;
        while (timer >= 0)
        {
            this.transform.position = this.transform.position + Vector3.up * Time.deltaTime * 0.1f;
            text.fontSize -= initSize * Time.deltaTime * 0.01f;
            timer -= Time.deltaTime;

            yield return null;
        }
        text.alpha = 0.0f;
        this.transform.position = initPos;
        text.fontSize = initSize;
    }
}
