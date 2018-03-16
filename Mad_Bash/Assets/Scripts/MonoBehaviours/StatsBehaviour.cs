using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsBehaviour : MonoBehaviour
{
    public CharacterInformation character;
    public Button speedButton;
    public Button sneakButton;
    public Button strengthButton;

    private int xp = 0;
    private int brave = 1;
    private int levelPoint = 0;

    float speed;
    float strength;
    float sneak;
    float health;

    bool levelUp = false;

    void Stats()
    {
        character.Speed.Value = speed;
        character.Strength.Value = strength;
        character.Sneak.Value = sneak;
        character.Health.Value = health;
        character.XP.Value = xp;
        character.BraveryLevel.Value = brave;
    }

    void LevelingUp()
    {
        if (xp >= 200)
        {
            xp %= 200;
            brave++;
            levelPoint++;
        }

        if (brave == brave++)
            character.BraveryLevel.Value += 10;
    }

    void UsingLevelPoint()
    {
        if (levelPoint >= 1)
            levelUp = true;

        if (levelUp == true && SceneManager.GetSceneByName("2.SafeHouse").isLoaded)
        {
            Instantiate(speedButton);
            Instantiate(sneakButton);
            Instantiate(strengthButton);
        }

        if (speedButton)
            character.Speed.Value++;
        if (sneakButton)
            character.Sneak.Value++;
        if (strengthButton)
            character.Strength.Value++;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Stats();
        LevelingUp();
        UsingLevelPoint();
	}
}
