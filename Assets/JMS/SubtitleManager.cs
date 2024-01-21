using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    [SerializeField]
    string[] subtitles;
    [SerializeField]
    float[] timers;
    public GameObject canvas;
    [SerializeField]
    TextMeshProUGUI subtitle;
    [SerializeField]
    private float typingSpeed = 0.04f;
    public Animator animator;
    private Coroutine SubtitleSwitchCoroutine;
    private void Start()
    {
        StartSub();
    }
    public void StartSub()
    {
        //canvas.SetActive(true);
        if (SubtitleSwitchCoroutine != null)
            StopCoroutine(SubtitleSwitch());
        SubtitleSwitchCoroutine = StartCoroutine(SubtitleSwitch());
    }

    IEnumerator SubtitleSwitch()
    {
        
        for (int i =0; i < subtitles.Length; i++)
        {
            subtitle.text = "";
            for (int j = 0; j < subtitles[i].Length; j++)
            {
                subtitle.text = subtitles[i].Substring(0,j+1);
                yield return new WaitForSeconds(typingSpeed);
            }
            yield return new WaitForSeconds(3f);
        }
        //animator.Play("Talk");
        animator.SetBool("Talk", false);
        yield return null;
    }


}
