using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsingFuncs : MonoBehaviour
{
    [SerializeField] PlayerController m_player;

    void Start()
    {
        if (m_player == null) { m_player = PlayerController.Instance; }    
    }

    public void MoveUsing()
    {

    }
}
