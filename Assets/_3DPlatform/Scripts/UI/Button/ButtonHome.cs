using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHome : ActionButton
{
    public override void OnButtonClicked()
    {
        SceneController.Instance.LoadHome();
    }
}
