using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool interactable = true;
    //Transform player;
    public Transform player;
    public virtual void Interact()
    {

        ///Function
    }
    void Update()
    {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                interactable = true;
                Debug.Log("Interactable!");
                Interact();
            }
            else
            {
                interactable = false;
            }
    }
   
    
      
}
