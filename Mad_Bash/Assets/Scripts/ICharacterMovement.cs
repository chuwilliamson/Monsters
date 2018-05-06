using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICharacterMovement
{
    void Disable(object sender);
    void Enable(object sender);
}


public interface ICharacterInput
{
    float Horizontal { get; set; }
    float Vertical { get; set; }
}
