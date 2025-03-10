using CogLog.UI.Models.Shared.Pagination;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class SharedViewMapper
{
    public static PaginationMetadataVm ToPaginationMetadataVm(this PaginationMetadata metadata)
    {
        return new PaginationMetadataVm
        {
            TotalItems = metadata.TotalItems,
            Page = metadata.Page,
            TotalPages = metadata.TotalPages,
            PerPage = metadata.PerPage,
        };
    }
}
