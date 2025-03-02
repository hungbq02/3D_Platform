using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>(); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!button.interactable) return;
        transform.localScale = Vector3.one * 1.3f;
        if (gameObject.TryGetComponent(out Animator anim))
        {
            anim.enabled = false;
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (!button.interactable) return;
        transform.localScale = Vector3.one * 1f;
        if (gameObject.TryGetComponent(out Animator anim))
        {
            anim.enabled = true;
        }
    }
}
