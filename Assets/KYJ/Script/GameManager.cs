using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneFade sceneFade;

    public int lifeCount = 3;
    public int score = 0;

    private bool check;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>(); 
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance != null)
        {
            if (_instance != this)
            {
                Destroy(this);
            }
            return;
        }
        _instance = GetComponent<GameManager>(); 
        DontDestroyOnLoad(gameObject);
    }
     void Update()
     {
        if (score >= 4)
        {
            Success();
        }
        if (lifeCount == 0)
        {
            Fail();
        }
     }
    public void Success()
    {
        StartCoroutine(SceneChange());
    }
    public void Fail()
    {
        StartCoroutine(SceneInit());
    }
    private IEnumerator SceneChange()
    {
        while (true)
        {
            sceneFade.FadeIn();

            yield return new WaitForSeconds(3);
            SceneChanger.SceneChange();
        }
    }
    private IEnumerator SceneInit()
    {
        while (true)
        {
            sceneFade.FadeIn();

            yield return new WaitForSeconds(3);
            SceneChanger.SceneInit();
        }
    }
}
