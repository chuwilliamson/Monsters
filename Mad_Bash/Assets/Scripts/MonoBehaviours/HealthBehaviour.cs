using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//Ryan

public class HealthBehaviour : MonoBehaviour
{
    public Slider HP;
    public CharacterInfo character;

    public int power;
    public float speed;
        
    bool dead = false, possible = false;

    void IsDead()
    {
        if (character.Health <= 0)
            dead = true;

        if (dead == true)
        {
            power = 0;
            speed = 0;

            character.Health = 0;

            SceneManager.LoadScene("2.SafeHouse");
        }
    }
    // Use this for initialization
    void Start ()
    {
        character.Health = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HP.value = character.Health;
        HP.maxValue = 100;
        HP.minValue = 0;

        IsDead();
	}
}
