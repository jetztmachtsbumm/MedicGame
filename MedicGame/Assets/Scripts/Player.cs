using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    private Transform equippableItemPoint;
    private UsableItem currentUsableItemEquipped;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There is more than one Player object active in the scene!");
            Destroy(gameObject);
        }
        Instance = this;

        equippableItemPoint = transform.Find("EquippableItemPoint");
    }

    public void EquipItem(Transform prefab)
    {
        foreach(Transform child in equippableItemPoint)
        {
            Destroy(child.gameObject);
        }

        Transform equippedItem = Instantiate(prefab, equippableItemPoint);
        SetCurrentUsableItemEquipped(equippedItem.GetComponent<UsableItem>());
    }

    public UsableItem GetCurrentUsableItemEquipped()
    {
        return currentUsableItemEquipped;
    }

    public void SetCurrentUsableItemEquipped(UsableItem usableItem)
    {
        currentUsableItemEquipped = usableItem;
    }

}
