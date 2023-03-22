using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCall;

    public List<Item> items = new List<Item>();
    public int inventorySpace=9;
    /**
    public static Inventory instance;
    void  Awake()
    {
        instance = this;
    }
    */
    public bool AddFunction(Item item)
    {
        Debug.Log("Item addes in list");
        if (items.Count < inventorySpace)
        {
            items.Add(item);

            if(onItemChangedCall!=null)
                onItemChangedCall.Invoke();

            return true;
        }
        else return false;

    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCall != null)
            onItemChangedCall.Invoke();
    }
}
