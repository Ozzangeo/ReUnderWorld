using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGroup : MonoBehaviour
{
    [SerializeField] Bullet[] m_bullets;
    [HideInInspector] public float angle = 0;

    void Start() {
        if (m_bullets.Length <= 0) { m_bullets = GetComponentsInChildren<Bullet>(); }
    }

    void Update()
    {
        Vector3 angle = transform.localEulerAngles;
        angle.z += this.angle * Time.deltaTime;
        transform.localEulerAngles = angle;

        if(transform.childCount <= 0) { Destroy(gameObject); }
    }

    public void Setting(float ATK)
    {
        foreach (Bullet bullet in m_bullets) { bullet.trueDamage = Convert.ToInt32(bullet.Info.mulATK * ATK); }
    }
}
