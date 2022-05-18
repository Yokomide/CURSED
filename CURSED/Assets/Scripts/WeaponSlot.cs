using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isLeftHandSlot;
    public bool isRightHandSlot;

    public GameObject currentWeapon;

    public void UnloadWeapon()
    {
        if(currentWeapon != null)
        {
            currentWeapon.SetActive(true);
        }
    }
    public void UnloadWeaponAndDestroy()
    {
        if (currentWeapon != null)
        {
          Destroy(currentWeapon);
        }

    }


        public void LoadWeaponModel(WeaponItem weaponItem)
    {
        UnloadWeaponAndDestroy();
        if (weaponItem == null)
        {
            UnloadWeapon();
            return;
        }
        GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;
        if(model != null)
        {
            if(parentOverride != null)
            {
                model.transform.parent = parentOverride;
            }
            else
            {
                model.transform.parent = transform;
            }

            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }

        currentWeapon = model;
    }
}
