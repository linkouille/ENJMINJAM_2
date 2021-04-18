using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{

    [SerializeField] private Transform target;
    public float lerpSpeed;
    public float rotaSpeed;

    public GameObject Camera;

    private void Update()
    {
        Camera.transform.LookAt(target);
        transform.position = Vector3.Slerp(transform.position, target.position, lerpSpeed);

        transform.Rotate(Vector3.up * -Input.GetAxis("Horizontal3") * rotaSpeed * Time.deltaTime);
    }

}
