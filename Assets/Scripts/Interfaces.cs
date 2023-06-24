using UnityEngine;

public interface IWritable
{
    void SetStartedParameters(Color color, StateCell state, int i, int j);
    void SetUpdatedCoordinates(int i, int j);
}

public interface ITransmittable
{
    StateCell GetCurrentState();
    int GetPoint_I();
    int GetPoint_J();
}