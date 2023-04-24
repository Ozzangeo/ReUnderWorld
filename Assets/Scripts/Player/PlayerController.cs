using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance => m_instance;
    private static PlayerController m_instance;

    [SerializeField] HeroData m_startHeroData;
    public HeroInfo NowStat => m_nowStat;
    private HeroInfo m_nowStat;

    public int Lv = 1;
    public int NextExp => m_nextExp;
    [SerializeField] int m_nextExp = 10;
    public int Exp = 0;

    public Vector2 MinPos => m_minPos;
    public Vector2 MaxPos => m_maxPos;
    public float Speed => m_speed;
    private float m_speed;

    [Space(10.0f)]
    [SerializeField] Vector2 m_minPos = Vector2.zero;
    [SerializeField] Vector2 m_maxPos = Vector2.zero;
    [SerializeField] Vector2 m_offsetPos = Vector2.zero;
    public const float SLOW_SPD = 0.6f;

    [Space(10.0f)]
    [SerializeField] SpriteRenderer m_spriterenderer;

    void Awake() { if (PlayerController.m_instance == null) { PlayerController.m_instance = this; } }

    void Start()
    {
        m_minPos += m_offsetPos;
        m_maxPos += m_offsetPos;

        transform.position = m_offsetPos;

        m_nowStat = m_startHeroData.GetStatInfo();

        if (m_spriterenderer == null) { m_spriterenderer = GetComponent<SpriteRenderer>(); }

        StartCoroutine(m_nowStat.Update());
    }

    void Update()
    {
        Vector3 pos = transform.position;
        m_speed = m_nowStat.SPD * (Input.GetKey(KeyCode.LeftShift) ? SLOW_SPD : 1.0f);

        pos.x = Mathf.Clamp(pos.x + (Input.GetAxisRaw("Horizontal") * m_speed * Time.deltaTime), m_minPos.x, m_maxPos.x);
        pos.y = Mathf.Clamp(pos.y + (Input.GetAxisRaw( "Vertical" ) * m_speed * Time.deltaTime), m_minPos.y, m_maxPos.y);

        transform.position = pos;

        LevelUpCheck();
    }

    void LevelUpCheck()
    {
        if (Exp >= m_nextExp)
        {
            Exp -= m_nextExp;
            m_nextExp = Convert.ToInt32(m_nextExp * 1.5f);

            m_nowStat.ATK += 1 + Convert.ToInt32(Lv * 0.1f);
            m_nowStat.MAX_HP += 2 + Convert.ToInt32(Lv * 0.2f);
            m_nowStat.MAX_MP += 3 + Convert.ToInt32(Lv * 0.3f);
            m_nowStat.DEF += Convert.ToInt32(Lv % 4 == 0);
            m_nowStat.DEX += Convert.ToSingle(Lv % 10 == 0) * 0.2f;

            m_nowStat.HPS += Convert.ToSingle(Lv % 15 == 0) * 0.4f;
            m_nowStat.MPS += Convert.ToSingle(Lv % 3 == 0) * 1.1f;

            Lv++;

            GameDirector.Instance.AddScore(Lv * 100);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent<EnemyController>(out var enemy)) {
                enemy.NowStat.HP += enemy.NowStat.GetDamage(m_nowStat);
                enemy.HitMotion();
            }
        }    
    }

    public void HitMotion() { CoroutineEffector.Instance.HitEffect(m_spriterenderer); }
}
