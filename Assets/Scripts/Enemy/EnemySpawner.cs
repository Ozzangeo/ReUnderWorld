using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] PatternData m_patterns;
    private int m_index = 0;

    void Start()
    {
        if (m_patterns == null) { Destroy(gameObject); return; }

        if (m_patterns.GetCount() > 0) { StartCoroutine(SpawnEnemy()); }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject pattern = Instantiate(m_patterns.GetPattern(m_index));
            pattern.transform.position += transform.position;

            EnemyGroup group = pattern.GetOrAddComponent<EnemyGroup>();
            group.angle = m_patterns.GetAngle(m_index);

            m_index++;
            if (m_index >= m_patterns.GetCount()) { m_index = 0; }

            yield return new WaitForSeconds(m_patterns.GetWaitTime(m_index));
        }
    }
}
