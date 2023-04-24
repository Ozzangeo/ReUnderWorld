using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletData m_startBulletData;

    public BulletInfo Info => m_info;
    private BulletInfo m_info;

    [Space(10.0f)]
    [SerializeField] Vector3 m_direction;
    [SerializeField] bool m_isPlayer = false;
    public int trueDamage = 0;

    [Space(10.0f)]
    [SerializeField] Rigidbody2D m_rigidbody2D;
    [SerializeField] SpriteRenderer m_spriteRenderer;

    void Awake()
    {
        m_info = m_startBulletData.GetBulletInfo();

        if (m_spriteRenderer == null ) { m_spriteRenderer = GetComponent<SpriteRenderer>(); }
        if (m_rigidbody2D == null) { m_rigidbody2D = GetComponent<Rigidbody2D>(); }

        m_spriteRenderer.sprite = m_info.profile;

        m_direction = Quaternion.AngleAxis(transform.localEulerAngles.z, Vector3.forward) * (m_isPlayer ? Vector3.up : Vector3.down);

        StartCoroutine(Life());
    }

    void Update()
    {
        m_rigidbody2D.velocity = m_direction * m_info.speed; 

        if (transform.position.x <= -32.0f || transform.position.x >= 32.0f) { Destroy(gameObject); }
        if (transform.position.y <= -18.0f || transform.position.y >= 18.0f) { Destroy(gameObject); }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !m_isPlayer) 
        {
            PlayerController player = PlayerController.Instance;
            player.NowStat.HP += player.NowStat.GetDamage(trueDamage);
            player.HitMotion();

            Destroy(gameObject);
        } else if(collision.CompareTag("Enemy") && m_isPlayer) {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            enemy.NowStat.HP += enemy.NowStat.GetDamage(trueDamage);
            enemy.HitMotion();

            Destroy(gameObject);
        }
    }

    private Vector3 AngleToDirection(float angle)
    {
        Vector3 direction = Vector3.one;

        var quaternion = Quaternion.Euler(0, angle, 0);
        Vector3 newDirection = quaternion * direction;

        return newDirection;
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(15.0f);
        Destroy(gameObject);
    }
}
