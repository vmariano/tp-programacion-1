using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConfiguration : MonoBehaviour
{
    private static String LEVEL1 = "Level1";
    private static String LEVEL2 = "Level2";
    private static String LEVEL3 = "Level3";
    
    public static WaveConfig GetFirstWave()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1)) 
        {
            // 4 enemigos,velocidad 60 vida 2. 
            return new WaveConfig(4, 60, 2, 1); 
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2)) 
        {
            // 4 enemigos,velocidad 60 vida 2. 
            return new WaveConfig(4, 60, 2, 1);    
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3)) 
        {
            // 4 enemigos,velocidad 60 vida 2. 
            return new WaveConfig(4, 60, 2, 1);            
        }
        return new WaveConfig();
    }

    public static Color GetFirstColor()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1))
        {
            return Color.clear;
        }       
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2))
        {
            return Color.clear;
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3))
        {
            return Color.clear;
        }
        
        return new Color();
    }

  
    public static WaveConfig GetSecondWave()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1))
        {
            // 8 enemigos, 80 speed, 4 de vida.
            return new WaveConfig(9, 80, 4, 3);
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2))
        {
            // 8 enemigos, 80 speed, 4 de vida.
            return new WaveConfig(9, 80, 4, 3);        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3)) 
        {
            // 8 enemigos, 80 speed, 4 de vida.
            return new WaveConfig(9, 80, 4, 3);        
        }
        return new WaveConfig();

    }
    
    public static Color GetSecondColor()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1))
        {
            return Color.magenta;
        }
        
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2))
        {
            return Color.magenta;
        }
        
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3))
        {
            return Color.magenta;
        }
        
        return new Color();
    }    
    
  
    public static WaveConfig GetThirthWave()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1))
        {
            // 6 enemigos, 100 speed, 5 de vida.
            return new WaveConfig(6,100,5, 5);
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2))
        {
            // 6 enemigos, 100 speed, 5 de vida.
            return new WaveConfig(6,100,5, 5);        
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3)) 
        {
            // 6 enemigos, 100 speed, 5 de vida.
            return new WaveConfig(6,100,5, 5);       
        }
        return new WaveConfig();

    }
   
    public static Color GetThirthColor()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1))
        {
            return Color.blue;
        }
        
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2))
        {
            return Color.blue;
        }
        
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3))
        {
            return Color.blue;
        }
        
        return new Color();
    } 
    
    
    public static WaveConfig GetBossWave()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1))
        {
            // 1 enemigos, 140 speed, 30 de vida.
            return new WaveConfig(1, 140, 8, 9);
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2))
        {
            // 1 enemigos, 140 speed, 30 de vida.
            return new WaveConfig(1, 140, 8, 9);     
        }
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3)) 
        {
            // 1 enemigos, 140 speed, 30 de vida.
            return new WaveConfig(1, 140, 8, 9);   
        }
        return new WaveConfig();

    }
   
    public static Color GetBossColor()
    {
        if (SceneManager.GetActiveScene().name.Equals(LEVEL1))
        {
            return Color.gray;
        }
        
        if (SceneManager.GetActiveScene().name.Equals(LEVEL2))
        {
            return Color.gray;
        }
        
        if (SceneManager.GetActiveScene().name.Equals(LEVEL3))
        {
            return Color.gray;
        }
        
        return new Color();
    }
}

