using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneFade sceneFade;

    public int lifeCount = 3;
    public int score = 0;

    private bool clear;
    private bool fail;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>(); 
                //DontDestroyOnLoad(_instance.gameObject);
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
        //DontDestroyOnLoad(gameObject);
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
        clear = true;
    }
    public void Fail()
    {
        StartCoroutine(SceneInit());
        fail = true;
    }
    private IEnumerator SceneChange()
    {
        while (clear)
        {
            sceneFade.FadeOut();

            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(1);
        }
    }
    private IEnumerator SceneInit()
    {
        while (fail)
        {
            sceneFade.FadeOut();

            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(0);
        }
    }
}
