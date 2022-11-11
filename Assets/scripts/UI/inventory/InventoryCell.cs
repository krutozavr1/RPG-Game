using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject obj;
    InventoryItem.Type type;
    Image image;
    [SerializeField] GameObject interactMenu;



    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void CreateNewCell(GameObject item, InventoryItem.Type itemType)
    {
        obj = item.gameObject;
        type = itemType;
        image.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        transform.GetChild(0).GetComponentInChildren<ShowDescriptionButton>().description = obj.GetComponent<InventoryItem>().description;//sets item description
        FindObjectsOfType<Inventory>(true)[0].AddCellToInventory(type, gameObject);
    }

    public void ReturnItemToInventory()
    {
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
    }

    void ShowInteractMenu()
    {
        interactMenu.SetActive(true);
    }

    void HideInteractMenu()
    {
        interactMenu.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowInteractMenu();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideInteractMenu();
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void UseItem()
    {
        InventoryItem item;
        if(obj.TryGetComponent<InventoryItem>(out item))
        {
            item.UseItem(); 
        }
    }


}
