using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public static void SceneInit()
    {
        SceneManager.LoadScene(0);
    }
    public static void SceneChange()
    {
        GameManager.Instance.lifeCount = 3;
        GameManager.Instance.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
