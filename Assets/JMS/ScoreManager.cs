using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ScoreManager");
                    instance = obj.AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftArm;
    public GameObject rightArm;
    public TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI perfectUI;
    [SerializeField]
    private TextMeshProUGUI goodUI;
    [SerializeField]
    private TextMeshProUGUI failUI;
    [SerializeField]
    private float fadeTime = 1.0f;
    public void Failed()
    {
        Debug.Log("failed");
        failUI.fontMaterial.SetColor("_FaceColor", Color.red);
        StartCoroutine(FadeCoroutine(failUI));
        //목숨 -1;
        //게이지 끊기
    }

    public void Good()
    {
        Debug.Log("good");
        goodUI.fontMaterial.SetColor("_FaceColor", Color.green);
        StartCoroutine(FadeCoroutine(goodUI));
        //UITimer(goodUI);
        //if(게이지 off)
        //Startgaugeing
    }
    public void Perfect()
    {
        Debug.Log("perfect");
        perfectUI.fontMaterial.SetColor("_FaceColor", Color.blue);
        StartCoroutine(FadeCoroutine(perfectUI));
        //UITimer(perfectUI);
        //if(게이지 off)
        //Startgaugeing
    }

    IEnumerator FadeCoroutine(TextMeshProUGUI text)
    {
        float duration = 1f; //Fade out over 2 seconds.
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;

    }




}
