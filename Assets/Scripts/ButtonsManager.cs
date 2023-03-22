using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private Canvas InventoryMenuCanvas;
    public Canvas[] canvases;
    public PlayerController playerController;
    private CharacterStats characterStats;
    private void Start()
    {
        characterStats = playerController.GetComponent<CharacterStats>();
    }
    public void ShowInventoryMenu()
    {
        foreach (Canvas canvas in canvases)
        {
            canvas.enabled = false;
        }
        InventoryMenuCanvas.enabled = true;

    }
    public void CloseInventoryMenu()
    {
        foreach (Canvas canvas in canvases)
        {
            canvas.enabled = true;
        }
        InventoryMenuCanvas.enabled = false;
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);

    }
    public void AttackButtonPressed()
    {
        playerController.Attack();
    }
    public void EatButtonPressed(int healValue)
    {
        characterStats.Heal(healValue);
    }
}
