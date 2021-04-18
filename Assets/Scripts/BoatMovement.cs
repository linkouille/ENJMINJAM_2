using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotaSpeed;
    [SerializeField] private float maxAngle;

    [SerializeField] private GliderMovement gM;
    [SerializeField] private Transform model;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        Vector3 input = Vector3.up * Input.GetAxis("Horizontal2");

        model.Rotate(input * rotaSpeed * Time.deltaTime);

        float angleWithBoat = Vector3.Angle(gM.dirToKiteProj, model.forward);
        float accB = Mathf.Clamp((maxAngle - angleWithBoat) / maxAngle, 0, 1f);


        rb.velocity = Vector3.ProjectOnPlane(model.forward, Vector3.up).normalized * speed * (gM.acc - 0.1f) * accB;

    }

}
