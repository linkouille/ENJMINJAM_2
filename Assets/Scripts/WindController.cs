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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private WindController()
    {
        currentWind = new Vector3(8f, 12f);
        //setWindToLocalWind();
    }

    public static WindController getWindController
    {
        get
        {
            if (_currentWC==null)
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

    /*A IMPLEMENTER POUR QUE LE VENT S'ADAPTE AU NIVEAU
    public void setWindToLocalWind()
    {
        
    }*/
}
