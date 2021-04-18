using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDIrBousole : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(WindController.current.currentWind.normalized, Vector3.up);
    }
}
