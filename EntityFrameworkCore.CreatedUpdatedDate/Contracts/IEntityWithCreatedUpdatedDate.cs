namespace EntityFrameworkCore.CreatedUpdatedDate.Contracts;

public interface IEntityWithCreatedUpdatedDate
{
    DateTimeOffset? CreatedDate { get; set; }
    DateTimeOffset? UpdatedDate { get; set; }
}