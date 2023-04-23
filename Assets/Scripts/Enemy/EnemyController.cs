using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] HeroData m_startHeroData;
    [SerializeField] PatternData m_patterns;
    private int m_index = 0;

    public StatInfo NowStat => nowStat;
    private StatInfo nowStat;

    [Space(10.0f)]
    [SerializeField] SpriteRenderer m_sprite;

    void Start()
    {
        nowStat = m_startHeroData.GetStatInfo();

        if (m_patterns == null) { Destroy(gameObject); }
        if (m_sprite == null) { m_sprite = GetComponent<SpriteRenderer>(); }

        m_sprite.sprite = nowStat.profile;
    }
}
