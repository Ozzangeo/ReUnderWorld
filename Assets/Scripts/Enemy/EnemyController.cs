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

    [Space(10.0f)]
    [SerializeField] SpriteRenderer m_sprite;

    void Start()
    {
        m_nowStat = m_startHeroData.GetStatInfo();

        if (m_patterns == null) { Destroy(gameObject); }
        if (m_sprite == null) { m_sprite = GetComponent<SpriteRenderer>(); }

        m_sprite.sprite = m_nowStat.profile;

        if (m_patterns.GetCount() > 0) { StartCoroutine(SpawnBullet()); }
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

    public void HitMotion()
    {

    }

    IEnumerator SpawnBullet()
    {
        while(true)
        {
            yield return new WaitForSeconds(m_patterns.GetWaitTime(m_index));

            GameObject pattern = Instantiate(m_patterns.GetPattern(m_index), transform.position, Quaternion.identity);
            BulletGroup group = pattern.GetOrAddComponent<BulletGroup>();
            group.angle = m_patterns.GetAngle(m_index);
            group.Setting(m_nowStat.ATK);

            m_index++;
            if (m_index >= m_patterns.GetCount()) { m_index = 0; }
        }
    }
}
