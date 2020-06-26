using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaperSpawner : MonoBehaviour
{

    public GameObject PaperPref;
    public Transform PositionSpawn;
    public GameObject[] BlotPref;
    public GameObject DoublePaperPref;
    private int PlaningSpawn = 10;
    public static float HeightSpawn = 30f;
    public static float paperSpeed = 5f;
    public static bool isCantSPawn;
    private bool isSpawned;

    private void Start()
    {

        if (PlayerPrefs.HasKey("LVL"))
        {
            PlaningSpawn = PlayerPrefs.GetInt("LVL") + 2;
            HeightSpawn = HeightSpawn + (PlayerPrefs.GetInt("LVL") * 2f);
            if((PlayerPrefs.GetInt("LVL") % 10 == 0))
            {
                paperSpeed += 0.8f;
                PlayerPrefs.SetFloat("PaperSpeed", paperSpeed);
                PlayerPrefs.Save();
            }
        }
        else if (!PlayerPrefs.HasKey("LVL"))
        {
            PlaningSpawn = 5;

        }
        if (PlayerPrefs.GetInt("LVL") == 1)
        {
            PlaningSpawn = 5;

        }


        SpawnerPaper();
    }


    private void SpawnerPaper()
    {

        for (int i = 0; i < PlaningSpawn;i++)
        {
            var paper = Instantiate(PaperPref, PositionSpawn.position, Quaternion.identity);

            while (true)
            {
                var position = new Vector2(Random.Range(-1f, 1f), Random.Range(20f, HeightSpawn));

                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f, 1);

                if (colliders.Length == 0)
                {
                    var blot = Instantiate(BlotPref[Random.Range(0, BlotPref.Length)],
                        position, Quaternion.identity);
                    blot.transform.SetParent(paper.transform);
                    colliders = null;
                    break;
                }


            }
                      
        }

        if(isSpawned != true)
        {
            Instantiate(DoublePaperPref, new Vector2(0, YPosSetter()), Quaternion.identity);

            if (PlayerPrefs.HasKey("doublLifeX2"))
            {
                Instantiate(DoublePaperPref, new Vector2(0, YPosSetter()), Quaternion.identity);
            }
            if (PlayerPrefs.HasKey("doublLifeX3"))
            {
                Instantiate(DoublePaperPref, new Vector2(0, YPosSetter()), Quaternion.identity);
            }
            if (PlayerPrefs.HasKey("doublLifeX6"))
            {
                Instantiate(DoublePaperPref, new Vector2(0, YPosSetter()), Quaternion.identity);
            }

        }

    }

    private float YPosSetter()
    {
        return Random.Range(7f, HeightSpawn);
    }


}
