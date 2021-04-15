using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ScoreReceiverSensor))]
[RequireComponent(typeof(BoxShapedRandomSpawnAction))]
public class LevelSpawnControl : MonoBehaviour
{

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float timeBetweenEnemies;

    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private float timeBetweenPowerUps;

    private ScoreReceiverSensor scoreReceiverSensor;
    private BoxShapedRandomSpawnAction spawnAction;

    private void Awake()
    {
        scoreReceiverSensor = GetComponent<ScoreReceiverSensor>();
        spawnAction = GetComponentInChildren<BoxShapedRandomSpawnAction>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int random = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = spawnAction.Spawn(enemyPrefabs[random]);
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0f);

            ScoreEmitterAction scoreEmitterAction = enemy.GetComponent<ScoreEmitterAction>();
            if (scoreEmitterAction != null)
            {
                // Open/Close!
                // If new components attached to the level have to listen to score emitter in the future,
                // we don't have to change anything here.
                // This new objects attached to the level will simply subscribe to the ScoreReceiverSensor.
                scoreEmitterAction.SetReceiver(scoreReceiverSensor);
            }

            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            GameObject powerUp = spawnAction.Spawn(powerUpPrefab);
            powerUp.transform.position = new Vector3(powerUp.transform.position.x, powerUp.transform.position.y, 0f);

            yield return new WaitForSeconds(timeBetweenPowerUps);
        }
    }

}
