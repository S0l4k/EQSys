using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUsage : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private GameObject player;

    
    [SerializeField] private Image helmetUI;
    [SerializeField] private Image torsoUI;
    [SerializeField] private Image legginsUI;
    [SerializeField] private Image shoesUI;

    
    [SerializeField] private GameObject helmetModel;
    [SerializeField] private GameObject torsoModel;
    [SerializeField] private GameObject legginsModel;
    [SerializeField] private GameObject shoesModel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseHoveredItem();
        }
    }

    private void UseHoveredItem()
    {
        SlotClass hoveredSlot = GetHoveredSlot();
        if (hoveredSlot == null || hoveredSlot.GetItem() == null)
            return;

        ItemClass item = hoveredSlot.GetItem();

        if (item.itemName == "Mleczko" || item.itemName == "Chlebek" || item.itemName == "Bigos")
        {
            ConsumeItem(hoveredSlot);
        }
        else if (item.itemName == "Helmet" || item.itemName == "Torso" || item.itemName == "Leggins" || item.itemName == "Shoes")
        {
            EquipArmor(item);
        }
    }

    private void ConsumeItem(SlotClass slot)
    {
        Debug.Log("Zjedzono: " + slot.GetItem().itemName);
        slot.SubQuantity(1);
        if (slot.GetQuantity() <= 0)
            slot.Clear();

        inventory.RefreshUI();
    }

    private void EquipArmor(ItemClass item)
    {
        switch (item.itemName)
        {
            case "Helmet":
                ToggleArmor(helmetUI, helmetModel);
                break;
            case "Torso":
                ToggleArmor(torsoUI, torsoModel);
                break;
            case "Leggins":
                ToggleArmor(legginsUI, legginsModel);
                break;
            case "Shoes":
                ToggleArmor(shoesUI, shoesModel);
                break;
        }
    }

    private void ToggleArmor(Image uiElement, GameObject model)
    {
        bool isActive = !model.activeSelf;
        model.SetActive(isActive);

        if (uiElement != null)
        {
            uiElement.gameObject.SetActive(isActive);  
            uiElement.enabled = isActive;  
            uiElement.color = isActive ? Color.white : new Color(1, 1, 1, 0); 
        }
    }

    private SlotClass GetHoveredSlot()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            RectTransform slotRect = inventory.slots[i].GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(slotRect, Input.mousePosition))
            {
                return inventory.items[i];
            }
        }
        return null;
    }
}
