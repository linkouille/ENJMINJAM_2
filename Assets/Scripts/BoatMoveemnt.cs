using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMoveemnt : MonoBehaviour
{

    [SerializeField] private GliderMovement gM;

    [SerializeField] private float speed;

    [SerializeField] private float C;

    [SerializeField] private Vector3 dir;

    private Vector3 gouvenailDir;

    private float acc;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float m = gM.angleWithWind;
        float o = Vector3.Angle(gM.dirToKiteProj, dir);

        acc = C * Mathf.Cos(m) * Mathf.Cos(m) * Mathf.Sin(o) * WindController.current.currentWind.sqrMagnitude;


    }
}
