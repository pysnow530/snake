using UnityEditor;
using UnityEngine;
using System.Collections;

public class Snake {

    // init walls
    // first select the wall prefab, second click this menuitem
    [ MenuItem("Snake/Place Wall") ]
    public static void PlaceWall() {
        GameObject parent = GameObject.Find("Environment/Walls");
        float x, y;

        // create top wall
        y = 4f;
        for (x = -11f; x <= 11; x++) {
            GameObject wallPrefab = Selection.activeObject as GameObject;
            GameObject tmp = PrefabUtility.InstantiatePrefab(wallPrefab) as GameObject;
            tmp.name = "WallT(" + x + ", " + y + ")";
            tmp.transform.parent = parent.transform;
            tmp.transform.position = new Vector2(x, y);
        }

        // create bottom wall
        y = -4f;
        for (x = -11f; x <= 11f; x++) {
            GameObject wallPrefab = Selection.activeObject as GameObject;
            GameObject tmp = PrefabUtility.InstantiatePrefab(wallPrefab) as GameObject;
            tmp.name = "WallB(" + x + ", " + y + ")";
            tmp.transform.parent = parent.transform;
            tmp.transform.position = new Vector2(x, y);
        }

        // create left wall
        x = -11f;
        for (y = -3f; y <= 3f; y++) {
            GameObject wallPrefab = Selection.activeObject as GameObject;
            GameObject tmp = PrefabUtility.InstantiatePrefab(wallPrefab) as GameObject;
            tmp.name = "WallL(" + x + ", " + y + ")";
            tmp.transform.parent = parent.transform;
            tmp.transform.position = new Vector2(x, y);
        }

        // create right wall
        x = 11f;
        for (y = -3f; y <= 3f; y++) {
            GameObject wallPrefab = Selection.activeObject as GameObject;
            GameObject tmp = PrefabUtility.InstantiatePrefab(wallPrefab) as GameObject;
            tmp.name = "WallR(" + x + ", " + y + ")";
            tmp.transform.parent = parent.transform;
            tmp.transform.position = new Vector2(x, y);
        }
    }

}
