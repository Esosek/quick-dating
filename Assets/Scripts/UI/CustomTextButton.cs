using UnityEngine;
using TMPro;

public class CustomTextButton : CustomButton {

    public override void TransitionUpdate()
    {
        if(transitionTime > 1) return;
        
        transitionTime += Time.deltaTime / transitionDuration;
        GetComponent<TextMeshProUGUI>().color = Color.Lerp(startingColor, endColor, transitionTime);
    }
}