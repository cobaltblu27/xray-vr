using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public static void SceneInit()
    {
        SceneManager.LoadScene(0);
    }
    public static void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }
}
