using Vonavulary.UI.Models.Shared.Pagination;
using Vonavulary.UI.Services.Base;

namespace Vonavulary.UI.Mapping;

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
