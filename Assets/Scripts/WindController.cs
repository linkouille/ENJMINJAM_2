using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController current;
    public Vector3 currentWind;

    void Start()
    {
        current = this;
        currentWind = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
    }
    void Update()
    {
        windEvolution();
    }

    private WindController()
    {

    }

    public Vector3 getCurrentWind()
    {
        return currentWind;
    }


    public void windEvolution()
    {
        currentWind.x += Random.Range(-5.0f, 5.0f) / 1000;
        currentWind.y += Random.Range(-5.0f, 5.0f) / 1000;
    }
}
