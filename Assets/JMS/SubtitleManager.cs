using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SubtitleManager : MonoBehaviour
{
    [SerializeField] string[] subtitles;
    [SerializeField] float[] timers;
    public GameObject canvas;
    [SerializeField]
    TextMeshProUGUI subtitle;
    [SerializeField]
    private float typingSpeed = 0.04f;
    public Animator animator;

    [SerializeField] private UnityEvent onEnd;
    private void Start()
    {
        animator.SetTrigger("Excite");
        animator.SetBool("Talk", true);
        StartSub();
    }

    public void StartSub()
    {
        //canvas.SetActive(true);
        StartCoroutine(SubtitleSwitch());
    }

    IEnumerator SubtitleSwitch()
    {
        int i = 0;
        while (i < subtitles.Length)
        {
            subtitle.text = "";
            foreach (char letter in subtitles[i].ToCharArray())
            {
                subtitle.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSeconds(3f);
            i++;
        }
        animator.SetBool("Talk", false);
        onEnd.Invoke();
        yield return null;
    }
}