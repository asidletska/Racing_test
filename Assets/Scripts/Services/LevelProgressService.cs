
public class LevelProgressService
{
    private SaveService Save => ServiceLocator.Get<SaveService>();

    public int UnlockedLevelIndex => Save.Data.unlockedLevelIndex;

    public bool IsUnlocked(int levelIndex) => levelIndex <= Save.Data.unlockedLevelIndex;

    public bool IsCompleted(int levelIndex) => Save.Data.completedLevels.Contains(levelIndex);

    public void MarkCompleted(int levelIndex)
    {
        if (!Save.Data.completedLevels.Contains(levelIndex))
            Save.Data.completedLevels.Add(levelIndex);

        if (levelIndex >= Save.Data.unlockedLevelIndex)
            Save.Data.unlockedLevelIndex = levelIndex + 1;

        Save.Save();
    }
}
