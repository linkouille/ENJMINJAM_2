using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    private static WindController _currentWC = null;
    static readonly object instanceLock = new object();
    public Vector3 currentWind;

    // Start is called before the first frame update
    void Start()
    {
        currentWind = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
    }

    // Update is called once per frame
    void Update()
    {
        windEvolution();
    }

    private WindController()
    {

    }

    public static WindController getWindController
    {
        get
        {
            if (_currentWC == null)
            {
                lock (instanceLock)
                {
                    if (_currentWC == null)
                        _currentWC = new WindController();
                }
            }
            return _currentWC;
        }
    }

    public Vector3 getCurrentWind()
    {
        return currentWind;
    }


    public void windEvolution()
    {
        currentWind.x += Random.Range(0.0f, 10.0f) / 1000;
        currentWind.y += Random.Range(0.0f, 10.0f) / 1000;
    }
}
