using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : CharacterBrain
{
  protected override float GetMoveInputValue()
  {
    return Input.GetAxisRaw("Horizontal");
  }
}
