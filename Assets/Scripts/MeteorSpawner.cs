using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    public float maxTime = 2;
    public GameObject[] meteor;

    private float timer;
    public float height;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > maxTime)
        {
            GameObject newMeteor = Instantiate(meteor[Random.Range(0, meteor.GetLength(0))]);
            newMeteor.transform.position = transform.position + new Vector3(Random.Range(-height, height),0,  0);
            Destroy(newMeteor, 15);
            timer = 0;
        }

        timer += Time.deltaTime;


    }
}
