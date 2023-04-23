using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Datas/Bullet Data", order = 0)]
public class BulletData : ScriptableObject
{
    [SerializeField] BulletInfo m_info;

    public BulletInfo GetBulletInfo()
    {
        return new BulletInfo()
        {
            profile = this.m_info.profile,
            mulATK = this.m_info.mulATK,
            speed = this.m_info.speed
        };
    }
}
