using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
   public string TargetLoad;
   
    private void OnMouseOver()
    {
       if (Input.GetMouseButtonDown(0))
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
    }
}
