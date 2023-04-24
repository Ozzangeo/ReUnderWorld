using System;
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

    public float HPS = 0.0f;
    public float MPS = 2.5f;

    [Space(10.0f)]
    public int ReturnScore = 0;
    public int ReturnPoint = 0;
    public int ReturnExp = 0;

    public IEnumerator Update()
    {
        float mp = 0.0f;
        float hp = 0.0f;

        while(true)
        {
            mp += MPS * Time.deltaTime;
            hp += HPS * Time.deltaTime;

            yield return new WaitForFixedUpdate();

            int t_mp = Convert.ToInt32(Mathf.Floor(mp));
            int t_hp = Convert.ToInt32(Mathf.Floor(hp));

            m_MP = Mathf.Clamp(m_MP + t_mp, 0, MAX_MP);
            m_HP = Mathf.Clamp(m_HP + t_hp, 0, MAX_HP);

            mp -= t_mp;
            hp -= t_hp;
        }
    }

    public void Reset()
    {
        m_HP = MAX_HP;
        m_MP = MAX_MP;
    }

    public int GetDamage(HeroInfo target, bool ignore = false) => Mathf.Clamp((ignore ? 0 : this.DEF) - target.ATK, -target.ATK, 0);
    public int GetDamage(int atk, bool ignore = false) => Mathf.Clamp((ignore ? 0 : this.DEF) - atk, -atk, 0);
}
