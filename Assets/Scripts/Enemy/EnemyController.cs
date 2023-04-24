using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] HeroData m_startHeroData;
    [SerializeField] PatternData m_patterns;
    private int m_index = 0;

    public HeroInfo NowStat => m_nowStat;
    private HeroInfo m_nowStat;

    [SerializeField] Vector3 m_direction;

    [Space(10.0f)]
    [SerializeField] Rigidbody2D m_rigidbody2D;
    [SerializeField] SpriteRenderer m_spriterenderer;

    void Start()
    {
        m_nowStat = m_startHeroData.GetStatInfo();

        if (m_patterns == null) { Destroy(gameObject); }
        if (m_spriterenderer == null) { m_spriterenderer = GetComponent<SpriteRenderer>(); }
        if (m_rigidbody2D == null) { m_rigidbody2D = GetComponent<Rigidbody2D>(); }

        m_spriterenderer.sprite = m_nowStat.profile;

        if (m_patterns.GetCount() > 0) { StartCoroutine(SpawnBullet()); }

        m_direction = Quaternion.AngleAxis(transform.localEulerAngles.z, Vector3.forward) * Vector3.down;

        m_nowStat.ATK += m_nowStat.ATK * (PlayerController.Instance.Lv / 5);
        m_nowStat.HP += m_nowStat.HP * (PlayerController.Instance.Lv / 4);
        m_nowStat.DEF += m_nowStat.DEF * (PlayerController.Instance.Lv / 6);

        m_nowStat.ReturnExp += m_nowStat.ReturnExp * (PlayerController.Instance.Lv / 30);
    }

    void Update()
    {
        m_rigidbody2D.velocity = m_direction * m_nowStat.SPD;
        if (m_nowStat.HP <= 0)
        {
            GameDirector.Instance.AddScore(m_nowStat.ReturnScore);
            PlayerController.Instance.NowStat.MP += m_nowStat.ReturnPoint;
            PlayerController.Instance.Exp += m_nowStat.ReturnExp;

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = PlayerController.Instance;
            player.NowStat.HP += player.NowStat.GetDamage(m_nowStat);
            player.HitMotion();
        }
    }

    public void HitMotion() { CoroutineEffector.Instance.DisplayHpBar(transform, m_nowStat); }

    IEnumerator SpawnBullet()
    {
        while(true)
        {
            GameObject pattern = Instantiate(m_patterns.GetPattern(m_index), transform.position, transform.rotation);
            BulletGroup group = pattern.GetOrAddComponent<BulletGroup>();
            group.angle = m_patterns.GetAngle(m_index);
            group.targetATK = m_nowStat.ATK;

            m_index++;
            if (m_index >= m_patterns.GetCount()) { m_index = 0; }

            yield return new WaitForSeconds(m_patterns.GetWaitTime(m_index));
        }
    }
}
