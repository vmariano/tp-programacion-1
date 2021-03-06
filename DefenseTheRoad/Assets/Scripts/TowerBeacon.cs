﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerBeacon : MonoBehaviour {
	private SpriteRenderer _sprite;
	public GameObject Tower;
	public ProgressBar GoldBar;
	public AudioSource SoundSource;
	public AudioClip NopeFx;

	private void Start()
	{
		this.GoldBar = GameObject.Find("Oro").GetComponent<ProgressBar>();
		this.SoundSource = this.GetComponent<AudioSource>();
	}

	private void OnMouseOver()
	{
		this.SetColorToSprite(Color.gray);
		if (Input.GetMouseButtonDown(0))
		{
			if (this.GoldBar.Total >= 3)
			{
				this.CreateTower();
			}
			else
			{
				if (!SoundSource.isPlaying)
				{
					SoundSource.PlayOneShot(NopeFx);
				}
			}
		}	
	}

	private void OnMouseExit()
	{
		SetColorToSprite(Color.white);
	}

	protected void SetColorToSprite(Color color)
	{
		this._sprite = this.gameObject.GetComponent<SpriteRenderer>();
		this._sprite.color = color;
	}

	private void CreateTower()
	{
		this.RemoveGold();
		var towerHeigth = 0.76f;
		var position = new Vector3(this.transform.position.x, this.transform.position.y + towerHeigth);
		Instantiate(this.Tower, position, Quaternion.identity);
		Destroy(this.gameObject);
	}

	private void RemoveGold()
	{
		this.GoldBar.RemoveItem();
		this.GoldBar.RemoveItem();
		this.GoldBar.RemoveItem();
	}
}
