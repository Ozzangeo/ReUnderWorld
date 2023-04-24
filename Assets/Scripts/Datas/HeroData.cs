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
            DEF = this.m_info.DEF,

            SPD = this.m_info.SPD,
            DEX = this.m_info.DEX,

            HPS = this.m_info.HPS,
            MPS = this.m_info.MPS,

            ReturnScore = this.m_info.ReturnScore,
            ReturnPoint = this.m_info.ReturnPoint,
            ReturnExp = this.m_info.ReturnExp,
        };
        info.Reset();

        return info;
    }
}
