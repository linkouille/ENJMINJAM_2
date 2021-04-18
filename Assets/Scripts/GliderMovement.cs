using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderMovement : MonoBehaviour
{

    public Vector3 windDir;
    public Vector3 dirToKiteProj;
    public float angleWithWind;

    [SerializeField] private Vector2 boundAngleX;

    [SerializeField] private Transform kite;

    [SerializeField] private float speed;
    [SerializeField] private float maxHeight;
    [SerializeField] private float maxAngle;

    private Vector3 rotation;
    public float acc;

    private void Awake()
    {
        kite = transform.GetChild(0);
        rotation = transform.eulerAngles;
    }
    private void Start()
    {
        windDir = WindController.current.currentWind.normalized;
        transform.rotation = Quaternion.LookRotation(new Vector3(windDir.x * Mathf.Cos(maxAngle) - windDir.y * Mathf.Cos(maxAngle), 0,
            windDir.x * Mathf.Sin(maxAngle) + windDir.y * Mathf.Cos(maxAngle)), Vector3.up);
    }

    private void Update()
    {
        Vector3 input = Vector3.up * Input.GetAxis("Horizontal");

        Vector3 dirToKite = kite.position - transform.position;

        dirToKiteProj = Vector3.ProjectOnPlane(dirToKite, Vector3.up).normalized;

        Debug.DrawRay(transform.position, dirToKiteProj, Color.red);
        Debug.DrawRay(transform.position, windDir, Color.green);
        windDir = WindController.current.currentWind.normalized;

        angleWithWind = Vector3.Angle(dirToKiteProj, windDir);

        acc = Mathf.Clamp((maxAngle - angleWithWind)/maxAngle,0,0.9f) + 0.1f;

        rotation = input * speed * (acc) * Time.deltaTime;
        transform.rotation = Quaternion.Euler( transform.eulerAngles + rotation);


        transform.rotation = Quaternion.Euler((maxHeight) * acc, transform.eulerAngles.y, transform.eulerAngles.z);

    }

}
