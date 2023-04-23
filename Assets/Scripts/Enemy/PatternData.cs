using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pattern Data", menuName = "Datas/Pattern Data", order = 0)]
public class PatternData : ScriptableObject
{
    public List<PatternInfo> patterns;

    public GameObject GetPattern(int index) => patterns[index].pattern;
    public float GetWaitTime(int index) => patterns[index].waitTime;
    public float GetAngle(int index) => patterns[index].angle;
}
