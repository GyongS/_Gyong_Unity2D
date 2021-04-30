using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CTileManager : MonoBehaviour
{
    [SerializeField]
    private int _x;

    [SerializeField]
    private CTile[] _tileBox;

    [SerializeField]
    private GameObject _item;

    [SerializeField]
    private int[] _tileIndex;

    private void Awake()
    {
        float posY = transform.position.y;
        
        for (int array = 0; array < _tileIndex.Length; array++)
        {
            Queue<int> randomFloor = new Queue<int>();
            // 5줄씩 범위를 지정해서 랜덤한 줄을 선택해서 큐에 넣어줌
            if (_tileIndex[array] >= 2)
            {
                for (int i = 0; i <= _tileIndex[array] / 2; ++i)
                {
                    int randNum = Random.Range(i * 5, (i + 1) * 5 - 1);
                    randomFloor.Enqueue(randNum);
                }
            }

            // 선택된 줄을 하나 꺼냄
            int front = -1;
            if(randomFloor.Count!=0) front = randomFloor.Dequeue();
            for (int y = 0; y < _tileIndex[array]; y++, posY -= 1.99f)
            {
                int itemX = -1;
                //지금 줄이 선택된 줄이라면?
                if (front == y)
                {
                    // 지금 줄에서 랜덤한 칸을 선택하고 다음에 선택할 줄을 큐에서 꺼낸다.
                    itemX = Random.Range(0, _x - 1);
                    if(randomFloor.Count != 0)
                        front = randomFloor.Dequeue();
                }
                int x_counter = 0;
                for (float x = transform.position.x; x < _x; x += 1.99f)
                {
                    CTile result = Instantiate(_tileBox[array], new Vector2(x, posY), Quaternion.identity, transform);
                    // 지금 칸이 선택된 칸이라면?
                    if (itemX == x_counter)
                    {
                        GameObject obj = Instantiate(_item, new Vector2(x, posY), Quaternion.identity, transform);

                        // 아이템으로 설정
                        result.SetIsItem();
                        Debug.Log("아이템이"+ y + ", " + x_counter + "위치에 생성됨!");
                    }                   
                    ++x_counter;
                }
            }
        }       
    }  
}