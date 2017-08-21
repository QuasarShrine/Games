using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{

    public GameObject enemyPrefab;

    private float xmin, xmax;
    //public float playSpacePadding = 0.5f;

    public float speed = 15.0f; // number of pixels the ships will move every frame
    public float spawnDealy = 0.5f;

    private float newX;

    private bool isGoingRight = true;

    public float width = 10f;
    public float height = 5f;

    // Use this for initialization
    void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x;
        xmax = rightmost.x;

        SpanwUntilFull();
    }

    void SpawnEnemies() {
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update() {

        MoveFormation();

        if (AllMembersAreDead()) {
            SpanwUntilFull();
        }
    }

    Transform NextFreePosition() {
        foreach (Transform childPostionGameObject in transform) {
            if (childPostionGameObject.childCount == 0) {
                return childPostionGameObject;
            }
        }
        return null;
    }

    void SpanwUntilFull() {
        Transform freePosition = NextFreePosition();
        if (freePosition) {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
            Invoke("SpanwUntilFull", spawnDealy);
        }
    }


    bool AllMembersAreDead() {
        foreach (Transform childPostionGameObject in transform) {
            if (childPostionGameObject.childCount > 0) {
                return false;
            }
        }
        return true;
    }

    void MoveFormation() {
        Vector3 tempPos = transform.position;

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);


        if (leftEdgeOfFormation < xmin) {
            isGoingRight = true;
        } else if (rightEdgeOfFormation > xmax) {
            isGoingRight = false;
        }

        if (isGoingRight) {
            tempPos += Vector3.right * speed * Time.deltaTime;
        } else {
            tempPos += Vector3.left * speed * Time.deltaTime;
        }

        // restrict player to playspace boundaries
        float newX = Mathf.Clamp(tempPos.x, xmin, xmax);
        transform.position = new Vector3(newX, tempPos.y, tempPos.z);
    }
}

