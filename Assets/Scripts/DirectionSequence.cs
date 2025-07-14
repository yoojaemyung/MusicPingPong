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
    private int _currentIndex = 0;

    public void CreateRandom(int count = 9)
    {
        _sequence.Clear();
        _currentIndex = 0;

        for(int i = 0; i < count; i++)
        {
            Direction dir = (Direction)UnityEngine.Random.Range(0, 5);
        }

    }


    public bool CheckInput(Direction input)
    {
        if (_currentIndex < _sequence.Count)
            return false;

        if (_sequence[_currentIndex] == input)
        {
            _currentIndex++;
            return true;
        }

        return false;
    }

    public bool IsComplete => _currentIndex >= _sequence.Count;
}
