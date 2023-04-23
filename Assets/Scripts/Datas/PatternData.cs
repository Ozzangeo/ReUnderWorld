using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pattern Data", menuName = "Datas/Pattern Data", order = 0)]
public class PatternData : ScriptableObject
{
    [SerializeField] List<PatternInfo> m_patterns;

    public GameObject GetPattern(int index) => m_patterns[index].pattern;
    public float GetWaitTime(int index) => m_patterns[index].waitTime;
    public float GetAngle(int index) => m_patterns[index].angle;
    public int GetCount() => m_patterns.Count;
}
