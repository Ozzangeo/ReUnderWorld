using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUsingDisplayer : MonoBehaviour
{
    public Image disableImage;
    public Image enableImage;
    public Text pricePointText;
    public Text keyText;

    public void Setting(PlayerUsingInfo info) {
        disableImage.sprite = info.profile;
        enableImage.sprite = info.profile;

        pricePointText.text = $"{info.pricePoint} mp";
        keyText.text = $"{info.fireKey}";

        enableImage.fillAmount = 1.0f;
    }
}
