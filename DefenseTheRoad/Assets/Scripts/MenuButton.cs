using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
   //Target de donde va cargar la escena
   public string TargetLoad;
   public GameObject CurrentButton;
   public AudioClip SoundsFx;
   public AudioSource SoundSource;

   private SpriteRenderer _sprite;

   private void Start()
   {
      this._sprite = CurrentButton.GetComponent<SpriteRenderer>();
      SoundSource = this.GetComponent<AudioSource>();
   }

   private void OnMouseOver()
   {
      this._sprite.color = Color.gray;
      if (Input.GetMouseButtonDown(0))
      {
         this.PlaySound();
         this.LoadScene();
      }
   }

   private void LoadScene()
   {
      if (SoundSource.isPlaying)
      {
         InvokeRepeating("LoadScene", 0, SoundsFx.length  + 0.1f); 
         return;
      }
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

   private void PlaySound()
   {
      if (SoundSource.isPlaying) return;
      SoundSource.PlayOneShot(SoundsFx);
   }

   //Esto nunca anduvo.  ¯\_(ツ)_/¯
   private IEnumerable LoadAsyncLevel()
   {  
      if (!SoundSource.isPlaying)
      {
         SoundSource.PlayOneShot(SoundsFx);
      }
      yield return new WaitForSeconds(SoundsFx.length + 0.1f);
      LoadScene();
   }
}
