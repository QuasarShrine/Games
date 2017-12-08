using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    public Camera camera;

    private GameObject defenderParent;
    public StarDisplay starDisplay;

    private void Start() {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (defenderParent == null) {
            defenderParent = new GameObject("Defenders");
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseDown() {
        GameObject selectedDefender = Button.selectedDefender;
        int starCost = selectedDefender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(starCost) == StarDisplay.Status.SUCCESS) {
            SpawnDefender(selectedDefender);
        } else {
            Debug.LogError("Not enough stars");
        }
    }

    void SpawnDefender(GameObject selectedDefender) {
        Vector2 rawPos = CalculateWorldUnitOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Instantiate(selectedDefender, roundedPos, Quaternion.identity) as GameObject;
        defender.transform.parent = defenderParent.transform;
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
