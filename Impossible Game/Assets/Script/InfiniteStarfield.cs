using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStarfield : MonoBehaviour
{

    private ParticleSystem.Particle[] points;
    public ParticleSystem.MinMaxCurve startSize;
    public float hSliderValue = 8.0F;
    public ParticleSystem.MinMaxGradient startColor;
    public float hSliderValueR = 0.0F;
    public float hSliderValueG = 0.0F;
    public float hSliderValueB = 0.0F;
    public float hSliderValueA = 1.0F;

    public ParticleSystem ps;
    private Transform tx;
    public int starsMax = 600;
    public float starSize = .35f;
    public float starDistance = 60f;
    private float starDistanceSqr = 10f;
    private float starClipDistnacesqr = 15f;
    public Color starColor;
    
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
        tx = GetComponent<Transform>();
        // ps = tx.GetComponent<ParticleSystem>();
        starDistanceSqr = starDistance * starDistance;
        starClipDistnacesqr *= starClipDistnacesqr;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;

        main.startDelay = 5.0f;
        main.startLifetime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {

        var main = ps.main;
         main.startSize = hSliderValue;
        main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);
        ps.SetParticles(points, points.Length);

        if (ps == null) CreateStars();
         
         for (int i = 0; i < starsMax; i++)
         {
              if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr)
             {
                points[i].position = (UnityEngine.Random.insideUnitSphere * starDistanceSqr) + tx.position;
                 points[i].startColor = new Color(1, 1, 1, 1);
             }
            if ((points[i].position - tx.position).sqrMagnitude <= starDistanceSqr)
            {
                float cap = (points[i].position - tx.position).sqrMagnitude / starClipDistnacesqr;
            }
         }
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }
  
    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];
        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = UnityEngine.Random.insideUnitSphere * starDistanceSqr + tx.position;
            points[i].startSize = starSize;
            points[i].startColor = new Color(1, 1, 1, 1);
    }
        } 
}
