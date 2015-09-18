using UnityEngine;
using System.Collections;

public class SpawnHandeler : MonoBehaviour {

    public GameObject[] stageCollection;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            var stage = other.gameObject;
			Transform spawnLocation = stage.transform.parent.Find("Spawnlocation");
            GameObject obj = Instantiate(stageCollection[Random.Range(0, stageCollection.Length)],
                spawnLocation.position, 
                Quaternion.identity) as GameObject;

            obj.name = "SpawnedStage";
        }

		if (other.gameObject.name == "Spawnlocation")
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
