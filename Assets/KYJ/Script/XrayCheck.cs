using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class XrayCheck : MonoBehaviour
{
    [SerializeField] private UIPanel panel;

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

    private float failScore = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        head = ScoreManager.Instance.head;
        leftArm = ScoreManager.Instance.leftArm;
        rightArm = ScoreManager.Instance.rightArm;
        leftHand = ScoreManager.Instance.leftHand;
        rightHand = ScoreManager.Instance.rightHand;
    }

    private void OnTriggerStay(Collider other)
    {
        panel.stage = true;
    }
    private void Update()
    {
        Debug.Log(panel.stay);
        Debug.Log(panel.stage);
        
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //TODO put score in singlton
        if (other.transform.root.CompareTag("Player"))
            CheckPose();
    }
    private void CheckPose()
    {
        float maxDistance = (head.transform.position - headP.position).magnitude;
        if ((leftArm.transform.position - leftArmP.position).magnitude > maxDistance)
            maxDistance = (leftArm.transform.position - leftArmP.position).magnitude;
        if ((leftHand.transform.position - leftHandP.position).magnitude > maxDistance)
            maxDistance = (leftHand.transform.position - leftHandP.position).magnitude;
        if ((rightHand.transform.position - rightHandP.position).magnitude > maxDistance)
            maxDistance = (rightHand.transform.position - rightHandP.position).magnitude;
        if ((rightArm.transform.position - rightArmP.position).magnitude > maxDistance)
            maxDistance = (rightArm.transform.position - rightArmP.position).magnitude;
        if (maxDistance < failScore) panel.stay = true;
        else panel.stay = false;
    }

}
