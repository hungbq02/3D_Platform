using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRetry : ActionButton
{
    public override void OnButtonClicked()
    {
        SceneController.Instance.RestartLevel();
    }
}
