using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera camera;

    private GameObject DefenderParent;

    private void Start() {
        DefenderParent = GameObject.Find("Defenders");

        if (DefenderParent == null) {
            DefenderParent = new GameObject("Defenders");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown() {
        Vector2 rawPos = CalculateWorldUnitOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
        defender.transform.parent = DefenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float worldPosX = Mathf.RoundToInt(rawWorldPos.x);
        float worldPosY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(worldPosX, worldPosY);
        
    }

    Vector2 CalculateWorldUnitOfMouseClick() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        return camera.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 10f));
    }
}
