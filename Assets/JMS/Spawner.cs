using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Walls;
    [SerializeField]
    private Transform spawnLocation;
    public float beat = 60/105;
    private float timer;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > beat)
        {
            GameObject wall = Instantiate(Walls[Random.Range(0, 4)], spawnLocation);
            wall.transform.localPosition = Vector3.zero;
            timer -= beat;
        }
        timer += Time.deltaTime;
    }
    
}
