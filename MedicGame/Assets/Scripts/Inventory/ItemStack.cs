using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemStack : IEquatable<ItemStack>
{

    private ItemSO item;
    private int amount;

    public ItemStack(ItemSO item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public ItemStack(ItemSO item)
    {
        this.item = item;
        amount = 0;
    }

    public bool Equals(ItemStack other)
    {
        return item == other.item && amount == other.amount;
    }

    public ItemSO GetItem()
    {
        return item;
    }

    public int GetAmount()
    {
        return amount;
    }

    public void SetAmount(int amount)
    {
        this.amount = amount;
    }

    public void IncreaseAmount(int amount)
    {
        this.amount += amount;
    }

    public void DecreaseAmount(int amount)
    {
        this.amount -= amount;
    }

}
