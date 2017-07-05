using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
   //Target de donde va cargar la escena
   public string TargetLoad;

   public GameObject CurrentButton;

   private SpriteRenderer _sprite;

   private void Start()
   {
      this._sprite = CurrentButton.GetComponent<SpriteRenderer>();
   }

   private void OnMouseOver()
   {
      this._sprite.color = Color.gray;
      if (Input.GetMouseButtonDown(0))
      {
         this.LoadScene();
      }
   }

   private void LoadScene()
   {
      if (TargetLoad.Equals("salir"))
      {
         Application.Quit();
      }
      else
      {
         SceneManager.LoadScene(TargetLoad);
      }
   }

   private void OnMouseExit()
   {
      this._sprite.color = Color.white;
   }
}
