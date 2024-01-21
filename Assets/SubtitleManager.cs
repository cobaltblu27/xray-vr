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
    [SerializeField] TextMeshProUGUI subtitle;
    [SerializeField] private float typingSpeed = 0.04f;

    [SerializeField] private UnityEvent onEnd;

    private void Start()
    {
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

        onEnd.Invoke();
        yield return null;
    }

    string s1 = "안녕하세요, 친구들! 반가워요. 나는 레이에요. 오늘은 특별한 여정에 함께 나가볼까요?";
    string s2 = "이곳은 병원 친구들의 비밀스러운 세계, 그리고 여러분의 놀라운 특별한 능력을 발견할 수 있는 곳이에요.";

    string s3 = "대단한 여정이 시작되었어요! 이제 여러분, 지정된 자리로 이동해 X-ray의 마법을 체험해볼까요? 마치 퍼즐 조각을 맞추듯, 여러분의 특별한 능력을 발휘해 보세요.";

    private string s4 =
        "멋져요! 이제 벽에 나타난 포즈를 따라해보아요. 이제 커다란 관문이 우리를 향해 천천히 다가올 거에요. 바닥의 원 안에 서서 관문을 통과할 수 있도록 포즈를 지어 보아요! 자세를 잡는 동안에는 움직이면 안돼요!";
}