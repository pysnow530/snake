using UnityEngine;
using System.Collections;

public class AppleController : MonoBehaviour {

    public GameObject walls;
    public GameObject player;

    // Use this for initialization
    void Start() {
    }
    
    // Update is called once per frame
    void Update() {
    }

    public bool At(Vector3 pos) {
    	return pos == transform.position;
    }

    // generate an new apple, cheat by change the apple's position
    public void GenNew(int unitsX, int unitsY, float unitWidth) {
        var times = 30;
        while (times-- > 0) {
            float x = (int) Random.Range(0f, unitsX) - unitsX / 2;
            float y = (int) Random.Range(0f, unitsY) - unitsY / 2;
            var newApplePos = new Vector3(x, y, 0);

            // if hit wall
            Collider2D[] colliders = Physics2D.OverlapCircleAll(newApplePos, 0.3f);
            if (colliders.Length > 0) {
                continue;
            }
//            for (var i = 0; i < colliders.Length; i++) {
//                if (colliders[i].gameObject != bodies[bodies.Count - 1]) {
//                    // hit an apple
//                    if (colliders[i].CompareTag("Food")) {          // eat an apple
//                        PowerUp();
//                        colliders[i].gameObject.GetComponent<AppleController>().GenNew(unitsX, unitsY, unitWidth);
//                    } else if (colliders[i].CompareTag("Wall") || colliders[i].CompareTag("Body")) {   // hit wall or body
//                        alive = false;
//                        dieText.SetActive(true);
//                    }
//                }
//            }
//            if (walls.GetComponent<WallController>().At(newApplePos)) {
//            	continue;
//            }
//
//            // if hit body
//            if (player.GetComponent<PlayerController>().At(newApplePos)) {
//                continue;
//            }

//            GameObject apple = GameObject.Find("Apple");
//            apple.transform.position = newApplePos;
            transform.position = newApplePos;
        }
    }

}
