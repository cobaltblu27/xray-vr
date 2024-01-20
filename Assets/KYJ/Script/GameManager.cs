using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lifeCount = 3;
    
    void Awake()
    {

    }
    void Update()
    {
        StartCoroutine(Fail(4,lifeCount));
    }
    private IEnumerator Fail(float timer, int life)
    {
        while (lifeCount > 0)
        {


            yield return null;
        }

    }
}
