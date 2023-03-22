using UnityEngine;
[CreateAssetMenu]
 public class Item:ScriptableObject
{
    public string id;
    public string name;
    public Sprite sprite;
    public string description;
    public bool isGivable;
    public bool isEquipment;
    public AudioClip audioUse;
    [Header("Item Type")]
    public bool forConsumable;
    public bool forCombat;
    public bool forQuest;

    [Header("For Combat")]
    public float damage;
    public float radius;
    [Header("Consumable")]
    public int healAmount;
    #region
    public Item(string idd,string namee,Sprite spritee,bool forComsubalee,bool forCombatt,bool forQuestt)
    {
        this.id = idd;
        this.name = namee;
        this.sprite = spritee;
        this.forConsumable = forComsubalee;
        this.forCombat = forCombatt;
        this.forQuest = forQuestt;
    }
    #endregion

    public virtual void Use(AudioSource audioSource)
    {
        ///USE the item;
        Debug.Log("Using " + name);
        if (audioUse != null)
        {
            audioSource.PlayOneShot(audioUse);
        }
    }
}
