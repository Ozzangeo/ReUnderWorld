using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatDisplay : MonoBehaviour
{
    [SerializeField] PlayerController m_player;

    [Header("ATK")]
    [SerializeField] Text m_atkText;

    [Header("DEF")]
    [SerializeField] Text m_defText;

    [Header("HP")]
    [SerializeField] Text m_hpText;
    [SerializeField] Text m_hpsText;
    [SerializeField] Slider m_hpSlider;

    [Header("MP")]
    [SerializeField] Text m_mpText;
    [SerializeField] Text m_mpsText;
    [SerializeField] Slider m_mpSlider;

    [Header("SPD")]
    [SerializeField] Text m_spdText;

    [Header("DEX")]
    [SerializeField] Text m_dexText;

    [Header("Other")]
    [SerializeField] Text m_lvText;
    [SerializeField] Text m_expText;
    [SerializeField] Slider m_expSlider;

    void Start()
    {
        if (m_player == null) { m_player = PlayerController.Instance; }    
    }

    void Update()
    {
        // ATK
        m_atkText.text = $"{m_player.NowStat.ATK:D3}";

        // DEF
        m_defText.text = $"{m_player.NowStat.DEF:D3}";

        // HP
        m_hpText.text = $"{m_player.NowStat.HP:N0}/{m_player.NowStat.MAX_HP:N0}";
        m_hpsText.text = $"{m_player.NowStat.HPS:N1}/s";
        m_hpSlider.maxValue = m_player.NowStat.MAX_HP;
        m_hpSlider.value = m_player.NowStat.HP;

        // MP
        m_mpText.text = $"{m_player.NowStat.MP:N0}/{m_player.NowStat.MAX_MP:N0}";
        m_mpsText.text = $"{m_player.NowStat.MPS:N1}/s";
        m_mpSlider.maxValue = m_player.NowStat.MAX_MP;
        m_mpSlider.value = m_player.NowStat.MP;

        // SPD
        m_spdText.text = $"{(m_player.Speed):N1}";

        // DEX
        m_dexText.text = $"{m_player.NowStat.DEX:N1}";

        // Other
        m_lvText.text = $"{m_player.Lv:D3}";
        m_expText.text = $"{m_player.Exp:N0}/{m_player.NextExp:N0}";
        m_expSlider.maxValue = m_player.NextExp;
        m_expSlider.value = m_player.Exp;
    }
}
