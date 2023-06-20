using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{

    [SerializeField] private ItemSO testItem;

    private void Update()
    {
        //Inventory
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryUI.Instance.gameObject.activeInHierarchy)
            {
                InventoryUI.Instance.Hide();
            }
            else
            {
                InventoryUI.Instance.Show();
            }
        }

        //Use item
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.Instance.GetCurrentUsableItemEquipped()?.Use();
        }

        //Test Code
        if (Input.GetKeyDown(KeyCode.T))
        {
            Inventory.Instance.AddItem(testItem, 1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Inventory.Instance.RemoveItem(testItem, 1);
        }
    }

}
