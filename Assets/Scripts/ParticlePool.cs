using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool instance;

    private List<ParticleSystem> particles;
    private IEnumerator<ParticleSystem> particlesIterator;
    public ParticleSystem particlePrafab;

    public int count = 20;

    private void Awake()
    {
        instance = this;
        Setup();
    }

    public ParticleSystem GetParticle()
    {
        // 다음 순번 아이템으로 커서를 넘기기 시도
        if (!particlesIterator.MoveNext())
        {
            // 마지막 아이템을 가리키고 있어서 넘기기 실패했다면
            // 순번 리셋후 1회 넘기기
            particlesIterator.Reset();
            particlesIterator.MoveNext();
        }
        return particlesIterator.Current;
    }

    public void Setup()
    {
        particles = new List<ParticleSystem>();

        for (int i = 0; i < count; i++)
        {
            var particle = Instantiate<ParticleSystem>(particlePrafab, transform);
            particles.Add(particle);
        }

        // 생성된 파티클 리스트를 한번씩 넘겨가면서 조회하는 이터레이터 생성
        particlesIterator = particles.GetEnumerator();
    }
}