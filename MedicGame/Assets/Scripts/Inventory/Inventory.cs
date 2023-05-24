using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }

    [SerializeField] private int inventorySize;

    private List<ItemStack> items;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There is more than one Inventory object active in the scene!");
            Destroy(gameObject);
        }
        Instance = this;

        items = new List<ItemStack>();
    }

    public void AddItem(ItemSO item, int amount)
    {
        ItemStack itemStack = new ItemStack(item, amount);
        foreach(ItemStack stack in items)
        {
            if (itemStack.GetItem() == stack.GetItem())
            {
                stack.IncreaseAmount(amount);
                return;
            }
        }
    }

    public void AddItem(ItemSO item)
    {
        AddItem(item, 1);
    }

    public void RemoveItem(ItemSO item, int amount)
    {
        foreach (ItemStack stack in items)
        {
            if (stack.GetItem() == item)
            {
                stack.DecreaseAmount(amount);
                if(stack.GetAmount() <= 0)
                {
                    items.Remove(stack);
                }
                return;
            }
        }
    }

    public void RemoveItem(ItemSO item)
    {
        RemoveItem(item, 1);
    }

    public void RemoveAllItemsOfType(ItemSO item)
    {
        foreach(ItemStack stack in items)
        {
            if(stack.GetItem() == item)
            {
                items.Remove(stack);
            }
        }
    }

}
