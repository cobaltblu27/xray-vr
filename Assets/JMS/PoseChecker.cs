using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoseChecker : MonoBehaviour
{
    public Transform headP;
    public Transform leftHandP;
    public Transform rightHandP;
    public Transform leftArmP;
    public Transform rightArmP;

    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftArm;
    public GameObject rightArm;

    [SerializeField]
    private float perfectScore;
    [SerializeField]
    private float failScore;
    //public TextMeshProUGUI text;
    [SerializeField]
    private float speed = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        head = ScoreManager.Instance.head;
        leftArm = ScoreManager.Instance.leftArm;
        rightArm = ScoreManager.Instance.rightArm;
        leftHand = ScoreManager.Instance.leftHand;
        rightHand = ScoreManager.Instance.rightHand;
        //text = ScoreManager.Instance.scoreText;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,0.1f*speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        //TODO put score in singlton
        if(other.transform.root.CompareTag("Player"))
            CheckPose();
    }
    private void CheckPose()
    {
        float maxDistance = (head.transform.position - headP.position).magnitude;
        if ((leftArm.transform.position - leftArmP.position).magnitude > maxDistance)
            maxDistance = (leftArm.transform.position - leftArmP.position).magnitude;
        if ((leftHand.transform.position - leftHandP.position).magnitude > maxDistance)
               maxDistance = (leftHand.transform.position - leftHandP.position).magnitude;
        if((rightHand.transform.position - rightHandP.position).magnitude > maxDistance)
            maxDistance = (rightHand.transform.position - rightHandP.position).magnitude;
        if ((rightArm.transform.position - rightArmP.position).magnitude > maxDistance)
            maxDistance = (rightArm.transform.position - rightArmP.position).magnitude;
        Debug.Log("maxDistance:" + GameManager.Instance.score);
        //text.text = "score: " + GameManager.Instance.score;
        if (maxDistance > failScore)
        ScoreManager.Instance.Failed();
        else if (maxDistance > perfectScore)
        ScoreManager.Instance.Good();
        else
        ScoreManager.Instance.Perfect();

        Destroy(gameObject, 3f);

    }

}
