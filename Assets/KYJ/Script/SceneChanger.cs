using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
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
