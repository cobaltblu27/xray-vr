using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lifeCount = 3;

    private bool check;
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            Fail();
        }
    }
    public void Fail()
    {
        StartCoroutine(SceneChange());
    }
    private IEnumerator SceneChange()
    {
        while (true)
        {
            SceneChanger.SceneChange();
        }
    }
}
