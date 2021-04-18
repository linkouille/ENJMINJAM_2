using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{

    public GameObject playerObj;
    private WindController _WC;
    public Vector3 normalizedWind;

    // Start is called before the first frame update
    void Start()
    {
        _WC = WindController.current;

    }

    // Update is called once per frame
    void Update()
    {
        normalizedWind = WindController.current.currentWind.normalized;
        Vector3 offset = new Vector3(0, 3, 0);
        transform.position = Vector3.Slerp(transform.position, playerObj.transform.position + normalizedWind * 15 + offset, 0.1f);
        transform.LookAt(playerObj.transform.position);
    }
}
