using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPuzzleManager : MonoBehaviour
{
    public GameObject PuzzleGameObject;
    public GameObject PoseWall;
    public GameObject PoseCanvas;
    
    enum Stage
    {
        INTRO,
        PUZZLE,
        POSE
    }

    private Stage stage = Stage.INTRO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToPuzzle()
    {
        stage = Stage.PUZZLE;
        
    }

    public void ToPose()
    {
        stage = Stage.POSE;
    }

    public void StartPose()
    {
        
    }
    
    public void ToXrayScene()
    {
        
    }
}
