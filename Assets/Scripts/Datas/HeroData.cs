using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero Data", menuName = "Datas/Hero Data", order = 0)]
public class HeroData : ScriptableObject
{
    [SerializeField] HeroInfo m_info;

    public HeroInfo GetStatInfo()
    {
        HeroInfo info = new HeroInfo()
        {
            profile = this.m_info.profile,

            ATK = this.m_info.ATK,
            MAX_HP = this.m_info.MAX_HP,
            MAX_MP = this.m_info.MAX_MP,
            DEF = this.m_info.DEF
        };
        info.Reset();

        return info;
    }
}
