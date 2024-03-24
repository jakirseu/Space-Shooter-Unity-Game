using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralSpawner : MonoBehaviour
{
    public float maxTime = 1.1f;
    public GameObject[] Mineral;
    public float speed = 3;
    private float timer;
    public float height = 2;

    void Start()
    {
        
    }

  
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newMeneral = Instantiate(Mineral[Random.Range(0, Mineral.GetLength(0))]);
            newMeneral.transform.position = transform.position + new Vector3(Random.Range(-height, height), 0, 0);
            newMeneral.transform.Rotate(Random.Range(1, 10), Random.Range(1, 10), Random.Range(10, 100) * Time.deltaTime);
            Destroy(newMeneral, 10);
            timer = 0;
        }



        timer += Time.deltaTime;
    }
}
