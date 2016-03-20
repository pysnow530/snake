using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool At(Vector3 pos) {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls) {
            if (wall.transform.position == pos) {
                return true;
            }
        }
        return false;
    }
}
