using UnityEngine;

[System.Serializable]
public class CharacterData
{
  [field: SerializeField]
  public float MoveSpeed { get; private set; }

  public CharacterData(float speed)
  {
    MoveSpeed = speed;
  }
}
