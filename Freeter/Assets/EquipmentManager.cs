using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange; 

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numOfSlots];

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        if (onEquipmentChange != null)
            onEquipmentChange.Invoke(newItem, oldItem);
 
    }
    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.add(oldItem);

            currentEquipment[slotIndex] = null;

            if(onEquipmentChange != null)
            onEquipmentChange.Invoke(null, oldItem);
        }
    }
    public void UnequipAll()
    {
        for ( int i=0; i <currentEquipment.Length; i++)
        {
            Unequip(i); 
        }
    }


}

