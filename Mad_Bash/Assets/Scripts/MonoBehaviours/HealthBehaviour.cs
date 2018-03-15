using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//Ryan

public class HealthBehaviour : MonoBehaviour
{
    public Slider HP;
    public CharacterInformation character;

    int power;
    float speed;

    bool dead = false;
    bool possible = false;

    void IsDead()
    {
        if (character.Health.Value <= 0)
            dead = true;

        if (dead == true)
        {
            power = 0;
            speed = 0;

            character.Health.Value = 0;

            SceneManager.LoadScene("2.SafeHouse");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        HP.value = character.Health.Value;
        HP.maxValue = 100;
        HP.minValue = 0;

        IsDead();
	}
}
