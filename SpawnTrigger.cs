using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    //현재 맵이 뭔지 넣기위해
    public map m;

    //기본형은 본인에게 다른것(뭐든지)이 닿았을 때
    public void OnTriggerEnter(Collider other)
    {
        //이렇게 실행하면 한번에 90도 가 확 돌아가게 됨-순간이동 처럼
        //m.transform.Rotate(new Vector3(0, 90, 0));
        //코루틴-프레임과 상관없이 별도의 서브 루틴에서 원하는 작업을 원하는 시간만큼 수행
        StartCoroutine(rotateMap());
    }

    public IEnumerator rotateMap()
    {
        //15번 반복/한번 실행될때마다 맵을 6도씩 돌림
        for (int i = 0; i < 15; i++)
        {
            //현재 맵이 들어간 m을 돌림.
            m.transform.Rotate(new Vector3(0, 6, 0));
            //yield return new WaitForSeconds() < 함수는  0.02초 동안 잠시 멈추라는 의미를 가진 코드
            yield return new WaitForSeconds(0.02f);
        }
        //== 화면이 0.3 초에 걸쳐서 돌아가게 됨
    }
}
