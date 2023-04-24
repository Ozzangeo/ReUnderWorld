using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGroup : MonoBehaviour
{
    private Bullet[] m_bullets = new Bullet[0];
    [HideInInspector] public float angle = 0;
    [HideInInspector] public int targetATK = 0;

    void Start() {
        if (m_bullets.Length < transform.childCount) { m_bullets = GetComponentsInChildren<Bullet>(); }

        Setting(targetATK);
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
        foreach (Bullet bullet in m_bullets) {
            bullet.trueDamage = Convert.ToInt32(bullet.Info.mulATK * ATK);
        }
    }
}
