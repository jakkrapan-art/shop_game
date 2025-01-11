using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CharacterFactory : MonoBehaviour
{
  private int playerSpawnCount = 0;

  public enum CharacterType
  {
    Player,
    NonPlayer
  }

  [SerializeField] private Character characterPrefab;

  private IObjectPool<Character> characterPool;

  private void Awake()
  {
    characterPool = new ObjectPool<Character>(
        createFunc: () => Instantiate(characterPrefab),
        actionOnGet: character => character.gameObject.SetActive(true),
        actionOnRelease: character => character.gameObject.SetActive(false),
        actionOnDestroy: character => Destroy(character.gameObject),
        collectionCheck: false, // Disable warnings for too many active objects
        defaultCapacity: 10,   // Initial capacity
        maxSize: 50            // Maximum pool size
    );
  }

  public Character CreateCharacter(CharacterType type)
  {
    var character = characterPool.Get();
    CharacterBrain brain;
    switch (type)
    {
      case CharacterType.Player:
        if (playerSpawnCount >= 1)
        {
          characterPool.Release(character);
          throw new System.Exception("Cannot Create Player more than 1.");
        }
        // Initialize Player brain
        brain = character.AddComponent<PlayerBrain>();
        playerSpawnCount++;
        Debug.Log("Player character initialized.");
        break;

      case CharacterType.NonPlayer:
        // Initialize NonPlayer brain
        brain = character.AddComponent<NPCBrain>();
        Debug.Log("NonPlayer character initialized.");
        break;
      default:
        throw new System.ArgumentOutOfRangeException(nameof(type), type, null);
    }

    brain.Setup(character);

    return character;
  }

  public void ReleaseCharacter(Character character)
  {
    characterPool.Release(character);
  }
}
