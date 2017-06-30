using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
	public List<SpriteRenderer> BarItems;
	
	void Start () 
	{
		this.BarItems = this.gameObject.GetComponentsInChildren<SpriteRenderer>().ToList();
		//Siempre remuevo el base sprite.
		var baseSprite = this.gameObject.GetComponent<SpriteRenderer>();
		this.BarItems.Remove(baseSprite);
		this.SetupForStrikes();
	}

	private void SetupForStrikes()
	{
		if (this.gameObject.CompareTag("strikes"))
		{
			this.RemoveAll();
		}
	}


	public void AddItem()
	{
		var firstSpriteOrEmpty = this.BarItems.Find((x => x.color ==  Color.clear));
		if (firstSpriteOrEmpty != null)
		{
			this.ShowFragment(firstSpriteOrEmpty);
		}
	}

	public void AddAll()
	{
		foreach (var sprite in BarItems)
		{
			this.ShowFragment(sprite);
		}	
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

	public void RemoveItem()
	{
		var lastSpriteOrEmpty = this.BarItems.FindLast((x => x.color ==  Color.white));
		if (lastSpriteOrEmpty != null)
		{
			this.HideFragment(lastSpriteOrEmpty);
		}
	}

	public void RemoveAll()
	{
		foreach (var sprite in BarItems)
		{
			this.HideFragment(sprite);
		}
	}

	private void HideFragment(SpriteRenderer sprite)
	{
		sprite.color = Color.clear;
	}
}
