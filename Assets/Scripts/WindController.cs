using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController current;
    public Vector3 currentWind;

    void Awake()
    {
        current = this;
        if(currentWind == Vector3.zero)
        {
            currentWind = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        }
    }
    void Update()
    {
        windEvolution();
    }

    public void windEvolution()
    {
        currentWind.x += Random.Range(-5.0f, 5.0f) / 1000;
        currentWind.z += Random.Range(-5.0f, 5.0f) / 1000;
    }
}
