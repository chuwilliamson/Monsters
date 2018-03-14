using UnityEngine;
using UnityEngine.SceneManagement;

//Ryan

public class PlayerBehaviour : MonoBehaviour
{
    public Animation runaway;
    
    LoadSceneMode loadScene;
    
    public CharacterInfo character;

    public int level, xp, intellegence, power, levelpoint;
    public float speed, health, brave, weight, fear;

    bool dead = false, possible = false;    
    
    void Stats()
    {
        //ToDo: seperate this into another script
        xp = character.XP;
        brave = character.BraveLevel;
        fear = character.Fear;

        if (xp >= 200)
        {
            character.XP = 0;
            character.BraveLevel++;
            //levelpoint++;
        }
        
        if (brave == 1)
            character.BraveLevel = 10;
        if (brave == 2)
            character.BraveLevel = 20;
        if (brave == 3)
            character.BraveLevel = 30;
        if (brave == 4)
            character.BraveLevel = 40;
        if (brave == 5)
            character.BraveLevel = 50;
        if (brave == 6)
            character.BraveLevel = 60;
        if (brave == 7)
            character.BraveLevel = 70;
        if (brave == 8)
            character.BraveLevel = 80;
        if (brave == 9)
            character.BraveLevel = 90;
        if (brave == 10)
            character.BraveLevel = 100;
    }

    void Start()
    {
        character.BraveLevel = 1;
        character.XP = 0;
        character.Health = 100;
        character.Fear = 0;
    }

    void Update()
    {
        Stats();
    }

}
