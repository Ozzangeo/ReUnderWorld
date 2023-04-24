using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerUsingFuncs : MonoBehaviour
{
    [SerializeField] PlayerController m_player;
    [SerializeField] GameObject m_defaultBullet;
    [SerializeField] GameObject m_skillBullet;

    void Start()
    {
        if (m_player == null) { m_player = PlayerController.Instance; }
    }
    public void UsingMove()
    {
        Vector3 pos = m_player.transform.position;

        pos.x = Mathf.Clamp(pos.x + (Input.GetAxisRaw("Horizontal") * m_player.Speed * 5.0f * Time.deltaTime), m_player.MinPos.x, m_player.MaxPos.x);
        pos.y = Mathf.Clamp(pos.y + (Input.GetAxisRaw( "Vertical" ) * m_player.Speed * 5.0f * Time.deltaTime), m_player.MinPos.y, m_player.MaxPos.y);

        m_player.transform.position = pos;
    }

    public void UsingShoot()
    {
        Bullet bullet = Instantiate(m_defaultBullet, m_player.transform.position, Quaternion.identity).GetComponent<Bullet>();

        bullet.trueDamage = Convert.ToInt32(bullet.Info.mulATK * m_player.NowStat.ATK);
    }

    public void UsingHeal()
    {
        m_player.NowStat.HP += m_player.NowStat.MAX_HP / 4;
    }

    public void UsingSkill()
    {
        BulletGroup bullet = Instantiate(m_skillBullet, m_player.transform.position, Quaternion.identity).GetComponent<BulletGroup>();

        bullet.targetATK = m_player.NowStat.ATK;
        bullet.angle = 45 * m_player.Speed;

        bullet = Instantiate(m_skillBullet, m_player.transform.position, Quaternion.identity).GetComponent<BulletGroup>();

        bullet.targetATK = m_player.NowStat.ATK;
        bullet.angle = 30 * m_player.Speed;
    }

    public void UsingAtkUp()
    {
        StartCoroutine(AtkUp());
    }

    IEnumerator AtkUp()
    {
        const float Persent = 0.75f;

        float atk = m_player.NowStat.ATK;
        m_player.NowStat.ATK += Convert.ToInt32(atk * Persent);

        yield return new WaitForSeconds(5.0f);

        m_player.NowStat.ATK -= Convert.ToInt32(atk * Persent);
    }
}
