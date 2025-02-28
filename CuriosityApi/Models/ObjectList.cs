namespace CuriosityApi.Models;

public record ObjectListModel<T>(
    List<T> List,
    int Total
);