using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phaze{
    Puzzle,
    Wall,
    Tutorial
}
public class WaitingRoom : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    [SerializeField] private GameObject wallSpawner;
    [SerializeField] private GameObject tutorialObj;


    //public bool PuzzleCheck = false;
    public static Phaze phaze;
    public bool phazeClear;
    private void Start()
    {
        phaze = Phaze.Puzzle;
    }
    void Update()
    {
        switch (phaze)
        {
            case Phaze.Puzzle:
                StartCoroutine(PhazeChange(puzzle));
                if (phazeClear)
                {
                    phaze = Phaze.Wall;
                }
                break;
            case Phaze.Wall:
                phazeClear = false;
                StartCoroutine(PhazeChange(wallSpawner));
                //if (phazeClear)
                //{
                //    phaze = Phaze.Tutorial;
                //}
                break;
            //case Phaze.Tutorial:
            //    if (phazeClear)
            //    {
            //        StartCoroutine(PhazeChange(tutorialObj));
            //    }
            //    break;
        }
    }
    
    IEnumerator PhazeChange(GameObject obj)
    {
        float timer = 3;
        while (timer >= 0)
        {
            timer -= Time.deltaTime;

            yield return null;
        }
        obj.SetActive(true);
    }
}
