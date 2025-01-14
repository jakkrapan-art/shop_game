using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
  [SerializeField]
  private CharacterFactory _factory;

  private void Update()
  {
    if (_factory != null)
    {
      Character character = null;
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        character = _factory.CreateCharacter(CharacterFactory.CharacterType.Player);
      }
      else if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        character = _factory.CreateCharacter(CharacterFactory.CharacterType.NonPlayer);
        character.transform.position = new Vector3(character.transform.position.x, -1);
      }

      if (character != null)
      {
        character.transform.position = transform.position;
      }
    }
  }
}
