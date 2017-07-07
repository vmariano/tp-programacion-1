public class WaveConfig
{
    public int TotalEnemies;
    public int Speed;
    public int Life;
    public int Damage;

    public WaveConfig(int totalEnemies, int speed, int life, int damage)
    {
        this.TotalEnemies = totalEnemies;
        this.Speed = speed;
        this.Life = life;
        this.Damage = damage;
    }    

    public WaveConfig()
    {
        this.TotalEnemies = 0;
        this.Speed = 0;
        this.Life = 0;
        this.Damage = 0;
    }    
}
