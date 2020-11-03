using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    
    void Update()
    {
        //트랜스폼/x,y 건들지 않고 z축만 - 방향으로 
        //deltaTime =한 프레임 당 실행하는 시간/단위는 초 
        //기준을 월드 좌표계로 잡음
        //로컬좌표계에서 z축은 무조건 바라보고있는 방향
        //월드좌표계에서는 바라보는 방향과 상관없이 고정된 한축의 방향
        //로컬좌표계로 Translate쓰면 이동방향도 같이 90도로 이동함
        //방지하기 위해 월드 좌표 계 생성/회전과 상관없이 무조건 플레이어 반대 방향으로 맵이 이동해야하니
        transform.Translate(new Vector3(0,0,-2f*Time.deltaTime), Space.World);
    }

}
