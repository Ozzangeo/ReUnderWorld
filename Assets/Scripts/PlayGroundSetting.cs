using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGroundSetting : MonoBehaviour
{
    [SerializeField] PlayerController m_player;
    [SerializeField] Vector2Int m_resolution;

    [Space(10.0f)]
    [SerializeField] BoxCollider2D m_boxCollider;

    void Start()
    {
        if (m_player == null) { m_player = PlayerController.Instance; }
        if (m_boxCollider == null) { m_boxCollider = GetComponent<BoxCollider2D>(); }

        m_boxCollider. size  = m_player.AbsGroundSize;
        m_boxCollider.offset = m_player.GroundOffset;

        Screen.SetResolution(m_resolution.x, m_resolution.y, false);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);    
    }
}
