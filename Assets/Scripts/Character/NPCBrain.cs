using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBrain : CharacterBrain
{
  private EnumTypes.HoriziontalDirection _currentDirection;
  private float _lastDirChangeTime = 0;
  private float _delayChangeDir = 0;
  private const float MIN_CHANGE_DIR = 1;
  private const float MAX_CHANGE_DIR = 3;

  protected override float GetMoveInputValue()
  {
    if(_lastDirChangeTime + _delayChangeDir < Time.time)
    {
      _currentDirection = (EnumTypes.HoriziontalDirection)(Random.Range(-1, 2));
      _delayChangeDir = Random.Range(MIN_CHANGE_DIR, MAX_CHANGE_DIR);
      _lastDirChangeTime = Time.time;
    }

    return (int) _currentDirection;
  }
}
