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
    }

    void Update()
    {
        foreach(var info in m_usingInfo)
        {
            if (Input.GetKey(info.fireKey) && info.isOn)
            {
                info.isOn = false;
                info.usingFunc.Invoke();
                
                StartCoroutine(info.WaitUsing(m_player.NowStat.DEX));
            }
        }
    }
}
