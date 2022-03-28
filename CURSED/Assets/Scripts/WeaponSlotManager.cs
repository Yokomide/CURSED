using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponSlot leftHandSlot;
    WeaponSlot rightHandSlot;

    private void Awake()
    {
        WeaponSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponSlot>();
        foreach(WeaponSlot weaponSlot in weaponHolderSlots)
        {
            if(weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if(weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if(isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
        }
        else
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
        }
    }
}
