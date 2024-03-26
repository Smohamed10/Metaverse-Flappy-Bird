using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject pipe;
    public float timer = 0;
    float spawnrate = 3;

    float randomy = 150;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawn();
            timer = 0;
        }
    }
    void spawn()
    {
        float lowest = transform.position.y + randomy;
        float highest = transform.position.y - randomy;
        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(lowest,highest),transform.position.z), transform.rotation);
    }
}
