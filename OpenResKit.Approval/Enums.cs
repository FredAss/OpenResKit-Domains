namespace OpenResKit.Approval
{
    public enum KindOfPermission
    {
        WHG_Genehmigung = 0,
        BImschG_Genehmigung = 1,
        BBodSchG_Genehmigung = 2
    }

    public enum Progress
    {
        Angelegt = 0,
        Laufend = 1,
        Abgeschlossen = 2
    }

    public enum RiskPotential
    {
        Niedrig = 0,
        Mittel = 1,
        Hoch = 2
    }

    public enum Type
    {
        Input = 0,
        Output = 1
    }

    public enum Category
    {
        Gasförmig = 0,
        Flüssig = 1,
        Fest = 2
    }
}
