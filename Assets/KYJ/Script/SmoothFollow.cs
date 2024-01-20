using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] public Transform obj;
    [SerializeField] public Transform obj_base;
    public float speed = 0.2f;

    public IEnumerator ObjectMove()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 3f && obj.position != obj_base.position)
        {
            elapsedTime += Time.deltaTime * speed;
            obj.position = Vector3.Lerp(obj.position, obj_base.position, elapsedTime / 3.0f);
            obj.rotation = Quaternion.Lerp(obj.rotation, obj_base.rotation, elapsedTime / 3.0f);
            yield return null;
        }
        obj.rotation = obj_base.rotation;
        obj.position = obj_base.position;
    }
}