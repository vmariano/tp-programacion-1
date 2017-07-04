using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
	public List<SpriteRenderer> BarItems;
	public int Total;
	public int Max = 13;
	
	void Start ()
	{
		this.Total = this.Max;
		this.BarItems = this.gameObject.GetComponentsInChildren<SpriteRenderer>().ToList();
		//Siempre remuevo el base sprite.
		var baseSprite = this.gameObject.GetComponent<SpriteRenderer>();
		this.BarItems.Remove(baseSprite);
		this.RemoveAll();
		this.SetupForGold();
	}

	private void SetupForGold()
	{
		if (!this.gameObject.CompareTag("strikes"))
		{
			this.RemoveAll();
			this.AddItem();	
			this.AddItem();	
			this.AddItem();	
			this.AddItem();	
		}
	}

	public bool IsFull()
	{
		return this.Total >= this.Max;
	}

	public void AddItem()
	{
		var firstSpriteOrEmpty = this.BarItems.Find((x => x.color ==  Color.clear));
		if (firstSpriteOrEmpty != null)
		{
			this.ShowFragment(firstSpriteOrEmpty);
		}
		this.Total += 1;
	}

	public void AddAll()
	{
		foreach (var sprite in BarItems)
		{
			this.ShowFragment(sprite);
		}
		this.Total = this.Max;
	}

	public void RemoveItem()
	{
		var lastSpriteOrEmpty = this.BarItems.FindLast((x => x.color ==  Color.white));
		if (lastSpriteOrEmpty != null)
		{
			this.HideFragment(lastSpriteOrEmpty);
		}
		this.Total -= 1;
	}


	public void RemoveAll()
	{
		foreach (var sprite in BarItems)
		{
			this.HideFragment(sprite);
		}
		this.Total = 0;
	}

	private void HideFragment(SpriteRenderer sprite)
	{
		sprite.color = Color.clear;
	}
	
	private void ShowFragment(SpriteRenderer sprite)
	{
		if (this.gameObject.CompareTag("strikes"))
		{
			sprite.color = Color.red;
		}
		else
		{
			sprite.color = Color.white;
		}
	}
}
