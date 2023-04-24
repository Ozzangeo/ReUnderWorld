using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUsingController : MonoBehaviour
{
    [SerializeField] PlayerController m_player;
    [SerializeField] PlayerUsingInfo[] m_usingInfo;

    private void Start()
    {
        if (m_player == null) { m_player = PlayerController.Instance; }

        foreach (PlayerUsingInfo info in m_usingInfo) { info.Setting(); }
    }

    void Update()
    {
        foreach(var info in m_usingInfo)
        {
            if (Input.GetKey(info.fireKey) && info.isOn && m_player.NowStat.MP >= info.pricePoint)
            {
                info.isOn = false;
                info.usingFunc.Invoke();
                m_player.NowStat.MP -= info.pricePoint;

                StartCoroutine(info.WaitUsing(m_player.NowStat.DEX));
            }
        }
    }


}
