using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    void Update()
    {
        //트랜스폼/x,y 건들지 않고 z축만 - 방향으로 
        //deltaTime =한 프레임 당 실행하는 시간/단위는 초 
        //기준을 월드 좌표계로 잡음
        //로컬좌표계에서 z축은 무조건 바라보고있는 방향
        //월드좌표계에서는 바라보는 방향과 상관없이 고정된 한축의 방향
        //로컬좌표계로 Translate쓰면 이동방향도 같이 90도로 이동함
        //방지하기 위해 월드 좌표 계 생성/회전과 상관없이 무조건 플레이어 반대 방향으로 맵이 이동해야하니까
        transform.Translate(new Vector3(0, 0, -1f * Time.deltaTime), Space.World);

        if (ScoreManager.instance._Score >= 1000 && ScoreManager.instance._Score < 2000)//
        {
            transform.Translate(new Vector3(0, 0, -0.1f * Time.deltaTime), Space.World);
        }
        else if (ScoreManager.instance._Score >= 2000)
        {
            transform.Translate(new Vector3(0, 0, -0.3f * Time.deltaTime), Space.World);
        }

        //만약 맵 오브젝트의 z축 위치가 -30 이하가 될 경우 삭제
        //게임오브젝트의 기본은 자기 자신이다.  Destroy(gameObject); 를 하면 자기자신을 삭제함
        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }

}