using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHealthBar : MonoBehaviour
{
    public Transform MainCamare;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + MainCamare.forward);
    }
}
