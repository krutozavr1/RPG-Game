using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowDescriptionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string description;
    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectsOfType<ItemDescription>(true)[0].ShowDescription(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectsOfType<ItemDescription>(true)[0].HideDescription();
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
