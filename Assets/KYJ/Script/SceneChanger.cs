using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    private static SceneChanger _instance;
    public static SceneChanger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneChanger>();
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
        _instance = GetComponent<SceneChanger>();
        DontDestroyOnLoad(gameObject);
    }
    public static void SceneInit()
    {
        GameManager.Instance.lifeCount = 3;
        GameManager.Instance.score = 0;
        SceneManager.LoadScene(0);
    }
    public static void SceneChange()
    {
        GameManager.Instance.lifeCount = 3;
        GameManager.Instance.score = 0;
        SceneManager.LoadScene(1);
    }
}
