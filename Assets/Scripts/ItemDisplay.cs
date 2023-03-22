using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private Item theItem;
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = theItem.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
