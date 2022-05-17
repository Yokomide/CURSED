using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager weaponSlotManager;

    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;
    public WeaponItem unarmedWeapon;
    public WeaponItem swordWeapon;
    public WeaponItem axeWeapon;
    public WeaponItem spearWeapon;

    public GameObject changeButton;

    public WeaponItem[] weaponsInRightHandSlots = new WeaponItem[1];
    public WeaponItem[] weaponsInLeftHandSlots = new WeaponItem[1];

    public int currentRightWeaponIndex = 0;
    public int currentLeftWeaponIndex = 0;



    private void Awake()
    {
        weaponSlotManager = GetComponent<WeaponSlotManager>();
        
        
    }

    private void Start()
    {
        rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
        weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
        leftWeapon = unarmedWeapon;
        CheckWeaponInventory();
    }


    public void CheckWeaponInventory()
    {
        if (weaponsInRightHandSlots.Length == 1)
        {
            changeButton.SetActive(false);
        }
        else
        {
            changeButton.SetActive(true);
        }

    }


    public void ChangeRightWeapon()
    {
        currentRightWeaponIndex = currentRightWeaponIndex + 1;

        if (currentRightWeaponIndex == 0 && weaponsInRightHandSlots[0] != null)
        {
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
        }
        else if(currentRightWeaponIndex == 0 && weaponsInRightHandSlots[0] == null)
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1;
        }
        else if (currentRightWeaponIndex == 1 && weaponsInRightHandSlots[0] != null)
        {
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
        }
        else if (currentRightWeaponIndex == 1 && weaponsInRightHandSlots[0] == null)
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1;
        }
        else if (currentRightWeaponIndex == 2 && weaponsInRightHandSlots[0] != null)
        {
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
        }
        else if (currentRightWeaponIndex == 2 && weaponsInRightHandSlots[0] == null)
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1;
        }

        if (currentRightWeaponIndex> weaponsInRightHandSlots.Length -1)
        {
            currentRightWeaponIndex = 0;
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
        }

    }
    public void ChangeLeftWeapon()
    {
        currentLeftWeaponIndex = currentLeftWeaponIndex + 1;

        if (currentLeftWeaponIndex == 0 && weaponsInLeftHandSlots[0] != null)
        {
            rightWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlots[currentLeftWeaponIndex], true);
        }
        else if (currentLeftWeaponIndex == 0 && weaponsInLeftHandSlots[0] == null)
        {
            currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
        }
        else if (currentLeftWeaponIndex == 1 && weaponsInLeftHandSlots[0] != null)
        {
            rightWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlots[currentLeftWeaponIndex], true);
        }
        else if (currentLeftWeaponIndex == 1 && weaponsInLeftHandSlots[0] == null)
        {
            currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
        }

        if (currentLeftWeaponIndex > weaponsInLeftHandSlots.Length - 1)
        {
            currentLeftWeaponIndex = 0;
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlots[currentRightWeaponIndex], false);
        }


        
    }
    public void addAxe()
    {
        if (weaponsInRightHandSlots.Length == 1)
        {
            weaponsInRightHandSlots = new WeaponItem[2];
            weaponsInRightHandSlots[0] = swordWeapon;
            weaponsInRightHandSlots[1] = axeWeapon;
        }
        else if (weaponsInRightHandSlots.Length == 2)
        {
            weaponsInRightHandSlots = new WeaponItem[3];
            weaponsInRightHandSlots[0] = swordWeapon;
            weaponsInRightHandSlots[1] = spearWeapon;
            weaponsInRightHandSlots[2] = axeWeapon;
        }

    }

    public void addSpear()
    {
        if (weaponsInRightHandSlots.Length == 1)
        {
            weaponsInRightHandSlots = new WeaponItem[2];
            weaponsInRightHandSlots[0] = swordWeapon;
            weaponsInRightHandSlots[1] = spearWeapon;
        }
        else if (weaponsInRightHandSlots.Length == 2)
        {
            weaponsInRightHandSlots = new WeaponItem[3];
            weaponsInRightHandSlots[0] = swordWeapon;
            weaponsInRightHandSlots[1] = axeWeapon;
            weaponsInRightHandSlots[2] = spearWeapon;
        }
    }
}
