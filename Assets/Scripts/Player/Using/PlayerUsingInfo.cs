using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerUsingInfo
{
    public PlayerUsingDisplayer displayer;

    [Space(10.0f)]
    public Sprite profile;
    public KeyCode fireKey;
    public float waitTime;
    public int pricePoint;
    public UnityEvent usingFunc;
    [HideInInspector] public bool isOn = true;

    public void Setting() { displayer.Setting(this); }

    public IEnumerator WaitUsing(float waitMul)
    {
        float wait = waitTime * (1.0f / waitMul);
        float time = 0;

        while (time < wait)
        {
            time += Time.deltaTime;

            yield return new WaitForFixedUpdate();

            displayer.enableImage.fillAmount = (time / wait);
        }

        isOn = true;
    }
}
