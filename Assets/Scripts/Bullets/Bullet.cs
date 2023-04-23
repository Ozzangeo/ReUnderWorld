using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletData m_startBulletData;

    public BulletInfo Info => m_info;
    private BulletInfo m_info;
    
    public int trueDamage = 0;

    [Space(10.0f)]
    [SerializeField] Rigidbody2D m_rigidbody2D;
    [SerializeField] SpriteRenderer m_spriteRenderer;

    void Start()
    {
        m_info = m_startBulletData.GetBulletInfo();

        if (m_spriteRenderer == null ) { m_spriteRenderer = GetComponent<SpriteRenderer>(); }
        if (m_rigidbody2D == null) { m_rigidbody2D = GetComponent<Rigidbody2D>(); }

        m_spriteRenderer.sprite = m_info.profile;
    }

    void Update()
    {
        m_rigidbody2D.velocity = Vector3.down * m_info.speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerController player = PlayerController.Instance;
            player.NowStat.HP += player.NowStat.GetDamage(trueDamage);
            player.HitMotion();

            Destroy(gameObject);
        }
    }
}
