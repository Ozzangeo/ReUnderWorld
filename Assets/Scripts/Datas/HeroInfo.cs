using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HeroInfo
{
    public Sprite profile;

    [Space(10.0f)]
    public int ATK = 0;

    public int HP { get => m_HP; set { m_HP = Mathf.Clamp(value, 0, MAX_HP); } }
    public int MAX_HP = 0;
    private int m_HP = 0;

    public int MP { get => m_MP; set { m_MP = Mathf.Clamp(value, 0, MAX_MP); } }
    public int MAX_MP = 0;
    private int m_MP = 0;
    
    public int DEF = 0;
    public float SPD = 5.0f;
    public float DEX = 1.0f;

    public void Reset()
    {
        m_HP = MAX_HP;
        m_MP = MAX_MP;
    }

    public int GetDamage(HeroInfo target, bool ignore = false) => Mathf.Clamp((ignore ? 0 : this.DEF) - target.ATK, -target.ATK, 0);
    public int GetDamage(int atk, bool ignore = false) => Mathf.Clamp((ignore ? 0 : this.DEF) - atk, -atk, 0);
}
