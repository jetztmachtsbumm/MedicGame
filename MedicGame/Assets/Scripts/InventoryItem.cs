using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private Transform selectedVisual;
    private ItemSO item;

    private void Awake()
    {
        selectedVisual = transform.Find("Selected");
        selectedVisual.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectedVisual.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectedVisual.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item.prefab != null)
        {
            Player.Instance.EquipItem(item.prefab);
        }
    }

    public void SetItem(ItemSO item)
    {
        this.item = item;
    }

}
