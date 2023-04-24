using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineEffector : MonoBehaviour
{
    public static CoroutineEffector Instance => m_instance;
    private static CoroutineEffector m_instance;

    [SerializeField] GameObject m_hpSlider;
    private static GameObject HpSlider;

    private const float scale = 2.0f;

    void Start()
    {
        if (m_instance == null) { m_instance = this; }
        if (HpSlider == null) { HpSlider = m_hpSlider; }    
    }

    // Hit Effect
    public void HitEffect(SpriteRenderer sprite)
    {
        StartCoroutine(CoHitEffect(sprite));
    }
    private IEnumerator CoHitEffect(SpriteRenderer sprite)
    {
        float time = 0.0f;
        float waitTime = 1.0f / scale;

        Color color = Color.red;
        while (time < waitTime)
        {
            sprite.color = color;

            yield return new WaitForFixedUpdate();

            time += Time.deltaTime;

            float other = Mathf.Clamp(time * scale, 0.0f, 1.0f);
            color.g = other;
            color.b = other;
        }

        sprite.color = Color.white;
    }

    // Display HP Bar
    public void DisplayHpBar(Transform position, HeroInfo info, float distance = 1.0f)
    {
        StartCoroutine(CoDisplayHpBar(position, info, distance));
    }
    private IEnumerator CoDisplayHpBar(Transform position, HeroInfo info, float distance = 1.0f)
    {
        GameObject hp = Instantiate(HpSlider, m_instance.transform);
        Slider slider = hp.GetComponent<Slider>();
        slider.maxValue = info.MAX_HP;
        slider.value = info.HP;

        float time = 0.0f;
        while (time < 1.0f)
        {
            if(position == null) { break; }

            hp.transform.position = (position ? position.position : Vector3.zero) + (Vector3.down * distance);

            yield return new WaitForFixedUpdate();

            time += Time.deltaTime;
        }

        Destroy(hp);
    }
}
