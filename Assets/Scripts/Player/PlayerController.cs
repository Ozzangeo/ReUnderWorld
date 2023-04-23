using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [Space(10.0f)]
    [SerializeField] Vector2 m_minPos = Vector2.zero;
    [SerializeField] Vector2 m_maxPos = Vector2.zero;

    void Update()
    {
        Vector3 pos = transform.position;
        float speed = this.speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift)) { speed *= 0.6f; }

        pos.x = Mathf.Clamp(pos.x + (Input.GetAxisRaw("Horizontal") * speed), m_minPos.x, m_maxPos.x);
        pos.y = Mathf.Clamp(pos.y + (Input.GetAxisRaw( "Vertical" ) * speed), m_minPos.y, m_maxPos.y);

        transform.position = pos;
    }
}
