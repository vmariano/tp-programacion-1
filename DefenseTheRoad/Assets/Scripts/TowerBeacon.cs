using UnityEngine;

public class TowerBeacon : MonoBehaviour {
	private SpriteRenderer _sprite;
	public GameObject Bacon;

	private void Start()
	{
		this._sprite = this.Bacon.GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			this._sprite.color = Color.gray;
			Debug.Log("click aca");
		}	
	}
}
