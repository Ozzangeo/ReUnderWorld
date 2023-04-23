using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero Data", menuName = "Datas/Hero Data", order = 0)]
public class HeroData : ScriptableObject
{
    [SerializeField] StatInfo info;

    public StatInfo GetStatInfo()
    {
        StatInfo info = new StatInfo()
        {
            profile = this.info.profile,

            ATK = this.info.ATK,
            MAX_HP = this.info.MAX_HP,
            MAX_MP = this.info.MAX_MP,
            DEF = this.info.DEF
        };
        info.Reset();

        return info;
    }
}
