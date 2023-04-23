using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance => instance;
    private static PlayerController instance;

    [SerializeField] HeroData m_startHeroData;
    public HeroInfo NowStat => m_nowStat;
    private HeroInfo m_nowStat;

    [Space(10.0f)]
    [SerializeField] Vector2 m_minPos = Vector2.zero;
    [SerializeField] Vector2 m_maxPos = Vector2.zero;
    [SerializeField] Vector2 m_offsetPos = Vector2.zero;
    public Vector2 AbsGroundSize => m_minPos.Abs() + m_maxPos.Abs();
    public Vector2 GroundOffset => m_offsetPos;

    public const float SLOW_SPD = 0.6f;

    [SerializeField] SpriteRenderer m_sprite;

    void Awake() { if (PlayerController.instance == null) { PlayerController.instance = this; } }

    void Start()
    {
        m_minPos += m_offsetPos;
        m_maxPos += m_offsetPos;

        transform.position = m_offsetPos;

        m_nowStat = m_startHeroData.GetStatInfo();

        if (m_sprite == null) { m_sprite = GetComponent<SpriteRenderer>(); }
    }

    void Update()
    {
        Vector3 pos = transform.position;
        float speed = m_nowStat.SPD * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift)) { speed *= SLOW_SPD; }

        pos.x = Mathf.Clamp(pos.x + (Input.GetAxisRaw("Horizontal") * speed), m_minPos.x, m_maxPos.x);
        pos.y = Mathf.Clamp(pos.y + (Input.GetAxisRaw( "Vertical" ) * speed), m_minPos.y, m_maxPos.y);

        transform.position = pos;
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

    public void HitMotion() { StartCoroutine(CorutineEffects.HitEffect(m_sprite)); }
}
