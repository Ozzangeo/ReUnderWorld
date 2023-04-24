using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineEffector : MonoBehaviour
{
    private static CoroutineEffector m_instance;

    [SerializeField] GameObject m_hpSlider;
    private static GameObject HpSlider;

    private const float scale = 2.0f;

    void Start()
    {
        if (m_instance == null) { m_instance = this; }
        if (HpSlider == null) { HpSlider = m_hpSlider; }    
    }

    public static IEnumerator HitEffect(SpriteRenderer sprite)
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
    public static IEnumerator DisplayHpBar(Transform position, HeroInfo info, float distance = 1.0f)
    {
        GameObject hp = Instantiate(HpSlider, m_instance.transform);
        Slider slider = hp.GetComponent<Slider>();
        slider.maxValue = info.MAX_HP;
        slider.value = info.HP;

        float time = 0.0f;
        while (time < 1.0f)
        {
            hp.transform.position = position.position + (Vector3.down * distance);

            yield return new WaitForFixedUpdate();

            time += Time.deltaTime;
        }

        Destroy(hp);
    }
}
