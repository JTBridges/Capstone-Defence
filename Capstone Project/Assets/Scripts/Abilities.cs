using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Abilities : MonoBehaviour
{
    public Renderer groundRenderer;
    public Collider groundCollider;

    public GameObject[] ParticleExamples;
    public int exampleIndex;

    public List<GameObject> onScreenParticles = new List<GameObject>();

    void Awake()
    {
        List<GameObject> particleExampleList = new List<GameObject>();
        int nbChild = this.transform.childCount;
        for (int i = 0; i < nbChild; i++)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            particleExampleList.Add(child);
        }
        particleExampleList.Sort(delegate (GameObject o1, GameObject o2) { return o1.name.CompareTo(o2.name); });
        ParticleExamples = particleExampleList.ToArray();

        StartCoroutine("CheckForDeletedParticles");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            if (groundCollider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 9999f))
            {
                GameObject particle = spawnParticle();
                particle.transform.position = hit.point + particle.transform.position;
            }
        }
    }



    public void OnPreviousEffect()
    {
        prevParticle();
    }

    public void OnNextEffect()
    {
        nextParticle();
    }


    private GameObject spawnParticle()
    {
        GameObject particles = (GameObject)Instantiate(ParticleExamples[exampleIndex]);
        particles.transform.position = new Vector3(0, particles.transform.position.y, 0);
        particles.SetActive(true);
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            var main = ps.main;
            if (main.loop)
            {
                ps.gameObject.AddComponent<CFX_AutoStopLoopedEffect>();
                ps.gameObject.AddComponent<CFX_AutoDestructShuriken>();
            }
        }
        onScreenParticles.Add(particles);
        return particles;
    }

    IEnumerator CheckForDeletedParticles()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            for (int i = onScreenParticles.Count - 1; i >= 0; i--)
            {
                if (onScreenParticles[i] == null)
                {
                    onScreenParticles.RemoveAt(i);
                }
            }
        }
    }

    private void prevParticle()
    {
        exampleIndex--;
        if (exampleIndex < 0) exampleIndex = ParticleExamples.Length - 1;
    }
    private void nextParticle()
    {
        exampleIndex++;
        if (exampleIndex >= ParticleExamples.Length) exampleIndex = 0;
    }

    private void destroyParticles()
    {
        for (int i = onScreenParticles.Count - 1; i >= 0; i--)
        {
            if (onScreenParticles[i] != null)
            {
                GameObject.Destroy(onScreenParticles[i]);
            }

            onScreenParticles.RemoveAt(i);
        }
    }
}
