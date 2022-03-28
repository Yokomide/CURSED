using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon Item")]
public class WeaponItem : MonoBehaviour
{
    public GameObject modelPrefab;
    public bool isUnarmed;

    [Header("One Handed Attack Animation")]
    public string OH_Light_Attack_1;
    public string OH_Heavy_Attack_1;
   
}
