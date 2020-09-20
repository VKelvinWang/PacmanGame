using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    Transform[] transformArray;

    int lastTime;
    int lastMoveTime; 
    float timer;

    Coroutine moveCoroutine;

    const float moveWait = 2.0f;
    const float scaleWait = 4.0f;

    void Start()
    {
        //lastTime = (int)Time.time; For 50% band
        ResetTime();

        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 2.0f;
    }

	void Update () {
        /*For 50% band
         if ((int)Time.time > lastTime) {
            lastTime = (int)Time.time;
            Debug.Log(lastTime);
        }
        */

        timer += Time.deltaTime;
        if ((int)timer > lastTime) {
            lastTime = (int)timer;
			Debug.Log(lastTime);
        }

         if (timer > lastMoveTime + (int)moveWait) {
            lastMoveTime = (int)timer;
            MoveObjects();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Space pressed");
            Time.timeScale = 1 - Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.Return)) 
            ResetTime();
        if (Input.GetKeyDown(KeyCode.Escape) && moveCoroutine == null)
            moveCoroutine = StartCoroutine(RotateObjects(Random.Range(0.25f, 0.75f)));
	}


    private void ResetTime() {
        lastTime = -1;
        lastMoveTime = 0; 
        timer = 0.0f;

        CancelInvoke("ScaleObjects");
        InvokeRepeating("ScaleObjects", scaleWait, scaleWait);
    }


    /* Below is approach for being invariant to starting position. 
     * Student solutions may be hard coaded or have a different solution for 
     * invariance */
     private void MoveObjects() { 
        int rightMost = 0;
        if (transformArray[1].position.x > transformArray[0].position.x)
            rightMost = 1;

        Vector3 tempPos = transformArray[rightMost].position;
        // Moving vertically
        if (transformArray[rightMost].position.y > transformArray[1 - rightMost].position.y)
        {
            transformArray[rightMost].position = new Vector3(transformArray[rightMost].position.x,
                                                            transformArray[1 - rightMost].position.y,
                                                            transformArray[rightMost].position.z);
            transformArray[1 - rightMost].position = new Vector3(transformArray[1 - rightMost].position.x,
                                                               tempPos.y,
                                                               transformArray[1 - rightMost].position.z);
        }

        // Moving horizontally
        else
        {
            transformArray[rightMost].position = new Vector3(transformArray[1 - rightMost].position.x,
                                                            transformArray[rightMost].position.y,
                                                            transformArray[rightMost].position.z);
            transformArray[1 - rightMost].position = new Vector3(tempPos.x,
                                                               transformArray[1 - rightMost].position.y,
                                                               transformArray[1 - rightMost].position.z);
        }
    }


    private void ScaleObjects() {
        foreach (Transform trans in transformArray) {
            if (trans.localScale.x > 1.5f)
                trans.localScale = trans.localScale / 1.2f;
            else
                trans.localScale = trans.localScale * 1.2f; 
        }
    }


    IEnumerator RotateObjects(float randomDelay) {
        for (int i = 0; i < 4; i++) {
            yield return new WaitForSeconds(randomDelay);
            foreach (Transform trans in transformArray)
                trans.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
                
        }

        moveCoroutine = null;
    }
}
