﻿using UnityEngine;
using System.Collections;

public class EventsManager : MonoBehaviour {

    public int sector = 1;

    public ShipSpawnManager spawnerMng;
    public PauseManager pauseMng;
    public BulletSpawnerManager bulletSpawnerMng;
    public WeaponManager weaponMng;

    public GameObject modalWindow;
    ModalWindowManager modalWindowMng;
    public Transform mainShipPos;
    public Transform shipCenterPos;
    public Transform enemyShipPos;
    public GameObject mainShip;
    public GameObject enemyShip;


    public void EnemyEncounter()
    {
        pauseMng.Pause();
        mainShip.transform.position = mainShipPos.position;
        enemyShip = spawnerMng.SpawnEnemy();
        enemyShip.transform.position = enemyShipPos.position;

        modalWindowMng.SetTitle("Ship in view !");
        modalWindowMng.SetDescription("A ship is on your way, it's a pirate ship ! \n Prepare to fight !");
        modalWindowMng.AddAwnser("Fight");
        modalWindow.SetActive(true);
    }

    public void StartBattle()
    {

        // affichage complet vaisseau
        pauseMng.Pause();

    }
    public void EnemyDestroyed()
    {
        bulletSpawnerMng.DestroyAllBullets();
        weaponMng.StopAttacking();

        // animation de destruction du vaisseau enemy
        pauseMng.Pause();
        StandardRewardEvent();
        // all crew in mainship, movement stop;
        mainShip.transform.position = shipCenterPos.position;
        // all crew in mainship, movement move;
    }

    public void StandardEvent()
    {
        // position du vaisseau center;
        pauseMng.Pause();
        // affichage d'une fenetre modale
    }
    public void MainShipDestroyed()
    {
        // Animation de destruction du vaisseau
        pauseMng.Pause();
        // affichage du score + boutton retry
    }

    void StandardRewardEvent()
    {
        // récupere la récompense

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().gold += 10;
        modalWindowMng.SetTitle("Enemy destroyed !");
        modalWindowMng.SetDescription("you won the fight and earned 10 Golds !\n Congratulations !");
        modalWindowMng.AddAwnser("Close");
        modalWindow.SetActive(true);
        // Affichage de fenetre de récompense
        // ajout des ressources
    }

    // Use this for initialization
    void Start ()
    {
        modalWindowMng = modalWindow.GetComponent<ModalWindowManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
