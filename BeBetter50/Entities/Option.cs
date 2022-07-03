namespace BeBetter50.Entities;

public record Option(
    String Name,
    String Manufacturer,
    int DefaultPrice,
    int ProductionYear,
    String Type,
    DateTime StartDate,
    DateTime? EndDate
);