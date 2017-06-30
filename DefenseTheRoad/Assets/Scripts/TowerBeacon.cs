using UnityEngine;

public class TowerBeacon : MonoBehaviour {
	private SpriteRenderer _sprite;
	public GameObject Tower;

	private void OnMouseOver()
	{
		this.SetColorToSprite(Color.gray);
		if (Input.GetMouseButtonDown(0))
		{
			this.CreateTower();
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
		var towerHeigth = 0.76f;
		var position = new Vector3(this.transform.position.x, this.transform.position.y + towerHeigth);
		Instantiate(this.Tower, position, Quaternion.identity);
	}
}
