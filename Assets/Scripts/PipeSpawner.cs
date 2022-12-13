using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float spawnRate = 2;
    [SerializeField] float timer = 0;
    [SerializeField] float pipeHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float highestPoint = transform.position.y + pipeHeight;
        float lowestPoint = transform.position.y - pipeHeight;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0f), transform.rotation);
    }
}
