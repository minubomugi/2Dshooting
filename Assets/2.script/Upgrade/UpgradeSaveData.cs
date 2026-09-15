[System.Serializable]
public class UpgradeSaveData
{
    public string[] _name;
    public int[] _level;

    public UpgradeSaveData(int count)
    {
        _name = new string[count];
        _level = new int[count];
    }
}