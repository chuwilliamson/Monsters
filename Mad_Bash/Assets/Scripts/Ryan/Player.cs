using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Item item;
    public Animation runaway;
    
    LoadSceneMode loadScene;
    
    public CharacterInfo character;

    public int level, xp, intellegence, power, levelpoint;
    public float speed, health, brave, weight, fear;

    bool dead = false, possible = false;    

    void IsDead()
    {
        if (character._health <= 0)
            dead = true;

        if (dead == true)
        {
            power = 0;
            speed = 0;

            character._health = 0;

            SceneManager.LoadScene("SafeHouse");
        }
    }

    void Afraid()
    {
        bool toAfraid = false;
        
        if (character._fear >= character._bravness)
        {
            toAfraid = true;
            character._fear = 100;
        }

        if(toAfraid == true)
        {
            //runaway.SetTrigger("Run");
            SceneManager.LoadScene("SafeHouse");
            if (character._fear == 0)
            {
                toAfraid = false;
            }
        }
    }
    
    void Stats()
    {
        //ToDo: seperate this into another script
        level = character._level;
        xp = character._xp;
        intellegence = character._int;
        power = character._pow;
        speed = character._speed;
        health = character._health;
        brave = character._bravness;
        weight = character._presence;
        fear = character._fear;

        if (xp >= 200)
        {
            character._xp = 0;
            character._level++;
            //levelpoint++;
        }
        
        if (level == 1)
            character._bravness = 10;
        if (level == 2)
            character._bravness = 20;
        if (level == 3)
            character._bravness = 30;
        if (level == 4)
            character._bravness = 40;
        if (level == 5)
            character._bravness = 50;
        if (level == 6)
            character._bravness = 60;
        if (level == 7)
            character._bravness = 70;
        if (level == 8)
            character._bravness = 80;
        if (level == 9)
            character._bravness = 90;
        if (level == 10)
            character._bravness = 100;
    }

    void Start()
    {
        character._level = 1;
        character._xp = 0;
        character._health = 100;
        character._fear = 0;
    }

    void Update()
    {       
        Stats();
        Afraid();
        IsDead();
    }

}
