using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("ERROR: Multiple Instances of Inventory detected");
            return;
        }
        instance = this;  
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onITemChangedCallBack;


    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough space in inventory");
                return false;
            }
            items.Add(item);
            if(onITemChangedCallBack !=null)
                onITemChangedCallBack.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onITemChangedCallBack != null)
            onITemChangedCallBack.Invoke();
    }
}
