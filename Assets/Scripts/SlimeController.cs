
﻿using UnityEngine;
using UnityEngine.AI;

public class SlimeController : MonoBehaviour
{
    private NavMeshAgent agent;  // ตัวแปรเก็บ NavMeshAgent ของ Slime
    public GameObject player;    // ตัวแปรเก็บ Player ที่ Slime จะไล่ตาม

    public float detectionRange = 10f;  // ระยะตรวจจับ Player
    public float updateRate = 0.2f;     // อัปเดตตำแหน่งทุก 0.2 วินาที
    private float nextUpdateTime = 0f;  //เวลาในอนาคตที่ Slime จะอัปเดตตำแหน่ง Player ครั้งถัดไป

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // ดึง NavMeshAgent ของ Slime ที่อยู่บน GameObject
    }

    void Update()
    {
        if (player == null) return;   // ถ้า Player ยังไม่ได้ Assign → ไม่ทำอะไร

        // คำนวณระยะระหว่าง Slime กับ Player
        float distance = Vector3.Distance(transform.position, player.transform.position);
       
        // คำนวณระยะระหว่าง Slime กับ Player
        // transform.position → ตำแหน่งของ Slime
        // player.transform.position → ตำแหน่งของ Player
        // Vector3.Distance() → คำนวณระยะทางแบบ 3D

        if (distance <= detectionRange)    // ตรวจสอบว่า Player อยู่ในระยะตรวจจับหรือไม่
        {
            if (Time.time >= nextUpdateTime)   // ตรวจสอบว่าเวลาปัจจุบัน ≥ nextUpdateTime (ถึงเวลาจะอัปเดตตำแหน่งครั้งถัดไป)
            {
                agent.SetDestination(player.transform.position);    // สั่ง NavMeshAgent ให้เดินไปตำแหน่ง Player

                nextUpdateTime = Time.time + updateRate;   // ตั้งเวลาครั้งถัดไปที่ Slime จะอัปเดตตำแหน่ง
            }
        }
        else
        {
            // ถ้า Player อยู่ไกลเกินไป Slime จะหยุด
            agent.ResetPath();
        }

    }
}
