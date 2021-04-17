using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderMovement : MonoBehaviour
{
    [SerializeField] private Vector2 boundAngleX;

    public Vector3 windDir;

    private float distToGround;
    private float distToCenter;

    [SerializeField] private Transform kite;

    [SerializeField] private float speed;
    [SerializeField] private float maxHeight;
    [SerializeField] private float maxAngle;
    [SerializeField] private float radius;

    private Vector3 rotation;
    private float acc;

    private void Awake()
    {
        kite = transform.GetChild(0);
        radius = Vector3.Distance(kite.position, transform.position);
        rotation = transform.eulerAngles;
    }

    private void Update()
    {
        Vector3 input = Vector3.up * Input.GetAxis("Horizontal");

        Vector3 dirToKite = kite.position - transform.position;

        Vector3 dirToKiteProj = Vector3.ProjectOnPlane(dirToKite, Vector3.up).normalized;

        Debug.DrawRay(transform.position, dirToKiteProj, Color.red);
        Debug.DrawRay(transform.position, windDir, Color.green);

        float angleWithWind = Vector3.Angle(dirToKiteProj, windDir);

        acc = Mathf.Clamp((maxAngle - angleWithWind)/maxAngle,0,1);

        rotation = input * speed * acc * Time.deltaTime;
        transform.rotation = Quaternion.Euler( transform.eulerAngles + rotation);

        Debug.Log((transform.rotation.eulerAngles.x - 360) * acc);

        transform.rotation = Quaternion.Euler((maxHeight) * acc, transform.eulerAngles.y, transform.eulerAngles.z);

    }

}
