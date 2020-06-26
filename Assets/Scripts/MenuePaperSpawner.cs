using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuePaperSpawner : MonoBehaviour
{
    public GameObject[] BlotPref;
    public GameObject DoublePaperPref;
    public GameObject PaperPref;
    public Transform PositionSpawn;


    public void SpawnPaper()
    {
        var paper = Instantiate(PaperPref, PositionSpawn.position, Quaternion.identity);

        int rnd = Random.Range(0, 10);
        int rndType = Random.Range(0, 100);

        if(rnd >= 7)
        {
            if (rndType <= 80)
            {
                int i = Random.Range(0, BlotPref.Length);

                var blot = Instantiate(BlotPref[i], new Vector2(Random.Range(-0.5f, 0.5f), paper.transform.position.y), Quaternion.identity);
                blot.transform.SetParent(paper.transform);
            }
            else
            {
                var blot = Instantiate(DoublePaperPref, new Vector2(paper.transform.position.x, paper.transform.position.y), Quaternion.identity);
                blot.transform.SetParent(paper.transform);
            }

        }

    }
}
