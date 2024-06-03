namespace ZeeKer.DndTracker.Module.BusinessObjects.NonPersistent;

public class AvailableFeatJson
{
    public virtual StatBonusJson StatBonus { get; set; }
}


public class StatBonusJson
{
    public virtual int Strength { get; set; }
    public virtual int Dexterity { get; set; }
    public virtual int Constitution { get; set; }
    public virtual int Intelligence { get; set; }
    public virtual int Wisdom { get; set; }
    public virtual int Charisma { get; set; }

}