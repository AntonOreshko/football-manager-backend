namespace BusinessLayer.Builders.BuildersData
{
    public interface IMatchBuilderData
    {
        int Stage { get; set; }

        int SubStage { get; set; }

        string Group { get; set; }

        int Number { get; set; }

        long HomeId { get; set; }

        long VisitorsId { get; set; }
    }
}
