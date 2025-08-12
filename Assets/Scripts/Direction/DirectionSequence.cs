using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;


public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Spacebar
}

public class DirectionSequence
{
    private List<Direction> _sequence = new();
    public int _currentIndex = 0;

    public void CreateSequence(int count = 9)
    {
        _sequence.Clear();
        _currentIndex = 0;

        for(int i = 0; i < count; i++)
        {
            Direction dir = (Direction)UnityEngine.Random.Range(0, 5);
            _sequence.Add(dir);
        }

    }


    public bool CheckInput(Direction input)
    {
        if (_currentIndex >= _sequence.Count) // currentindex는 현재 몇번째 차례인지 알려주는 숫자
            return false;

        if (_sequence[_currentIndex] == input)
        {
            _currentIndex++;
            return true;
        }

        return false;
    }

    public bool IsComplete => _currentIndex >= _sequence.Count;

    public List<Direction> GetSequence() => _sequence;

    public int beforeIndex => _currentIndex-1;
}
