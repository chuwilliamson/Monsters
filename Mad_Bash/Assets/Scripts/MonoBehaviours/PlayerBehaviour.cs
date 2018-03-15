using UnityEngine;
using UnityEngine.SceneManagement;

//Ryan

public class PlayerBehaviour : MonoBehaviour
{
    public Animation runaway;
    
    LoadSceneMode loadScene;
    
    public CharacterInformation character;

    public int level, xp, intellegence, power, levelpoint;
    public float speed, health, brave, weight, fear;

    bool dead = false, possible = false;    
    
    void Stats()
    {
        //ToDo: seperate this into another script
        xp = character.XP.Value;
        brave = character.BraveLevel.Value;
        fear = character.Fear.Value;

        if (xp >= 200)
        {
            character.XP.Value = 0;
            character.BraveLevel.Value++;
            //levelpoint++;
        }
        
        if (brave == 1)
            character.BraveLevel.Value = 10;
        if (brave == 2)
            character.BraveLevel.Value = 20;
        if (brave == 3)
            character.BraveLevel.Value = 30;
        if (brave == 4)
            character.BraveLevel.Value = 40;
        if (brave == 5)
            character.BraveLevel.Value = 50;
        if (brave == 6)
            character.BraveLevel.Value = 60;
        if (brave == 7)
            character.BraveLevel.Value = 70;
        if (brave == 8)
            character.BraveLevel.Value = 80;
        if (brave == 9)
            character.BraveLevel.Value = 90;
        if (brave == 10)
            character.BraveLevel.Value = 100;
    }

    void Start()
    {
        character.BraveLevel.Value = 1;
        character.XP.Value = 0;
        character.Health.Value = 100;
        character.Fear.Value = 0;
    }

    void Update()
    {
        Stats();
    }

}
