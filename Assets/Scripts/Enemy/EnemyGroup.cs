
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [HideInInspector] public float angle = 0;

    void Update()
    {
        Vector3 angle = transform.localEulerAngles;
        angle.z += this.angle * Time.deltaTime;
        transform.localEulerAngles = angle;

        if (transform.childCount <= 0) { Destroy(gameObject); }
    }
}
