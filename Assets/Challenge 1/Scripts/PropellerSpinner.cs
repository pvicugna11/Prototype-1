using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpinner : MonoBehaviour
{
    private float rotationSpeed = 1.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward, 360 * Time.deltaTime * rotationSpeed);
    }
}
