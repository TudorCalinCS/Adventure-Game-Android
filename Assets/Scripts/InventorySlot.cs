using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    
    public Item item;
    public Image icon;
    
    private InventoryMenuUI invMenu;
    private InventoryUI invUi;
    public void Start()
    {
         invMenu = transform.GetComponentInParent<InventoryMenuUI>();
         invUi = transform.GetComponentInParent<InventoryUI>();
        
    }
    public void AddItem(Item newItem)
    {

        item = newItem;
        icon.sprite = item.sprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

    }
    public void SelectItem()
    {
        if (item != null)
        {
            invUi.selectedItem = item;
            Debug.Log("Selected " + item.name);
            
        
        if (invMenu != null)
        {
                invMenu.itemDescription.text = item.description.ToString();

        }
        }

    }
  
}
