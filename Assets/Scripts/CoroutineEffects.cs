using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorutineEffects : MonoBehaviour
{
    public static IEnumerator HitEffect(SpriteRenderer sprite)
    {
        const float scale = 2.0f;

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
}
