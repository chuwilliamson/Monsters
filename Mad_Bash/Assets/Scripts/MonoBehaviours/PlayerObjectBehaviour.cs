using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectBehaviour : MonoBehaviour
{
    public CharacterInformation characterInfo_config;
    [SerializeField]
    private CharacterInformation characterInfo_runtime;


    public CharacterInformation CharacterInfo
    {
        get { return characterInfo_runtime; }        
    }

    private void Start()
    {
        if (characterInfo_config == null)
        {
            characterInfo_config = Resources.Load("ScriptableObjects/Characters/PlayerConfig") as CharacterInformation;
        }        

        characterInfo_runtime = Instantiate(characterInfo_config);
    }
}
