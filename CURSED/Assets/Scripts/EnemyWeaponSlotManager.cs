using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSlotManager : MonoBehaviour
{
    public WeaponItem rightHandWeapon;
    public WeaponItem leftHandWeapon;

    WeaponSlot rightHandSlot;
    WeaponSlot leftHandSlot;
    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    private void Awake()
    {

        WeaponSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponSlot>();
        foreach (WeaponSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
        }
    }
    private void Start()
    {
        LoadWeaponsOnBothHands();
    }

    public void LoadWeaponsOnBothHands()
    {
        if (rightHandWeapon != null)
        {
            LoadWeaponOnSlot(rightHandWeapon, false);
        }
        if (leftHandWeapon != null)
        {
            LoadWeaponOnSlot(leftHandWeapon, false);
        }
    }
    public void LoadWeaponOnSlot(WeaponItem weapon, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.currentWeapon = weapon.modelPrefab;
            leftHandSlot.LoadWeaponModel(weapon);
            LoadWeaponDamageCollider(true);
        }
        else
        {
            rightHandSlot.currentWeapon = weapon.modelPrefab;
            rightHandSlot.LoadWeaponModel(weapon);
            LoadWeaponDamageCollider(false);
        }
    }
    public void LoadWeaponDamageCollider(bool isLeft)
    {
        if (isLeft)
        {
            leftHandDamageCollider = leftHandSlot.currentWeapon.GetComponentInChildren<DamageCollider>();
        }
        else
        {
            leftHandDamageCollider = rightHandSlot.currentWeapon.GetComponentInChildren<DamageCollider>();
        }
    }

    public void OpenDamageCollider()
    {
        rightHandDamageCollider.EnableDamageCollider();
    }
    public void CloseDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
    }
}
