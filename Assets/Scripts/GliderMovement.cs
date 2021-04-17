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
    private float acc;

    private void Awake()
    {
        kite = transform.GetChild(0);
        rotation = transform.eulerAngles;
    }

    private void Update()
    {
        Vector3 input = Vector3.up * Input.GetAxis("Horizontal");

        Vector3 dirToKite = kite.position - transform.position;

        dirToKiteProj = Vector3.ProjectOnPlane(dirToKite, Vector3.up).normalized;

        Debug.DrawRay(transform.position, dirToKiteProj, Color.red);
        Debug.DrawRay(transform.position, windDir, Color.green);

        angleWithWind = Vector3.Angle(dirToKiteProj, windDir);

        acc = Mathf.Clamp((maxAngle - angleWithWind)/maxAngle,0,1);

        rotation = input * speed * acc * Time.deltaTime;
        transform.rotation = Quaternion.Euler( transform.eulerAngles + rotation);

        Debug.Log((transform.rotation.eulerAngles.x - 360) * acc);

        transform.rotation = Quaternion.Euler((maxHeight) * acc, transform.eulerAngles.y, transform.eulerAngles.z);

    }

}
