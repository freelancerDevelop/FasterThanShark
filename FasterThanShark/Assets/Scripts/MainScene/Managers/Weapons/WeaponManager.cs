﻿using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public ItemInventory playerInventory;
    public ClickEventManager clickEvntMng;
    public GameObject enemy;

    public int weaponSelected = -1;

    Vector3 gismoPos = new Vector3(100f, 100f, 0f);

    // Weapon 1 :
    Item weapon1;
    IEnumerator Weapon1CRT;
    bool Weapon1CRTIsRunning;
    // Weapon 2 :
    Item weapon2;
    IEnumerator Weapon2CRT;
    bool Weapon2CRTIsRunning;
    // Weapon 3 :
    Item weapon3;
    IEnumerator Weapon3CRT;
    bool Weapon3CRTIsRunning;
    // Weapon 4 :
    Item weapon4;
    IEnumerator Weapon4CRT;
    bool Weapon4CRTIsRunning;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void UnselectWeapon()
    {
        weaponSelected = -1;
    }

    public void SelectWeapon(int index)
    {
        clickEvntMng.ResetSelection();
        // change le curseur en mode cible
        // selectionne l'arme
        weaponSelected = index;
        Debug.Log("Weapon selected : " + index);
    }

    public void UseWeapon(int index, int _mapIndex, Vector3 targetPos)
    {
        Debug.Log("tentative d'atk");
        
        if(_mapIndex == 1 && weaponSelected != -1)
        {
            // map valide, arme valide,
            if (enemy == null)
            { return; }
            // enemy valide,
            // Arme 1:
            if (weaponSelected == 0)
            {
                if(weapon1 == null)         
                { return; }
                if(Weapon1CRTIsRunning)
                {
                    StopCoroutine(Weapon1CRT);
                }
                Weapon1CRT = UseWeapon1CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon1CRT);
            }
            // Arme 2:
            if (weaponSelected == 1)
            {
                if (weapon2 == null)         
                { return; }
                if (Weapon2CRTIsRunning)
                {
                    StopCoroutine(Weapon2CRT);
                }
                Weapon2CRT = UseWeapon2CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon2CRT);
            }
            // Arme 3:
            if (weaponSelected == 2)
            {
                if (weapon3 == null)
                { return; }
                if (Weapon3CRTIsRunning)
                {
                    StopCoroutine(Weapon3CRT);
                }
                Weapon3CRT = UseWeapon3CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon3CRT);
            }
            // Arme 4:
            if (weaponSelected == 3)
            {
                if (weapon4 == null)
                { return; }
                if (Weapon4CRTIsRunning)
                {
                    StopCoroutine(Weapon4CRT);
                }
                Weapon4CRT = UseWeapon4CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon4CRT);
            }
            // Fin de l'attaque
            weaponSelected = -1;
            gismoPos = targetPos;
        }
    }

    public void RefreshWeapons()
    {
        weapon1 = null;
        weapon2 = null;
        weapon3 = null;
        weapon4 = null;
        for (int i = 0; i < playerInventory.playerWeaponInventory.Count; i++ )
        {
            switch(i)
            {
                case 0:
                    {
                        weapon1 = playerInventory.playerWeaponInventory[i];
                        break;
                    }
                case 1:
                    {
                        weapon2 = playerInventory.playerWeaponInventory[i];
                        break;
                    }
                case 2:
                    {
                        weapon3 = playerInventory.playerWeaponInventory[i];
                        break;
                    }
                case 3:
                    {
                        weapon4 = playerInventory.playerWeaponInventory[i];
                        break;
                    }
            }
        }
    }

    IEnumerator UseWeapon1CRT(Vector3 targetPosition, int mapIndex)
    {

        Weapon1CRTIsRunning = true;
        while (true)
        {
            if (weapon1.itemCurrentCD >= weapon1.itemCD)
            {
                if (mapIndex == 1)
                {
                    enemy.GetComponent<EnemyStats>().GetDamage(weapon1.itemDamage);
                }
                weapon1.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon1CRTIsRunning = false;
    }

    IEnumerator UseWeapon2CRT(Vector3 targetPosition, int mapIndex)
    {
        Weapon2CRTIsRunning = true;
        while (true)
        {
            if (weapon2.itemCurrentCD >= weapon2.itemCD)
            {
                if (mapIndex == 1)
                {
                    enemy.GetComponent<EnemyStats>().GetDamage(weapon2.itemDamage);
                }
                weapon2.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon2CRTIsRunning = false;
    }
    IEnumerator UseWeapon3CRT(Vector3 targetPosition, int mapIndex)
    {
        Weapon3CRTIsRunning = true;
        while (true)
        {
            if (weapon3.itemCurrentCD >= weapon3.itemCD)
            {
                if (mapIndex == 1)
                {
                    enemy.GetComponent<EnemyStats>().GetDamage(weapon3.itemDamage);
                }
                weapon3.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon3CRTIsRunning = false;
    }
    IEnumerator UseWeapon4CRT(Vector3 targetPosition, int mapIndex)
    {
        Weapon4CRTIsRunning = true;
        while (true)
        {
            if (weapon4.itemCurrentCD >= weapon4.itemCD)
            {
                if (mapIndex == 1)
                {
                    enemy.GetComponent<EnemyStats>().GetDamage(weapon4.itemDamage);
                }
                weapon4.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon4CRTIsRunning = false;
    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gismoPos, 0.1f);
    }
}
