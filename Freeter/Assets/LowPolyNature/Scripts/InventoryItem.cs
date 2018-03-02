using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem {

    string Name { get; }

    Sprite Image { get;  }

    void OnPickup();

    void OnDrop();

    void OnUse();

    InventorySlot Slot { get; set; }
}

public class InventorySlotEventArgs : EventArgs
{
    public InventorySlotEventArgs(InventorySlot slot)
    {
        Slot = slot;
    }

    public InventorySlot Slot;
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}

