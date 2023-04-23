using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerUsingInfo
{
    public Sprite profile;
    public KeyCode fireKey;
    public float waitTime;
    public int pricePoint;
    public UnityEvent usingFunc;
    [HideInInspector] public bool isOn = true;

    public IEnumerator WaitUsing(float waitMul)
    {
        yield return new WaitForSeconds(waitTime * waitMul);
        isOn = true;
    }
}
