namespace BugStore.Api.Requests;

public abstract class PagedRequest(int pageNumber = Configuration.DefaultPageNumber,
    int pageSize = Configuration.DefaultPageSize){

    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
}