using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectBehaviour : MonoBehaviour
{
    public CharacterInfo characterInfo_config;
    [SerializeField]
    private CharacterInfo characterInfo_runtime;


    public CharacterInfo CharacterInfo
    {
        get { return characterInfo_runtime; }        
    }

    private void Start()
    {
        if (characterInfo_config == null)
        {
            characterInfo_config = Resources.Load("ScriptableObjects/Characters/PlayerConfig") as CharacterInfo;
        }        

        characterInfo_runtime = Instantiate(characterInfo_config);
    }
}
