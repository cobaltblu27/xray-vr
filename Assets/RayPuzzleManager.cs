using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayPuzzleManager : MonoBehaviour
{
    public SubtitleManager IntroCanvas;
    public PuzzleManager Puzzle;
    public GameObject PoseWall;
    public SubtitleManager PoseCanvas;
    
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
        Puzzle.StartPuzzle();
        StartCoroutine(SolvePuzzle());
    }

    // for debugging
    IEnumerator SolvePuzzle()
    {
        yield return new WaitForSeconds(5);
        Puzzle.SolvePuzzle();
    }

    public void ToPose()
    {
        stage = Stage.POSE;
        IntroCanvas.gameObject.SetActive(false);
        PoseCanvas.gameObject.SetActive(true);
    }

    public void StartPose()
    {
        Puzzle.gameObject.SetActive(false);
        PoseWall.SetActive(true);
    }
    
    public void ToXrayScene()
    {
        SceneManager.LoadScene("X_rayScene");
    }
}
