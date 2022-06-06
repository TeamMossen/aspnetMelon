namespace Infrastructure.Parameters.Interfaces;

public interface IPageParameters
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

}