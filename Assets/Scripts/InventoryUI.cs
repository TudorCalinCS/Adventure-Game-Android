using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public Item selectedItem;
    public Transform itemsParent;
    InventorySlot[] slots;
    public GameObject[] npcs;
    [Header("Buttons")]
    [SerializeField] private ButtonsManager buttonsManager;
    [SerializeField] private GameObject eatButton;
    [SerializeField] private GameObject giveButton;
    [SerializeField] private GameObject attackButton;
    private bool cangive;
    private AudioSource audioSource;

    void Start()
    {
        inventory = Inventory.FindObjectOfType<Inventory>();
        inventory.onItemChangedCall += UpdateUI;
        audioSource = this.GetComponent<AudioSource>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGive();
        UpdateButtons();
        
    }

    private void checkGive()
    {
        int ok = 0;
        foreach (GameObject gameObject in npcs)
        {
            NPC npcscript = gameObject.GetComponent<NPC>();
            if (npcscript.isOnTrigger == true)
            {
                ok = 1;
            }
        }
        if (ok == 1)
            cangive = true;
        else cangive = false;
    }
    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

    public void UsingItem()
    {
        if (selectedItem != null)
        {
            selectedItem.Use(audioSource);
            if (selectedItem.forConsumable == true)
            {
                buttonsManager.EatButtonPressed(selectedItem.healAmount);
                inventory.Remove(selectedItem);
            }
            
        }
        
    }

    void UpdateButtons()
    {
        if (selectedItem != null)
        {
            ///SHOW "EAT_BUTTON"
            if (selectedItem.forConsumable == true && selectedItem.forCombat == false && selectedItem.forQuest == false)
            {
                eatButton.SetActive(true);
            }
            else eatButton.SetActive(false);
            ///SHOW "GIVE_BUTTON"
            if (selectedItem.isGivable == true && cangive == true)
            {

                giveButton.SetActive(true);

            }
            else giveButton.SetActive(false);
            ///SHOW "ATTACK_BUTTON"
            if (selectedItem.forConsumable == false && selectedItem.forCombat == true && selectedItem.forQuest == false)
            {
                attackButton.SetActive(true);
            }
            else attackButton.SetActive(false);
        }
    }
}
