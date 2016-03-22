using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject bodyPrefab;
    public GameObject dieText;

    public const int unitsX = 22;
    public const int unitsY = 8;
    public const float unitWidth = 1f;
    public float interval = 1;       // interval(second) to move

    protected Vector3 headPos;
    protected ArrayList bodies;
    private Vector3 oldTailPos;
    private Vector3 direction;
    private float timeAcc;

    private bool alive = true;

    // Use this for initialization
    void Start () {
        // init one body
        bodies = new ArrayList();
        var head = Instantiate(bodyPrefab, new Vector3(-7f, 0f, 0f), Quaternion.identity) as GameObject;
        head.tag = "Player";
        head.transform.parent = transform;
        bodies.Add(head);

        direction = new Vector3(1f, 0f, 0f);
        timeAcc = 0f;
    }

    // Update is called once per frame
    void Update () {
        if (!alive) {
            return;
        }

        // direction control
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        if (dx != 0) {
            direction.x = dx > 0 ? 1.0f : -1.0f;
            direction.y = 0.0f;
        } else if (dy != 0) {
            direction.x = 0.0f;
            direction.y = dy > 0 ? 1.0f : -1.0f;
        }

        timeAcc += Time.deltaTime;
        if (timeAcc > interval) {
            timeAcc = 0.0f;

            var oldTail = bodies[0] as GameObject;
            oldTailPos = oldTail.transform.position;
            MoveNext();

            // get headpos for next move
            var head = bodies[bodies.Count - 1] as GameObject;
            Vector3 headpos = head.transform.position;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(headpos, 0.3f);
            for (var i = 0; i < colliders.Length; i++) {
                if (colliders[i].gameObject != bodies[bodies.Count - 1]) {
                    // hit an apple
                    if (colliders[i].CompareTag("Food")) {          // eat an apple
                        PowerUp();
                        colliders[i].gameObject.GetComponent<AppleController>().GenNew(unitsX, unitsY, unitWidth);
                    } else if (colliders[i].CompareTag("Wall") || colliders[i].CompareTag("Body")) {   // hit wall or body
                        alive = false;
                        dieText.SetActive(true);
                    }
                }
            }
        }
    }

    private GameObject head {
        get { return bodies[bodies.Count - 1] as GameObject; }
    }

    public bool At(Vector3 pos, bool skipHead=false) {
        int i = skipHead ? bodies.Count - 2 : bodies.Count - 1;
	    for (; i >= 0; i--) {
    	    var o = bodies[i] as GameObject;
    	    if (o.transform.position == pos) {
    	    	return true;
    	    }
    	}
    	return false;
    }

    void PowerUp() {
        var newTail = Instantiate(bodyPrefab, oldTailPos, Quaternion.identity) as GameObject;
        newTail.transform.parent = transform;
        bodies.Add(head);
        for (var i = bodies.Count - 1; i > 0; i--) {
            bodies[i] = bodies[i - 1];
        }
        bodies[0] = newTail;
    }

    void MoveNext() {
        for (var i = 0; i < bodies.Count - 1; i++) {
            var b1 = bodies[i] as GameObject;
            var b2 = bodies[i + 1] as GameObject;
            b1.transform.position = b2.transform.position;
        }
        head.transform.Translate(direction);
    }

    public void TurnLeft() {
        if (direction.x == 1f || direction.x == -1f) {
            direction.y = direction.x;
            direction.x = 0f;
        } else if (direction.y == 1f || direction.y == -1f) {
            direction.x = -direction.y;
            direction.y = 0;
        }
    }

    public void TurnRight() {
        if (direction.x == 1f || direction.x == -1f) {
            direction.y = -direction.x;
            direction.x = 0f;
        } else if (direction.y == 1f || direction.y == -1f) {
            direction.x = direction.y;
            direction.y = 0;
        }
    }

}
