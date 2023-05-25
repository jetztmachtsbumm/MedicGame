using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public static InventoryUI Instance { get; private set; }

    [SerializeField] private Transform inventoryItemPrefab;

    private Transform contentTransform;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There is more than one InventoryUI object active in the scene!");
            Destroy(gameObject);
        }
        Instance = this;

        contentTransform = transform.Find("Content");
    }

    private void Start()
    {
        Inventory.Instance.OnInventoryItemsChanged += Inventory_OnInventoryItemsChanged;

        Hide();
    }

    private void Inventory_OnInventoryItemsChanged(object sender, System.EventArgs e)
    {
        CreateInventoryUIContent();
    }

    private void CreateInventoryUIContent()
    {
        foreach(Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }

        foreach(ItemStack item in Inventory.Instance.GetItems())
        {
            Transform inventoryItemUITransform = Instantiate(inventoryItemPrefab, contentTransform);

            inventoryItemUITransform.Find("ItemImage").GetComponent<Image>().sprite = item.GetItem().sprite;
            inventoryItemUITransform.Find("AmountText").GetComponent<TextMeshProUGUI>().text = item.GetAmount().ToString();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
