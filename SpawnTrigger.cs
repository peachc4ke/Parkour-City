using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    //현재 맵이 뭔지 넣기위해
    public Map m;

    //맵을 넣을 게임오브젝트 배열
    public GameObject[] maps;

    //코루틴 관리
    Coroutine rotate;

    //기본형은 본인에게 다른것(뭐든지)이 닿았을 때
    public void OnTriggerEnter(Collider other)
    {
        //이렇게 실행하면 한번에 90도 가 확 돌아가게 됨-순간이동 처럼
        //m.transform.Rotate(new Vector3(0, 90, 0));
        //코루틴-프레임과 상관없이 별도의 서브 루틴에서 원하는 작업을 원하는 시간만큼 수행
        rotate = StartCoroutine(Check());
    }

    public void OnTriggerExit(Collider other)
    {
        SpawnMap();
        StopCoroutine(rotate);
    }

    public IEnumerator rotateMap()
    {
        //스페이스바를 눌렀을 때 태그가 왼쪽이면 왼쪽으로 돌림 오른쪽이면 오른쪽으로 돌림
        //15번 반복/한번 실행될때마다 맵을 6도씩 돌림
        //위치 변경 - 왼쪽
        if (gameObject.tag == "Left")
        {
            for (int i = 0; i < 15; i++)
            {
                //현재 맵이 들어간 m을 돌림.
                m.transform.Rotate(new Vector3(0, 6, 0));
                //yield return new WaitForSeconds() < 함수는  0.02초 동안 잠시 멈추라는 의미를 가진 코드
                //== 화면이 0.3 초에 걸쳐서 돌아가게 됨
                yield return new WaitForSeconds(0.02f);
            }
        }

        //위치변경 - 오른쪽
        if (gameObject.tag == "Right")
        {
            for (int i = 0; i < 15; i++)
            {
                //현재 맵이 들어간 m을 돌림.
                m.transform.Rotate(new Vector3(0, -6, 0));
                //yield return new WaitForSeconds() < 함수는  0.02초 동안 잠시 멈추라는 의미를 가진 코드
                //== 화면이 0.3 초에 걸쳐서 돌아가게 됨
                yield return new WaitForSeconds(0.02f);
            }
        }

    }

    public IEnumerator Check()
    {
        while (Input.GetKey(KeyCode.Space) == false)
        {
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(rotateMap());
    }

    public void SpawnMap()
    {
        //게임 오브젝트 go 에 Instantiate(오브젝트 생성 코드) 생성한 오브젝트를 넣어줌
        //Instantiate(GameObject original ,Vector3 position ,Quaternion rotation) = 차례대로 생성할 게임 오브젝트/생성할 위치 값/회전 값
        //만약 회전을 하지 않을 경우에는 Quaternion.identity 기입 =기본값, 회전없음
        GameObject go = Instantiate(maps[Random.Range(0, 7)], new Vector3(0, 0, 10), Quaternion.identity);

        //게임 오브젝트인 go에서 맵 컴포넌트를 찾아서 맵 변수인 ma에 넣음
        Map ma= go.GetComponent<Map>();

        //스폰트리거를 를 찾아서 스폰트리거 변수인 sa에 넣음
        SpawnTrigger sa = go.transform.GetComponentInChildren<SpawnTrigger>();

        //sa스폰트리거 컴포넌트 안에 있는 변수인 m에 맵 변수를 넣음
        //이것은 SpawnMap로 생성 된 프리팹 스폰트리거(콜라이드에 있음) 컴포넌트 m에 맵 프리팹이 들어가 있지 않아서임
        sa.m = ma;
    }

}
