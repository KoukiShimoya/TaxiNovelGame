﻿using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class GeneralCarMove : MonoBehaviour
{
    [SerializeField] private GameObject checkPointGameObjectRoot;
    private List<Vector2> checkPointList;
    private Vector2 destination;
    private int aimPointNumber;
    private Rigidbody2D rigidbody2D;
    private const float moveSpeed = 0.03f;
    private const float threshould = 0.1f;
    private GeneralCarStateHolder generalCarStateHolder;
    private WorldStateHolder worldStateHolder;

    private void Start()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        generalCarStateHolder = this.gameObject.GetComponent<GeneralCarStateHolder>();
        worldStateHolder = WorldStateHolder.Instance;
        
        if (checkPointGameObjectRoot.transform.childCount == 0)
        {
            EditorDebug.LogWarning("通行車の通るべきチェックポイントが設定されていません");
        }
        else
        {
            checkPointList = new List<Vector2>();
            foreach (var gameObject in checkPointGameObjectRoot.GetOnlyOwnChildren())
            {
                checkPointList.Add(gameObject.transform.position);
            }

            destination = checkPointList[0];
            aimPointNumber = 0;
            this.gameObject.transform.LookAt2D(destination);
        }
    }

    private void Update()
    {
        if (worldStateHolder.worldState == WorldStateHolder.WorldState.AllStopping)
        {
            return;
        }
        
        if (generalCarStateHolder.generalCarState == GeneralCarState.Stopping)
        {
            return;
        }
        
        if (Vector2.Distance(this.gameObject.transform.position, destination) < threshould)
        {
            aimPointNumber++;
            if (aimPointNumber > checkPointList.Count - 1)
            {
                aimPointNumber = 0;
            }

            destination = checkPointList[aimPointNumber];
            
            this.gameObject.transform.LookAt2D(destination);
        }
        
        CarMove();
    }

    private void CarMove()
    {
        Vector2 moveVector = new Vector2(destination.x - this.gameObject.transform.position.x,
            destination.y - this.gameObject.transform.position.y);
        moveVector.Normalize();
        moveVector *= moveSpeed;
        Vector2 nextPosition = new Vector2(this.gameObject.transform.position.x + moveVector.x,
            this.gameObject.transform.position.y + moveVector.y);
        rigidbody2D.MovePosition(nextPosition);
    }
}